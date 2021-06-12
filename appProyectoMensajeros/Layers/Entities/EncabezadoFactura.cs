using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.Mensajeros.Layers.Entities
{
    class EncabezadoFactura
    {

        public string idNumeroFactura { get; set; }
        public DateTime fecha { get; set; }
        public double montoTotal { get; set; }
        public Cliente idCliente { get; set; }
        public Mensajero idMensajero { get; set; }
        
        
        public Tarjeta tipoTarjeta { get; set; }

        public List<DetalleFactura> _ListaFacturaDetalle { get; } = new List<DetalleFactura>();

        public void AddDetalle(DetalleFactura pDetalleFactura)
        {
            _ListaFacturaDetalle.Add(pDetalleFactura);
        }

        public double GetSubTotal()
        {
             return _ListaFacturaDetalle.Sum(p => p.CantidadPaquetes * p.PrecioCalculado);
        }

        public double GetImpuesto()
        {
            return _ListaFacturaDetalle.Sum(p => p.Impuesto);
        }
    }
}
