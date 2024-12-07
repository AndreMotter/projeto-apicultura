using App.Domain.Entities;
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
        private IRepositoryBase<abe_colmeia> _repositoryColmeia { get; set; }
        private IRepositoryBase<abe_leitura> _repositoryLeitura { get; set; }
        public ReportService(IRepositoryBase<abe_raca> repository, IRepositoryBase<abe_colmeia> repositoryColmeia, IRepositoryBase<abe_leitura> repositoryLeitura)
        {
            _repository = repository;
            _repositoryColmeia = repositoryColmeia;
            _repositoryLeitura = repositoryLeitura;
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

        public byte[] ImprimirAbe_colmeia(string col_descricao, int col_status)
        {
            col_descricao = col_descricao ?? "";
            var lista = _repositoryColmeia.Query(x => x.col_descricao.ToUpper().Contains(col_descricao.ToUpper())
            && col_status == 0 ? (x.col_status == false || x.col_status == true) : x.col_status == (col_status == 1 ? true : false)).Select(p => new abe_colmeia
            {
                col_codigo = p.col_codigo,
                col_numero = p.col_numero,
                col_datainstalacao = p.col_datainstalacao,
                col_descricao = p.col_descricao,
                col_status = p.col_status,
                abe_raca = new abe_raca
                {
                    rac_descricao = p.abe_raca.rac_descricao,
                },
            }).OrderByDescending(x => x.col_descricao).ToList();

            StringBuilder html = new StringBuilder();

            html.Append($@"
            <table style='width: 100%;font-size: 14px;font-family:Helvetica;padding: 10px;'>
                <tr>
                    <td style='text-align: left; width: 50%;'>
                        <h2>Relatório de Colmeias</h2>
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
                                <td style='text-align:left; padding: 3px; width:25%;'><strong>Número</strong></td>
                                <td style='text-align:left; padding: 3px; width:25%;'><strong>Descrição</strong></td>
                                <td style='text-align:left; padding: 3px; width:25%;'><strong>Raça</strong></td>
                                <td style='text-align:left; padding: 3px; width:25%;'><strong>Data Instalação</strong></td>
                            </tr>
                        </tbody>
                    </table>");

            foreach (var registro in lista)
            {

                html.Append($@"
                       <table style='width: 100%;font-size: 12px;font-family:Helvetica;border-bottom: solid black 1px;border-right: solid black 1px;border-left:solid black 1px;'>
                        <tbody>
                            <tr>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{registro.col_numero}</td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{registro.col_descricao}</td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{registro.abe_raca.rac_descricao}</td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{registro.col_datainstalacao.ToString("dd/MM/yyyy")}</td>
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

        public byte[] ImprimirAbe_leitura(Guid? col_codigo, Guid? tip_codigo, DateTime? data_inicial, DateTime? data_final)
        {
            var query = _repositoryLeitura.Query(x => 1 == 1);

            if (data_inicial.HasValue && data_final.HasValue)
            {
                query = query.Where(x => x.lei_data >= Convert.ToDateTime(data_inicial).ToUniversalTime() && x.lei_data <= Convert.ToDateTime(data_final).ToUniversalTime());
            }

            if (col_codigo != Guid.Empty && col_codigo != null)
            {
                query = query.Where(x => x.col_codigo == col_codigo);
            }

            if (tip_codigo != Guid.Empty && tip_codigo != null)
            {
                query = query.Where(x => x.tip_codigo == tip_codigo);
            }

            var lista = query.Select(p => new abe_leitura
            {
                lei_data = p.lei_data,
                lei_valor = p.lei_valor,
                abe_colmeia = new abe_colmeia
                {
                    col_descricao = p.abe_colmeia.col_descricao,
                },
                abe_tipodeitura = new abe_tipodeitura
                {
                    tip_descricao = p.abe_tipodeitura.tip_descricao,
                    abe_unidademedida = new abe_unidademedida
                    {
                        uni_descricao = p.abe_tipodeitura.abe_unidademedida.uni_descricao,
                        uni_representante = p.abe_tipodeitura.abe_unidademedida.uni_representante
                    }
                },
            }).OrderByDescending(x => x.lei_data).ToList();

            StringBuilder html = new StringBuilder();

            html.Append($@"
            <table style='width: 100%;font-size: 14px;font-family:Helvetica;padding: 10px;'>
                <tr>
                    <td style='text-align: left; width: 50%;'>
                        <h2>Relatório de Leituras</h2>
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
                                <td style='text-align:left; padding: 3px; width:10%;'><strong>Data/Hora</strong></td>
                                <td style='text-align:left; padding: 3px; width:10%;'><strong>Valor</strong></td>
                                <td style='text-align:left; padding: 3px; width:30%;'><strong>Colmeia</strong></td>
                                <td style='text-align:left; padding: 3px; width:30%;'><strong>Tipo Leitura</strong></td>
                                <td style='text-align:left; padding: 3px; width:20%;'><strong>Unidade Medida</strong></td>
                            </tr>
                        </tbody>
                    </table>");

            foreach (var registro in lista)
            {

                html.Append($@"
                       <table style='width: 100%;font-size: 12px;font-family:Helvetica;border-bottom: solid black 1px;border-right: solid black 1px;border-left:solid black 1px;'>
                        <tbody>
                            <tr>
                                <td style='text-align:left; padding: 3px; width:10%;page-break-inside: avoid'>{registro.lei_data}</td>
                                <td style='text-align:left; padding: 3px; width:10%;page-break-inside: avoid'>{registro.lei_valor}</td>
                                <td style='text-align:left; padding: 3px; width:30%;page-break-inside: avoid'>{registro.abe_colmeia.col_descricao}</td>
                                <td style='text-align:left; padding: 3px; width:30%;page-break-inside: avoid'>{registro.abe_tipodeitura.tip_descricao}</td>
                                <td style='text-align:left; padding: 3px; width:20%;page-break-inside: avoid'>{registro.abe_tipodeitura.abe_unidademedida.uni_descricao}</td>
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
