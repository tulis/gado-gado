<Query Kind="Program">
  <Reference Relative="..\..\.nuget\BenchmarkDotNet.Core.0.10.14\lib\net46\BenchmarkDotNet.Core.dll">C:\Users\mon_m\.nuget\BenchmarkDotNet.Core.0.10.14\lib\net46\BenchmarkDotNet.Core.dll</Reference>
  <Reference Relative="..\..\.nuget\BenchmarkDotNet.0.10.14\lib\net46\BenchmarkDotNet.dll">C:\Users\mon_m\.nuget\BenchmarkDotNet.0.10.14\lib\net46\BenchmarkDotNet.dll</Reference>
  <Reference Relative="..\..\.nuget\BenchmarkDotNet.Toolchains.Roslyn.0.10.14\lib\net46\BenchmarkDotNet.Toolchains.Roslyn.dll">C:\Users\mon_m\.nuget\BenchmarkDotNet.Toolchains.Roslyn.0.10.14\lib\net46\BenchmarkDotNet.Toolchains.Roslyn.dll</Reference>
  <Reference Relative="..\..\.nuget\Microsoft.CodeAnalysis.CSharp.2.6.1\lib\netstandard1.3\Microsoft.CodeAnalysis.CSharp.dll">C:\Users\mon_m\.nuget\Microsoft.CodeAnalysis.CSharp.2.6.1\lib\netstandard1.3\Microsoft.CodeAnalysis.CSharp.dll</Reference>
  <Reference Relative="..\..\.nuget\Microsoft.CodeAnalysis.Common.2.6.1\lib\netstandard1.3\Microsoft.CodeAnalysis.dll">C:\Users\mon_m\.nuget\Microsoft.CodeAnalysis.Common.2.6.1\lib\netstandard1.3\Microsoft.CodeAnalysis.dll</Reference>
  <Reference Relative="..\..\.nuget\Microsoft.DotNet.PlatformAbstractions.2.1.0\lib\net45\Microsoft.DotNet.PlatformAbstractions.dll">C:\Users\mon_m\.nuget\Microsoft.DotNet.PlatformAbstractions.2.1.0\lib\net45\Microsoft.DotNet.PlatformAbstractions.dll</Reference>
  <Reference Relative="..\..\.nuget\System.Collections.Immutable.1.3.1\lib\portable-net45+win8+wp8+wpa81\System.Collections.Immutable.dll">C:\Users\mon_m\.nuget\System.Collections.Immutable.1.3.1\lib\portable-net45+win8+wp8+wpa81\System.Collections.Immutable.dll</Reference>
  <Reference Relative="..\..\.nuget\System.Reflection.Metadata.1.4.2\lib\portable-net45+win8\System.Reflection.Metadata.dll">C:\Users\mon_m\.nuget\System.Reflection.Metadata.1.4.2\lib\portable-net45+win8\System.Reflection.Metadata.dll</Reference>
  <Reference Relative="..\..\.nuget\System.Threading.Tasks.Extensions.4.3.0\lib\portable-net45+win8+wp8+wpa81\System.Threading.Tasks.Extensions.dll">C:\Users\mon_m\.nuget\System.Threading.Tasks.Extensions.4.3.0\lib\portable-net45+win8+wp8+wpa81\System.Threading.Tasks.Extensions.dll</Reference>
  <Namespace>BenchmarkDotNet</Namespace>
  <Namespace>BenchmarkDotNet.Analysers</Namespace>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Attributes.Columns</Namespace>
  <Namespace>BenchmarkDotNet.Attributes.Exporters</Namespace>
  <Namespace>BenchmarkDotNet.Attributes.Filters</Namespace>
  <Namespace>BenchmarkDotNet.Attributes.Jobs</Namespace>
  <Namespace>BenchmarkDotNet.Characteristics</Namespace>
  <Namespace>BenchmarkDotNet.Code</Namespace>
  <Namespace>BenchmarkDotNet.Columns</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Diagnosers</Namespace>
  <Namespace>BenchmarkDotNet.Engines</Namespace>
  <Namespace>BenchmarkDotNet.Environments</Namespace>
  <Namespace>BenchmarkDotNet.Exporters</Namespace>
  <Namespace>BenchmarkDotNet.Exporters.Csv</Namespace>
  <Namespace>BenchmarkDotNet.Exporters.Json</Namespace>
  <Namespace>BenchmarkDotNet.Exporters.Xml</Namespace>
  <Namespace>BenchmarkDotNet.Extensions</Namespace>
  <Namespace>BenchmarkDotNet.Filters</Namespace>
  <Namespace>BenchmarkDotNet.Helpers</Namespace>
  <Namespace>BenchmarkDotNet.Horology</Namespace>
  <Namespace>BenchmarkDotNet.Jobs</Namespace>
  <Namespace>BenchmarkDotNet.Loggers</Namespace>
  <Namespace>BenchmarkDotNet.Mathematics</Namespace>
  <Namespace>BenchmarkDotNet.Mathematics.Histograms</Namespace>
  <Namespace>BenchmarkDotNet.Order</Namespace>
  <Namespace>BenchmarkDotNet.Parameters</Namespace>
  <Namespace>BenchmarkDotNet.Portability</Namespace>
  <Namespace>BenchmarkDotNet.Portability.Cpu</Namespace>
  <Namespace>BenchmarkDotNet.Properties</Namespace>
  <Namespace>BenchmarkDotNet.Reports</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>BenchmarkDotNet.Toolchains</Namespace>
  <Namespace>BenchmarkDotNet.Toolchains.CsProj</Namespace>
  <Namespace>BenchmarkDotNet.Toolchains.CustomCoreClr</Namespace>
  <Namespace>BenchmarkDotNet.Toolchains.DotNetCli</Namespace>
  <Namespace>BenchmarkDotNet.Toolchains.InProcess</Namespace>
  <Namespace>BenchmarkDotNet.Toolchains.Parameters</Namespace>
  <Namespace>BenchmarkDotNet.Toolchains.Results</Namespace>
  <Namespace>BenchmarkDotNet.Toolchains.Roslyn</Namespace>
  <Namespace>BenchmarkDotNet.Validators</Namespace>
  <Namespace>Microsoft.DotNet.PlatformAbstractions</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    Environment.CurrentDirectory = Environment
        .GetFolderPath(Environment.SpecialFolder.UserProfile)
        .Dump();
        
    var alices = new int[] {1, 4, 5, 9, 9, 11, 12};
    var bobs = new int[] {1, 2, 5, 9, 10, 11, 14, 15, 20};
    var charlies = new List<int>();
    
    var summary = BenchmarkRunner.Run<AddRemove>();
    //summary.Reports.Dump();
    var reports = summary.Reports
        .SelectMany(report => report.AllMeasurements
            .Where(measurement => measurement.IterationMode == IterationMode.Result)
            .Select(measurement => new{
                Name = report.Benchmark.DisplayInfo
                , IterationIndex = measurement.IterationIndex
                , Nanoseconds = measurement.Nanoseconds
                , Operations = measurement.Operations
        }));
    var groupYSeries = reports.GroupBy(report => report.Name);
    var min = groupYSeries.Min(groupYserie => groupYserie.Count());
    var xSeries = reports.Select(report => report.IterationIndex).Distinct().Take(min).Dump();
    var chart = xSeries.Chart(xSerie => xSerie);    
    foreach(var groupYserie in groupYSeries)
    {
//        groupYserie.Select(report => report.Nanoseconds)
//            .Take(min)
//            .Dump(groupYserie.Key);

        chart.AddYSeries(
            groupYserie.Select(report => report.Nanoseconds / report.Operations).Take(min)
            , Util.SeriesType.Line
            , groupYserie.Key);
    }
    chart.Dump("Average AddRemove in Nanoseconds");
}

