﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    public class abe_colmeia
    {
        [Key]
        public Guid col_codigo { get; set; }
        public string col_descricao { get; set; }
        public DateTime col_datainstalacao { get; set; }
        public bool col_status { get; set; }
        public int col_numero { get; set; }
        public decimal col_latitude { get; set; }
        public decimal col_longitude { get; set; }
        [ForeignKey("abe_raca")]
        public Guid rac_codigo { get; set; }
        public virtual abe_raca abe_raca { get; set; }
    }
}
