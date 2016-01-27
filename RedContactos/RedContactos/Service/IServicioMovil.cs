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

        #region USUARIO

        Task<UsuarioModel> ValidarUsuario(UsuarioModel usuario);
        Task<bool> UsuarioNuevo(String login);
        Task<UsuarioModel> AddUsuario(UsuarioModel usuario);

        #endregion


        #region CONTACTO

        Task<ContactoModel> AddContacto(ContactoModel contacto);
        Task<List<ContactoModel>> GetContactos(bool actuales, int id);
        Task DelContacto(ContactoModel contacto);

        #endregion


        #region MENSAJE

        Task<List<MensajeModel>> GetMensaje(int id);
        Task<MensajeModel> AddMensaje(MensajeModel mensaje);
        Task UpdateMensaje(MensajeModel mensaje);

        #endregion





    }
}