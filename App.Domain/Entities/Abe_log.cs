using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class abe_log
    {
        [Key]
        public Guid log_codigo { get; set; }
        public string log_tabela { get; set; }
        public string log_operacao { get; set; }
        public DateTime log_data { get; set; }
        public Guid usu_codigo { get; set; }
        public Usuario usuario { get; set; }
    }
}
