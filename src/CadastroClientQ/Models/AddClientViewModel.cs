namespace CadastroClientQ.WebApp.Models
{
    public class AddClientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public int StateId { get; set; }
        public string StateDescription { get; set; }
        public int CityId { get; set; }
        public string CityDescription { get; set; }
    }
}
