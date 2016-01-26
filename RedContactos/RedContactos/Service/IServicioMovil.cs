using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactosModel.Model;

namespace RedContactos.Service
{
    public interface IServicioMovil
    {
        //En tareas asyncronas siempre devuelven un objeto TASK. Si no se indica un tipo, devuelve un void.
        //Devuelven un TASK y un RESULT, el task puede ser de un tipo concreto o vacio (void)

        Task<UsuarioModel> ValidarUsuario(UsuarioModel usuario);
        Task<bool> UsuarioNuevo(String login);
        Task<UsuarioModel> AddUsuario(UsuarioModel usuario);

        Task AddContacto(UsuarioModel usuario);
        Task<List<ContactoModel>> GetContactos(UsuarioModel usuario, ContactoModel contacto);

        Task SendMensaje(UsuarioModel usuario, ContactoModel contacto, MensajeModel mensaje);

    }
}