<Query Kind="Program">
  <NuGetReference>Microsoft.AspNet.SignalR.Client</NuGetReference>
  <Namespace>Microsoft.AspNet.SignalR.Client</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var url = "http://localhost:8070";
	var hubConnection = new HubConnection(url);
	IHubProxy chatHub = hubConnection.CreateHubProxy("ChatHub");
	
	RegisterEvents(chatHub);	
	hubConnection.Start().Wait();
		
	Start(chatHub);
	Console.ReadLine();
}

// Define other methods and classes here
public void RegisterEvents(IHubProxy chatHub)
{
	chatHub.On<Message>("AddMessage", message => 
	{
		message.Content.Dump(message.By);
	});
}

public void Start(IHubProxy chatHub)
{
	var isContinue = true;
	Console.WriteLine("What's your name?");
	var name = Console.ReadLine();
	chatHub.Invoke<Message>("send", name, "just joined");
	
	while(isContinue)
	{
		var content = Console.ReadLine();
		
		if(String.IsNullOrEmpty(content))
		{
			isContinue = false;
			chatHub.Invoke<Message>("send", name, "just left");
		}
		
		chatHub.Invoke<Message>("send", name, content);
	}
}

public class Message
{
	public string By {get; set;}
	public string Content {get; set;}
}