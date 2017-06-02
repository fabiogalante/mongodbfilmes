using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using LocadoraDevmedia.Models;
using MongoDB.Bson;

namespace LocadoraDevmedia.Controllers
{
    public class FilmesController : ApiController
    {
        private readonly DataAccess _dataAccess;
        public FilmesController()
        {
            _dataAccess = new DataAccess();
        }
        public async Task<IEnumerable<Filme>> Get()
        {
            return await _dataAccess.GetFilmesAsync();
        }
        public Filme Get(string _id)
        {
            var filme = _dataAccess.GetFilmes(new ObjectId(_id));
            return filme;
        }
        public Filme Post([FromBody]Filme filme)
        {
            _dataAccess.Create(filme);
            return filme;
        }
        public void Put(string _id, Filme filme)
        {
            _dataAccess.AtualizaFilme(_id, filme);
        }
        public void Delete(ObjectId id)
        {
            _dataAccess.Remove(id);
        }
    }
}