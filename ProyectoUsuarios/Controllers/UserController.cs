using ProyectoUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;

namespace ProyectoUsuarios.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1")]

    public class UserController : ApiController
    {
        string CadenaSQL = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnectionString"].ToString();
        
        [HttpGet]
        [Route("getAllUsers")]
        public HttpResponseMessage GetAllUsers()
        {
            List<User> ListaUsuarios = new List<User>();
            try
            {
                SqlConnection conn = new SqlConnection(CadenaSQL);
                conn.Open();
                SqlCommand cmd = new SqlCommand("stp_GetAllUsers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListaUsuarios.Add(new User 
                    {
                        id = int.Parse(dr["id"].ToString()),
                        Nombre = dr["Nombre"].ToString(),
                        Paterno = dr["Paterno"].ToString(),
                        Materno = dr["Materno"].ToString(),
                        CURP = dr["CURP"].ToString(),
                        EdoCivil = dr["EdoCivil"].ToString(),
                        Genero = dr["Genero"].ToString(),
                        ImgSRC = dr["ImgSRC"].ToString(),
                        Alternative = dr["Alternative"].ToString()
                    });
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Request.CreateResponse(HttpStatusCode.OK, ListaUsuarios);
        }

        [HttpGet]
        [Route("getUserById/{id}")]
        public HttpResponseMessage GetUserById(int id)
        {
            List<User> ListaUsuarios = new List<User>();
            try
            {
                SqlConnection conn = new SqlConnection(CadenaSQL);
                conn.Open();
                SqlCommand cmd = new SqlCommand("stp_GetUserById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListaUsuarios.Add(new User
                    {
                        id = int.Parse(dr["id"].ToString()),
                        Nombre = dr["Nombre"].ToString(),
                        Paterno = dr["Paterno"].ToString(),
                        Materno = dr["Materno"].ToString(),
                        CURP = dr["CURP"].ToString(),
                        EdoCivil = dr["EdoCivil"].ToString(),
                        Genero = dr["Genero"].ToString(),
                        ImgSRC = dr["ImgSRC"].ToString(),
                        Alternative = dr["Alternative"].ToString()
                    });
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Request.CreateResponse(HttpStatusCode.OK, ListaUsuarios);
        }

        [HttpPost]
        [Route("addUser")]
        public HttpResponseMessage AddUser(User NewUser)
        {
            User User = new User();
            try
            {
                SqlConnection conn = new SqlConnection(CadenaSQL);
                conn.Open();
                SqlCommand cmd = new SqlCommand("stp_AddUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", NewUser.Nombre);
                cmd.Parameters.AddWithValue("@Paterno", NewUser.Paterno);
                cmd.Parameters.AddWithValue("@Materno", NewUser.Materno);
                cmd.Parameters.AddWithValue("@CURP", NewUser.CURP);
                cmd.Parameters.AddWithValue("@EdoCivil", NewUser.EdoCivil);
                cmd.Parameters.AddWithValue("@Genero", NewUser.Genero);
                cmd.Parameters.AddWithValue("@ImgSRC", NewUser.ImgSRC);
                cmd.Parameters.AddWithValue("@Alternative", NewUser.Alternative);
                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    User.id = int.Parse(dr["id"].ToString());
                    User.Nombre = dr["Nombre"].ToString();
                    User.Paterno = dr["Paterno"].ToString();
                    User.Materno = dr["Materno"].ToString();
                    User.CURP = dr["CURP"].ToString();
                    User.EdoCivil = dr["EdoCivil"].ToString();
                    User.Genero = dr["Genero"].ToString();
                    User.ImgSRC = dr["ImgSRC"].ToString();
                    User.Alternative = dr["Alternative"].ToString();
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Request.CreateResponse(HttpStatusCode.OK, User);
        }

        [HttpPut]
        [Route("updateUserById")]
        public HttpResponseMessage UpdateUserById(User NewUser)
        {
            List<User> ListaUsuarios = new List<User>();
            try
            {
                SqlConnection conn = new SqlConnection(CadenaSQL);
                conn.Open();
                SqlCommand cmd = new SqlCommand("stp_UpdateUserById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", NewUser.id);
                cmd.Parameters.AddWithValue("@Nombre", NewUser.Nombre);
                cmd.Parameters.AddWithValue("@Paterno", NewUser.Paterno);
                cmd.Parameters.AddWithValue("@Materno", NewUser.Materno);
                cmd.Parameters.AddWithValue("@CURP", NewUser.CURP);
                cmd.Parameters.AddWithValue("@EdoCivil", NewUser.EdoCivil);
                cmd.Parameters.AddWithValue("@Genero", NewUser.Genero);
                cmd.Parameters.AddWithValue("@ImgSRC", NewUser.ImgSRC);
                cmd.Parameters.AddWithValue("@Alternative", NewUser.Alternative);
                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListaUsuarios.Add(new User
                    {
                        id = int.Parse(dr["id"].ToString()),
                        Nombre = dr["Nombre"].ToString(),
                        Paterno = dr["Paterno"].ToString(),
                        Materno = dr["Materno"].ToString(),
                        CURP = dr["CURP"].ToString(),
                        EdoCivil = dr["EdoCivil"].ToString(),
                        Genero = dr["Genero"].ToString(),
                        ImgSRC = dr["ImgSRC"].ToString(),
                        Alternative = dr["Alternative"].ToString()
                    });
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Request.CreateResponse(HttpStatusCode.OK, ListaUsuarios);
        }

        [HttpDelete]
        [Route("deleteUserByUrl/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            List<User> ListaUsuarios = new List<User>();
            try
            {
                SqlConnection conn = new SqlConnection(CadenaSQL);
                conn.Open();
                SqlCommand cmd = new SqlCommand("stp_DeleteUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListaUsuarios.Add(new User
                    {
                        id = int.Parse(dr["id"].ToString()),
                        Nombre = dr["Nombre"].ToString(),
                        Paterno = dr["Paterno"].ToString(),
                        Materno = dr["Materno"].ToString(),
                        CURP = dr["CURP"].ToString(),
                        EdoCivil = dr["EdoCivil"].ToString(),
                        Genero = dr["Genero"].ToString(),
                        ImgSRC = dr["ImgSRC"].ToString(),
                        Alternative = dr["Alternative"].ToString()
                    });
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (ListaUsuarios.Count > 0)
                return Request.CreateResponse(HttpStatusCode.OK, ListaUsuarios);
            else
                return Request.CreateResponse(HttpStatusCode.OK, "USUARIO ELIMINADO CORRECTAMENTE");            
        }
    }
}