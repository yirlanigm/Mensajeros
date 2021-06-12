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
    class DALFactura : IDALFactura
    {
        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");
        Usuario _Usuario = new Usuario();

        public DALFactura()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }
        public int GetCurrentNumeroFactura()
        {
            DataSet ds = null;
            IDbCommand command = new SqlCommand();
            int numeroFactura = 0;
            string sql = @"SELECT current_value FROM sys.sequences WHERE name = 'SequenceFactura'  ";
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
                numeroFactura = int.Parse(dt.Rows[0][0].ToString());
                return numeroFactura;
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

        public int GetNextNumeroFactura()
        {

            DataSet ds = null;
            IDbCommand command = new SqlCommand();
            int numeroFactura = 0;
            string sql = @"SELECT NEXT VALUE FOR SequenceFactura";

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
                numeroFactura = int.Parse(dt.Rows[0][0].ToString());
                return numeroFactura;
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

        public EncabezadoFactura SaveFactura(EncabezadoFactura pFactura)
        {
            EncabezadoFactura oFacturaEncabezado = null;
            string sql = string.Empty;
            SqlCommand cmdFacturaEncabezado = new SqlCommand();
            SqlCommand cmdFacturaDetalle = new SqlCommand();
            List<IDbCommand> listaCommands = new List<IDbCommand>();
            double rows = 0;

            sql = @"  
                            INSERT INTO [dbo].[EncabezadoFactura]
           ([idNumeroFactura]
           ,[Fecha]
           ,[MontoTotal]
           ,[idClienteEncabezado]
           ,[idMensajeroEncabezado]
          
           ,[idTarjeta])
     VALUES
           (@idNumeroFactura,
               getdate(),
             @MontoTotal,
             @idClienteEncabezado,
             @idMensajeroEncabezado,
             @idTarjeta) ";


            try
            {
                // Encabezado de factura
                cmdFacturaEncabezado.Parameters.AddWithValue("@idNumeroFactura", pFactura.idNumeroFactura);
                cmdFacturaEncabezado.Parameters.AddWithValue("@MontoTotal", pFactura.montoTotal);
                cmdFacturaEncabezado.Parameters.AddWithValue("@idClienteEncabezado", pFactura.idCliente.IdCliente);
                cmdFacturaEncabezado.Parameters.AddWithValue("@idMensajeroEncabezado", pFactura.idMensajero.idMensajero);
                cmdFacturaEncabezado.Parameters.AddWithValue("@idTarjeta", pFactura.tipoTarjeta.IdTarjeta);
                cmdFacturaEncabezado.CommandText = sql;
                cmdFacturaEncabezado.CommandType = CommandType.Text;
                // Agregar a la lista de commands
                listaCommands.Add(cmdFacturaEncabezado);


                // Detalle de factura
                sql = @"INSERT INTO [dbo].[DetalleFactura]
           ([idFactura]
           ,[Secuencia]
           ,[CantidadPaquetes]
           ,[Kilometros]
           ,[PrecioCalculado]
           ,[Impuesto]
           ,[DescripcionRuta]
           ,[idTpoEnvio])
     VALUES
           (@idFactura,
            @Secuencia,
            @CantidadPaquetes,
            @Kilometros,
            @PrecioCalculado,
            @Impuesto,
            @DescripcionRuta,
            @idTpoEnvio)";

                foreach (DetalleFactura pFacturaDetalle in pFactura._ListaFacturaDetalle)
                {
                    cmdFacturaDetalle = new SqlCommand();
                    cmdFacturaDetalle.Parameters.AddWithValue("@IdFactura", pFacturaDetalle.idFactura);
                    cmdFacturaDetalle.Parameters.AddWithValue("@Secuencia", pFacturaDetalle.Secuencia);
                    cmdFacturaDetalle.Parameters.AddWithValue("@CantidadPaquetes", pFacturaDetalle.CantidadPaquetes);
                    cmdFacturaDetalle.Parameters.AddWithValue("@Kilometros", pFacturaDetalle.Kilometros);
                    cmdFacturaDetalle.Parameters.AddWithValue("@PrecioCalculado", pFacturaDetalle.PrecioCalculado);
                    cmdFacturaDetalle.Parameters.AddWithValue("@Impuesto", pFacturaDetalle.Impuesto);
                    cmdFacturaDetalle.Parameters.AddWithValue("@DescripcionRuta", pFacturaDetalle.DescripcionRuta);
                    cmdFacturaDetalle.Parameters.AddWithValue("@idTpoEnvio", pFacturaDetalle.IdTipoEnvio);
                    cmdFacturaDetalle.CommandText = sql;
                    cmdFacturaDetalle.CommandType = CommandType.Text;
                    listaCommands.Add(cmdFacturaDetalle);
                }


                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(listaCommands, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo

                if (rows == 0)
                {
                    throw new Exception("No se pudo  correctamente la factura");
                }
                else
                {
                    oFacturaEncabezado = GetFactura(pFactura.idNumeroFactura);
                }

                return oFacturaEncabezado;
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);

                foreach (var oCmd in listaCommands)
                {
                    msg.AppendFormat("SQL            {0}\n", oCmd.CommandText);
                }
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }
        private EncabezadoFactura GetFactura(string pNumeroFactura)
        {

            EncabezadoFactura a = null;
            return a;

        //    EncabezadoFactura oFacturaEncabezado = new EncabezadoFactura();
        //    DataSet ds = null;
        //    IDALCliente _DALCliente = new DALCliente();
        //    IDALTarjeta _DALTarjeta = new DALTarjeta();
        //    SqlCommand command = new SqlCommand();

        //    string sql = @"  ";


        //    sql = @"SELECT    EncabezadoFactura.idNumeroFactura, EncabezadoFactura.IdTarjeta, EncabezadoFactura.idClienteEncabezado, EncabezadoFactura.Fecha, EncabezadoFactura.idMensajeroEncabezado, EncabezadoFactura.MontoTotal, 
        //                                             EncabezadoFactura.TarjetaNumero, DetalleFactura.Secuencia, DetalleFactura.IdTipoEnvio, DetalleFactura.CantidadPaquetes, DetalleFactura.PrecioCalculado, DetalleFactura.Impuesto
        //                    FROM            EncabezadoFactura INNER JOIN
        //                                             DetalleFactura ON EncabezadoFactura.idNumeroFactura = DetalleFactura.IdFactura
        //                    WHERE        (EncabezadoFactura.idNumeroFactura = @idNumeroFactura) ";

        //    try
        //    {
        //        command.CommandText = sql;
        //        command.CommandType = CommandType.Text;
        //        command.Parameters.AddWithValue("@IdFactura", pNumeroFactura);

        //        using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
        //        {
        //            ds = db.ExecuteReader(command, "query");
        //        }

        //        Si devolvió filas
        //                if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            DataRow dr = ds.Tables[0].Rows[0];
        //            oFacturaEncabezado = new FacturaEncabezado()
        //            {
        //                EstadoFactura = (bool)dr["EstadoFactura"],
        //                FechaFacturacion = DateTime.Parse(dr["FechaFacturacion"].ToString()),
        //                IdFactura = double.Parse(dr["IdFactura"].ToString()),
        //                _Cliente = _DALCliente.GetClienteById(dr["IdCliente"].ToString()),
        //                _Tarjeta = _DALTarjeta.GetTarjetaById(int.Parse(dr["IdTarjeta"].ToString())),
        //                TipoPago = (int)dr["TipoPago"]
        //            };

        //            foreach (var item in ds.Tables[0].Rows)
        //            {
        //                FacturaDetalle oFacturaDetalle = new FacturaDetalle();
        //                oFacturaDetalle.IdElectronico = double.Parse(dr["IdElectronico"].ToString());
        //                oFacturaDetalle.Cantidad = int.Parse(dr["Cantidad"].ToString());
        //                oFacturaDetalle.Precio = double.Parse(dr["Precio"].ToString());
        //                oFacturaDetalle.IdFactura = double.Parse(dr["IdFactura"].ToString());
        //                Calcular el Impuesto
        //                        oFacturaDetalle.Impuesto = double.Parse(dr["Impuesto"].ToString());
        //                Enumerar la secuencia
        //                        oFacturaDetalle.Secuencia = int.Parse(dr["Secuencia"].ToString());
        //                Agregar
        //                        oFacturaEncabezado.AddDetalle(oFacturaDetalle);
        //            }
        //        }


        //        return oFacturaEncabezado;
        //    }
        //    catch (Exception er)
        //    {
        //        StringBuilder msg = new StringBuilder();
        //        msg.AppendFormat("Message        {0}\n", er.Message);
        //        msg.AppendFormat("Source         {0}\n", er.Source);
        //        msg.AppendFormat("InnerException {0}\n", er.InnerException);
        //        msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
        //        msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);
        //        msg.AppendFormat("SQL            {0}\n", command.CommandText);
        //        _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
        //        throw;
        //    }

        //}
   // }
} }
}
