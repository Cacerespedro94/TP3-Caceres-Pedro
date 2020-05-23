<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="TP3_Caceres_Pedro.WebForm2" %>
<asp:Content ID="ListaProductos" ContentPlaceHolderID="MainContent" runat="server">

    <div ID="listaProductos" class="card-columns" style="margin-left: 10px; margin-right: 10px;">

                    <% foreach (var item in listaProductos)
            { %>
         <div class="card" style="width: 18rem;">
            <img src="<% = item.UrlImagen %>" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title"><% = item.Nombre %></h5>
                <p class="card-text"><% = item.Descripcion %></p>
                <a href="PokemonDetail.aspx?idpkm=<% = item.Id.ToString() %>" class="btn btn-primary">Seleccionar</a>
            </div>
        </div>
        <% } %>
    </div>
    <%  foreach (  item in)
        {

        } %>
</asp:Content>
