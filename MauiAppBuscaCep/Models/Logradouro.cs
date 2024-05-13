﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppBuscaCep.Models
{
    public class Logradouro
    {
        public string CEP { get; set; }
        public string id_logradouro { get; set; }
        public string tipo { get; set; }
        public string descricao { get; set; }
        public string id_cidade { get; set; }
        public string UF { get; set; }
        public string complemento { get; set; }
        public string descricao_sem_numero { get; set; }
        public string descricao_cidade { get; set; }
        public string codigo_cidade_ibge { get; set; }
        public string descricao_bairro { get; set; }
    }
}