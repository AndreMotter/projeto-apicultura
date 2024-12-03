using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class abe_apiario
    {
        [Key]
        public Guid apa_codigo { get; set; }
        public string apa_descricao { get; set; }
        public string apa_endereco { get; set; }
        public Guid api_codigoresponsavel { get; set; }
        public abe_apicultor abe_apicultor { get; set; }
    }
}
