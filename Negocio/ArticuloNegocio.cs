using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Dominio;
using System.Data.SqlClient;




namespace Negocio
{
    public class ArticuloNegocio
    {
       
        

        public void Agregar(Articulo nuevo)
        {
         

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                    conexion.ConnectionString = "data source= DESKTOP-PJFNJ5R\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = "insert into ARTICULOS (Nombre, Codigo, Descripcion, IdCategoria, IdMarca, ImagenUrl, Precio) Values (@Nombre,@Codigo,@Descripcion,@IdCategoria,@IdMarca,@ImagenUrl,@Precio)";
                    comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                    comando.Parameters.AddWithValue("@Codigo", nuevo.Codigo);
                    comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
                    comando.Parameters.AddWithValue("@IdCategoria", nuevo.Categoria.Id.ToString());
                    comando.Parameters.AddWithValue("@IdMarca", nuevo.Marca.Id.ToString());
                    comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
                    comando.Parameters.AddWithValue("@ImagenUrl", nuevo.ImagenUrl);

                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("delete from Articulos where id =" + id);
                datos.ejecutarAccion();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Update ARTICULOS set Codigo=@Codigo,Nombre=@Nombre, Descripcion=@Descripcion, ImagenURL=@ImagenURL, Precio=@Precio, IdMarca=@IdMarca, IdCategoria = @IdCategoria where Id=@Id");
                datos.agregarParametro("@Codigo", articulo.Codigo);
                datos.agregarParametro("@Nombre", articulo.Nombre);
                datos.agregarParametro("@Id", articulo.Id);
                datos.agregarParametro("@IdMarca", articulo.Marca.Id);
                datos.agregarParametro("IdCategoria", articulo.Categoria.Id);
                datos.agregarParametro("@Descripcion", articulo.Descripcion);
                datos.agregarParametro("@ImagenURL", articulo.ImagenUrl);
                datos.agregarParametro("@Precio", articulo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Articulo> listar2()
        {
            List<Articulo> listadoArticulo = new List<Articulo>();
            Articulo aux;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("select a.id, a.codigo, a.Nombre, a.Descripcion, a.ImagenUrl, a.Precio, m.Descripcion as DescMarca, m.Id as IdMarca, C.Descripcion as DescCat, C.Id as IdCat from Articulos as A inner join MARCAS as M on m.Id = a.IdMarca inner join Categorias as C on C.Id = a.IdCategoria");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    aux = new Articulo();
                    aux.Id = datos.lector.GetInt32(0);
                    aux.Codigo = datos.lector.GetString(1);
                    aux.Nombre = datos.lector.GetString(2);
                    aux.Descripcion = datos.lector.GetString(3);
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.lector["DescMarca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.lector["DescCat"];
                    aux.Categoria.Id = datos.lector.GetInt32(9);
                    aux.Marca.Id = datos.lector.GetInt32(7);
                    aux.ImagenUrl = datos.lector.GetString(4);
                    aux.Precio = Decimal.Round((decimal)datos.lector["Precio"], 3);

                    listadoArticulo.Add(aux);
                }    


                
                
                return listadoArticulo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
          
        }
        
    }
}
