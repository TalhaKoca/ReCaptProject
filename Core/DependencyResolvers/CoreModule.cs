using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceColleciton)
        {
            serviceColleciton.AddMemoryCache();
            //arkaplanda hazır IMemoryCache instance oluşturuyor.

            serviceColleciton.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            serviceColleciton.AddSingleton<ICacheManager, MemoryCacheManager>();
            // biri senden ICacheManager isterse ona MemoryCacheManager ver anlamına geliyor.
        }
    }
}
