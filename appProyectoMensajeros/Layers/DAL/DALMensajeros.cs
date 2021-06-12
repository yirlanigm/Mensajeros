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
    class DALMensajeros : IDALMensajeros
    {
        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");

        Usuario _Usuario = new Usuario();
        public DALMensajeros()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }
        public bool DeleteMensajero(string pId)
        {
            bool retorno = false;
            double rows = 0d;
            SqlCommand command = new SqlCommand();
            try
            {
                /// string sql = @"Delete from  Cliente Where (IdCliente = @IdCliente) ";
                string sql = "usp_DELETE_Mensajero_ByID";
                command.Parameters.AddWithValue("@idMensajero", pId);
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

        public List<Mensajero> GetAllMensajero()
        {
            DataSet ds = null;
            List<Mensajero> lista = new List<Mensajero>();
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @" select * from  Mensajero WITH (NOLOCK) ";
                /// string sql = "usp_SELECT_Cliente_All";
                command.CommandText = sql;
                // command.CommandType = CommandType.StoredProcedure;

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
                        Mensajero oMensajero = new Mensajero();
                        oMensajero.idMensajero = dr["idMensajero"].ToString();
                        oMensajero.nombre = dr["Nombre"].ToString();
                        oMensajero.Apellido1 = dr["Apellido1"].ToString();
                        oMensajero.Apellido2 = dr["Apellido2"].ToString();
                        oMensajero.Telefono = dr["Telefono"].ToString();
                        oMensajero.sexo = (bool)dr["Sexo"];
                        oMensajero.Fotografia = (byte[])dr["Fotografia"];
                        oMensajero.Email = dr["Email"].ToString();
                        


                        lista.Add(oMensajero);
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

        public Mensajero GetMensajeroById(string pId)
        {
            DataSet ds = null;
            Mensajero oMensajero = null;
            SqlCommand command = new SqlCommand();

            string sql = @" select * from  Mensajero Where idMensajero = @idMensajero ";

            try
            {
                command.Parameters.AddWithValue("@idMensajero", pId);
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
                        oMensajero = new Mensajero();
                        oMensajero.idMensajero = dr["idMensajero"].ToString();
                        oMensajero.nombre = dr["Nombre"].ToString();
                        oMensajero.Apellido1 = dr["Apellido1"].ToString();
                        oMensajero.Apellido2 = dr["Apellido2"].ToString();
                        oMensajero.Telefono = dr["Telefono"].ToString();
                        oMensajero.sexo = (bool)dr["Sexo"];
                        oMensajero.Fotografia = (byte[])dr["Fotografia"];
                        oMensajero.Email = dr["Email"].ToString();
                        //oMensajero.IdRol = (int)dr["IdRol"];


                    }
                }

                return oMensajero;
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

        public List<Mensajero> GetMensajerosByFilter(string pDescripcion)
        {
            DataSet ds = null;
            List<Mensajero> lista = new List<Mensajero>();
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @" select * from  Mensajero WITH (NOLOCK) Where Nombre+Apellido1+Apellido2 like @filtro ";
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
                        Mensajero oMensajero = new Mensajero();
                        oMensajero.idMensajero = dr["idMensajero"].ToString();
                        oMensajero.nombre = dr["Nombre"].ToString();
                        oMensajero.Apellido1 = dr["Apellido1"].ToString();
                        oMensajero.Apellido2 = dr["Apellido2"].ToString();
                        oMensajero.Telefono = dr["Telefono"].ToString();
                        oMensajero.sexo = (bool)dr["Sexo"];
                        oMensajero.Fotografia = (byte[])dr["Fotografia"];
                        oMensajero.Email = dr["Email"].ToString();
                        //oMensajero.IdRol = (int)dr["IdRol"];


                        lista.Add(oMensajero);
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

        public Mensajero SaveMensajero(Mensajero pMensajero)
        {
            Mensajero oMensajero = null;
            SqlCommand cmd = new SqlCommand();
            // Insert
            //string sql = @"Insert into Mensajero(idMensajero,Nombre,Apellido1,Apellido2,Sexo,Fotografia,Email) values (@idMensajero,@Nombre,@Apellido1,@Apellido2,@Sexo,@Fotografia,@Email)";

            double rows = 0;
            try
            {
                cmd.Parameters.AddWithValue("@idMensajero", pMensajero.idMensajero);
                cmd.Parameters.AddWithValue("@Nombre", pMensajero.nombre);
                cmd.Parameters.AddWithValue("@Apellido1", pMensajero.Apellido1);
                cmd.Parameters.AddWithValue("@Apellido2", pMensajero.Apellido2);
                cmd.Parameters.AddWithValue("@Telefono", pMensajero.Telefono);
                cmd.Parameters.AddWithValue("@Sexo",(bool)pMensajero.sexo);
                cmd.Parameters.AddWithValue("@Fotografia", pMensajero.Fotografia.ToArray());
                cmd.Parameters.AddWithValue("@Email", pMensajero.Email);
                //cmd.Parameters.AddWithValue("@IdRol", pMensajero.IdRol);
                cmd.CommandText = "usp_INSERT_Mensajero";
                cmd.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(cmd, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo
                if (rows > 0)
                    oMensajero = this.GetMensajeroById(pMensajero.idMensajero);

                return oMensajero;

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

        public Mensajero UpdateMensajero(Mensajero pMensajero)
        {
            Mensajero oMensajero = null;
            SqlCommand cmd = new SqlCommand();
            // Insert
            //string sql = @"Insert into Cliente(IdCliente,Nombre,Apellido1,Apellido2,Sexo,FechaNacimiento,IdProvincia) values (@IdCliente,@Nombre,@Apellido1,@Apellido2,@Sexo,@FechaNacimiento,@IdProvincia)";
            string sql = "usp_UPDATE_Mensajero";
            double rows = 0;
            try
            {
                cmd.Parameters.AddWithValue("@idMensajero", pMensajero.idMensajero);
                cmd.Parameters.AddWithValue("@Nombre", pMensajero.nombre);
                cmd.Parameters.AddWithValue("@Apellido1", pMensajero.Apellido1);
                cmd.Parameters.AddWithValue("@Apellido2", pMensajero.Apellido2);
                cmd.Parameters.AddWithValue("@Telefono", pMensajero.Telefono);
                cmd.Parameters.AddWithValue("@Sexo", pMensajero.sexo);
                cmd.Parameters.AddWithValue("@Fotografia", pMensajero.Fotografia.ToArray());
                cmd.Parameters.AddWithValue("@Email", pMensajero.Email);
                //cmd.Parameters.AddWithValue("@IdRol", pMensajero.IdRol);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(cmd, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo
                if (rows > 0)
                    oMensajero = this.GetMensajeroById(pMensajero.idMensajero);

                return oMensajero;

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
