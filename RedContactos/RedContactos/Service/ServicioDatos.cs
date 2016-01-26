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
            request.AddQueryParameter("login", usuario.login);
            request.AddQueryParameter("password", usuario.password);

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


        public Task AddContacto(UsuarioModel usuario)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ContactoModel>> GetContactos(UsuarioModel usuario, ContactoModel contacto)
        {
            throw new System.NotImplementedException();
        }

        public Task SendMensaje(UsuarioModel usuario, ContactoModel contacto, MensajeModel mensaje)
        {
            throw new System.NotImplementedException();
        }
    }
}