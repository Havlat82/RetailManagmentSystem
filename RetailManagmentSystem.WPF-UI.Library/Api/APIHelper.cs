using RetailManagmentSystem.WPF_UI.Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RetailManagmentSystem.WPF_UI.Library.Api
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient _apiClient;
        private ILoggedInUserModel _loggedInUser;

        public APIHelper(ILoggedInUserModel loggedInUser)
        {
            InitializeClient();
            _loggedInUser = loggedInUser;
        }

        public async Task<LoggedInUserModel> GetLoggedInUserInfo(string token)
        {
            _apiClient.DefaultRequestHeaders.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            using (var response = await _apiClient.GetAsync("/api/User"))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                var result = await response.Content.ReadAsAsync<LoggedInUserModel>();
                _loggedInUser.CreatedDate = result.CreatedDate;
                _loggedInUser.EmailAddress = result.EmailAddress;
                _loggedInUser.FirstName = result.FirstName;
                _loggedInUser.LastName = result.LastName;
                _loggedInUser.Id = result.Id;
                _loggedInUser.Token = token;
                return result;
            }

        }

        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            using (var response = await _apiClient.PostAsync("/Token", data))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                return result;
            }
        }

        private void InitializeClient()
        {
            var api = ConfigurationManager.AppSettings["api"];

            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
