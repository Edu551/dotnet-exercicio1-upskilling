using System;
using System.Collections.Generic;

namespace Exercicio.Model
{
    public class ClienteModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public List<VeiculoModel> Veiculos { get; set; }
    }
}
