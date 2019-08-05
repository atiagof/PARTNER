using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Teste_Partner.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Teste_Partner.Controllers
{
    public class PatrimonioController : ApiController
    {
        private MeuContext db = new MeuContext();

        // GET: api/Patrimonio
        public List<Patrimonio> Get()
        {
            return db.Patrimonios.ToList();
        }

        // GET: api/Patrimonio/5
        public Patrimonio Get(int id)
        {
            return db.Patrimonios.Find(id);
        }

        // POST: api/Patrimonio
        public string Post([FromBody]Patrimonio objPatrimonio)
        {
            using (MeuContext PatrimonioContext = new MeuContext())
            {
                // Verifica se já existe patrimonio registrado com o nome passado para o post.
                var PatrimonioIns = PatrimonioContext.Patrimonios.FirstOrDefault(acc => acc.NOME == objPatrimonio.NOME);
                Random random = new Random();
                var rnd =  random.Next(1, 1000000);
                objPatrimonio.NUM_TOMBO = rnd;

                // Se o patrimonio já foi cadastrado exibe a msg abaixo.
                if (PatrimonioIns != null)
                {
                    return "Já foi cadastrado patrimônio com esse nome!";
                }
                // Se o patrimonio não foi cadastrado efetua o cadastro no bd.
                PatrimonioContext.Patrimonios.Add(objPatrimonio);
                PatrimonioContext.SaveChanges();
            }
            return "Patrimonio cadastro efetuado com sucesso!";
        }

        // PUT: api/Patrimonio/5
        public string Put(int id, [FromBody]Patrimonio objPatrimonio)
        {
            using (MeuContext PatrimonioContext = new MeuContext())
            {
                // Recupera o patrimonio que vai ser alterado.
                var PatrimonioUpd = PatrimonioContext.Marcas.FirstOrDefault(m => m.MARCA_ID == id);

                // Recupera o patrimonio para alterar
                if (PatrimonioUpd != null)
                {
                    // Verifica se já existe o patrimonio registrado com o nome passado para o post.
                    var PatrimonioExist = PatrimonioContext.Marcas.FirstOrDefault(acc => acc.NOME == objPatrimonio.NOME);
                    // Se o patrimonio já foi cadastrado exibe a msg abaixo.
                    if (PatrimonioExist != null)
                    {
                        return "Já foi cadastrado patrimonio com esse nome!";
                    }
                    // Efetua a alteração do nome do patrimonio no bd.
                    PatrimonioUpd.NOME = objPatrimonio.NOME;
                    PatrimonioContext.SaveChanges();

                    return "Patrimonio alterado com sucesso!";
                }
            }
            return "Não existe o Patrimonio informado. A alteração não foi efetuada!";
        }

        // DELETE: api/Patrimonio/5
        public string Delete(int id)
        {
            using (MeuContext PatrimonioContext = new MeuContext())
            {
                // Recupera o patrimonio que vai ser removido.
                var PatrimonioDel = PatrimonioContext.Patrimonios.FirstOrDefault(m => m.PATRIMONIO_ID == id);

                // Recupera o patrimonio para remover.
                if (PatrimonioDel != null)
                {
                    // Efetua o patrimonio no bd.
                    PatrimonioContext.Patrimonios.Remove(PatrimonioDel);
                    PatrimonioContext.SaveChanges();

                    return "Patrimonio removido com sucesso!";
                }
            }
            return "Não existe o Patrimonio informado. A exclusão não foi efetuada!";
        }
    }
}
