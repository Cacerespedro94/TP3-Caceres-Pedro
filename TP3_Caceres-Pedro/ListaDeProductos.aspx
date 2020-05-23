<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaDeProductos.aspx.cs" Inherits="TP3_Caceres_Pedro.ListaDeProductos" %>


<asp:Content runat="server" ID="ListaProductos" ContentPlaceHolderID="MainContent">

    <h1>Lista Pokemons</h1>

    
    <asp:DropDownList runat="server" ID="cboPokemons" />

    <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">

        <%-- ESTO funciona perfecto, pero lo cambiamos por el repeater para poder usar el 
            pasaje de parámetros con el CommandArgument de un botón (el PRUEBA), ya que de ESTE modo, 
            no toma el valor. --%>
            <% foreach (var item in listaProductos )
            { %>
         <div class="card" style="width: 18rem;">
            <img src="<% = item.ImagenUrl %>" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title"><% = item.Nombre %></h5>
                <p class="card-text"><% = item.Descripcion %></p>
                <a href="PokemonDetail.aspx?idpkm=<% = item.Id.ToString() %>" class="btn btn-primary">Seleccionar</a>
            </div>
        </div>
        <% } %>
  </div>
</asp:Content>
