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
    class DALTarjeta : IDALTarjeta
    {
        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");

        private Usuario _Usuario = new Usuario();
        public DALTarjeta()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }
        public List<Tarjeta> GetAllTarjeta()
        {
            IDataReader reader = null;
            List<Tarjeta> lista = new List<Tarjeta>();
            Tarjeta oTarjeta = null;
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @" select * from  Tarjeta  With (NoLock)";
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    reader = db.ExecuteReader(command);
                    // Si devolvió filas
                    while (reader.Read())
                    {
                        oTarjeta = new Tarjeta();
                        oTarjeta.IdTarjeta = int.Parse(reader["IdTarjeta"].ToString());
                        oTarjeta.DescripcionTarjeta = reader["Descripcion"].ToString();
                        lista.Add(oTarjeta);
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
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }

        }

        public Tarjeta GetTarjetaById(int pIdTarjeta)
        {
            DataSet ds = null;
            Tarjeta oTarjeta = null;
            SqlCommand command = new SqlCommand();
            string sql = @" select * from  Tarjeta ";

            try
            {
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
                        oTarjeta = new Tarjeta();
                        oTarjeta.IdTarjeta = int.Parse(dr["IdTarjeta"].ToString());
                        oTarjeta.DescripcionTarjeta = dr["Descripcion"].ToString();

                    }
                }

                return oTarjeta;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }

        }
    }
}
