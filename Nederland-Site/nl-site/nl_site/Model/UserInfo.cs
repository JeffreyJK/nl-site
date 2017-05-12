using System;
using System.Collections.Generic;
using System.Text;

namespace nl_site.Model
{
    public class UserInfo
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string status { get; set; }
        public string profile_img { get; set; }
        public string created_at { get; set; }
        public int rank { get; set; }
        public int active { get; set; }
    }
}
