using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class abe_apicultor
    {
        [Key]
        public Guid api_codigo { get; set; }
        public string api_nome { get; set; }
        public string api_cpfcnpj { get; set; }
        public string api_telefone { get; set; }
        public bool api_status { get; set; }
    }
}
