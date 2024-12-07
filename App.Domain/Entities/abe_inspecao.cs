using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    public class abe_inspecao
    {
        [Key]
        public Guid ins_codigo { get; set; }
        public DateTime ins_data { get; set; }
        public int ins_situacao { get; set; }
        public string ins_observacao { get; set; }
        [ForeignKey("abe_apicultor")]
        public Guid api_codigo { get; set; }
        public virtual abe_apicultor abe_apicultor { get; set; }
        [ForeignKey("abe_colmeia")]
        public Guid col_codigo { get; set; }
        public virtual abe_colmeia abe_colmeia { get; set; }
    }
}
