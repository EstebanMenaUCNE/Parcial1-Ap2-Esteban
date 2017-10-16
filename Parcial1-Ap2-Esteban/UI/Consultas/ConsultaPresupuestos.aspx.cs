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
            LlenarDropDownListCategorias();
            //MostrarOcultarEntradas();
        }

        private void LlenarDropDownListCategorias()
        {
            CategoriaDropDownList.DataSource = BLL.CategoriaBLL.GetList(P => P.CategoriaId > 0);
            CategoriaDropDownList.DataValueField = "CategoriaId";
            CategoriaDropDownList.DataTextField = "Descripcion";
            CategoriaDropDownList.DataBind();
        }

        //private void MostrarOcultarEntradas()
        //{
        //    if (FiltrarDropDownList.SelectedIndex == 3)
        //    {
        //        CategoriaDropDownList.Visible = true;
        //        FiltrarTextBox.Visible = false;
        //    }
        //    else
        //    {
        //        CategoriaDropDownList.Visible = false;
        //        FiltrarTextBox.Visible = true;
        //    }
        //}

        private void Filtrar()
        {
            DateTime fechaDesde = Utilidad.ToDateTime(FechaDesdeTextBox.Text);
            DateTime fechaHasta = Utilidad.ToDateTime(FechaHastaTextBox.Text);
            if (FiltrarDropDownList.SelectedIndex == 1)
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
            else if (FiltrarDropDownList.SelectedIndex == 2)
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
            else if (FiltrarDropDownList.SelectedIndex == 3)
            {
                int categoriaId = Utilidad.ToInt(CategoriaDropDownList.SelectedValue);
                if (FiltrarFechaCheckBox.Checked)
                {
                    Lista = BLL.PresupuestoBLL.GetList(P => P.CategoriaId == categoriaId && P.Fecha >= fechaDesde.Date && P.Fecha <= fechaHasta.Date);
                }
                else
                {
                    Lista = BLL.PresupuestoBLL.GetList(P => P.CategoriaId == categoriaId);
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

        protected void FiltrarDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //MostrarOcultarEntradas();
        }
    }
}