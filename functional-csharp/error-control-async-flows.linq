<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// https://enterprisecraftsmanship.com/2015/03/20/functional-c-handling-failures-input-errors/
// https://gist.github.com/vkhorikov/7852c7606f27c52bc288

// https://web.archive.org/web/20190518163046/https://enterprisecraftsmanship.com/2015/03/20/functional-c-handling-failures-input-errors/
// https://web.archive.org/web/20190518163050/https://gist.github.com/vkhorikov/7852c7606f27c52bc288


// Need AsyncSupport
async void Main()
{
    var outputs = (await SeedNumbers(50)
        .ThenAsync(Multiply)
        .ThenAsync((inputs) => Divide(inputs, by: 5)))
        .Dump();
}

// Define other methods and classes here
public enum Status
{
    Error, Success, Warning
}

public class Output<T> 
{
    public T Entity {get; set;}
    public string Message {get; set;}
    public Status Status {get; set;}
    
    public static Output<T> Success(T entity)
    {
        return new Output<T>
        {
            Entity = entity            
            , Status = Status.Success
        };
    }
    
    public static Output<T> Warning(T entity, string message)
    {
        return new Output<T>
        {
            Entity = entity
            , Message = message
            , Status = Status.Warning
        };
    }
    
    public static Output<T> Error(T entity, string message)
    {
        return new Output<T>
        {
            Entity = entity
            , Message = message
            , Status = Status.Error
        };
    }
}

public static class OutputExtensions
{
    public static async Task<IEnumerable<Output<T>>> ThenAsync<T>(
        this Task<IEnumerable<Output<T>>> outputs
        , Func<IEnumerable<T>, Task<IEnumerable<Output<T>>>> doesAsync)
    {
        var groupedOutputs = (await outputs)
            .GroupBy(output => output.Status)
            .ToList();
            
        var inputs = groupedOutputs
            .Where(groupedOutput => groupedOutput.Key != Status.Error)
            .SelectMany(groupedOutput => groupedOutput.Select(output => output.Entity))
            .ToList();
            
        var results = await doesAsync(inputs);
        var groupedResults = results
            .GroupBy(result => result.Status)
            .ToList();
            
        var successfulResults = groupedResults
            .Where(groupedResult => groupedResult.Key != Status.Error)
            .SelectMany(groupedResult => groupedResult.Select(result => result));            
            
        return successfulResults
            .GroupJoin(inner: groupedOutputs
                    .Where(groupedOutput => groupedOutput.Key != Status.Error)
                    .SelectMany(groupedOutput => groupedOutput.Select(output => output))                    
                , outerKeySelector: successfulResult => successfulResult.Entity
                , innerKeySelector: parameterResults => parameterResults.Entity
                , resultSelector: (successfulResult, parameterResults) => 
                {
                    var warningMessages = String.Join(Environment.NewLine, parameterResults
                        .Where(warningParameterResult => warningParameterResult.Status == Status.Warning)
                        .Select(warningParameterResult => warningParameterResult.Message));
                    
                    if(!String.IsNullOrWhiteSpace(warningMessages))
                    {                       
                        successfulResult.Message += $"{Environment.NewLine}{warningMessages}";
                        successfulResult.Status = Status.Warning;
                    }
                    return successfulResult;
                })
            .Concat(groupedOutputs
                .Where(groupedOutput => groupedOutput.Key == Status.Error)
                .SelectMany(groupedOutput => groupedOutput.Select(output => output))            
                .Concat(groupedResults
                    .Where(groupedResult => groupedResult.Key == Status.Error)
                    .SelectMany(groupedResult => groupedResult.Select(result => result))))
            .ToList();
    }
}

public class Foo
{
    public Foo(int number){this.Number = number;}

    public int Number {get; set;}    
}

public async Task<IEnumerable<Output<Foo>>> SeedNumbers(int max)
{
    "SeedNumbers Before Delay".Dump();
    await Task.Delay(1500);
    "SeedNumbers After Delay".Dump();
    return Enumerable.Range(0, max)
        .Select(_ => 
        {
            if(_%3 == 0)
            {
                return Output<Foo>.Success(new Foo(_));
            }
            else if(_%3 == 1)
            {
                return Output<Foo>.Warning(new Foo(_), $"{_}%3 == 3");
            }
            return Output<Foo>.Error(new Foo(_), $"{_}%3 == {_%3}");
        }).ToList();
}

public async Task<IEnumerable<Output<Foo>>> Multiply(IEnumerable<Foo> foos)
{
    "Multiply Before Delay".Dump();
    await Task.Delay(1500);
    "Multiply After Delay".Dump();
    return foos
        .Select(foo => 
        {
            if(foo.Number % 4 == 3 || foo.Number % 4 == 2)
            {
                foo.Number *= 10;
                return Output<Foo>.Success(foo);
            }
            else 
            {
                return Output<Foo>.Error(foo, $"Unable to multiply because [{foo.Number}] % 4 != 3");
            }
        }).ToList();
}

public async Task<IEnumerable<Output<Foo>>> Divide(IEnumerable<Foo> foos, int by)
{
    "Divide Before Delay".Dump();
    await Task.Delay(1500);
    "Divide After Delay".Dump();

    return foos
        .Select(foo => 
        {
            if(foo.Number % 5 == 0)
            {
                foo.Number /= by;
                return Output<Foo>.Success(foo);
            }
            else 
            {
                return Output<Foo>.Error(foo, $"Unable to divide [{foo.Number}] by [{by}] because [{foo.Number}] % 4 != 5");
            }
        }).ToList();
}