using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;

namespace TP3_Caceres_Pedro
{
    public partial class Carro : System.Web.UI.Page
    {
        Articulo ar = new Articulo();
        public Carrito prue = new Carrito();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Articulo ar = new Articulo();
            Articulo arti = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> listaArticulo;
            listaArticulo = negocio.listar2();
            try
            {
                if (Session[Session.SessionID + "elemento"] != null)
                {
                    prue = (Carrito)Session[Session.SessionID + "elemento"];
                    dgvCarrito.DataSource = prue.item;
                    dgvCarrito.DataBind();
                    dgvCarrito.RowStyle.CssClass = "font-weight-bold";
                   
                    Total.Text = "$" + prue.precioTotal.ToString();
                    CanUni.Text = "Estás llevando " + prue.cantidad + " unidades...";
                    
                    if(prue.cantidad>0)
                    { 
                    dgvCarrito.HeaderRow.CssClass = "bg-primary";
                    }
                }
            }

            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }

        }

        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void dgvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idProducto = Convert.ToInt32(dgvCarrito.Rows[index].Cells[0].Text);
                ar  = prue.item.Find(J => J.Id == idProducto);
                prue.precioTotal -= ar.Precio;
                prue.cantidad--;
                prue.item.Remove(ar);
                Response.Redirect("Carro.aspx");
            }
        }
    }
}
