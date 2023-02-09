using CadastroClientQ.Domain.Models;

namespace CadastroClientQ.WebApp.Models
{
    public class ClientFormViewModel
    {
        public IEnumerable<ClientViewModel> Clients { get; set; }
        public IEnumerable<State> States { get; set; }
    }

    public class ClientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
