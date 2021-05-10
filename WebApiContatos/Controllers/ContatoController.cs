using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using System.Data;
using WebApiContatos.Models;
using System.Data.SqlClient;

namespace WebApiContatos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ContatoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            List<Contato> listaContato = new List<Contato>();

            string connect = _configuration.GetConnectionString("AgendaDB");

            using (SqlConnection con = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand("stp_Contatos_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Contato usuario = new Contato
                    {
                        IdPessoa = Convert.ToInt32(rdr["idPessoa"]),
                        Nome = rdr["nome"].ToString(),
                        DataNascimento = Convert.ToDateTime(rdr["dataNascimento"].ToString()),
                        Observacoes = rdr["observacoes"].ToString(),
                        Telefone = rdr["telefone"].ToString(),
                        Email = rdr["email"].ToString()
                    };

                    listaContato.Add(usuario);
                }
                con.Close();
            }
            return new JsonResult(listaContato);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            List<Contato> listaContato = new List<Contato>();

            string connect = _configuration.GetConnectionString("AgendaDB");

            using (SqlConnection con = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand("stp_Contatos_Sel_Id", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@idPessoa", id);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Contato usuario = new Contato
                    {
                        IdPessoa = Convert.ToInt32(rdr["idPessoa"]),
                        Nome = rdr["nome"].ToString(),
                        DataNascimento = Convert.ToDateTime(rdr["dataNascimento"].ToString()),
                        Observacoes = rdr["observacoes"].ToString(),
                        Telefone = rdr["telefone"].ToString(),
                        Email = rdr["email"].ToString()
                    };

                    listaContato.Add(usuario);
                }
                con.Close();
            }
            return new JsonResult(listaContato);
        }

        [HttpPost]
        public JsonResult Post(Contato contato)
        {
            string connect = _configuration.GetConnectionString("AgendaDB");

            using (SqlConnection con = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand("stp_Contatos_Ins", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@Nome", contato.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", contato.DataNascimento);
                cmd.Parameters.AddWithValue("@Observacoes", contato.Observacoes);
                cmd.Parameters.AddWithValue("@Telefone", contato.Telefone);
                cmd.Parameters.AddWithValue("@Email", contato.Email);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public void Edit(Contato contato)
        {
            string connect = _configuration.GetConnectionString("AgendaDB");

            using (SqlConnection con = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand("stp_Contatos_Upd", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@idPessoa", contato.IdPessoa);
                cmd.Parameters.AddWithValue("@Nome", contato.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", contato.DataNascimento);
                cmd.Parameters.AddWithValue("@Observacoes", contato.Observacoes);
                cmd.Parameters.AddWithValue("@Telefone", contato.Telefone);
                cmd.Parameters.AddWithValue("@Email", contato.Email);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int? id)
        {
            string connect = _configuration.GetConnectionString("AgendaDB");

            using (SqlConnection con = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand("stp_Contatos_Del", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@idPessoa", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
