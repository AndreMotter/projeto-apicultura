using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class Nfc
    {
        [Key]
        public Guid Id { get; set; }
        public string Token { get; set; }
        public bool Ativo { get; set; }
        public Guid? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
