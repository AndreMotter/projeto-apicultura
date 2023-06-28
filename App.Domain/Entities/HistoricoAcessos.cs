using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class HistoricoAcessos
    {
        [Key]
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public int Operacao { get; set; }
        public DateTime? Data { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
