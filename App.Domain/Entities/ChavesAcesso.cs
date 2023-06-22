using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class ChavesAcesso
    {
        [Key]
        public Guid Id { get; set; }
        public string Chave { get; set; }
        public int Tipo { get; set; } 
        public int UsuarioId { get; set; } 
        public Usuario Usuario { get; set; } 
    }
}
