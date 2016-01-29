using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using RedContactos.Service;
//windows phone es asincrono al completo
namespace RedContactos.WinPhone.Servicios
{
    public class ServicioFicheros:IServicioFicheros
    {
        public async void GuardarTexto(string texto, string fichero)
        {
            var carpeta = ApplicationData.Current.LocalFolder;
            var f = await carpeta.CreateFileAsync(fichero, CreationCollisionOption.ReplaceExisting);
            using (var stream=new StreamWriter(await f.OpenStreamForWriteAsync()))
            {
                stream.Write(texto);
            }

        }
        //Se hace un metodo intermedio porque devuelve un task de string, que IOS y Android no
        //recuperan, de esta forma se recupera aquí y luego se pasa al metodo final
        private async Task<String> CargarTexto(String fichero)
        {
            try
            {
                var carpeta = ApplicationData.Current.LocalFolder;
                var f = await carpeta.GetFileAsync(fichero);
                using (var stream = new StreamReader(f.Path))
                {
                    var txt = stream.ReadToEnd();
                    return txt;
                }
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public string RecuperarTexto(string fichero)
        {
            var data = CargarTexto(fichero);
            data.Wait();
            return data.Result;
        }
    }
}
