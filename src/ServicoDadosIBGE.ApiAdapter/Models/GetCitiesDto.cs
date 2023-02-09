﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBGEServicoDados.ApiAdapter.Models
{
    public class GetCitiesDto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public Municipio municipio { get; set; }
    }

    public class Mesorregiao
    {
        public int id { get; set; }
        public string nome { get; set; }
        public UF UF { get; set; }
    }

    public class Microrregiao
    {
        public int id { get; set; }
        public string nome { get; set; }
        public Mesorregiao mesorregiao { get; set; }
    }

    public class Municipio
    {
        public int id { get; set; }
        public string nome { get; set; }
        public Microrregiao microrregiao { get; set; }

        [JsonProperty("regiao-imediata")]
        public RegiaoImediata regiaoimediata { get; set; }
    }

    public class Regiao
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
    }

    public class RegiaoImediata
    {
        public int id { get; set; }
        public string nome { get; set; }

        [JsonProperty("regiao-intermediaria")]
        public RegiaoIntermediaria regiaointermediaria { get; set; }
    }

    public class RegiaoIntermediaria
    {
        public int id { get; set; }
        public string nome { get; set; }
        public UF UF { get; set; }
    }
    public class UF
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public Regiao regiao { get; set; }
    }


}
