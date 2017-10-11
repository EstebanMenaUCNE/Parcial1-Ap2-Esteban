using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial1_Ap2_Esteban.UI.Consultas
{
    public partial class ConsultaCategorias : System.Web.UI.Page
    {
        public static List<Categoria> Lista { get; set; }
        public static Categoria CategoriaSeleccionada = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Lista = new List<Categoria>();
            CategoriaSeleccionada = null;
            AlertaEliminadoExito.Visible = false;
            AlertaError.Visible = false;
        }

        private void Filtrar()
        {
            if (FiltrarDropDownList.Text == "ID")
            {
                int id = Utilidad.ToInt(FiltrarTextBox.Text);
                Lista = BLL.CategoriaBLL.GetList(P => P.CategoriaId == id);
            }
            else if (FiltrarDropDownList.Text == "Descripción")
            {
                Lista = BLL.CategoriaBLL.GetList(P => P.Descripcion == FiltrarTextBox.Text);

            }
            else
            {
                Lista = BLL.CategoriaBLL.GetList(P => P.CategoriaId > 0);
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Utilidad.ToInt(FilaTextBox.Text);
            CategoriaSeleccionada = BLL.CategoriaBLL.Buscar(P => P.CategoriaId == id);
            if (BLL.CategoriaBLL.Eliminar(CategoriaSeleccionada))
            {
                AlertaEliminadoExito.Visible = true;
            }
            else
            {
                AlertaError.Visible = true;
            }
            CategoriaSeleccionada = null;

        }

        protected void ModificarButton_Click(object sender, EventArgs e)
        {
            int id = Utilidad.ToInt(FilaTextBox.Text);
            CategoriaSeleccionada = BLL.CategoriaBLL.Buscar(P => P.CategoriaId == id);
            Response.Redirect("../Registros/RegistroCategorias.aspx");
        }
    }
}