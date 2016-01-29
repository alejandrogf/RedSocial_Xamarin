using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Models;
using RedContactos.Service;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel.Contactos
{
    public class AddContactosViewModel:GeneralViewModel
    {
        private ObservableCollection<ContactoModel> _amigos;
        private ObservableCollection<NoAmigosModel> _noAmigos;

        public ObservableCollection<ContactoModel> Amigos
        {
            get { return _amigos; }
            set { SetProperty(ref _amigos, value); }
        }

        public ObservableCollection<NoAmigosModel> NoAmigos
        {
            get { return _noAmigos; }
            set { SetProperty(ref _noAmigos, value); }
        }
        //public ICommand cmdAdd { get; set; }

        public AddContactosViewModel(INavigator navigator, IServicioMovil servicio, Session session, IPage page) :
            base(navigator, servicio, session, page)
        {
           // cmdAdd=new Command(addContacto);
        }

        //private async void addContacto(object obj)
        //{
        //    var id = int.Parse(obj.ToString());
        //    var c = NoAmigos.FirstOrDefault(o => o.idOrigen == id);
        //    if (c!=null)
        //    {
        //        var r = await _page.MostrarAlerta("Confirmacion", 
        //                                          "Estas seguro de añadir a "+c.nombreCompleto,
        //                                          "Si", 
        //                                          "No");
        //        if (r)
        //        {
        //            var ok = await _servicio.AddContacto(c);
        //            if (ok!=null)
        //            {
        //                await _page.MostrarAlerta("Exito", "Contacto añadido", "Aceptar");
        //                Amigos.Add(c);
        //                NoAmigos.Remove(c);
        //            }
        //            else
        //            {
        //                await _page.MostrarAlerta("Error", "Contacto NO añadido", "Aceptar");
        //            }
        //        }
        //    }
        //}

    }
}