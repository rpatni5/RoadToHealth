using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Helpers.DataCaching
{
    public static class AppCachePolicy
    {
        static RequestCachePolicy _imageCachePolicy = new System.Net.Cache.RequestCachePolicy(RequestCacheLevel.CacheIfAvailable);
        public static RequestCachePolicy ImageCachePolicy { get { return _imageCachePolicy; } }

        static RequestCachePolicy _dataCachePolicy = new System.Net.Cache.RequestCachePolicy(RequestCacheLevel.CacheIfAvailable);
        public static RequestCachePolicy DataCachePolicy { get { return _dataCachePolicy; } }
    }
}
