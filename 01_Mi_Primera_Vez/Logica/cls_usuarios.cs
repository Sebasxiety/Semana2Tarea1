using _01_Mi_Primera_Vez.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Mi_Primera_Vez.Logica
{
    internal class cls_usuarios
    {
        private readonly conexion _conexion = new conexion();

        public bool InsertUsuario(dto_usuarios usuario)
        {
            using (SqlConnection con = _conexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Cedula", usuario.Cedula);
                cmd.Parameters.AddWithValue("@NombresApellidos", usuario.NombresApellidos);
                cmd.Parameters.AddWithValue("@DireccionDomicilio", usuario.DireccionDomicilio);
                cmd.Parameters.AddWithValue("@CodigoPostal", usuario.CodigoPostal);
                cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                cmd.Parameters.AddWithValue("@IdPais", usuario.Pais);

                SqlParameter outputIdParam = new SqlParameter
                {
                    ParameterName = "@IdUsuario",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                usuario.IdUsuario = (int)outputIdParam.Value;
                return rowsAffected > 0;
            }
        }

        public DataTable GetUsuarios()
        {
            using (SqlConnection con = _conexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_GetUsuarios", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable usuarios = new DataTable();
                adapter.Fill(usuarios);
                return usuarios;
            }
        }

        public dto_usuarios GetUsuarioById(int idUsuario)
        {
            using (SqlConnection con = _conexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_GetUsuarioById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new dto_usuarios
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Cedula = reader["Cedula"].ToString(),
                        NombresApellidos = reader["NombresApellidos"].ToString(),
                        DireccionDomicilio = reader["DireccionDomicilio"].ToString(),
                        CodigoPostal = reader["CodigoPostal"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                        Pais = Convert.ToInt32(reader["IdPais"])
                    };
                }
                return null;
            }
        }

        public bool UpdateUsuario(dto_usuarios usuario)
        {
            using (SqlConnection con = _conexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@Cedula", usuario.Cedula);
                cmd.Parameters.AddWithValue("@NombresApellidos", usuario.NombresApellidos);
                cmd.Parameters.AddWithValue("@DireccionDomicilio", usuario.DireccionDomicilio);
                cmd.Parameters.AddWithValue("@CodigoPostal", usuario.CodigoPostal);
                cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                cmd.Parameters.AddWithValue("@IdPais", usuario.Pais);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool DeleteUsuario(int idUsuario)
        {
            using (SqlConnection con = _conexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
