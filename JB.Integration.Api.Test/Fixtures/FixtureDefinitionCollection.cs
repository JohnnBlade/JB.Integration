using Xunit;

namespace JB.Integration.Api.Test.Fixtures
{

    [CollectionDefinition("IntegrationTestCollection")]
    public class FixtureDefinitionCollection : ICollectionFixture<IntegrationFixture>
    {
    }
}
