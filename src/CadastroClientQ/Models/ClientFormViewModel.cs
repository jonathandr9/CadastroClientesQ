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
        public int SexId { get; set; }
        public string Sex { get; set; }
        public int StateId { get; set; }
        public string StateDescription { get; set; }
        public int CityId { get; set; }
        public string CityDescription { get; set; }
    }
}
