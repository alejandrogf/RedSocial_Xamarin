using System;
using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class LoginViewModel:GeneralViewModel
    {
        private UsuarioModel _usuario;
        public UsuarioModel Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }
        public ICommand CmdLogin { get; set; }
        public ICommand CmdAlta { get; set; }
        public LoginViewModel(INavigator navigator, IServicioMovil servicio, Session session) : 
            base(navigator, servicio, session)
        {
            _usuario=new UsuarioModel();
            CmdLogin=new Command(RunLogin);
            CmdAlta=new Command(RunAlta);
            Titulo = "Contacteitor";
        }

        private async void RunLogin()
        {
            try
            {
                IsBusy = true;
                var us=await _servicio.ValidarUsuario(Usuario);
                if (us != null)
                {
                    Session["usuario"] = us;//Guardo el usuario
                    await  _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                    {
                        viewModel.Titulo = "Principal";
                    });
                }
                else
                {
                    //TODo: Informar
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void RunAlta()
        {
            await _navigator.PushAsync<AltaViewModel>(viewModel =>
            {
                viewModel.Titulo = "Nuevo usuario";
            });
        }


       
    }
}