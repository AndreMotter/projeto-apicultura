using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace App.Application.Services
{
    public class HistoricoAcessosService : IHistoricoAcessosService
    {
        private IRepositoryBase<HistoricoAcessos> _repository { get; set; }
        public HistoricoAcessosService(IRepositoryBase<HistoricoAcessos> repository)
        {
            _repository = repository;
        }

        public List<HistoricoAcessos> Listar(string usuario, DateTime? dataInicial, DateTime? DataFinal)
        {
            usuario = usuario ?? "";
            var listaQuery = _repository.Query(x => EF.Functions.Like(x.Usuario.Nome.ToUpper(), $"%{usuario.ToUpper()}%"));
            if (dataInicial != null)
            {
                listaQuery = listaQuery.Where(x => x.Data >= dataInicial.Value.ToUniversalTime());
            }
            if (DataFinal != null)
            {
                listaQuery = listaQuery.Where(x => x.Data <= DataFinal.Value.ToUniversalTime());
            }
            var lista = listaQuery.Select(p => new HistoricoAcessos
            {
                Id = p.Id,
                Descricao = p.Descricao,
                Usuario = new Usuario
                {
                    Nome = p.Usuario.Nome
                },
                Data = p.Data,
                Operacao = p.Operacao
            })
            .OrderByDescending(x => x.Data)
            .ToList();
            return lista;
        }
        public byte[] Imprimir(string usuario, DateTime? dataInicial, DateTime? DataFinal)
        {
            var lista = Listar(usuario, dataInicial, DataFinal);

            StringBuilder html = new StringBuilder();

            html.Append($@"
            <table style='width: 100%;font-size: 14px;font-family:Helvetica;padding: 10px;'>
                <tr>
                    <td style='text-align: left; width: 50%;'>
                        <h2>Relatório de Histórico de Acessos</h2>
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
                                <td style='text-align:left; padding: 3px; width:40%;'><strong>Descrição</strong></td>
                                <td style='text-align:left; padding: 3px; width:20%;'><strong>Data</strong></td>
                                <td style='text-align:left; padding: 3px; width:20%;'><strong>Tipo de Entrada</strong></td>
                                <td style='text-align:left; padding: 3px; width:20%;'><strong>Usuário</strong></td>
                            </tr>
                        </tbody>
                    </table>");

            foreach (var historico in lista)
            {

                html.Append($@"
                       <table style='width: 100%;font-size: 12px;font-family:Helvetica;border-bottom: solid black 1px;border-right: solid black 1px;border-left:solid black 1px;'>
                        <tbody>
                            <tr>
                                <td style='text-align:left; padding: 3px; width:40%;page-break-inside: avoid'>{historico.Descricao}</td>
                                <td style='text-align:left; padding: 3px; width:20%;page-break-inside: avoid'>{(historico.Data != null ? historico.Data.Value.ToString("dd/MM/yyyy") : "")}</td>
                                <td style='text-align:left; padding: 3px; width:20%;page-break-inside: avoid'>{(historico.Operacao == 1 ? "Token NFC" : "Código De Acesso")}</td>
                                <td style='text-align:left; padding: 3px; width:20%;page-break-inside: avoid'>{(historico.Usuario != null ? historico.Usuario.Nome : "")}</td>
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
        public void Remover(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
    }
}
