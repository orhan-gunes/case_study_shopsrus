
using AutoMapper;
using shopsruscase.Applications;
using shopsruscase.Applications.Repostory;
using shopsruscase.Domain.Interfaces;
using shopsruscase.Infrastructure;
using StackExchange.Redis;

namespace shopsruscase.api
{
    public static class IocConfiguration
    {
        public static void RegisterAllDependencies(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IAppDbContext, AppDbContext>();

            var redis = new RedisHelper(ConnectionMultiplexer.Connect(new ConfigurationOptions
            {
                EndPoints = { config["Redis:Host"] },
                AbortOnConnectFail = config["Redis:AbortOnConnectFail"].TryParseBool(),
                Ssl = config["Redis:Ssl"].TryParseBool(),
                ConnectTimeout = config["Redis:ConnectTimeout"].TryParseInt(),
                ConnectRetry = config["Redis:ConnectRetry"].TryParseInt()
            }));


            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton<IRedisService>(opt => redis);
            services.AddScoped<IinvoiceService,InvoiceService>();
      
         

        }

    }


}
