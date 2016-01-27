using MvvmLibrary.Factorias;
using MvvmLibrary.ViewModel.Base;
using RedContactos.Service;
using RedContactos.Util;

namespace RedContactos.ViewModel
{
    public class GeneralViewModel:ViewModelBase
    {
        //Todos los servicios que se quieren que estén en todas las pantallas es mejor
        //ponerlas aquí para no tener que repetirlas por todas partes

        //De esta forma ya tengo un objeto sesión en la memoria del dispositivo, ya que se construye
        //Aquí que es de el que heredan todos los viewmodel

        protected INavigator _navigator;
        protected IServicioMovil _servicio;
        protected Session Session { get; set; }
        protected IPage _page;

        public GeneralViewModel(INavigator navigator, IServicioMovil servicio, Session session, IPage page)
        {
            _navigator = navigator;
            _servicio = servicio;
            Session = session;
            _page = page;
        }
    }
}