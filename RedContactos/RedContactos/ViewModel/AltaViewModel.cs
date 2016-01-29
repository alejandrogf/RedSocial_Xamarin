using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class AltaViewModel:GeneralViewModel
    {
        private UsuarioModel _usuario;
        public UsuarioModel Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        public ICommand cmdAlta { get; set; }
        public AltaViewModel(INavigator navigator, IServicioMovil servicio, Session session, IPage page) :
            base(navigator, servicio, session, page)
        {
            _usuario=new UsuarioModel();
            cmdAlta=new Command(RunAlta);
        }

        private async void RunAlta()
        {
            try
            {
                IsBusy = true;
                var noesta = await _servicio.UsuarioNuevo(Usuario.Login);
                if (noesta)
                {
                    var r = await _servicio.AddUsuario(Usuario);
                    if (r != null)
                    {
                        Session["usuario"] = r;//Guardo el usuario
                        await _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                        {
                            Titulo = "Contacteitor";
                        });
                    }
                    else
                    {
                        await _page.MostrarAlerta("Error", "Error al registrarse", "Aceptar");
                    }
                }
                else
                {
                    await _page.MostrarAlerta("Error", "Usuario ya registrado", "Aceptar");
                }
            }
            finally
            {
                IsBusy = false;
            }

        }
        
    }
}