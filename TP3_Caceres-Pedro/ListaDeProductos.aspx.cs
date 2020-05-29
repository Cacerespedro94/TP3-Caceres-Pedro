using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TP3_Caceres_Pedro
{
    public partial class ListaDeProductos : System.Web.UI.Page
    {
        public List<Articulo> listaProductos { get; set; }
        public Carrito prue = new Carrito();
        List<Articulo> listaArticulo;
        Articulo ar = new Articulo();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaProductos = negocio.listar2();

                //List<Articulo> prue = new List<Articulo>();
                listaArticulo = negocio.listar2();
                
                Articulo arti = new Articulo();

                //cboPokemons.Items.Add("Rojo");
                //cboPokemons.Items.Add("Azul");
                //cboPokemons.Items.Add("Verde");

                if (!IsPostBack)
                { //pregunto si es la primera carga de la page


                    //esto es lo que necesitamos para el repeater.
                    repetidor.DataSource = listaProductos;
                    repetidor.DataBind();
                }
            }

            //    if(Request.QueryString["IdProducto"]!=null)
            //    {
            //       var articuloSeleccionado = Convert.ToInt32(Request.QueryString["IdProducto"]);
            //       ar = listaArticulo.Find(J => J.Id == articuloSeleccionado);
            //        if (Session[Session.SessionID + "elemento"] != null)
            //        {
            //            prue = (List<Articulo>)Session[Session.SessionID + "elemento"];
            //        }

            //        prue.Add(ar);
            //       Session.Add(Session.SessionID + "elemento", prue);
            //    }

            //}
            catch (Exception ex)
            {
                throw;
            }
            }
            
        protected void btnargumento_click(object sender, EventArgs e)
        {
            CarritoNegocio carrito = new CarritoNegocio();
            Articulo articulo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
              var articuloSeleccionado = Convert.ToInt32(((Button)sender).CommandArgument);
              ar = listaArticulo.Find(J => J.Id == articuloSeleccionado);

                if (Session[Session.SessionID + "elemento"] != null)
                {
                    prue = (Carrito)Session[Session.SessionID + "elemento"];
                }
                if(!prue.item.Exists(A => A.Id == ar.Id))
                {

                    prue.item.Add(ar);
                    prue.precioTotal += ar.Precio;
                    prue.cantidad++;
                    Session.Add(Session.SessionID + "elemento", prue);
                }
                
            }
            catch (Exception)
            {

            }


        }
    }
}