using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLibrary.Factorias
{
    public class DialogService:IDialogService
    {
        //De esta forma sabemos en que página nos encontramos, ya que los dialogos dependen de donde estemos
        private readonly IPage _page;
        public string borrame { get; set; }

        public DialogService(IPage page)
        {
            _page = page;
        }

        public Task MostrarAlerta(string titulo, string msg, string cancelar)
        {
            return _page.MostrarAlerta(titulo, msg, cancelar);
        }

        public async Task<bool> MostrarAlerta(string titulo, string msg, string aceptar, string cancelar)
        {
            return await _page.MostrarAlerta(titulo, msg, aceptar, cancelar);
        }

        public async Task<string> MostrarActionSheet(string titulo, string cancelar, string destruccion, 
                                               params string[] botones)
        {
            return await _page.MostrarActionSheet(titulo, cancelar, destruccion, botones);
        }
    }
}
