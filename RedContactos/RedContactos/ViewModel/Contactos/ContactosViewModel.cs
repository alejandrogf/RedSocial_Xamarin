using System.Collections.ObjectModel;
using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel.Contactos
{
    class ContactosViewModel:GeneralViewModel
    {

        private ObservableCollection<ContactoModel> _amigos;
        private ObservableCollection<NoAmigosModel> _noAmigos;
        private ContactoModel _contactoSeleccionado;

        public ObservableCollection<ContactoModel> Amigos
        {
            get { return _amigos; }
            set { SetProperty(ref _amigos, value); }
        }

        public ObservableCollection<ContactoModel> NoAmigos
        {
            get { return _noAmigos; }
            set { SetProperty(ref _noAmigos, value); }
        }

        public ContactoModel ContactoSeleccionado
        {
            get { return _contactoSeleccionado; }
            set
            {
                SetProperty(ref _contactoSeleccionado, value);
                if (value!=null)
                {
                    RunNuevoMensaje();
                }
                
            }
        }

        //public ICommand cmdNuevo { get; set; }

        public ContactosViewModel(INavigator navigator, IServicioMovil servicio, Session session, IPage page) :
            base(navigator, servicio, session, page)
        {
            //cmdNuevo = new Command(RunNuevoContacto);

        }

        //private async void RunNuevoContacto()
        //{
        //    await _navigator.PushAsync<AddContactosViewModel>(viewModel =>
        //    {
        //        viewModel.Amigos = Amigos;
        //        viewModel.NoAmigos = NoAmigos;
        //    });
        //}

        private async void RunNuevoMensaje()
        {
            await _navigator.PushAsync<EnviarMensajeViewModel>(viewModel =>
            {
                viewModel.Contacto = ContactoSeleccionado;
                viewModel.Mensaje=new MensajeModel();
                
            });
        }


    }
}
