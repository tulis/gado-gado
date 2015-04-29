<Query Kind="Program">
  <NuGetReference>StackExchange.Redis</NuGetReference>
  <Namespace>StackExchange.Redis</Namespace>
  <Namespace>StackExchange.Redis.KeyspaceIsolation</Namespace>
</Query>

void Main()
{
	var redis = Redis.Server;
	var sequence = redis.Keys(database:0, pattern: "foo:*", pageSize: 1);
	sequence.Dump();
	
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