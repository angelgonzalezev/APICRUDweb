using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BLL
{
    public class ClientsBLL
    {
        public int InsertClient(string nombre, string primerApellido, string segundoApellido)
        {
            int rowsAffected;

            ClientsDAL clientDAL = new ClientsDAL();

            rowsAffected = clientDAL.InsertClient(nombre, primerApellido, segundoApellido);

            return rowsAffected;
        }
        //public int IniciarSesion(string nombre, string contraseña, string nombreMaquina)
        //{

        //    ClientsDAL clientDAL = new ClientsDAL();


        //    return clientDAL.IniciarSesion(nombre, contraseña, nombreMaquina);
        //}

        public int DeleteClientById(int idCliente)
        {
            int rowsAffected;

            ClientsDAL clientDAL = new ClientsDAL();

            rowsAffected = clientDAL.DeleteClientById(idCliente);

            return rowsAffected;
        }

        public DataTable GetAllClients( )
        {
            ClientsDAL clientsDAL = new ClientsDAL();

            return clientsDAL.SearchAllClients();
        }

        public DataTable UpdateUser(string id, string nombre, string primerApellido, string segundoApellido, DateTime fechaAfiliacion)
        {
            ClientsDAL clientsDAL = new ClientsDAL();

            return clientsDAL.UpdateUser(id, nombre, primerApellido, segundoApellido, fechaAfiliacion);
        }

        public DataTable GetClientByParameter (string nombre, DateTime fechaInicial, DateTime fechaFinal)
        {
            ClientsDAL clientsDAL = new ClientsDAL();

            return clientsDAL.GetClientByParameter(nombre, fechaInicial, fechaFinal);
        }


    }
}
