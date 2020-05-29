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
        Carrito prue = new Carrito();
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
                    Total.Text = prue.precioTotal.ToString();

                }
                //else
                //{
                //    if (!IsPostBack)
                //    {
                //        var pokeSeleccionado = Convert.ToInt32(Request.QueryString["IdProducto"]);
                //        ar = listaArticulo.Find(J => J.Id == pokeSeleccionado);
                //        Session.Add(Session.SessionID + "elemento", ar);
                //        arti = (Articulo)Session[Session.SessionID + "elemento"];


                //    }
                //    else
                //    {
                //        arti = (Articulo)Session[Session.SessionID + "elemento"];
                //        lblNombre.Text = arti.Nombre;
                //    }



                //}


                // if (!IsPostBack)
                // {

                //     var pokeSeleccionado = Convert.ToInt32(Request.QueryString["IdProducto"]);
                //     ar = listaArticulo.Find(J => J.Id == pokeSeleccionado);
                //     Session.Add(Session.SessionID + "elemento", ar);

                //     arti = (Articulo)Session[Session.SessionID + "elemento"];


                // }

                //else if (Session[Session.SessionID + "elemento"] != null)
                // {
                //     Session.Add(Session.SessionID + "elemento", ar);
                //     arti = (Articulo)Session[Session.SessionID + "elemento"];
                //     lblNombre.Text = arti.Nombre;
                // }
                // else { lblNombre.Text = ""; }

            }



            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }




        }

        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            //            ArticuloNegocio negocio = new ArticuloNegocio();
            //List<Carrito> prue = new List<Carrito>();

            //Carrito car = new Carrito();
            //List<Articulo> listaArticulo;
            //Articulo ar = new Articulo();
            //listaArticulo = negocio.listar2();

            //if (e.CommandName == "Select")
            //{
            //    int index = Convert.ToInt32(e.CommandArgument);
            //    int idProducto = Convert.ToInt32(dgvCarrito.Rows[index].Cells[1].Text);
            //    var pokeSeleccionado = Convert.ToInt32(Request.QueryString["IdProducto"]);
            //    ar = listaArticulo.Find(J => J.Id == pokeSeleccionado);
            //    car = (Carrito)Session[Session.SessionID + "elemento"];
            //    car.item.Remove(ar);
            //    Session.Add(Session.SessionID + "elemento", car);
            //    //Response.Redirect("Carro.aspx");
            //}
        }
        protected void dgvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
 

            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idProducto = Convert.ToInt32(dgvCarrito.Rows[index].Cells[1].Text);
                ar  = prue.item.Find(J => J.Id == idProducto);
                prue.item.Remove(ar);
                Response.Redirect("Carro.aspx");
            }
        }
    }
}
