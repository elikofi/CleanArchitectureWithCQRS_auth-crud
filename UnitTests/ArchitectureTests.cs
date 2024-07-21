using Xunit;

namespace UnitTests
{
    public class ArchitectureTests
    {
        private const string ApplicationNamespace = "Application";
        private const string ContractsNamespace = "Contracts";
        private const string DomainNamespace = "Domain";
        private const string InfrastructureNamespace = "Infrastructure";
        private const string CleanArchCQRSNamespace = "CleanArchCQRS.API";


        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Arrange


            //Act

            //Assert
        }
    }
}
