<Query Kind="Program">
  <Reference>C:\src\AttendAnywhere\packages\StackExchange.Redis.1.0.394\lib\net45\StackExchange.Redis.dll</Reference>
  <Namespace>StackExchange.Redis</Namespace>
</Query>

void Main()
{
	var redis = Redis.Server;	
	var information = redis
		.Info()
		.FirstOrDefault(info => info.Key.ToLower() == "keyspace");	
		
	information.Dump();
	
	var cacheId = String.Format("db{0}", 0);	
	var cacheInformation = information
		.FirstOrDefault(info => info.Key.ToLower() == cacheId)
		.Value
		.Split(',');
	cacheInformation.Dump();	
	
	var totalKeys = cacheInformation.First().Split('=').Last();
	totalKeys.Dump();	
}

// Define other methods and classes here
    public class Redis
    {
        private static readonly Lazy<ConnectionMultiplexer> RedisConnectionLazy = new Lazy<ConnectionMultiplexer>(() =>
        {			
            var configurationOptions = ConfigurationOptions.Parse("localhost");           
            configurationOptions.AbortOnConnectFail = false;
            configurationOptions.AllowAdmin = true;
			
            return ConnectionMultiplexer.Connect(configurationOptions);
            //return ConnectionMultiplexer.Connect("localhost");
        });

        internal static IDatabase Database
        {
            get { return RedisConnectionLazy.Value.GetDatabase(); }
        }

        internal static IServer Server
        {
            get
            {
                var endPoint = RedisConnectionLazy.Value.GetEndPoints()[0];
                return RedisConnectionLazy.Value.GetServer(endPoint);
            }
        }
    }