using App.Domain.Enum;
using System;
using System.Linq;

namespace Autenticador.Domain.DTOs.Auth
{
    public class AuthData
    {
        public Guid IdUsuario { get; set; }
        public PermissaoEnum Permissao { get; set; }

        public AuthData(Guid idUsuario, PermissaoEnum permissao)
        {
            IdUsuario = idUsuario;
            Permissao = permissao;
        }

        public override string ToString()
        {
            return IdUsuario + "." + ((int)Permissao);
        }

        public static AuthData Parse(string token)
        {
            if (token.Count(x => x == '.') != 1)
            {
                throw new Exception("Token inválido");
            }
            var data = token.Split('.');
            return new AuthData(new Guid(data[0]), (PermissaoEnum)Convert.ToInt32(data[1]));
        }

        public bool HasData()
        {
            return !(IdUsuario == Guid.Empty);
        }
    }
}