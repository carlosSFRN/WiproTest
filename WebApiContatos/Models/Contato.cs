using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiContatos.Models
{
    public class Contato
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Observacoes { get; set; }
        public string Telefone  { get; set; }
        public string Email { get; set; }
    }
}
