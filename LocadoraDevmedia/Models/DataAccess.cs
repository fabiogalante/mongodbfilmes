using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LocadoraDevmedia.Models
{


    public class DataAccess
    {
        internal string conexao = "mongodb://estudos:10102030F@ds157971.mlab.com:57971/locadoradb";//"mongodb://127.0.0.1:27017";
        String uri = "mongodb://user:pass@host:port/db";
        private readonly MongoClient _cliente;
        private readonly IMongoDatabase _banco;
        private IMongoCollection<Filme> _collection;

        public DataAccess()
        {
            _cliente = new MongoClient(conexao);
            _banco = _cliente.GetDatabase("locadoradb");
            _collection = _banco.GetCollection<Filme>("Filmes");
        }

        public async Task<List<Filme>> GetFilmesAsync()
        {
            var lista = await _collection.Find(new BsonDocument()).ToListAsync();
            return lista;
        }
        public Filme GetFilmes(ObjectId _id)
        {
            var filter = Builders<Filme>.Filter.Eq("_id", _id);
            var filmeUnico = _collection.Find(filter).FirstOrDefault();
            return filmeUnico;
        }
        public Filme Create(Filme filme)
        {
            var adiciona = _collection.InsertOneAsync(filme);
            return filme;
        }
        public async Task<ReplaceOneResult> AtualizaFilme(string _id, Filme filme)
        {
            var codigo = new ObjectId(_id);
            return await _collection.ReplaceOneAsync(a => a._id == codigo, filme,
                new UpdateOptions { IsUpsert = true });
        }
        public async Task<DeleteResult> Remove(ObjectId id)
        {
            var query = Builders<Filme>.Filter.Eq(f => f._id, id);
            return await _collection.DeleteOneAsync(query);
        }




    }
}