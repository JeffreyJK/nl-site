using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using nl_site.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace nl_site
{
    class ApiClient
    {
        public HttpClient connectToServer()
        {
            HttpClient connection = new HttpClient();

            connection.BaseAddress = new Uri("http://jeffreykolkman.nl/nl-site-api/");
            connection.DefaultRequestHeaders.Accept.Clear();
            connection.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return connection;
        }



        public async Task<ClientOutput> loginUserData(string Email, string Password)
        {
            UserInfo userInfo = new UserInfo();
            HttpClient client = connectToServer();
            Login loginUser = new Login
            {
                email = Email,
                password = Password
            };
            String str = JsonConvert.SerializeObject(loginUser);
            HttpResponseMessage response;
            try
            {
                response = await client.PostAsync("login", new StringContent(str));

            }
            catch (Exception)
            {
                ClientOutput o = new ClientOutput
                {
                    errorCode = 1,
                    Content = "Kon geen verbinding maken met de server"
                };
                return o;
            }


            if (response.IsSuccessStatusCode)
            {
                String s = await response.Content.ReadAsStringAsync();
                try
                {
                    ClientOutput t = (ClientOutput)JsonConvert.DeserializeObject(s, typeof(ClientOutput));
                    return t;
                } catch (Exception e)
                {
                    ClientOutput oe = new ClientOutput
                    {
                        errorCode = 1,
                        Content = e.Message
                    };
                    return oe;
                }
                
            }
            else
            {
                ClientOutput o = new ClientOutput
                {
                    errorCode = 1,
                    Content = "Kon geen verbinding maken met de server"
                };
                return o;
            }
        }

        public async Task<ClientOutput> registerData(string Email, string FirstName, string LastName)
        {
            UserInfo userInfo = new UserInfo();
            HttpClient client = connectToServer();
            Register registerUser = new Register
            {
                email = Email,
                first_name = FirstName,
                last_name = LastName
            };
            String str = JsonConvert.SerializeObject(registerUser);
            HttpResponseMessage response;
            try
            {
                response = await client.PostAsync("register", new StringContent(str));

            }
            catch (Exception)
            {
                ClientOutput o = new ClientOutput
                {
                    errorCode = 1,
                    Content = "Kon geen verbinding maken met de server1"
                };
                return o;
            }


            if (response.IsSuccessStatusCode)
            {
                String s = await response.Content.ReadAsStringAsync();
                try
                {
                    ClientOutput t = (ClientOutput)JsonConvert.DeserializeObject(s, typeof(ClientOutput));
                    return t;
                }
                catch (Exception e)
                {
                    ClientOutput oe = new ClientOutput
                    {
                        errorCode = 1,
                        Content = e.Message
                    };
                    return oe;
                }

            }
            else
            {
                ClientOutput o = new ClientOutput
                {
                    errorCode = 1,
                    Content = "Kon geen verbinding maken met de server2"
                };
                return o;
            }
        }
    }
}
