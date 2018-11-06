<Query Kind="Program">
  <Reference Relative="..\..\.nuget\Microsoft.Owin.4.0.0\lib\net451\Microsoft.Owin.dll">C:\Users\tulis\.nuget\Microsoft.Owin.4.0.0\lib\net451\Microsoft.Owin.dll</Reference>
  <Reference Relative="..\..\.nuget\Microsoft.Owin.Host.HttpListener.2.0.2\lib\net40\Microsoft.Owin.Host.HttpListener.dll">C:\Users\tulis\.nuget\Microsoft.Owin.Host.HttpListener.2.0.2\lib\net40\Microsoft.Owin.Host.HttpListener.dll</Reference>
  <Reference Relative="..\..\.nuget\Microsoft.Owin.Hosting.2.0.2\lib\net40\Microsoft.Owin.Hosting.dll">C:\Users\tulis\.nuget\Microsoft.Owin.Hosting.2.0.2\lib\net40\Microsoft.Owin.Hosting.dll</Reference>
  <Reference Relative="..\..\.nuget\Microsoft.Owin.Security.4.0.0\lib\net451\Microsoft.Owin.Security.dll">C:\Users\tulis\.nuget\Microsoft.Owin.Security.4.0.0\lib\net451\Microsoft.Owin.Security.dll</Reference>
  <Reference Relative="..\..\.nuget\Newtonsoft.Json.6.0.4\lib\net45\Newtonsoft.Json.dll">C:\Users\tulis\.nuget\Newtonsoft.Json.6.0.4\lib\net45\Newtonsoft.Json.dll</Reference>
  <Reference Relative="..\..\.nuget\Owin.1.0\lib\net40\Owin.dll">C:\Users\tulis\.nuget\Owin.1.0\lib\net40\Owin.dll</Reference>
  <Reference Relative="..\..\.nuget\System.Collections.Immutable.1.3.1\lib\portable-net45+win8+wp8+wpa81\System.Collections.Immutable.dll">C:\Users\tulis\.nuget\System.Collections.Immutable.1.3.1\lib\portable-net45+win8+wp8+wpa81\System.Collections.Immutable.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference Relative="..\..\.nuget\Microsoft.AspNet.WebApi.Client.5.2.6\lib\net45\System.Net.Http.Formatting.dll">C:\Users\tulis\.nuget\Microsoft.AspNet.WebApi.Client.5.2.6\lib\net45\System.Net.Http.Formatting.dll</Reference>
  <Reference Relative="..\..\.nuget\System.Reflection.Metadata.1.4.2\lib\portable-net45+win8\System.Reflection.Metadata.dll">C:\Users\tulis\.nuget\System.Reflection.Metadata.1.4.2\lib\portable-net45+win8\System.Reflection.Metadata.dll</Reference>
  <Reference Relative="..\..\.nuget\System.Threading.Tasks.Extensions.4.3.0\lib\portable-net45+win8+wp8+wpa81\System.Threading.Tasks.Extensions.dll">C:\Users\tulis\.nuget\System.Threading.Tasks.Extensions.4.3.0\lib\portable-net45+win8+wp8+wpa81\System.Threading.Tasks.Extensions.dll</Reference>
  <Reference Relative="..\..\.nuget\Microsoft.AspNet.WebApi.Core.5.2.6\lib\net45\System.Web.Http.dll">C:\Users\tulis\.nuget\Microsoft.AspNet.WebApi.Core.5.2.6\lib\net45\System.Web.Http.dll</Reference>
  <Reference Relative="..\..\.nuget\Microsoft.AspNet.WebApi.Owin.5.2.6\lib\net45\System.Web.Http.Owin.dll">C:\Users\tulis\.nuget\Microsoft.AspNet.WebApi.Owin.5.2.6\lib\net45\System.Web.Http.Owin.dll</Reference>
  <Reference Relative="..\..\.nuget\Microsoft.AspNet.WebApi.WebHost.5.2.6\lib\net45\System.Web.Http.WebHost.dll">C:\Users\tulis\.nuget\Microsoft.AspNet.WebApi.WebHost.5.2.6\lib\net45\System.Web.Http.WebHost.dll</Reference>
  <Namespace>Microsoft.Owin.Host.HttpListener</Namespace>
  <Namespace>Microsoft.Owin.Hosting</Namespace>
  <Namespace>Microsoft.Owin.Security</Namespace>
  <Namespace>Microsoft.Owin.Security.DataHandler</Namespace>
  <Namespace>Microsoft.Owin.Security.DataHandler.Encoder</Namespace>
  <Namespace>Microsoft.Owin.Security.DataHandler.Serializer</Namespace>
  <Namespace>Microsoft.Owin.Security.DataProtection</Namespace>
  <Namespace>Microsoft.Owin.Security.Infrastructure</Namespace>
  <Namespace>Microsoft.Owin.Security.Notifications</Namespace>
  <Namespace>Microsoft.Owin.Security.Provider</Namespace>
  <Namespace>Owin</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Formatting</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Web.Http</Namespace>
  <Namespace>System.Web.Http.Batch</Namespace>
  <Namespace>System.Web.Http.Controllers</Namespace>
  <Namespace>System.Web.Http.Dependencies</Namespace>
  <Namespace>System.Web.Http.Description</Namespace>
  <Namespace>System.Web.Http.Dispatcher</Namespace>
  <Namespace>System.Web.Http.ExceptionHandling</Namespace>
  <Namespace>System.Web.Http.Filters</Namespace>
  <Namespace>System.Web.Http.Hosting</Namespace>
  <Namespace>System.Web.Http.Metadata</Namespace>
  <Namespace>System.Web.Http.Metadata.Providers</Namespace>
  <Namespace>System.Web.Http.ModelBinding</Namespace>
  <Namespace>System.Web.Http.ModelBinding.Binders</Namespace>
  <Namespace>System.Web.Http.Owin</Namespace>
  <Namespace>System.Web.Http.Results</Namespace>
  <Namespace>System.Web.Http.Routing</Namespace>
  <Namespace>System.Web.Http.Routing.Constraints</Namespace>
  <Namespace>System.Web.Http.Services</Namespace>
  <Namespace>System.Web.Http.Tracing</Namespace>
  <Namespace>System.Web.Http.Validation</Namespace>
  <Namespace>System.Web.Http.Validation.Providers</Namespace>
  <Namespace>System.Web.Http.Validation.Validators</Namespace>
  <Namespace>System.Web.Http.ValueProviders</Namespace>
  <Namespace>System.Web.Http.ValueProviders.Providers</Namespace>
  <Namespace>System.Web.Http.WebHost</Namespace>
