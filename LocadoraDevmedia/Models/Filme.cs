using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LocadoraDevmedia.Models
{
    public class Filme
    {
        public ObjectId _id { get; set; }
         [BsonElement("FilmeId")]
         public int FilmeId { get; set; }
         [BsonElement("Titulo")]
         public string Titulo { get; set; }
         [BsonElement("Preco")]
         public int Preco { get; set; }
         [BsonElement("Categoria")]
         public string Categoria { get; set; }
    }
}