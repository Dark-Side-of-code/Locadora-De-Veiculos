using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Locadora_De_Veiculos.Dominio.ModuloLocacao;
using Locadora_De_Veiculos.WindApp.ModuloLocacao;
using Locadora_De_Veiculos.Infra.Orm.ModuloLocacao;

namespace Locadora_De_Veiculos.WindApp.Compartilhado.Funções
{
    public class GeraPDF
    {
        //metodo que possibilita a escolha onde salvar e qual o nome do relatório gerado
        public static string pathArquivo(string nome)
        {
            SaveFileDialog savePath = new SaveFileDialog(); savePath.Title = "Selecione o local e o nome para salvar seu documento";
            savePath.Filter = "Arquivo|*.pdf";
            savePath.FileName = nome + "-" + Convert.ToString(DateTime.Now).Replace("/", "-").Replace(":", "-") + ".pdf";
            if (savePath.ShowDialog() == DialogResult.OK)
            {
                return Convert.ToString(savePath.FileName);
            }
            else
            {
                return "Locadora de veículos.pdf";
            }
        }

        public static void PdfLocacao(string pathArquivo, Guid id)
        {
            try
            {
                Locacao locacao = new Locacao();
                // pathArquivo() é o método criado para pegar o local onde o pdf será salvo
                PdfWriter pdfWriter = new PdfWriter(pathArquivo);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                Document document = new Document(pdfDocument, PageSize.A4.Rotate());
                {
                    //PageSize.A4 - vertical ou PageSize.A4.Rotate() - horizontal
                    document.Add(new Paragraph("Locadora de veículos").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20));
                    document.Add(new Paragraph("Locação" + id).SetTextAlignment(TextAlignment.CENTER).SetFontSize(15));
                    document.Add(new LineSeparator(new SolidLine()));

                    Table table = new Table(10, false);
                    table.SetWidth(UnitValue.CreatePercentValue(100));
                    table.SetTextAlignment(TextAlignment.LEFT);
                    table.AddCell(new Cell().Add(new Paragraph("ID: " + id)).SetBorder(Border.NO_BORDER));
                    table.AddCell(new Cell().Add(new Paragraph("Funcionario: " + locacao.Funcionario.Nome)).SetBorder(Border.NO_BORDER));
                    table.AddCell(new Cell().Add(new Paragraph("Cliente: " + locacao.Cliente.Nome)).SetBorder(Border.NO_BORDER));
                    table.AddCell(new Cell().Add(new Paragraph("Condutor: " + locacao.Condutor.Nome)).SetBorder(Border.NO_BORDER));
                    table.AddCell(new Cell().Add(new Paragraph("Categoria: " + locacao.Categoria.Nome)).SetBorder(Border.NO_BORDER));
                    table.AddCell(new Cell().Add(new Paragraph("Veículo: " + locacao.Veiculo.Placa)).SetBorder(Border.NO_BORDER));
                    table.AddCell(new Cell().Add(new Paragraph("Plano: " + locacao.NomeDoPlano)).SetBorder(Border.NO_BORDER));
                    table.AddCell(new Cell().Add(new Paragraph("Data inicio: " + locacao.DataInicio)).SetBorder(Border.NO_BORDER));
                    table.AddCell(new Cell().Add(new Paragraph("Data final: " + locacao.DataFinalPrevista)).SetBorder(Border.NO_BORDER));
                    
                    //adiciona a tabela criada, já com os dados, no documento
                    document.Add(table);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
