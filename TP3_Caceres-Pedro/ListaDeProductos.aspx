<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaDeProductos.aspx.cs" Inherits="TP3_Caceres_Pedro.ListaDeProductos" %>


<asp:Content runat="server" ID="ListaProductos" ContentPlaceHolderID="MainContent">

    <div class="container">
        <div class="row">
            <div class="col text-center">
                <asp:TextBox ID="txtBuscador" CssClass="mt-5" runat="server" OnTextChanged="Buscador_TextChanged" />
                <asp:Button Text="Buscar" CssClass="btn btn-primary" OnClick="Buscador_TextChanged" runat="server" />
            </div>
        </div>
    </div>
    <div class="card-columns mt-5 " style="margin-left: 10px; margin-right: 10px;">

        <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>

                <div class="card border-dark">
                    <h3 class="card-title text-center font-weight-bold text-primary"><%#Eval("Nombre")%></h3>
                    <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text text-center font-weight-bold"><%#Eval("Descripcion")%></p>
                        <h4 class="card-text text-center text-danger">$<%#Eval("Precio")%></h4>
                    </div>
                    <div class="row">
                        <div class="col text-center">
                            <asp:Button ID="btnargumento" CssClass="btn btn-success border border-primary rounded-pill mb-3 float-none " Text="Agregar al carrito" CommandArgument='<%#Eval("Id")%>' CommandName="idproducto" runat="server" OnClick="btnargumento_click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
    <script>

        function prueba() {


        }

    </script>




</asp:Content>
