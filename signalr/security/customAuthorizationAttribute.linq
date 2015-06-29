<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
public class CustomAuthorizeAttribute : Attribute, IAuthorizeHubConnection, IAuthorizeHubMethodInvocation
{
    private const string Password = "hip-hip";

    public bool AuthorizeHubConnection(HubDescriptor hubDescriptor, IRequest request)
    {
        var token = request.QueryString["token"];

        if (token == Password)
        {
            var cookieAuthenticationOptions = new CookieAuthenticationOptions()
            {
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                LoginPath = CookieAuthenticationDefaults.LoginPath,
                LogoutPath = CookieAuthenticationDefaults.LogoutPath
            };

            var claimsIdentity = new ClaimsIdentity(cookieAuthenticationOptions.AuthenticationType);                
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, token));                

            request.Environment["server.User"] = new ClaimsPrincipal(claimsIdentity);

            return true;
        }

        return false;
    }

    public bool AuthorizeHubMethodInvocation(IHubIncomingInvokerContext hubIncomingInvokerContext, bool appliesToMethod)
    {
        var connectionId = hubIncomingInvokerContext.Hub.Context.ConnectionId;
        var environment = hubIncomingInvokerContext.Hub.Context.Request.Environment;
        var serverUser = environment["server.User"] as ClaimsPrincipal;

        if (serverUser != null && serverUser.Identity.IsAuthenticated)
        {
            hubIncomingInvokerContext.Hub.Context = new HubCallerContext(new ServerRequest(environment), connectionId);
            return true;
        }

        return false;
    }
}