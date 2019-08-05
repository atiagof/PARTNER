using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teste_Partner.Models
{
    public class Marca
    {
        [Key]
        [Required(ErrorMessage = "Campo Marca obrigatório!")]
        public int MARCA_ID { get; set; }

        [Required(ErrorMessage = "Campo nome obrigatório!")]
        public string NOME { get; set; }

        public Marca(int marcaid, string nome)
        {
            this.MARCA_ID = marcaid;
            this.NOME = nome;
        }

        private Marca() { }
    }
}