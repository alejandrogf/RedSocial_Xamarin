using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;

namespace RedContactos.ViewModel.Mensajes
{
    public class MisMensajesViewModel:GeneralViewModel
    {
        private ObservableCollection<MensajeModel> _mensajes;

        private MensajeModel _mensajeSeleccionado;

        public MisMensajesViewModel(INavigator navigator, IServicioMovil servicio, Session session, IPage page) :
            base(navigator, servicio, session, page)
        {
        }

        public ObservableCollection<MensajeModel> Mensajes
        {
            get { return _mensajes; }
            set { SetProperty(ref _mensajes, value);}
        }

        public MensajeModel MensajeSeleccionado
        {
            get { return _mensajeSeleccionado; }
            set
            {
                SetProperty(ref _mensajeSeleccionado, value);
                if (value!=null)
                {
                    
                    /*Así se llama automáticamente a ver el detalle
                    Si no, habría que tener un botón que pulsar después de seleccionar un mensaje
                    Y como al volver se ha pasado antes por poner mensajeseleccionado==null
                    no vuelve a lanzar este evento*/
                    VerDetalleMensaje();
                }
                
            }
        }

        private async void VerDetalleMensaje()
        {
            if (_mensajeSeleccionado!=null)
            {
                if (!_mensajeSeleccionado.Leido)
                {
                    _mensajeSeleccionado.Leido = true;
                    await _servicio.UpdateMensaje(_mensajeSeleccionado);
                }

                await _navigator.PushAsync<DetalleMensajeViewModel>(viewmodel =>
                {
                    viewmodel.Mensaje = _mensajeSeleccionado;
                    viewmodel.Titulo = _mensajeSeleccionado.Asunto;
                });
                //Para al volver no haya ninguno seleccionado y poder elegir otro.
                MensajeSeleccionado = null;
            }
        }
    }
}
