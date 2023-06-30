using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public Guid? CidadeId { get; set; }
        public Cidade Cidade { get; set; }
        public string Senha { get; set; }
        public int Permissao { get; set; }
    }
}
