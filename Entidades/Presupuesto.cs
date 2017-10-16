using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Presupuesto
    {
        [Key]
        public int PresupuestoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public int CategoriaId { get; set; }

        public Presupuesto()
        {

        }

        public Presupuesto(int presupuestoId, DateTime fecha, string descripcion, decimal monto, int categoriaId)
        {
            PresupuestoId = presupuestoId;
            Fecha = fecha;
            Descripcion = descripcion;
            Monto = monto;
            CategoriaId = categoriaId;
        }

    }
}
