using Locadora_De_Veiculos.Dominio.ModuloLocacao;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;

namespace Locadora_De_Veiculos.Infra.PDF.IText7
{
    public class GeradorRelatorioLocacaoItext7 : IGeradorRelatorioLocacao
    {
        
        public void GeradorRalatorioPdf(Locacao locacao)
        {
            PdfWriter pdfWriter = new PdfWriter("C:\\RelatorioLocação.pdf");
            PdfDocument pdfDocument = new PdfDocument(pdfWriter);
            Document document = new Document(pdfDocument, PageSize.A4.Rotate());
            {
                //PageSize.A4 - vertical ou PageSize.A4.Rotate() - horizontal
                document.Add(new Paragraph("Locadora de veículos").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20));
                document.Add(new Paragraph("Locação" + locacao.Id).SetTextAlignment(TextAlignment.CENTER).SetFontSize(15));
                document.Add(new LineSeparator(new SolidLine()));

                Table table = new Table(9, false);
                table.SetWidth(UnitValue.CreatePercentValue(100));
                table.SetTextAlignment(TextAlignment.LEFT);
                table.AddCell(new Cell().Add(new Paragraph("ID: " + locacao.Id)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph("Funcionario: " + locacao.Funcionario.Nome)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph("Cliente: " + locacao.Cliente.Nome)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph("Condutor: " + locacao.Condutor.Nome)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph("Categoria: " + locacao.Categoria.Nome)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph("Veículo: " + locacao.Veiculo.Placa)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph("Plano: " + locacao.NomeDoPlano)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph("Data inicio: " + locacao.DataInicio.ToString("dd/MM/yyyy"))).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph("Data final: " + locacao.DataFinalPrevista.ToString("dd/MM/yyyy")).SetBorder(Border.NO_BORDER)));

                //adiciona a tabela criada, já com os dados, no documento
                document.Add(table);
            }
        }
    }
}
