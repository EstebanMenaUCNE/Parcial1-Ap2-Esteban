<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaPresupuestos.aspx.cs" Inherits="Parcial1_Ap2_Esteban.UI.Consultas.ConsultaPresupuestos" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta lang="es-ES" />
    <title>Consulta de presupuestos</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!--Inclusión de Bootstrap 4.0.0 CDN-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>

    <!--Inclusión de scripts  personales-->
    <script src="../../Scripts/Scripts.js"></script>

</head>
<body>
    <header>
        <div class="jumbotron bg-success">
            <h1 class="display-3" style="color: white;">Presupuestos</h1>
        </div>
    </header>

    <nav>
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link disabled"></a>
            </li>
            <li class="nav-item">
                <a class="nav-link disabled" href="../Registros/RegistroPresupuestos.aspx">Registro</a>
            </li>
            <li class="nav-item">
                <a class="nav-link active" href="#">Consulta</a>
            </li>
        </ul>
    </nav>

    <br />
    <br />

    <div class="container">

        <!--Alertas-->
        <div class="col-xs-12">
            <asp:Panel id="AlertaEliminadoExito" class="alert alert-success text-center" role="alert" runat="server">
                <asp:Label ID="MensajeAlertaEliminadoExito" runat="server">¡Eliminado con éxito!</asp:Label>
            </asp:Panel>
            <asp:Panel id="AlertaError" class="alert alert-danger text-center" role="alert" runat="server">
                <asp:Label ID="MensajeAlertaError" runat="server">¡Algo salió mal!</asp:Label>
            </asp:Panel>
        </div>
        <br />

        <form runat="server">
            <div class="col-xs-12 col-sm-4 d-inline-block">
                <asp:DropDownList CssClass="form-control" ID="FiltrarDropDownList" runat="server">
                    <asp:ListItem>Todo</asp:ListItem>
                    <asp:ListItem>ID</asp:ListItem>
                    <asp:ListItem>Descripción</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-xs-12 col-sm-7 d-inline-block">
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="FiltrarTextBox" runat="server" autocomplete="off"></asp:TextBox>
                </div>
            </div>

            <div class="col-xs-12 col-lg-2 d-inline-block">
                <div class="form-group">
                    <asp:CheckBox ID="FiltrarFechaCheckBox" runat="server" OnCheckedChanged="FiltrarFechaCheckBox_CheckedChanged" />
                    <label for="FiltrarFechaCheckBox">Fitrar por fecha</label>
                </div>
            </div>

            <div class="col-xs-12 col-sm-4 d-inline-block">
                <div class="form-group">
                    <label for="FechaDesdeTextBox">Desde</label>
                    <asp:TextBox type="date" CssClass="form-control" ID="FechaDesdeTextBox" runat="server" autocomplete="off"></asp:TextBox>
                </div>
            </div>

            <div class="col-xs-12 col-sm-4 d-inline-block">
                <div class="form-group">
                    <label for="FechaHastaTextBox">Hasta</label>
                    <asp:TextBox type="date" CssClass="form-control" ID="FechaHastaTextBox" runat="server" autocomplete="off"></asp:TextBox>
                </div>
            </div>

            <div class="col-xs-12 col-sm-1 d-inline-block">
                <asp:Button CssClass="btn btn-primary" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
            </div>
            <br />
            <br />

            <!--TextBox de manipulación-->
            <asp:TextBox CssClass="d-none" ID="FilaTextBox" runat="server" ></asp:TextBox>


            <!--Modal de confirmación eliminar-->
            <div class="modal" id="ModalConfirmacionEliminar">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header bg-danger">
                            <h5 class="modal-title">¡Advertencia!</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <p>¿Seguro que desea eliminar este presupuesto?</p>
                        </div>
                        <div class="modal-footer">
                            <asp:Button CssClass="btn btn-danger" ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>

            <!--Modal de confirmación modificar-->
            <div class="modal" id="ModalConfirmacionModificar">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header bg-warning">
                            <h5 class="modal-title">¡Advertencia!</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <p>¿Seguro que desea ir al registro de presupuesto para modificar este presupuesto?</p>
                        </div>
                        <div class="modal-footer">
                            <asp:Button CssClass="btn btn-warning" ID="ModificarButton" runat="server" Text="Continuar" OnClick="ModificarButton_Click" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>

        </form>

        <div class="row">
            <div class="col-12">
                <!--Tabla de consultas-->
                <table class="table table-hover table-responsive">
                    <!--Encabezados de la tabla-->
                    <tr>
                        <th class="bg-info">Presupuesto ID</th>
                        <th class="bg-info">Fecha</th>
                        <th class="bg-info">Descripción</th>
                        <th class="bg-info">Monto</th>
                        <th class="bg-info"></th>
                        <th class="bg-info"><a class="btn btn-warning" href="../Reportes/ReportePresupuestos.aspx" id="ImprimirButton">Imprimir</a></th>
                    </tr>

                    <!--Resultado de la consulta-->                          
                    <tbody id="listaF">
                        <% foreach (var presupuesto in Lista) %>
                        <% { Response.Write("<tr class='fila'> <td>" + presupuesto.PresupuestoId + "</td> <td>" + presupuesto.Fecha.ToString().Substring(0,10) + "</td> <td>" + presupuesto.Descripcion + "</td> <td>" + presupuesto.Monto + "</td> <td> <button class='btn-modificar btn btn-sm btn-success' data-toggle='modal' data-target='#ModalConfirmacionModificar'>Modificar</button> </td> <td>  <button class='btn-eliminar btn btn-sm btn-danger' data-toggle='modal' data-target='#ModalConfirmacionEliminar'>Eliminar</button> </td> </tr>"); } %>
                    </tbody>
                       
                    <tr>
                        <th class="bg-dark"></th>
                        <th class="bg-dark"></th>
                        <th class="bg-dark"></th>
                        <th class="bg-dark"></th>
                        <th class="bg-dark"></th>
                        <th class="bg-dark"></th>
                    </tr>
                </table>
            </div>
        </div>

    </div>

    <br />
    <br />

    <footer class="bg-success">
        <p class="text-center" style="color: white;">Esteban Mena - 2014-0563 - Primer parcial</p>
    </footer>

</body>
</html>
