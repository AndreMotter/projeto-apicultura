using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class abe_leitura
    {
        [Key]
        public Guid lei_codigo { get; set; }
        public Guid col_codigo { get; set; }
        public abe_colmeia abe_colmeia { get; set; }
        public Guid tip_codigo { get; set; }
        public abe_tipodeitura abe_tipodeitura { get; set; }
        public DateTime lei_data { get; set; }
        public decimal lei_valor { get; set; }
    }
}
