using App.Application.Helpers;
using App.Domain.Entities;
using App.Domain.Enum;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace App.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IRepositoryBase<Usuario> _repository { get; set; }
        public UsuarioService(IRepositoryBase<Usuario> repository)
        {
            _repository = repository;
        }
        public Usuario BuscaPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Informe o id");
            }
            var obj = _repository.Query(x => x.Id == id).FirstOrDefault();
            return obj;
        }

        public List<Usuario> listaUsuarios(string usuario, int status)
        {

            usuario = usuario ?? "";
            return _repository.Query(x => x.Nome.ToUpper().Contains(usuario.ToUpper()) 
            && status == 0 ? (x.Ativo == false || x.Ativo == true) : x.Ativo == (status == 1 ? true : false)
            ).Select(p => new Usuario
            {
                Id = p.Id,
                Nome = p.Nome,
                Ativo = p.Ativo,
                DataNascimento = p.DataNascimento
            }).OrderByDescending(x => x.Nome).ToList();
        }
        public void Remover(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
        public void Salvar(Usuario obj)
        {
            if (String.IsNullOrEmpty(obj.Nome))
            {
                throw new Exception("Informe o nome");
            }
            if (obj.Permissao == 0)
            {
                throw new Exception("Informe um permissão");
            }
            if (obj.DataNascimento == null)
            {
                throw new Exception("Informe a data de nascimento");
            }

            obj.DataNascimento = obj.DataNascimento?.ToUniversalTime();
            
            if(obj.Id == Guid.Empty)
            {
                _repository.Save(obj);
            }
            else
            {
                _repository.Update(obj);
            }
            _repository.SaveChanges();
        }
        public void Ativar(Guid id)
        {
            var obj = BuscaPorId(id);
            if(obj.Ativo) 
            {
                obj.Ativo = false;
            }
            else
            {
                obj.Ativo = true;
            }
            _repository.Update(obj);
            _repository.SaveChanges();
        }

        public byte[] Imprimir(string usuario, int status)
        {
            var lista = listaUsuarios(usuario, status);

            StringBuilder html = new StringBuilder();

            html.Append($@"
            <table style='width: 100%;font-size: 14px;font-family:Helvetica;padding: 10px;'>
                <tr>
                    <td style='text-align: left; width: 50%;'>
                        <h2>Relatório de Usuários</h2>
                    </td>
                    <td style='text-align: right; width: 50%;'>
                        <p>Data de Emissão: <strong>{DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy")}</strong></p>
                        <p><strong>Sistema HoneyTrack</strong></p>
                    </td>
                </tr>
            </table>");

            html.Append(@"<table style='width: 100%;font-size: 14px;font-family:Helvetica; page-break-inside: avoid;margin-top: 12px;border: solid black 1px;background-color: #E8E8E8;'>
                        <tbody>
                            <tr>
                                <td style='text-align:left; padding: 3px; width:25%;'><strong>Usuário</strong></td>
                                <td style='text-align:left; padding: 3px; width:25%;'><strong>Data Nascimento</strong></td>
                                <td style='text-align:left; padding: 3px; width:25%;'><strong>Status</strong></td>
                                <td style='text-align:left; padding: 3px; width:25%;'><strong>Cidade</strong></td>
                            </tr>
                        </tbody>
                    </table>");

            foreach (var _usuario in lista)
            {

                html.Append($@"
                       <table style='width: 100%;font-size: 12px;font-family:Helvetica;border-bottom: solid black 1px;border-right: solid black 1px;border-left:solid black 1px;'>
                        <tbody>
                            <tr>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{_usuario.Nome}</td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{_usuario.DataNascimento?.ToString("dd/MM/yyyy")}</td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{(_usuario.Ativo ? "Ativo" : "Inativo")}</td>
                            </tr>
                        </tbody>
                    </table>");
            }

            HtmlToPdf converter = new HtmlToPdf();
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            PdfDocument doc = converter.ConvertHtmlString(html.ToString());
            using (MemoryStream ms = new MemoryStream())
            {
                doc.Save(ms);
                byte[] bytes = ms.ToArray();
                doc.Close();

                return bytes;
            }
        }
    }
}
