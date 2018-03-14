using AluraTunes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AluraTunes
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Linq To Entity
            //using (var contexto = new AluraTunesEntities())
            //{
            //    var query = from g in contexto.Generos
            //                select g;

            //    foreach (var genero in query)
            //    {
            //        Console.WriteLine("{0}\t{1}", genero.GeneroId, genero.Nome);
            //    }
            //    Console.WriteLine();

            //    var faixaEGenero = from g in contexto.Generos
            //                       join f in contexto.Faixas on g.GeneroId equals f.GeneroId
            //                       select new
            //                       {
            //                           f,
            //                           g
            //                       };

            //    faixaEGenero = faixaEGenero.Take(10);

            //    contexto.Database.Log = Console.WriteLine;

            //    foreach (var item in faixaEGenero)
            //    {
            //        Console.WriteLine("{0}\t{1}", item.f.Nome, item.g.Nome);
            //    }

            //}

            using (var contexto = new AluraTunesEntities())
            {
                var textoBusca = "Led";

                var query = from a in contexto.Artistas
                            join alb in contexto.Albums on a.ArtistaId equals alb.ArtistaId
                            where a.Nome.Contains(textoBusca)
                            select new
                            {
                               NomeArtista = a.Nome,
                               NomeAlbum = alb.Titulo
                            };

                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}",item.NomeArtista, item.NomeAlbum);
                }
                Console.WriteLine();

                var query2 = contexto.Artistas.Where(a => a.Nome.Contains(textoBusca));
                foreach (var item in query2)
                {
                    Console.WriteLine("{0}\t{1}", item.ArtistaId, item.Nome);
                }
                Console.WriteLine();
            }

            #endregion


            #region Linq To XML
            //XElement root = XElement.Load(@"C:\Dev\Estudos\AluraTunes\AluraTunes\Data\AluraTunes.xml");
            //var queryXML = from g in root.Element("Generos").Elements("Genero")
            //               select g;

            //foreach (var genero in queryXML)
            //{
            //    Console.WriteLine("{0}\t{1}", genero.Element("GeneroId").Value, genero.Element("Nome").Value);
            //}
            //Console.WriteLine();

            //var query = from g in root.Element("Generos").Elements("Genero")
            //            join m in root.Element("Musicas").Elements("Musica") 
            //                on g.Element("GeneroId").Value equals m.Element("GeneroId").Value
            //            select new
            //            {
            //                Musica = m.Element("Nome").Value,
            //                Genero = g.Element("Nome").Value
            //            };

            //foreach (var musicaEGenero in query)
            //{
            //    Console.WriteLine("{0}\t{1}", musicaEGenero.Musica, musicaEGenero.Genero);
            //} 
            #endregion
            #region Linq To Object

            //IList<Genero> generos = new List<Genero>
            //{
            //    new Genero{ Id = 1, Nome = "Rock"},
            //    new Genero{ Id = 2, Nome = "Reggae"},
            //    new Genero{ Id = 3, Nome = "Rock Progressivo"},
            //    new Genero{ Id = 4, Nome = "Punk Rock"},
            //    new Genero{ Id = 5, Nome = "Clássica"},
            //};

            //foreach (var genero in generos)
            //{
            //    if (genero.Nome.Contains("Rock"))
            //    {
            //        Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
            //    }
            //}
            //Console.WriteLine();
            //var query = from g in generos
            //            where g.Nome.Contains("Rock")
            //            select g;

            //foreach (var genero in query)
            //{
            //    Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
            //}
            //Console.WriteLine();
            //IList<Musica> musicas = new List<Musica>
            //{
            //    new Musica { Id = 1, Nome= "Sweet Chield O'Mine", GeneroId = 1 },
            //    new Musica { Id = 2, Nome = "I Shot The Sheriff", GeneroId = 2},
            //    new Musica { Id = 3, Nome = "Danúbio Azul", GeneroId = 5},
            //};

            //var musicaQuery = from m in musicas
            //                  join g in generos on m.GeneroId equals g.Id
            //                  select new {
            //                      m,
            //                      g
            //                  };

            //foreach (var musica in musicaQuery)
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}", musica.m.Id, musica.m.Nome, musica.g.Nome);
            //} 
            #endregion
        }
    }
    #region Linq To Object

    //class Genero
    //{
    //    public int Id { get; set; }
    //    public string Nome { get; set; }
    //}

    //class Musica
    //{
    //    public int Id { get; set; }
    //    public string Nome { get; set; }
    //    public int GeneroId { get; set; }
    //} 
    #endregion
}
