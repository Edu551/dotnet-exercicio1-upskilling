using System;

namespace Exercicio.Model
{
    public class EstacionadoModel
    {
        public string Id { get; set; }
        public string Veiculo_id{ get; set; }
        public DateTime Entrada { get; set; }
        public DateTime? Saida { get; set; }
    }
}
