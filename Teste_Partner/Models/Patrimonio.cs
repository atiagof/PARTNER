using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teste_Partner.Models
{
    public class Patrimonio
    {
        [Key]
        public int PATRIMONIO_ID { get; set; }

        [Required(ErrorMessage = "Campo nome obrigatório!")]
        public string NOME { get; set; }

        [Required(ErrorMessage = "Campo Marca obrigatório!")]
        public int MARCA_ID { get; set; }

        public string DESCRICAO { get; set; }

        public int NUM_TOMBO { get; set; }

        public Patrimonio(string nome, int marcaid, string descricao, int tombo)
        {
            this.NOME = nome;
            this.MARCA_ID = marcaid;
            this.DESCRICAO = descricao;
            this.NUM_TOMBO = tombo;
        }

        private Patrimonio() { }
    }
}