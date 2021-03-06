﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactosModel.Model;
using RedContactos.Util;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace RedContactos.Service
{
    public class ServicioDatos:IServicioMovil
    {
        private RestClient client;

        public ServicioDatos()
        {
            client=new RestClient(Cadenas.Url);
        }

        #region USUARIO

        public async Task<UsuarioModel> ValidarUsuario(UsuarioModel usuario)
        {
            var request = new RestRequest("Usuario");

            request.Method = Method.GET;
            request.AddQueryParameter("login", usuario.Login);
            request.AddQueryParameter("password", usuario.Password);

            var response = await client.Execute<UsuarioModel>(request);
            if (response.IsSuccess)
                return response.Data;
            return null;

        }

        public async Task<bool> UsuarioNuevo(string login)
        {
            var request = new RestRequest("Usuario");

            request.Method = Method.GET;
            request.AddQueryParameter("login", login);


            var response = await client.Execute<bool>(request);
            if (response.IsSuccess)
                return response.Data;
            return false;
        }

        public async Task<UsuarioModel> AddUsuario(UsuarioModel usuario)
        {
            var request = new RestRequest("Usuario")
            {
                Method = Method.POST
            };
            request.AddJsonBody(usuario);
            var response = await client.Execute<UsuarioModel>(request);
            if (response.IsSuccess)
                return response.Data;
            return null;
        }

        #endregion


        #region CONTACTO

        public async Task<ContactoModel> AddContacto(ContactoModel contacto)
        {
            var request = new RestRequest("Contacto")
            {
                Method = Method.POST
            };
            request.AddJsonBody(contacto);
            var response = await client.Execute<ContactoModel>(request);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            return null;
        }

        public async Task<List<ContactoModel>> GetContactos(bool actuales, int id)
        {
            var request = new RestRequest("Contacto")
            {
                Method = Method.GET
            };

            request.AddQueryParameter("id", id);
            request.AddQueryParameter("amigos", actuales);

            var response = await client.Execute<List<ContactoModel>>(request);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            return null;
        }

        public async Task DelContacto(ContactoModel contacto)
        {
            var request=new RestRequest("Contacto")
            {
                Method = Method.DELETE
            };
            request.AddJsonBody(contacto);
            await client.Execute(request);
        }

        #endregion


        #region MENSAJE

        public async Task<List<MensajeModel>> GetMensaje(int id)
        {
            var request = new RestRequest("Mensaje")
            {
                Method = Method.GET
            };

            request.AddQueryParameter("id", id);
            
            var response = await client.Execute<List<MensajeModel>>(request);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            return null;
        }

        public async Task<MensajeModel> AddMensaje(MensajeModel mensaje)
        {
            var request = new RestRequest("Mensaje")
            {
                Method = Method.POST
            };
            request.AddJsonBody(mensaje);
            var response = await client.Execute<MensajeModel>(request);
            if (response.IsSuccess)
            {
                return response.Data;
            }
            return null;
        }

        public async Task UpdateMensaje(MensajeModel mensaje)
        {
            var request = new RestRequest("Mensaje")
            {
                Method = Method.PUT
            };
            request.AddJsonBody(mensaje);
            await client.Execute<MensajeModel>(request);
        }

        #endregion

    }
}