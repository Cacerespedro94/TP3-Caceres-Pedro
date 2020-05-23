using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
namespace Negocio

{
    public class CategoriaNegocio
    {
        public List<Categoria> ListarCategoria()
        {

            List<Categoria> listadoCategoria = new List<Categoria>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source= DESKTOP-PJFNJ5R\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Id, Descripcion from CATEGORIAS";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = lector.GetInt32(0);
                    aux.Descripcion = lector.GetString(1);
                    

                    listadoCategoria.Add(aux);
                }

                return listadoCategoria;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
