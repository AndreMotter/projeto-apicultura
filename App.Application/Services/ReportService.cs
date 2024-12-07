﻿using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using SelectPdf;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace App.Application.Services
{
    public class ReportService : IReportService
    {
        private IRepositoryBase<abe_raca> _repository { get; set; }
        public ReportService(IRepositoryBase<abe_raca> repository)
        {
            _repository = repository;
        }
        public byte[] ImprimirAbe_raca(string rac_descricao, int rac_status)
        {
            rac_descricao = rac_descricao ?? "";

            var lista = _repository.Query(x => x.rac_descricao.ToUpper().Contains(rac_descricao.ToUpper())
            && rac_status == 0 ? (x.rac_status == false || x.rac_status == true) : x.rac_status == (rac_status == 1 ? true : false)).Select(p => new abe_raca
            {
                rac_codigo = p.rac_codigo,
                rac_descricao = p.rac_descricao,
                rac_origem = p.rac_origem,
                rac_status = p.rac_status,
            }).OrderByDescending(x => x.rac_descricao).ToList();

            StringBuilder html = new StringBuilder();

            html.Append($@"
            <table style='width: 100%;font-size: 14px;font-family:Helvetica;padding: 10px;'>
                <tr>
                    <td style='text-align: left; width: 50%;'>
                        <h2>Relatório de Raças</h2>
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
                                <td style='text-align:left; padding: 3px; width:25%;'><strong>Descrição</strong></td>
                                <td style='text-align:left; padding: 3px; width:25%;'><strong>Origem</strong></td>
                                <td style='text-align:left; padding: 3px; width:25%;'><strong>Status</strong></td>
                            </tr>
                        </tbody>
                    </table>");

            foreach (var registro in lista)
            {

                html.Append($@"
                       <table style='width: 100%;font-size: 12px;font-family:Helvetica;border-bottom: solid black 1px;border-right: solid black 1px;border-left:solid black 1px;'>
                        <tbody>
                            <tr>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{registro.rac_descricao}</td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{registro.rac_origem}</td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{(registro.rac_status ? "Ativo" : "Inativo")}</td>
                            </tr>
                        </tbody>
                    </table>");
            }

            html.Append(@"
            <div style='height:20px;'></div>
            <table style='width: 100%;font-size: 14px;font-family:Helvetica; margin-top: 20px;'>
                <tr>
                    <td style='text-align: center; width: 100%;'>
                        <p>_______________________________</p>
                        <p><strong>Apicultor Responsável</strong></p>
                    </td>
                </tr>
            </table>");

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