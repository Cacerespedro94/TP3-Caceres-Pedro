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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaProductos = negocio.listar2();
                List<Articulo> listaArticulo;
                List<Articulo> prue = new List<Articulo>();
                listaArticulo = negocio.listar2();
                Articulo ar = new Articulo();
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
                
                if(Request.QueryString["IdProducto"]!=null)
                {
                   var pokeSeleccionado = Convert.ToInt32(Request.QueryString["IdProducto"]);
                   ar = listaArticulo.Find(J => J.Id == pokeSeleccionado);
                    if(Session[Session.SessionID + "elemento"]!=null)
                    {
                       prue = (List<Articulo>)Session[Session.SessionID + "elemento"];
                    }
                    prue.Add(ar);
                   Session.Add(Session.SessionID + "elemento", prue);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void btnargumento_click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            string args = btn.CommandArgument;
            






        }
    }
}