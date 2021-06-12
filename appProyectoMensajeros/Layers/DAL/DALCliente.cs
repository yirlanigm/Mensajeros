using appProyectoMensajeros.Util;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.Mensajeros.Layers.Entities;
using UTN.Winform.Mensajeros.Layers.Interfaces;
using UTN.Winform.Mensajeros.Properties;

namespace UTN.Winform.Mensajeros.Layers.DAL
{
    class DALCliente : IDALCliente
    {
        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");

        Usuario _Usuario = new Usuario();
        public DALCliente()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }
        public bool DeleteCliente(string pId)
        {
            bool retorno = false;
            double rows = 0d;
            SqlCommand command = new SqlCommand();
            try
            {
                /// string sql = @"Delete from  Cliente Where (IdCliente = @IdCliente) ";
                string sql = "usp_DELETE_Cliente_ByID";
                command.Parameters.AddWithValue("@IdCliente", pId);
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo
                if (rows > 0)
                    retorno = true;

                return retorno;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public List<Cliente> GetAllCliente()
        {
            DataSet ds = null;
            List<Cliente> lista = new List<Cliente>();
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @" select * from  Cliente WITH (NOLOCK) ";
                /// string sql = "usp_SELECT_Cliente_All";
                command.CommandText = sql;
                // command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login,_Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                // Si devolvió filas
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Iterar en todas las filas y Mapearlas
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Cliente oCliente = new Cliente();
                        oCliente.IdCliente = dr["IdCliente"].ToString();
                        oCliente.Nombre = dr["Nombre"].ToString();
                        oCliente.Apellido1 = dr["Apellido1"].ToString();
                        oCliente.Apellido2 = dr["Apellido2"].ToString();
                        oCliente.Provincia = (int)dr["Provincia"];
                        oCliente.Direccion = dr["Direccion"].ToString();
                        oCliente.Telefono = dr["Telefono"].ToString();


                        lista.Add(oCliente);
                    }
                }

                return lista;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public List<Cliente> GetClienteByFilter(string pDescripcion)
        {
            
            DataSet ds = null;
            List<Cliente> lista = new List<Cliente>();
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @" select * from  Cliente WITH (NOLOCK) Where Nombre+Apellido1+Apellido2 like @filtro ";
                command.Parameters.AddWithValue("@filtro", pDescripcion);
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                // Si devolvió filas
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Iterar en todas las filas y Mapearlas
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Cliente oCliente = new Cliente();
                        oCliente.IdCliente = dr["IdCliente"].ToString();
                        oCliente.Nombre = dr["Nombre"].ToString();
                        oCliente.Apellido1 = dr["Apellido1"].ToString();
                        oCliente.Apellido2 = dr["Apellido2"].ToString();
                        oCliente.Telefono = dr["Telefono"].ToString();
                        oCliente.Provincia = (int)dr["Provincia"];
                        oCliente.Direccion = dr["Direccion"].ToString();

                        lista.Add(oCliente);
                    }
                }

                return lista;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);
                msg.AppendFormat("SQL            {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Cliente GetClienteById(string pIdCliente)
        {
            DataSet ds = null;
            Cliente oCliente = null;
            SqlCommand command = new SqlCommand();

            string sql = @" select * from  Cliente Where IdCliente = @IdCliente ";

            try
            {
                command.Parameters.AddWithValue("@IdCliente", pIdCliente);
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                // Si devolvió filas
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Iterar en todas las filas y Mapearlas
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        
                        oCliente.IdCliente = dr["IdCliente"].ToString();
                        oCliente.Nombre = dr["Nombre"].ToString();
                        oCliente.Apellido1 = dr["Apellido1"].ToString();
                        oCliente.Apellido2 = dr["Apellido2"].ToString();
                        oCliente.Telefono = dr["Telefono"].ToString();
                        oCliente.Provincia = (int)dr["Provincia"];
                        oCliente.Direccion = dr["Direccion"].ToString();


                    }
                }

                return oCliente;
            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", command.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Cliente SaveCliente(Cliente pCliente)
        {
            Cliente oCliente = null;
            SqlCommand cmd = new SqlCommand();
            // Insert
            //string sql = @"Insert into Cliente(IdCliente,Nombre,Apellido1,Apellido2,Sexo,FechaNacimiento,IdProvincia) values (@IdCliente,@Nombre,@Apellido1,@Apellido2,@Sexo,@FechaNacimiento,@IdProvincia)";
            
            double rows = 0;
            try
            {
                cmd.Parameters.AddWithValue("@idCliente", pCliente.IdCliente);
                cmd.Parameters.AddWithValue("@Nombre", pCliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido1", pCliente.Apellido1);
                cmd.Parameters.AddWithValue("@Apellido2", pCliente.Apellido2);
                cmd.Parameters.AddWithValue("@Telefono", pCliente.Telefono);
                cmd.Parameters.AddWithValue("@Provincia", pCliente.Provincia);
                cmd.Parameters.AddWithValue("@Direccion", pCliente.Direccion);
                cmd.CommandText = "usp_INSERT_Cliente";
                cmd.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(cmd, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo
                if (rows > 0)
                    oCliente = this.GetClienteById(pCliente.IdCliente);

                return oCliente;

            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", cmd.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Cliente UpdateCliente(Cliente pCliente)
        {
            Cliente oCliente = null;
            SqlCommand cmd = new SqlCommand();
            // Insert
            //string sql = @"Insert into Cliente(IdCliente,Nombre,Apellido1,Apellido2,Sexo,FechaNacimiento,IdProvincia) values (@IdCliente,@Nombre,@Apellido1,@Apellido2,@Sexo,@FechaNacimiento,@IdProvincia)";
            string sql = "usp_UPDATE_Cliente";
            double rows = 0;
            try
            {
                cmd.Parameters.AddWithValue("@IdCliente", pCliente.IdCliente);
                cmd.Parameters.AddWithValue("@Nombre", pCliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido1", pCliente.Apellido1);
                cmd.Parameters.AddWithValue("@Apellido2", pCliente.Apellido2);
                cmd.Parameters.AddWithValue("@Provincia", pCliente.Provincia);
                cmd.Parameters.AddWithValue("@Direccion", pCliente.Direccion);
                cmd.Parameters.AddWithValue("@Telefono",pCliente.Telefono);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(cmd, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo
                if (rows > 0)
                    oCliente = this.GetClienteById(pCliente.IdCliente);

                return oCliente;

            }
            catch (SqlException sqlError)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateSQLExceptionsErrorDetails(sqlError));
                msg.AppendFormat("SQL             {0}\n", cmd.CommandText);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }

        }
    }
    }