<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaDeProductos.aspx.cs" Inherits="TP3_Caceres_Pedro.ListaDeProductos" %>


<asp:Content runat="server" ID="ListaProductos" ContentPlaceHolderID="MainContent">

    

    <div class="card-columns mt-5 " style="margin-left: 10px; margin-right: 10px;">

        <%-- ESTO funciona perfecto, pero lo cambiamos por el repeater para poder usar el 
            pasaje de parámetros con el CommandArgument de un botón (el PRUEBA), ya que de ESTE modo, 
            no toma el valor. --%>
            
       
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
                   <asp:button ID="btnargumento" CssClass="btn btn-success border border-primary rounded-pill mb-3 float-none " text="Agregar al carrito" commandargument='<%#Eval("Id")%>' commandname="idproducto" runat="server" onclick="btnargumento_click" />
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
