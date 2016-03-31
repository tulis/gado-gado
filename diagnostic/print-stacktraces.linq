<Query Kind="Program" />

void Main()
{
	var foo = new Foo();
	foo.Dispose();	
}

// Define other methods and classes here
public class Foo : IDisposable
{
	public Foo()
	{
		var stringBuilder = new StringBuilder();
		var stackTrace = new StackTrace();
		var stackFrames = stackTrace.GetFrames().ToList();
		stringBuilder.AppendLine("<ctorFoo>");
		stackFrames.ForEach(stackFrame => stringBuilder.AppendFormat("{0}.{1}", stackFrame.GetMethod().DeclaringType.FullName, stackFrame.GetMethod().Name).AppendLine());
		stringBuilder.AppendLine("</ctorFoo>");
		//log4net.LogManager.GetLogger(typeof(IntraMapsEmbeddedProvider)).Info(stringBuilder.ToString());
		stringBuilder.ToString().Dump();
	}

	public void Dispose()
	{
		var stringBuilder = new StringBuilder();
		var stackTrace = new StackTrace();
		var stackFrames = stackTrace.GetFrames().ToList();
		stringBuilder.AppendLine("<disposeFoo>");
		stackFrames.ForEach(stackFrame => stringBuilder.AppendFormat("{0}.{1}", stackFrame.GetMethod().DeclaringType.FullName, stackFrame.GetMethod().Name).AppendLine());
		stringBuilder.AppendLine("</disposeFoo>");
		//log4net.LogManager.GetLogger(typeof(IntraMapsEmbeddedProvider)).Info(stringBuilder.ToString());
		stringBuilder.ToString().Dump();
	}
}