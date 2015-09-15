<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Diagnostics.Contracts.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Diagnostics.Debug.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Diagnostics.Tools.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Diagnostics.Tracing.dll</Reference>
  <NuGetReference>Microsoft.AspNet.SignalR.SelfHost</NuGetReference>
  <NuGetReference>Microsoft.Owin.Cors</NuGetReference>
  <Namespace>Microsoft.AspNet.SignalR</Namespace>
  <Namespace>Microsoft.AspNet.SignalR.Hosting</Namespace>
  <Namespace>Microsoft.Owin</Namespace>
  <Namespace>Microsoft.Owin.Cors</Namespace>
  <Namespace>Microsoft.Owin.Hosting</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Owin</Namespace>
  <Namespace>System.Diagnostics</Namespace>
</Query>

void Main()
{	
	string url = "http://localhost:8070";
	using (WebApp.Start<Startup>(url))
	{
		Console.WriteLine("Server running on {0}", url);
		Console.ReadLine();
	}
}

class Startup
{
	public void Configuration(IAppBuilder app)
	{
		app.UseCors(CorsOptions.AllowAll);
		app.MapSignalR();
	}
}

// Define other methods and classes here
public class ChatHub : Hub
{
	public void Send(string name, string message)
	{
		message.Dump(name);
		Clients.All.addMessage(new Message
		{
			By = name,
			Content = message
		});
	}
}

public class Message
{
	public string By {get; set;}
	public string Content {get; set;}
}