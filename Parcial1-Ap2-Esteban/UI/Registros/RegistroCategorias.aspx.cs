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
    public partial class RegistroCategorias : System.Web.UI.Page
    {
        private Categoria categoria = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            AlertaValidar.Visible = false;
            AlertaGuardadoExito.Visible = false;
            AlertaError.Visible = false;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                

            if (Consultas.ConsultaCategorias.CategoriaSeleccionada != null)
            {
                categoria = Consultas.ConsultaCategorias.CategoriaSeleccionada;
                Consultas.ConsultaCategorias.CategoriaSeleccionada = null;
                CargarDatos();
                NuevoOModificando();
            }
        }

        private void Limpiar()
        {
            categoria = null;
            Consultas.ConsultaCategorias.CategoriaSeleccionada = null;
            CategoriaIdTextBox.Text = "";
            DescripcionTextBox.Text = "";

            AlertaValidar.Visible = false;
            AlertaGuardadoExito.Visible = false;
            AlertaError.Visible = false;

            NuevoOModificando();
        }

        private void CargarDatos()
        {
            CategoriaIdTextBox.Text = categoria.CategoriaId.ToString();
            DescripcionTextBox.Text = categoria.Descripcion;
        }

        private void NuevoOModificando()
        {
            if (CategoriaIdTextBox.Text == "")
            {
                NuevoOModificandoLabel.Text = "Nueva categoría";
            }
            else
            {
                NuevoOModificandoLabel.Text = "Modificando la categoría " + CategoriaIdTextBox.Text;
            }
        }

        private bool Validar()
        {
            bool flag = true;
            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                flag = false;
            }
            return flag;
        }

        private void LlenarCamposInstancia()
        {
            int id = 0;
            if (CategoriaIdTextBox.Text != "")
            {
                id = Utilidad.ToInt(CategoriaIdTextBox.Text);
            }
            categoria = new Categoria(id, DescripcionTextBox.Text);
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                LlenarCamposInstancia();
                if (CategoriaBLL.Guardar(categoria))
                {
                    CategoriaIdTextBox.Text = categoria.CategoriaId.ToString();

                    if (Consultas.ConsultaCategorias.CategoriaSeleccionada == null)
                    {
                        MensajeAlertaGuardadoExito.Text = "¡Guardado con éxito con el ID " + categoria.CategoriaId + "!";
                    }
                    else
                    {
                        MensajeAlertaGuardadoExito.Text = "Repita los cambios realizados para modificar. Esto por la seguridad de los datos.";
                    }
                    AlertaGuardadoExito.Visible = true;
                    NuevoOModificando();
                    Consultas.ConsultaCategorias.CategoriaSeleccionada = null;
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