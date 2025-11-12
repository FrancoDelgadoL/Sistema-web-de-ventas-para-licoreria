using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ezel_Market.Models
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        public int InventarioId { get; set; }
        public Inventario Inventario { get; set; }

        public int CantidadVendida { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioUnitario { get; set; }

        public DateTime FechaVenta { get; set; } = DateTime.Now;
    }
}
