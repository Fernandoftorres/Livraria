using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Application.ViewModels
{
    public class LivroViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo título é obrigatório")]
        [MinLength(2, ErrorMessage ="Campo título inválido")]
        [MaxLength(100, ErrorMessage = "Campo título inválido")]
        [DisplayName("Titulo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo autor é obrigatório")]
        [MinLength(2, ErrorMessage = "Campo autor inválido")]
        [MaxLength(30, ErrorMessage = "Campo autor inválido")]
        [DisplayName("Autor")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O campo ano de publicação é obrigatório")]
        [DisplayName("Ano de publicação")]
        public int AnoPublicacao { get; set; }

        [Required(ErrorMessage = "O campo quantidade é obrigatório")]
        [DisplayName("Quantidade")]
        public int Quantidade { get; set; }
    }
}
