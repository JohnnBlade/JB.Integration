using JB.Integration.Api.Test.Fixtures;
using JB.Integration.Core.ViewModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JB.Integration.Api.Test.Controllers
{
    [Collection("IntegrationTestCollection")]
    public abstract class BaseIntegrationTest : IDisposable 
    {
        private bool disposedValue = false;

        public IntegrationFixture Factory { get; private set; }

        public HttpClient Client { get; private set; }

        public BaseIntegrationTest(IntegrationFixture factory)
        {
            Factory = factory;
            Client = factory.Client; //factory.CreateClient();
        }

        public StringContent ObjectToJsonContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        public string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T JsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<bool> AuthenticateUser(string username, string password)
        {
            if (Client == null)
                return false;

            var model = new LoginViewModel
            {
                Password = password,
                UserName = username
            };
            var content = ObjectToJsonContent(model);

            // Act
            var response = await Client.PostAsync("/v1/account/authenticate", content);
            var contents = await response.Content.ReadAsStringAsync();
            var result = JsonToObject<LoginResult>(contents);

            if (result.Token != null && result.Success)
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.Token);
                return true;
            }
                
            return false;
        }

        public async Task<LoginResult> Logout()
        {
            if (Client == null)
                return null;

            var response = await Client.GetAsync("/v1/account/logout");
            var contents = await response.Content.ReadAsStringAsync();
            var result = JsonToObject<LoginResult>(contents);

            if (result.Token == null && !result.Success)
                Client.DefaultRequestHeaders.Authorization = null;

            return result;
        }
        #region IDisposable Support



        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
