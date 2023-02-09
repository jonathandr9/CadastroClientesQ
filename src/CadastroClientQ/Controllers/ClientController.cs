using AutoMapper;
using CadastroClientQ.Domain.Models;
using CadastroClientQ.Domain.Services;
using CadastroClientQ.Models;
using CadastroClientQ.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CadastroClientQ.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(
            ILogger<ClientController> logger,
            IClientService clientService,
            IMapper mapper)
        {
            _clientService = clientService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetListClients();
            var states = await _clientService.GetAllStates();

            var model = new ClientFormViewModel()
            {
                Clients = _mapper.Map<IEnumerable<ClientViewModel>>(clients),
                States = states
            };

            return View(model);
        }

        public async Task<JsonResult> GetCities(int stateId)
        {
            var cities = await _clientService.GetCities(stateId);

            return new JsonResult(cities);
        }

        [HttpPost]
        public async Task<JsonResult> AddClient(
            [FromBody] AddClientViewModel model)
        {
            try
            {
                var clientAdd = _mapper.Map<Client>(model);

                await _clientService.AddClient(clientAdd);

                return new JsonResult(new
                {
                    type = "success",
                    message = "Cliente Cadastrado com Sucesso!"
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    type = "error",
                    message = ex.Message
                });
            }
        }


        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {
                RequestId = Activity.Current?.Id ?? 
                            HttpContext.TraceIdentifier 
            });
        }
    }
}