using CadastroClientQ.Domain.Models;
using CadastroClientQ.Models;
using CadastroClientQ.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CadastroClientQ.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new ClientFormViewModel()
            {
                Clients = new List<ClientViewModel>()
                {
                    new ClientViewModel()
                    {
                        Id = 1,
                        Name = "Jonathan",
                        Age = 26,
                        State = "Minas Gerais",
                        City = "Betim"
                    }
                },
                States = new List<State>()
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}