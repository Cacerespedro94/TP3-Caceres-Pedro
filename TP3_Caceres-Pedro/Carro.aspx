<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carro.aspx.cs" Inherits="TP3_Caceres_Pedro.Carro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Carro</h1>
  
 <asp:GridView CssClass="table" ID="dgvCarrito" runat="server" AutoGenerateColumns="false"  OnRowCommand="dgvCarrito_RowCommand">
        <Columns>
            <asp:ButtonField HeaderText="Opcion" ButtonType="Link" Text="Seleccionar"  CommandName="Select" />
            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
        </Columns>
    </asp:GridView>

</asp:Content>
