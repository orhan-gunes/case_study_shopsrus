﻿using shopsruscase.Domain.Dtos;
using StackExchange.Redis;

namespace shopsruscase.Infrastructure
{
    public interface IRedisService
    {
        OperationResultDto RedisSetData<T>(T Data, string? Key = null, TimeSpan? expire = null);
        OperationResultDto<T> RedisGetData<T>(string? Key = null) where T : new();
        OperationResultDto RedisCheck();

    }

    public class RedisHelper : IRedisService
    {

        private readonly IConnectionMultiplexer _multiplexer;
        public RedisHelper(IConnectionMultiplexer multiplexer)
        {
            _multiplexer = multiplexer;
        }



        public OperationResultDto RedisSetData<T>(T Data, string? Key = null, TimeSpan? expire = null)
        {
            var cache = _multiplexer.GetDatabase();
            cache.StringSet(Key ?? typeof(T).Name, Data?.ToJson()??"", expire ?? new TimeSpan(0, 1, 0));
            return new OperationResultDto (true,"Veri Eklendi");
        }

        public OperationResultDto RedisSetData<T>(T Data, TimeSpan? expire = null)
        {
            var cache = _multiplexer.GetDatabase();
            cache.StringSet(typeof(T).Name, Data?.ToJson()??"", expire ?? new TimeSpan(0, 1, 0));
            return new OperationResultDto (true,"Veri Eklendi");
        }
        public OperationResultDto<T> RedisGetData<T>(string? Key = null) where T : new()
        {
            var cache = _multiplexer.GetDatabase();
            string val = cache.StringGet(Key ?? typeof(T).Name).ToString();
            if (string.IsNullOrEmpty(val))
                return new OperationResultDto<T> (true, $"{Key ?? typeof(T).Name} İsimli Repo Bulunamadı",default(T));

            var repodata = val.ToModel<T>();
            return new OperationResultDto<T> ( true,"",repodata);
        }

        public OperationResultDto<T> RedisGetData<T>(Func<T, bool> exp, string? Key = null) where T : new()
        {
            var cache = _multiplexer.GetDatabase();
            string val = cache.StringGet(Key ?? typeof(T).Name).ToString();
            if (string.IsNullOrEmpty(val))
                return new OperationResultDto<T> (false,$"{Key ?? typeof(T).Name} İsimli Repo Bulunamadı",default(T) );

            var repodata = val.ToModel<T>();
            return new OperationResultDto<T>(true, "", repodata);
        }

        public OperationResultDto RedisCheck()
        {
           
                var cache = _multiplexer.GetDatabase();
                cache.StringSet("CHECK", "DATA INSERTED");
                return new OperationResultDto ( true,"Redis Server Access Success" );
           

        }
    }
}