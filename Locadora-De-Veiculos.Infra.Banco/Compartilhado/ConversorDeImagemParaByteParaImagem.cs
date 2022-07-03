using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.IO;
using System.Drawing.Imaging;

namespace Locadora_De_Veiculos.Infra.Banco.Compartilhado
{
    public class ConversorDeImagemParaByteParaImagem
    {
        public static byte[] ConverteImagemParaByteArray(Image img)
        {
            MemoryStream ms = new MemoryStream();
            if(img != null)
                img.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static Image ConverteByteArrayParaImagem(byte[] pData)
        {
            try
            {
                ImageConverter imgConverter = new ImageConverter();
                return imgConverter.ConvertFrom(pData) as Image;
            }
            catch
            {
                return null;
            }
        }
    }
}