</Query>

//http://jason.deabill.net/musings/2015/09/25/owin-webapi-linqpad.html
void Main()
{
    using (var app = WebApp.Start<Startup>("http://localhost:8090"))
    {
        Process.Start("http://localhost:8090/api");
        Console.ReadLine();
    }
}

// Define other methods and classes here
public class Startup
{
   public void Configuration(IAppBuilder app)
   {
        var config = new HttpConfiguration();
        config.Services.Replace(typeof(IHttpControllerTypeResolver), new ControllerResolver());
        config.MapHttpAttributeRoutes();
      
        var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
        json.UseDataContractJsonSerializer = true;
        config.Formatters[0] = json;
        config.Formatters.Remove(config.Formatters.XmlFormatter);

        app.UseWebApi(config);
   }
}

public class ControllerResolver : DefaultHttpControllerTypeResolver
{
    public override ICollection<Type> GetControllerTypes(IAssembliesResolver assembliesResolver)
    {
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(i => typeof(IHttpController).IsAssignableFrom(i))
            .ToList();
    }
}

[RoutePrefix("api")]
public class DefaultController : ApiController
{
    [HttpGet, Route("")]
    public IHttpActionResult Get()
    {
      return Ok("Hello, world!");
    }
   
    [HttpPost, Route("")]
    public async Task<IHttpActionResult> Post()
    {
        throw new NotImplementedException();
    }
}
