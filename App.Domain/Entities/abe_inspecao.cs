using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class abe_inspecao
    {
        [Key]
        public Guid ins_codigo { get; set; }
        public DateTime ins_data { get; set; }
        public int ins_situacao { get; set; }
        public string ins_observacao { get; set; }
        public Guid api_codigo { get; set; }
        public abe_apicultor abe_apicultor { get; set; }
        public Guid col_codigo { get; set; }
        public abe_colmeia abe_colmeia { get; set; }
    }
}
