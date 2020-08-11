using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using System.Data;

namespace CROUDClientesWebServices
{
    /// <summary>
    /// Summary description for CROUDClientesService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CROUDClientesService : System.Web.Services.WebService
    {

        //[WebMethod(Description = "Permite inicar sesion")]
        //public string IniciarSesion(string usuario, string contraseña, string nombreMaquina)
        //{
        //    ClientsBLL clientsBLL = new ClientsBLL();

        //    return clientsBLL.IniciarSesion(usuario, contraseña, nombreMaquina);
        //}

        [WebMethod(Description="Inserta un nuevo usuario.")]
        public int InsertarCliente(string nombre, string primerApellido, string segundoApellido)
        {
            ClientsBLL clientsBLL = new ClientsBLL();

            return clientsBLL.InsertClient(nombre, primerApellido, segundoApellido);
        }

        [WebMethod(Description ="Elimina un cliente mediante su ID. Es necesario conocer el identificador del cliente previamente.")]
        public string EliminarCliente(int id)
        {
            ClientsBLL clientsBLL = new ClientsBLL();

            clientsBLL.DeleteClientById(id);


            return "Se ha eliminado el cliente";
        }

        [WebMethod(Description = "Muestra todos los usuarios dados de alta.")]
        public DataTable MostrarClientes()
        {
            ClientsBLL clientsBLL = new ClientsBLL();

            DataTable tabla = new DataTable();
            tabla = clientsBLL.GetAllClients(); 


            return tabla;

           
        }

        [WebMethod(Description = "Muestra todos los usuarios dados de alta.")]
        public DataTable AztualizarUsuario(string id, string nombre, string primerApellido, string segundoApellido, DateTime fechaAfiliacion)
        {
            ClientsBLL clientsBLL = new ClientsBLL();

            return clientsBLL.UpdateUser(id, nombre, primerApellido, segundoApellido, fechaAfiliacion);
        }

        [WebMethod(Description = "Filtra los clientes por nombre y fecha de afiliación,")]
        public DataTable FiltrarClientes(string nombre, DateTime fechaInicio, DateTime fechaFinal)
        {
            ClientsBLL clientsBLL = new ClientsBLL();

            DataTable tabla = new DataTable();
            tabla = clientsBLL.GetClientByParameter(nombre, fechaInicio, fechaFinal);

            return tabla;
        }

    }
}
