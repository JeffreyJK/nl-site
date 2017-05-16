using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace nl_site.Model
{
    public class GroupList
    {
        public string id { get; set; }
        public string title { get; set; }
        public string group_icon { get; set; }
        public string created_at { get; set; }

        public UriImageSource cachedThumbnail
        {
            get { return ImageCache.GetCachedImageFromUrl(this.group_icon); }
        }

    }
}