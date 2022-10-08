
using shopsruscase.Applications;
using shopsruscase.Domain.Interfaces;
using shopsruscase.Infrastructure;
using StackExchange.Redis;

namespace shopsruscase.api
{
    public static class IocConfiguration
    {
        public static void RegisterAllDependencies(IServiceCollection services, IConfiguration config)
        {

            var redis = new RedisHelper(ConnectionMultiplexer.Connect(new ConfigurationOptions
            {
                EndPoints = { config["Redis:Host"] },
                AbortOnConnectFail = config["Redis:AbortOnConnectFail"].TryParseBool(),
                Ssl = config["Redis:Ssl"].TryParseBool(),
                ConnectTimeout = config["Redis:ConnectTimeout"].TryParseInt(),
                ConnectRetry = config["Redis:ConnectRetry"].TryParseInt()
            }));
            services.AddSingleton<IRedisService>(opt => redis);
            services.AddSingleton<ICustomerService,CustomerService>();
         

        }

    }


}
