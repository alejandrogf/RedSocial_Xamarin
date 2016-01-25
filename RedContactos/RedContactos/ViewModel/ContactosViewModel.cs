using MvvmLibrary.Factorias;
using RedContactos.Service;

namespace RedContactos.ViewModel
{
    public class ContactosViewModel:GeneralViewModel
    {
        public ContactosViewModel(INavigator navigator, IServicioMovil servicio) : base(navigator, servicio)
        {
        }
    }
}