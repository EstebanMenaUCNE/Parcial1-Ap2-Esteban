using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial1_Ap2_Esteban.UI.Consultas
{
    public partial class ConsultaPresupuestos : System.Web.UI.Page
    {
        public static List<Presupuesto> Lista { get; set; }
        public static Presupuesto PresupuestoSeleccionado = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lista = new List<Presupuesto>();
            PresupuestoSeleccionado = null;
            AlertaEliminadoExito.Visible = false;
            AlertaError.Visible = false;
        }

        private void Filtrar()
        {
            DateTime fechaDesde = Utilidad.ToDateTime(FechaDesdeTextBox.Text);
            DateTime fechaHasta = Utilidad.ToDateTime(FechaHastaTextBox.Text);
            if (FiltrarDropDownList.Text == "ID")
            {
                int id = Utilidad.ToInt(FiltrarTextBox.Text);
                if (FiltrarFechaCheckBox.Checked)
                {
                    Lista = BLL.PresupuestoBLL.GetList(P => P.PresupuestoId == id && P.Fecha >= fechaDesde.Date && P.Fecha <= fechaHasta.Date);
                }
                else
                {
                    Lista = BLL.PresupuestoBLL.GetList(P => P.PresupuestoId == id);
                }
            }
            else if (FiltrarDropDownList.Text == "Descripción")
            {
                if (FiltrarFechaCheckBox.Checked)
                {
                    Lista = BLL.PresupuestoBLL.GetList(P => P.Descripcion == FiltrarTextBox.Text && P.Fecha >= fechaDesde.Date && P.Fecha <= fechaHasta.Date);
                }
                else
                {
                    Lista = BLL.PresupuestoBLL.GetList(P => P.Descripcion == FiltrarTextBox.Text);
                }

            }
            else
            {
                if (FiltrarFechaCheckBox.Checked)
                {
                    Lista = BLL.PresupuestoBLL.GetList(P => P.PresupuestoId > 0 && P.Fecha >= fechaDesde.Date && P.Fecha <= fechaHasta.Date);
                }
                else
                {
                    Lista = BLL.PresupuestoBLL.GetList(P => P.PresupuestoId > 0);
                }
            }
        }

        protected void FiltrarFechaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Utilidad.ToInt(FilaTextBox.Text);
            PresupuestoSeleccionado = BLL.PresupuestoBLL.Buscar(P => P.PresupuestoId == id);
            if (BLL.PresupuestoBLL.Eliminar(PresupuestoSeleccionado))
            {
                AlertaEliminadoExito.Visible = true;
            }
            else
            {
                AlertaError.Visible = true;
            }
            PresupuestoSeleccionado = null;
            
        }

        protected void ModificarButton_Click(object sender, EventArgs e)
        {
            int id = Utilidad.ToInt(FilaTextBox.Text);
            PresupuestoSeleccionado = BLL.PresupuestoBLL.Buscar(P => P.PresupuestoId == id);
            Response.Redirect("../Registros/RegistroPresupuestos.aspx");
        }
    }
}