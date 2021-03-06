﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel.Contactos
{
    public class EnviarMensajeViewModel : GeneralViewModel
    {
        private ContactoModel _contacto;
        private MensajeModel _mensaje;

        public ContactoModel Contacto
        {
            get { return _contacto; }
            set { SetProperty(ref _contacto, value); }
        }

        public MensajeModel Mensaje
        {
            get { return _mensaje; }
            set { SetProperty(ref _mensaje, value); }
        }

        public ICommand cmdEnviar { get; set; }

        public EnviarMensajeViewModel(INavigator navigator, IServicioMovil servicio, Session session, IPage page) :
            base(navigator, servicio, session, page)
        {
            cmdEnviar = new Command(RunEnviarMensaje);
        }

        private async void RunEnviarMensaje()
        {
            try
            {
                IsBusy = true;
                Mensaje.idOrigen = Contacto.idOrigen;
                Mensaje.Fecha = DateTime.Now;
                Mensaje.idDestino = Contacto.idDestino;
                Mensaje.Leido = false;
                var r = await _servicio.AddMensaje(Mensaje);
                if (r != null)
                {
                    await _page.MostrarAlerta("Exito", "Mensaje enviado", "Aceptar");
                }
                else
                {
                    await _page.MostrarAlerta("Error", "Mensaje no enviado", "Aceptar");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
