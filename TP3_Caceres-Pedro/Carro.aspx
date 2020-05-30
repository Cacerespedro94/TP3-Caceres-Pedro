﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carro.aspx.cs" Inherits="TP3_Caceres_Pedro.Carro" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <style>
           .oculto {
               display: none;
           }
           #Tarjeta{
            
           }
          </style>
   
    <div class="container mt-5">
        <div class="row">
            <div class="col-sm-9 ">
 <asp:GridView CssClass="table" ID="dgvCarrito" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged" OnRowCommand="dgvCarrito_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" CommandName="Select" />
        </Columns>
   
    </asp:GridView>
        </div>
   <div class="col-sm-3">
            <div id="Tarjeta">
                <div class="row">
                        <div class="col text-center">
        <div class="card text-white bg-success mb-3 mx-auto" style="max-width: 20rem;">
  <div class="card-header font-weight-bold">Detalle de compra</div>
  <div class="card-body">
     <asp:Label ID="CanUni" CssClass="card-text" Text="" runat="server" />
    <h5 class="card-title font-weight-bold text-center">Precio final</h5>
       
      <asp:Label ID="Total" CssClass="card-text align-items-center" Text="" runat="server" />
 </div>
           </div>
      </div>
      </div>
</div>
</div>
        </div>   
     </div>
 <script>
     var PrecioTotal = <%=prue.precioTotal%>;
     if (PrecioTotal > 0) {
         document.getElementById("Tarjeta").style.display = "block";
     }
     else {
         document.getElementById("Tarjeta").style.display = "none";
     }
</script>
</asp:Content>

