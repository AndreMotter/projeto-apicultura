using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class abe_raca
    {
        [Key]
        public Guid rac_codigo { get; set; }
        public string rac_descricao { get; set; }
        public string rac_origem { get; set; }
        public bool rac_status { get; set; }
    }
}
