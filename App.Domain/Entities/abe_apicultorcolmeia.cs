using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class abe_apicultorcolmeia
    {
        [Key]
        public Guid cpi_codigo { get; set; }
        public bool cpi_principal { get; set; }
        public bool cpi_status { get; set; }
        public DateTime cpi_datainicio { get; set; }
        public Guid col_codigo{ get; set; }
        public abe_colmeia abe_colmeia { get; set; }
        public Guid api_codigo { get; set; }
        public abe_apicultor abe_apicultor { get; set; }
    }
}
