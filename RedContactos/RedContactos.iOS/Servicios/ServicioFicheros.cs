using System;
using System.IO;
using RedContactos.iOS.Servicios;
using RedContactos.Service;
using Xamarin.Forms;
using Environment = System.Environment;

//dependency de xamarin forms
[assembly: Dependency(typeof(ServicioFicheros))]
namespace RedContactos.iOS.Servicios
{
    public class ServicioFicheros:IServicioFicheros
    {
        public void GuardarTexto(string texto, string fichero)
        {//Enviroment es de system, que es de android
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var rutafinal = Path.Combine(path, fichero);
            //writeall crea el fichero si no existe o se carga lo que tenia para poner lo nuevo
            //Como es para los setting de usuario, no se añade un dialogo de aviso de sobreescritura
            File.WriteAllText(rutafinal,texto);
        }

        public string RecuperarTexto(string fichero)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var rutafinal = Path.Combine(path, fichero);
            try
            {
                return File.ReadAllText(rutafinal);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}