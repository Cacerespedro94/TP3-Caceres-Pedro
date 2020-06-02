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
        ArticuloNegocio negocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                listaProductos = negocio.listar2();
                
                listaArticulo = negocio.listar2();

                if (!IsPostBack)
                { //pregunto si es la primera carga de la page


                    //esto es lo que necesitamos para el repeater.
                    repetidor.DataSource = listaProductos;
                    repetidor.DataBind();
              
                }
                else
                {
              
                    if (txtBuscador.Text != "")
                    {
                        repetidor.DataSource = (List<Articulo>)Session[Session.SessionID + "filtrado"];
                        repetidor.DataBind();

                    }
                    else
                    {
                        repetidor.DataSource = listaProductos;
                        repetidor.DataBind();
                    }
                }

            }

            catch (Exception)
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
                if (!prue.item.Exists(A => A.Id == ar.Id))
                {

                    prue.item.Add(ar);
                    prue.precioTotal += ar.Precio;
                    prue.cantidad++;
                    Session.Add(Session.SessionID + "elemento", prue);
                }
                {

                }
                Response.Redirect("ListaDeProductos.aspx");
            }
            catch (Exception)
            {

            }


        }
        protected void Buscador_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            try
            {
                listaProductos = negocio.listar2();
                if (txtBuscador.Text == "")
                {
                    listaFiltrada = listaProductos;
                    Session.Add(Session.SessionID + "filtrado", listaFiltrada);
                    repetidor.DataSource = listaFiltrada;
                    repetidor.DataBind();

                }
                else
                {
                    listaFiltrada = listaProductos.FindAll(k => k.Nombre.ToLower().Contains(txtBuscador.Text.ToLower()) ||
                      k.Marca.Descripcion.ToLower().Contains(txtBuscador.Text.ToLower()) ||
                      k.Categoria.Descripcion.ToLower().Contains(txtBuscador.Text.ToLower()) ||
                      k.Codigo.ToLower().Contains(txtBuscador.Text.ToLower()));
                    Session.Add(Session.SessionID + "filtrado", listaFiltrada);
                    repetidor.DataSource = listaFiltrada;
                    repetidor.DataBind();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}