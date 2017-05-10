using System;
using System.Collections.Generic;
using System.Text;

namespace nl_site
{
    public interface ICredentialsService
    {
        string UserName { get; }

        string Password { get; }

        void SaveCredentials(string userName, string password);

        void DeleteCredentials();

        bool DoCredentialsExist();
    }
}
