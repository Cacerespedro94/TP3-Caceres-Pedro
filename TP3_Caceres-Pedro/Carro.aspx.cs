using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3_Caceres_Pedro
{
    public partial class Carro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Articulo> prue = new List<Articulo>();
            Articulo ar = new Articulo();
            Articulo arti = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> listaArticulo;
            listaArticulo = negocio.listar2();
            try
            {
                if (Session[Session.SessionID + "elemento"] != null)
                {
                    prue = (List<Articulo>)Session[Session.SessionID + "elemento"];
                    dgvCarrito.DataSource = prue;
                    dgvCarrito.DataBind();

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
        protected void dgvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> prue = new List<Articulo>();

            Articulo ar = new Articulo();
            List<Articulo> listaArticulo;
            listaArticulo = negocio.listar2();

 
            int index = Convert.ToInt32(e.CommandArgument);
            int idProducto = Convert.ToInt32(dgvCarrito.Rows[index].Cells[1].Text);
                var pokeSeleccionado = Convert.ToInt32(Request.QueryString["IdProducto"]);
                ar = listaArticulo.Find(J => J.Id == pokeSeleccionado);
                prue = (List<Articulo>)Session[Session.SessionID + "elemento"];
                prue.Remove(ar);
                Session.Add(Session.SessionID + "elemento", prue);
      

        }
    }
    }
