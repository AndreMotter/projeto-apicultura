using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    public class abe_apicultorcolmeia
    {
        [Key]
        public Guid cpi_codigo { get; set; }
        public bool cpi_principal { get; set; }
        public bool cpi_status { get; set; }
        public DateTime cpi_datainicio { get; set; }
        [ForeignKey("abe_colmeia")]
        public Guid col_codigo{ get; set; }
        public virtual abe_colmeia abe_colmeia { get; set; }
        [ForeignKey("abe_apicultor")]
        public Guid api_codigo { get; set; }
        public virtual abe_apicultor abe_apicultor { get; set; }
    }
}
