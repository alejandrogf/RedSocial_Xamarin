﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedContactos.Service
{
    public interface IServicioFicheros
    {
        void GuardarTexto(String texto, String fichero);
        String RecuperarTexto(String fichero);
    }
}
