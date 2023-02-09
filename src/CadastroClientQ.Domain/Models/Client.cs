using System.ComponentModel.DataAnnotations;

namespace CadastroClientQ.Domain.Models
{
    public class Client
    {
        //Nome(máximo 40 caracteres)Idade(campo numérico)Sexo(campo numérico no banco, mas na view apresentar as apções Masculino, Feminino, Não Informar) Campo Estado(String)
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; } // Masculino, Feminino, Não Informar
        public string State { get; set; }
    }
}
