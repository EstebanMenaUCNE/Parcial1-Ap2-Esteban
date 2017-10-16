using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial1_Ap2_Esteban.UI.Registros
{
    public partial class RegistroPresupuestos : System.Web.UI.Page
    {
        private Presupuesto presupuesto = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            AlertaValidar.Visible = false;
            AlertaGuardadoExito.Visible = false;
            AlertaError.Visible = false;

            LlenarDropDownListCategorias();

            if (Consultas.ConsultaPresupuestos.PresupuestoSeleccionado != null)
            {
                presupuesto = Consultas.ConsultaPresupuestos.PresupuestoSeleccionado;
                Consultas.ConsultaPresupuestos.PresupuestoSeleccionado = null;
                CargarDatos();
                NuevoOModificando();
            }
        }

        private void LlenarDropDownListCategorias()
        {
            CategoriaIdDropDownList.DataSource = BLL.CategoriaBLL.GetList(P => P.CategoriaId > 0);
            CategoriaIdDropDownList.DataValueField = "CategoriaId";
            CategoriaIdDropDownList.DataTextField = "Descripcion";
            CategoriaIdDropDownList.DataBind();
        }

        private void Limpiar()
        {
            presupuesto = null;
            Consultas.ConsultaPresupuestos.PresupuestoSeleccionado = null;
            PresupuestoIdTextBox.Text = "";
            FechaTextBox.Text = "";
            DescripcionTextBox.Text = "";
            MontoTextBox.Text = "";

            AlertaValidar.Visible = false;
            AlertaGuardadoExito.Visible = false;
            AlertaError.Visible = false;

            NuevoOModificando();
        }

        private void CargarDatos()
        {
            PresupuestoIdTextBox.Text = presupuesto.PresupuestoId.ToString();
            FechaTextBox.Text = presupuesto.Fecha.GetDateTimeFormats()[80].ToString().Substring(0, 10);
            DescripcionTextBox.Text = presupuesto.Descripcion;
            MontoTextBox.Text = presupuesto.Monto.ToString();
            CategoriaIdDropDownList.SelectedValue = presupuesto.CategoriaId.ToString();
        }

        private void NuevoOModificando()
        {
            if (PresupuestoIdTextBox.Text == "")
            {
                NuevoOModificandoLabel.Text = "Nuevo presupuesto";
            }
            else
            {
                NuevoOModificandoLabel.Text = "Modificando el presupuesto " + PresupuestoIdTextBox.Text;
            }
        }

        private bool Validar()
        {
            bool flag = true;
            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                flag = false;
            }
            if (string.IsNullOrWhiteSpace(FechaTextBox.Text))
            {
                flag = false;
            }
            if (Utilidad.ToDouble(MontoTextBox.Text)<0)
            {
                flag = false;
            }
            return flag;
        }

        private void LlenarCamposInstancia()
        {
            string value = CategoriaIdDropDownList.SelectedValue;
            int index = CategoriaIdDropDownList.SelectedIndex;
            int id = 0;
            if (PresupuestoIdTextBox.Text != "")
            {
                id = Utilidad.ToInt(PresupuestoIdTextBox.Text);
            }
            presupuesto = new Presupuesto(id, DateTime.Parse(FechaTextBox.Text), DescripcionTextBox.Text, Utilidad.ToDecimal(MontoTextBox.Text), Utilidad.ToInt(CategoriaIdDropDownList.SelectedValue));
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                LlenarCamposInstancia();
                if (PresupuestoBLL.Guardar(presupuesto))
                {
                    PresupuestoIdTextBox.Text = presupuesto.PresupuestoId.ToString();
                    MensajeAlertaGuardadoExito.Text = "¡Guardado con éxito con el ID " + presupuesto.PresupuestoId + "!";
                    AlertaGuardadoExito.Visible = true;
                    NuevoOModificando();
                    Consultas.ConsultaPresupuestos.PresupuestoSeleccionado = null;
                }
                else
                {
                    AlertaError.Visible = true;
                }
            }
            else
            {
                AlertaValidar.Visible = true;
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}