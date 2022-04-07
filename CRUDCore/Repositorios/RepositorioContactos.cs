using CRUDCore.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUDCore.Repositorios
{
    public class RepositorioContactos
    {
        //Metodo para leer la tabla
        public List<ContactoViewModel> Listar()
        {
            //Va a usar una coleccion tipo lista que recibe al modelo
            var lista = new List<ContactoViewModel>();
            //Cadena de conexion
            var cn = new Conexion();

            //Establecer la cadena de conexion
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                //Abrimos la conexion
                conexion.Open();
                //Estructura de los comandos a ejecutar 
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                //Le decimos al cmd que es un SP
                cmd.CommandType = CommandType.StoredProcedure;

                //Leer el resultado de la ejecucion del SP
                using (var dr = cmd.ExecuteReader())
                {
                    //Recorremos los registros uno a uno para agregarlos a la lista
                    while (dr.Read())
                    {
                        lista.Add(new ContactoViewModel()
                        {
                            //Llamamos a cada propiedad [columna a leer]
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                        });
                    }
                }
            }

            return lista;
        }

        public ContactoViewModel ObtenerId(int IdContacto)
        {

            var contacto = new ContactoViewModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        contacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        contacto.Nombre = dr["Nombre"].ToString();
                        contacto.Telefono = dr["Telefono"].ToString();
                        contacto.Correo = dr["Correo"].ToString();
                    }
                }
            }

            return contacto;
        }

        public bool Guardar(ContactoViewModel contacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    //Como este sp recibe varios parametros, debemos enviarselos
                    cmd.Parameters.AddWithValue("Nombre", contacto.Nombre);
                    cmd.Parameters.AddWithValue("Correo", contacto.Correo);
                    cmd.Parameters.AddWithValue("Telefono", contacto.Telefono);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Ejecutamos el procedimiento almacenado
                    cmd.ExecuteNonQuery();
                }

                //Si no hubo ningun error devolvemos true
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;               
            }

            return rpta;
        }

        public bool Editar(ContactoViewModel contacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    //Como este sp recibe varios parametros, debemos enviarselos
                    cmd.Parameters.AddWithValue("IdContacto", contacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", contacto.Nombre);
                    cmd.Parameters.AddWithValue("Correo", contacto.Correo);
                    cmd.Parameters.AddWithValue("Telefono", contacto.Telefono);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Ejecutamos el procedimiento almacenado
                    cmd.ExecuteNonQuery();
                }

                //Si no hubo ningun error devolvemos true
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar(int IdContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    //Como este sp recibe varios parametros, debemos enviarselos
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Ejecutamos el procedimiento almacenado
                    cmd.ExecuteNonQuery();
                }

                //Si no hubo ningun error devolvemos true
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

    }
}
