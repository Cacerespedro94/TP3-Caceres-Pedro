using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP3_Caceres_Pedro
{
    public partial class SiteMaster : MasterPage
    {
        Carrito prue = new Carrito();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Session.SessionID + "elemento"] != null)
            {
                prue = (Carrito)Session[Session.SessionID + "elemento"];

            }
            Conta.Text = prue.cantidad.ToString();

        }
    }
}