using JB.Integration.Api.Test.Fixtures;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
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
