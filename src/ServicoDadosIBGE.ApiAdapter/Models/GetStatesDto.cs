using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBGEServicoDados.ApiAdapter.Models
{  

    public class GetStatesDto
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public RegionDto regiao { get; set; }
    }

    public class RegionDto
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
    }
}
