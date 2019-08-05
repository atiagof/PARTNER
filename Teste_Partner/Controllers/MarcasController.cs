using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Teste_Partner.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections;

namespace Teste_Partner.Controllers
{
    public class MarcasController : ApiController
    {

        private MeuContext db = new MeuContext();

        // GET: api/Marcas
        public List<Marca> Get()
        {
            return db.Marcas.ToList();
        }

        // GET: api/Marcas/5
        public Marca Get(int id)
        {
            return db.Marcas.Find(id);
        }

        // GET: api/Marcas/5
        public object GetPatrimonio(int id)
        {
            var LstPatrimoniosporMarcaId = (from ma in db.Marcas
                                            join pat in db.Patrimonios on ma.MARCA_ID equals pat.MARCA_ID
                                            where (ma.MARCA_ID == id)
                                            select new
                                            {
                                                MARCA_ID = pat.MARCA_ID,
                                                NOME = pat.NOME,
                                                DESCRICAO = pat.DESCRICAO,
                                                NUM_TOMBO = pat.NUM_TOMBO,
                                            }).ToList();

            return LstPatrimoniosporMarcaId;
        }

        // POST: api/Marcas
        public string Post([FromBody]Marca objMarca)
        {
            using (MeuContext MarcaContext = new MeuContext())
            {
                // Verifica se já existe marca registrada com o nome passado para o post.
                var MarcaIns = MarcaContext.Marcas.FirstOrDefault(acc => acc.NOME == objMarca.NOME);
                // Se a marca já foi cadastrada exibe a msg abaixo.
                if (MarcaIns != null)
                {
                    return "Já foi cadastrada marca com esse nome!";
                }
                // Se a marca não foi cadastrada efetua o cadastro no bd.
                MarcaContext.Marcas.Add(objMarca);
                MarcaContext.SaveChanges();
            }
            return "Marca cadastrada com sucesso!";
        }

        // PUT: api/Marcas/5
        public string Put(int id, [FromBody]Marca objMarca)
        {
            using (MeuContext MarcaContext = new MeuContext())
            {
                // Recupera a marca que vai ser alterada.
                var MarcaUpd = MarcaContext.Marcas.FirstOrDefault(m => m.MARCA_ID == id);

                // Recupera a marca para alterar
                if (MarcaUpd != null)
                {
                    // Verifica se já existe marca registrada com o nome passado para o post.
                    var MarcaExist = MarcaContext.Marcas.FirstOrDefault(acc => acc.NOME == objMarca.NOME);
                    // Se a marca já foi cadastrada exibe a msg abaixo.
                    if (MarcaExist != null)
                    {
                        return "Já foi cadastrada marca com esse nome!";
                    }
                    // Efetua a alteração do nome da marca no bd.
                    MarcaUpd.NOME = objMarca.NOME;
                    MarcaContext.SaveChanges();

                    return "Marca alterada com sucesso!";
                }
            }

            return "Não existe a Marca informada. A alteração não foi efetuada!";
        }

        // DELETE: api/Marcas/5
        public string Delete(int id)
        {
            using (MeuContext MarcaContext = new MeuContext())
            {
                // Recupera a marca que vai ser alterada.
                var MarcaDel = MarcaContext.Marcas.FirstOrDefault(m => m.MARCA_ID == id);

                // Recupera a marca para alterar
                if (MarcaDel != null)
                {
                    // Efetua a alteração do nome da marca no bd.
                    MarcaContext.Marcas.Remove(MarcaDel);
                    MarcaContext.SaveChanges();

                    return "Marca removida com sucesso!";
                }
            }
            return "Não existe a Marca informada. A exclusão não foi efetuada!";
        }
    }
}
