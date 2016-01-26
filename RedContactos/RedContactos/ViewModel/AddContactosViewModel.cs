using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;

namespace RedContactos.ViewModel
{
    public class AddContactosViewModel:GeneralViewModel
    {
        public AddContactosViewModel(INavigator navigator, IServicioMovil servicio, Session session) : 
            base(navigator, servicio, session)
        {
        }
    }
}