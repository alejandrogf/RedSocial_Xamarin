using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using RedContactos.ViewModel.Contactos;
using RedContactos.ViewModel.Mensajes;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class PrincipalViewModel:GeneralViewModel
    {

        //La carga de la lista de contactos de un usuario la hacemos en la pantalla principal, antes
        //  de llamar a la vista del listado en sí

        //Las listas en mvvm son siempre observablecollection, porque así se refrescan automáticamente
        private ObservableCollection<ContactoModel> _contactos;

        public ObservableCollection<ContactoModel> Contactos
        {
            get { return _contactos; }

            set { SetProperty(ref _contactos, value); }
        }

        public string TxtBtnContacto { get { return "Contactos"; } }
        public string TxtBtnMensaje { get { return "Mensajes"; } }

        public ICommand cmdVerContactos { get; set; }
        public ICommand cmdEnviarMensaje { get; set; }

        public PrincipalViewModel(INavigator navigator, IServicioMovil servicio, Session session, IPage page) :
            base(navigator, servicio, session, page)
        {
            cmdVerContactos = new Command(VerContactos);
            cmdEnviarMensaje = new Command(EnviarMensaje);

        }

        private async void VerContactos()
        {
            IsBusy = true;
            var yo = Session["usuario"] as UsuarioModel;
            var amigos = await _servicio.GetContactos(true, yo.id);
            var noAmigos = await _servicio.GetContactos(false, yo.id);
            await _navigator.PushAsync<ContactosViewModel>(viewModel =>
            {
                viewModel.Titulo = "Mis Contactos";
                viewModel.Amigos=new ObservableCollection<ContactoModel>(amigos);
                viewModel.NoAmigos = new ObservableCollection<ContactoModel>(noAmigos);
            });
        }

        private async void EnviarMensaje()
        {
            IsBusy = true;
            var yo = Session["usuario"] as UsuarioModel;
            var data = await _servicio.GetMensaje(yo.id);
            await _navigator.PushAsync<MisMensajesViewModel>(viewModel =>
            {
                viewModel.Titulo = "Mis Mensajes";
                viewModel.Mensajes = new ObservableCollection<MensajeModel>(data);

            });
        }
   }
}