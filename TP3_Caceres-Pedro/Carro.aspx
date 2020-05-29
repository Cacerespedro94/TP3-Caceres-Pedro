<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carro.aspx.cs" Inherits="TP3_Caceres_Pedro.Carro" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <style>
           .oculto {
               display: none;
           }
          </style>
    <h1>Carro</h1>
  
 <asp:GridView CssClass="table" ID="dgvCarrito" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged" OnRowCommand="dgvCarrito_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:ButtonField  HeaderText="" ButtonType="Link" Text="Eliminar"  CommandName="Select" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
   
    </asp:GridView>
      <div>
          <asp:Label ID="Total" Text="" runat="server" />
     </div>
</asp:Content>
