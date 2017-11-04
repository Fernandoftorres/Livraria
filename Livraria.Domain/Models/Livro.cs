using System;
using Livraria.Domain.Core.Models;

namespace Livraria.Domain.Models
{
    public class Livro : Entity
    {
        /// <summary>
        /// Método responsável por criar uma nova instância do objeto Livro
        /// </summary>
        /// <param name="id">Identificador único gerado automaticamente</param>
        /// <param name="titulo">Título do livro</param>
        /// <param name="autor">Autor do livro</param>
        /// <param name="anoPublicacao">Ano em que o livro foo publicado</param>
        /// <param name="quantidade">Quantidade de livros encontrados</param>
        public Livro(Guid id, string titulo, string autor, int anoPublicacao, int quantidade)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            Quantidade = quantidade;
        }

        /// <summary>
        /// Método usado para criação da classe pelo Entity Framework
        /// </summary>
        protected Livro() { }

        public string Titulo { get; private set; }

        public string Autor { get; private set; }

        public int AnoPublicacao { get; private set; }

        public int Quantidade { get; set; }
    }
}