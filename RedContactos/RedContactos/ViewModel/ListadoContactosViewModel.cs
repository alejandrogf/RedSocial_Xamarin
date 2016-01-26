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
    class ListadoContactosViewModel:GeneralViewModel
    {
        public ListadoContactosViewModel(INavigator navigator, IServicioMovil servicio, Session session) : 
            base(navigator, servicio, session)
        {
        }
    }
}
