using System;
using System.ComponentModel.DataAnnotations;

namespace jobRegister.Models.UserModel
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Este campo deve conter no mínimo 6 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Role { get; set; } = "user";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
