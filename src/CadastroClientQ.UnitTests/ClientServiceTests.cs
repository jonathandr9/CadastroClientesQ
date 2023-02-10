using CadastroClientQ.Application;
using CadastroClientQ.Domain.Adapters;
using CadastroClientQ.Domain.Models;
using CadastroClientQ.Domain.Repositories;
using CadastroClientQ.Domain.Services;
using Moq;
using Xunit;

namespace CadastroClientQ.UnitTests
{
    public class ClientServiceTests
    {
        private readonly Mock<IClientRepository> _clientRepositoryMock;
        private readonly Mock<IIBGEApi> _ibgeApiAdapter;
        public ClientServiceTests()
        {
            _clientRepositoryMock = new Mock<IClientRepository>();
            _ibgeApiAdapter = new Mock<IIBGEApi>();
        }

        [Fact]
        [Trait("AddClient", "Client")]
        public async Task AddClient_ClientService_Success()
        {
            //Arrange          
            var clientAdd = new Client()
            {
                Name = "Cliente teste",
                Age = 20,
                Sex = 1,
                StateId = 31,
                StateDescription = "Minas Gerais",
                CityId = 3106705,
                CityDescription = "Betim",
            };

            var clientReturn = clientAdd;
            clientReturn.Id = 1;

            _clientRepositoryMock.Setup(x => x.Add(It.IsAny<Client>())
                ).ReturnsAsync(clientReturn);

            IClientService clientService = new ClientService(_clientRepositoryMock.Object, _ibgeApiAdapter.Object);

            //Act      
            var returnClient = clientService.AddClient(clientAdd);

            //Assert
            Assert.True(returnClient.Id == 1);
        }


        [Fact]
        [Trait("AddProduct", "Product")]
        public async Task AddClient_ClientService_ErrorAnyNullParam()
        {
            //Arrange       
            var clientAdd = new Client()
            {
                Name = null,
                Age = 20,
                Sex = 1,
                StateId = 31,
                StateDescription = "Minas Gerais",
                CityId = 3106705,
                CityDescription = "Betim",
            };


            _clientRepositoryMock.Setup(x => x.Add(It.IsAny<Client>()));

            IClientService clientService = new ClientService(_clientRepositoryMock.Object, _ibgeApiAdapter.Object);


            //Act / Assert
            Assert.ThrowsAsync<ArgumentException>(() => clientService.AddClient(clientAdd));
        }
    }
}