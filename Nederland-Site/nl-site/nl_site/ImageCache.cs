using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace nl_site
{
    class ImageCache
    {

        private static Dictionary<string, UriImageSource> cache = new Dictionary<string, UriImageSource>();

        static public UriImageSource GetCachedImageFromUrl(string url)
        {
            UriImageSource uriImageSource = null;

            bool existsInCache = cache.TryGetValue(url, out uriImageSource);

            // if the imagesource is not in the cache, download it and cache it
            // UriImageSource supports caching, the more cache, the better :D

            if (!existsInCache)
            {
                // save cache for 1 day because the source does not change
                uriImageSource = new UriImageSource { CachingEnabled = true, Uri = new Uri(url), CacheValidity = new TimeSpan(1, 0, 0, 0) };
                cache[url] = uriImageSource;
            }

            return uriImageSource;

        }

    }
}
