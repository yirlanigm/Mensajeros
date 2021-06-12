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
    class DALPrecioEnvios : IDALPrecioEnvios
    {
        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");
        Usuario _Usuario = new Usuario();

        public DALPrecioEnvios()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }
        public bool DeletePrecioEnvios(int pTipoEnvio)
        {
            bool retorno = false;
            double rows = 0d;
            SqlCommand command = new SqlCommand();
            try
            {
                
                string sql = "usp_DELETE_EnvioPaquete_ByID";
                command.Parameters.AddWithValue("@TipoEnvio", pTipoEnvio);
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

        public List<PrecioEnvios> GetAllPrecioEnvios()
        {
            DataSet ds = null;
            List<PrecioEnvios> lista = new List<PrecioEnvios>();
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @" select * from  EnvioPaquete WITH (NOLOCK) ";
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
                        PrecioEnvios oPrecioEnvios = new PrecioEnvios();
                        oPrecioEnvios.TipoEnvio = (int)dr["TipoEnvio"];
                        oPrecioEnvios.KilometroInicial = (int)dr["KilometroInicial"];
                        oPrecioEnvios.KilometroFinal = (int)dr["KilometroFinal"];
                        oPrecioEnvios.Precio = (double)dr["Precio"];

                        lista.Add(oPrecioEnvios);
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

        public int GetCurrentNumeroEnvio()
        {
            DataSet ds = null;
            IDbCommand command = new SqlCommand();
            int numeroEnvio = 0;
            string sql = @"SELECT current_value FROM sys.sequences WHERE name = 'SequenceNoEnvio'  ";
            DataTable dt = null;
            try
            {

                command.CommandText = sql;
                command.CommandType = CommandType.Text;


                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    ds = db.ExecuteReader(command, "query");
                }

                // Extraer la tabla 
                dt = ds.Tables[0];
                //Extraer el valor que viene en el DataSet 
                numeroEnvio = int.Parse(dt.Rows[0][0].ToString());
                return numeroEnvio;
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

        public int GetNextNumeroEnvio()
        {
            DataSet ds = null;
            IDbCommand command = new SqlCommand();
            int numeroEnvio = 0;
            string sql = @"SELECT NEXT VALUE FOR SequenceNoEnvio";

            DataTable dt = null;
            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    ds = db.ExecuteReader(command, "query");
                }

                // Extraer la tabla 
                dt = ds.Tables[0];
                //Extraer el valor que viene en el DataTable 
                numeroEnvio = int.Parse(dt.Rows[0][0].ToString());
                return numeroEnvio;
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

        public List<PrecioEnvios> GetPrecioEnviosByFilter(int pTipoEnvio)
        {
            DataSet ds = null;
            List<PrecioEnvios> lista = new List<PrecioEnvios>();
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @" select * from  EnvioPaquete WITH (NOLOCK) Where TipoEnvio like @filtro ";
                command.Parameters.AddWithValue("@filtro", pTipoEnvio);
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
                        PrecioEnvios oPrecioEnvios = new PrecioEnvios();
                        oPrecioEnvios.TipoEnvio = (int)dr["TipoEnvio"];
                        oPrecioEnvios.KilometroInicial = (int)dr["KilometroInicial"];
                        oPrecioEnvios.KilometroFinal = (int)dr["KilometroFinal"];
                        oPrecioEnvios.Precio = (double)dr["Precio"];

                        lista.Add(oPrecioEnvios);
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

        public PrecioEnvios GetPrecioEnviosById(int pTipoEnvio)
        {
            DataSet ds = null;
            PrecioEnvios oPrecioEnvios = null;
            SqlCommand command = new SqlCommand();

            string sql = @" select * from  EnvioPaquete Where TipoEnvio = @TipoEnvio ";

            try
            {
                command.Parameters.AddWithValue("@TipoEnvio", pTipoEnvio);
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
                         oPrecioEnvios = new PrecioEnvios();
                        oPrecioEnvios.TipoEnvio = (int)dr["TipoEnvio"];
                        oPrecioEnvios.KilometroInicial = (int)dr["KilometroInicial"];
                        oPrecioEnvios.KilometroFinal = (int)dr["KilometroFinal"];
                        oPrecioEnvios.Precio = (double)dr["Precio"];

                       


                    }
                }

                return oPrecioEnvios;
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

        public PrecioEnvios SavePrecioEnvios(PrecioEnvios pPrecioEnvios)
        {
            PrecioEnvios oPrecioEnvios = null;
            SqlCommand cmd = new SqlCommand();
            // Insert
            //string sql = @"Insert into Cliente(IdCliente,Nombre,Apellido1,Apellido2,Sexo,FechaNacimiento,IdProvincia) values (@IdCliente,@Nombre,@Apellido1,@Apellido2,@Sexo,@FechaNacimiento,@IdProvincia)";

            double rows = 0;
            try
            {
                cmd.Parameters.AddWithValue("@TipoEnvio", pPrecioEnvios.TipoEnvio);
                cmd.Parameters.AddWithValue("@KilometroInicial", pPrecioEnvios.KilometroInicial);
                cmd.Parameters.AddWithValue("@KilometroFinal", pPrecioEnvios.KilometroFinal);
                cmd.Parameters.AddWithValue("@Precio", pPrecioEnvios.Precio);
              
                cmd.CommandText = "usp_INSERT_EnvioPaquete";
                cmd.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(cmd, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo
                if (rows > 0)
                    oPrecioEnvios = this.GetPrecioEnviosById(pPrecioEnvios.TipoEnvio);

                return oPrecioEnvios;

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

        public PrecioEnvios UpdatePrecioEnvios(PrecioEnvios pPrecioEnvios)
        {
            PrecioEnvios oPrecioEnvios = null;
            SqlCommand cmd = new SqlCommand();
            // Insert
            //string sql = @"Insert into Cliente(IdCliente,Nombre,Apellido1,Apellido2,Sexo,FechaNacimiento,IdProvincia) values (@IdCliente,@Nombre,@Apellido1,@Apellido2,@Sexo,@FechaNacimiento,@IdProvincia)";
            string sql = "usp_UPDATE_EnvioPaquete";
            double rows = 0;
            try
            {
                cmd.Parameters.AddWithValue("@TipoEnvio", pPrecioEnvios.TipoEnvio);
                cmd.Parameters.AddWithValue("@KilometroInicial", pPrecioEnvios.KilometroInicial);
                cmd.Parameters.AddWithValue("@KilometroFinal", pPrecioEnvios.KilometroFinal);
                cmd.Parameters.AddWithValue("@Precio", pPrecioEnvios.Precio);

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(cmd, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo
                if (rows > 0)
                    oPrecioEnvios = this.GetPrecioEnviosById(pPrecioEnvios.TipoEnvio);

                return oPrecioEnvios;

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
