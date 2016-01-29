using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;

namespace RedContactos.ViewModel.Mensajes
{
    public class DetalleMensajeViewModel:GeneralViewModel
    {
        private MensajeModel _mensaje;

        public MensajeModel Mensaje
        {
            get { return _mensaje; }
            set
            {
                SetProperty(ref _mensaje, value);
            }
        }

        public DetalleMensajeViewModel(INavigator navigator, IServicioMovil servicio, Session session, IPage page) :
            base(navigator, servicio, session, page)
        {
        }
    }
}
