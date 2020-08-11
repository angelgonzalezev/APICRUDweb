using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ClientsDAL
    {
        //DateTime daytime = new DateTime();

        private string connectionString;
        private SqlConnection conn;
        DateTime daytime = DateTime.Now;

        public ClientsDAL()
        {
            connectionString = Connection.getConnectionString();
        }

        public int InsertClient(string nombre, string primerApellido, string segundoApellido)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    int affectedRows;
                    SqlCommand cmdInsert =
                        new SqlCommand("dbo.spInsertClient", conn);
                    cmdInsert.CommandType = CommandType.StoredProcedure;
                    cmdInsert.Parameters.AddWithValue("@Name", nombre);
                    cmdInsert.Parameters.AddWithValue("@F_Surname", primerApellido);
                    cmdInsert.Parameters.AddWithValue("@S_Surname", segundoApellido);
                    cmdInsert.Parameters.AddWithValue("@DATE", daytime);

                    conn.Open();

                    affectedRows = cmdInsert.ExecuteNonQuery();
                    //conn.Close();

                    return affectedRows;
                }
            }
            catch
            {
                throw;
            }
        }

        #region Código Eliminado
        /*
                public bool ComprobarUsuario(string usuario, string contraseña, string nombreMaquina)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            int affectedRows;
                            SqlCommand cmdInsert =
                                new SqlCommand("dbo.spComprobarUsuario", conn);
                            cmdInsert.CommandType = CommandType.StoredProcedure;
                            cmdInsert.Parameters.AddWithValue("@Nombre", nombre);
                            cmdInsert.Parameters.AddWithValue("@F_Surname", primerApellido);
                            cmdInsert.Parameters.AddWithValue("@S_Surname", segundoApellido);
                            cmdInsert.Parameters.AddWithValue("@DATE", daytime);

                            conn.Open();

                            affectedRows = cmdInsert.ExecuteNonQuery();
                            //conn.Close();

                            return affectedRows;
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
        */
        #endregion


        public int DeleteClientById(int idCliente)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    int affectedRows;
                    SqlCommand cmdInsert =
                        new SqlCommand("dbo.spDeleteClientById", conn);
                    cmdInsert.CommandType = CommandType.StoredProcedure;
                    cmdInsert.Parameters.AddWithValue("@id", idCliente);

                    conn.Open();

                    affectedRows = cmdInsert.ExecuteNonQuery();
                    //conn.Close();

                    return affectedRows;
                }
            }
            catch
            {
                throw;
            }
        }

        public DataTable SearchAllClients()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataTable data = new DataTable("TablaClientes");

                SqlCommand cmdShowAllClients =
                    new SqlCommand("dbo.spShowAllClients", conn);
                cmdShowAllClients.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataReader RegisterData = cmdShowAllClients.ExecuteReader();

                data.Load(RegisterData);

                return data;
            }
        }

        public DataTable UpdateUser(string id, string name, string fSurname, string sSurname, DateTime fechaAfiliacion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataTable data = new DataTable("TablaClientes");

                SqlCommand cmdUpdateUser =
                    new SqlCommand("dbo.spUpdateUser", conn);
                cmdUpdateUser.CommandType = CommandType.StoredProcedure;
                cmdUpdateUser.Parameters.AddWithValue("@id", id);
                cmdUpdateUser.Parameters.AddWithValue("@name", name);
                cmdUpdateUser.Parameters.AddWithValue("@fSurname", fSurname);
                cmdUpdateUser.Parameters.AddWithValue("@sSurname", sSurname);
                cmdUpdateUser.Parameters.AddWithValue("@FechaAfiliacion", fechaAfiliacion);
                conn.Open();

                SqlDataReader RegisterData = cmdUpdateUser.ExecuteReader();

                data.Load(RegisterData);

                return data;
            }
        }

        public DataTable GetClientByParameter(string name, DateTime dateInicioBuscar, DateTime dateFinalBuscar)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataTable data = new DataTable("TablaClientes");
                try
                {
      
                    SqlCommand cmdGetClientByParameter =
                        new SqlCommand("dbo.spGetClientByParameter", conn);
                    cmdGetClientByParameter.CommandType = CommandType.StoredProcedure;
                    cmdGetClientByParameter.Parameters.AddWithValue("@name", name);
                    cmdGetClientByParameter.Parameters.AddWithValue("@fechaInicio", dateInicioBuscar);
                    cmdGetClientByParameter.Parameters.AddWithValue("@fechaFinal", dateFinalBuscar);

                    conn.Open();

                    SqlDataReader RegisterData = cmdGetClientByParameter.ExecuteReader();

                    data.Load(RegisterData);

                    return data;
                }
                catch
                {
                    return data;
                }

            }
        }



    }
}
