<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaDeProductos.aspx.cs" Inherits="TP3_Caceres_Pedro.ListaDeProductos" %>


<asp:Content runat="server" ID="ListaProductos" ContentPlaceHolderID="MainContent">

    <h1>Lista Pokemons</h1>

    
    <asp:DropDownList runat="server" ID="cboPokemons" />
  
    
    <div class="card-columns" style="margin-left: 10px; margin-right: 10px; ">

        <%-- ESTO funciona perfecto, pero lo cambiamos por el repeater para poder usar el 
            pasaje de parámetros con el CommandArgument de un botón (el PRUEBA), ya que de ESTE modo, 
            no toma el valor. --%>
            
       
                <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>
                <div class="card">
                    <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("Nombre")%></h5>
                        <p class="card-text"><%#Eval("Descripcion")%></p>
                    </div>
                    <a id="seleccionar" onclick="prueba()" class="btn btn-primary" href="?idProducto=<%#Eval("Id")%>">Seleccionar</a>
                   <asp:button id="btnargumento" cssclass="btn btn-primary" text="argumento to back" commandargument='<%#Eval("Id")%>' commandname="idproducto" runat="server" onclick="btnargumento_click" />
                
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Label ID="lblaaaa" Text="Texto" runat="server" />
                  

         </div>
    <script>


        function prueba() {
       
        }
           
    </script>   


        
   
</asp:Content>
