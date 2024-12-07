using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    public class abe_log
    {
        [Key]
        public Guid log_codigo { get; set; }
        public string log_tabela { get; set; }
        public string log_operacao { get; set; }
        public DateTime log_data { get; set; }
        [ForeignKey("usuario")]
        public Guid usu_codigo { get; set; }
        public virtual Usuario usuario { get; set; }
    }
}
