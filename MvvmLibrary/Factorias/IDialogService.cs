using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLibrary.Factorias
{
    public interface IDialogService
    {
        //Informativo
        Task MostrarAlerta(string titulo, string msg, string cancelar);
        //Para dar la opción de aceptar o cancelar, devuelve un bool
        Task<bool> MostrarAlerta(string titulo, string msg, string aceptar, string cancelar);
        //Para mostrar un listado de acciones a realizar con el elemento seleccionado
        Task<string> MostrarActionSheet(string titulo, string cancelar, string destruccion,
            params string[] botones);
    }
}
