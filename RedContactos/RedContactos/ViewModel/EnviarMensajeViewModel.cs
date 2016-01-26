using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;

namespace RedContactos.ViewModel
{
    public class EnviarMensajeViewModel:GeneralViewModel
    {
        public EnviarMensajeViewModel(INavigator navigator, IServicioMovil servicio, Session session) : 
            base(navigator, servicio, session)
        {
        }
    }
}
