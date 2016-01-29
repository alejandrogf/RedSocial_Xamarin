using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using ContactosModel.Model;
using RedContactos.ViewModel.Contactos;
using Xamarin.Forms;

namespace RedContactos.Models
{
    public class NoAmigosModel
    {
        public ICommand CmdAdd { get; set; }
        public ContactoModel ContactoModel { get; set; }
        public IComponentContext ComponentContext { get; set; }

        public NoAmigosModel()
        {
            CmdAdd = new Command(RunComandoAdd);
        }

        private async void RunComandoAdd()
        {
            var vm = ComponentContext.Resolve<AddContactosViewModel>();
            var d = await vm._servicio.AddContacto(ContactoModel);
            if (d!=null)
            {
                vm.Amigos.Add(ContactoModel);
                vm.NoAmigos.Remove(this);
                await vm._page.MostrarAlerta("Exito", "Contacto añadido", "OK");
            }
            else
            {
                await vm._page.MostrarAlerta("Error", "Contacto NO añadido", "OK");
            }

        }

    }
}