// Define other methods and classes here
public class AddRemove
{
    public List<int> Alices { get; } = new List<int>(){1, 4, 5, 9, 9, 11, 12};
    public List<int> Bobs { get; } = new List<int>(){1, 2, 5, 9, 10, 11, 14, 15, 20};

    [Benchmark]
    public List<int> OneIteration()
    {
        var charlies = new List<int>();
        var aliceLength = this.Alices.Count();
        var bobLength = this.Bobs.Count();
        for(int aliceIndex = 0, bobIndex = 0
        ; aliceIndex < aliceLength || bobIndex < bobLength
        ;)
        {
            if(aliceIndex < aliceLength 
                && bobIndex < bobLength
                && Alices[aliceIndex] == Bobs[bobIndex])
            {
                //$"Do Nothing - {Alices[aliceIndex]} == {Bobs[bobIndex]}".Dump();
                charlies.Add(Bobs[bobIndex]);
                aliceIndex++;
                bobIndex++;
            }
            else if(aliceIndex < aliceLength
                && bobIndex < bobLength
                && Alices[aliceIndex] < Bobs[bobIndex])
            {
                //$"Remove alice - {Alices[aliceIndex]} < {Bobs[bobIndex]}".Dump();
                aliceIndex++;
            }
            else if(aliceIndex < aliceLength)
            {
                //$"Remove alice - {Alices[aliceIndex]}".Dump();
                aliceIndex++;
            }
            else if(bobIndex < bobLength)
            {
                //$"Add bob {Bobs[bobIndex]}".Dump();
                charlies.Add(Bobs[bobIndex]);
                bobIndex++;
            }            
        }
        return charlies;
    }
    
    [Benchmark]
    public List<int> DoubleIteration()
    {
        foreach(var alice in Alices.ToArray())
        {
            this.Alices.Remove(alice);
        }
        
        foreach(var bob in Bobs)
        {
            this.Alices.Add(bob);        
        }
        
        return this.Alices;
    }
}