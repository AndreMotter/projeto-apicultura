using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class abe_unidademedida
    {
        [Key]
        public Guid uni_codigo { get; set; }
        public string uni_descricao { get; set; }
        public string uni_representante { get; set; }
    }
}
