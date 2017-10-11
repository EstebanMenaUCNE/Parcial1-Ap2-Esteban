<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroCategorias.aspx.cs" Inherits="Parcial1_Ap2_Esteban.UI.Registros.RegistroCategorias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta lang="es-ES"/>
    <title>Registro de categorías</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!--Inclusión de Bootstrap 4.0.0 CDN-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous"/>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>

</head>
<body>
    <header>
        <div class="jumbotron bg-success">
            <h1 class="display-3" style="color:white;">Categorías</h1>
        </div>
    </header>

    <div class="fluid-container">
        <a class="btn btn-danger float-right" href="../Registros/RegistroPresupuestos.aspx">Presupuestos</a>
    </div>

    <nav>
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link disabled"></a>
            </li>
            <li class="nav-item">
                <a class="nav-link active" href="#">Registro</a>
            </li>
            <li class="nav-item">
                <a class="nav-link disabled" href="../Consultas/ConsultaCategorias.aspx">Consulta</a>
            </li>
        </ul>
    </nav>

    <br />
    <br /> 
    
    <div class="fluid-container">
        <div class="col-xs-12 col-sm-4">

            <!--Alertas-->
            <div class="col-xs-12">
                <asp:Panel id="AlertaGuardadoExito" class="alert alert-success text-center" role="alert" runat="server">
                    <asp:Label ID="MensajeAlertaGuardadoExito" runat="server">¡Guardado con éxito!</asp:Label>
                </asp:Panel>
                <asp:Panel id="AlertaError" class="alert alert-danger text-center" role="alert" runat="server">
                    <asp:Label ID="MensajeAlertaError" runat="server">¡Algo salió mal!</asp:Label>
                </asp:Panel>
                <asp:Panel id="AlertaValidar" class="alert alert-info text-center" role="alert" runat="server">
                    <asp:Label ID="MensajeAlertaValidar" runat="server">Por favor llene todos los campos correctamente...</asp:Label>
                </asp:Panel>
            </div>
            <br />

            <!--Formulario-->
            <form id="form" runat="server">
                <div class="text-center">
                    <h4><asp:Label CssClass="text-center" ID="NuevoOModificandoLabel" runat="server" Text="Nueva categoría"></asp:Label></h4>
                </div>
                <asp:Button CssClass="btn btn-success float-right" ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                <br />
                <br />
                <div class="form-group d-none">
                    <label for="CategoriaIdTextBox">Presupuesto Id</label>
                    <asp:TextBox Type="number" CssClass="form-control" ID="CategoriaIdTextBox" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="DescripcionTextBox">Descripción</label>
                    <asp:TextBox CssClass="form-control" ID="DescripcionTextBox" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="text-center">
                    <asp:Button CssClass="btn btn-success" ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                </div>
            </form>
        </div>
    </div>

    <br />
    <br />

    <footer class="bg-success">
        <p class="text-center" style="color:white;">Esteban Mena - 2014-0563 - Primer parcial</p>
    </footer>
    
</body>
</html>

