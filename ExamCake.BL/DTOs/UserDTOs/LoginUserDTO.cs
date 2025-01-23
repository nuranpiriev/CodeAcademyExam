using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCake.BL.DTOs.UserDTOs
{
    public record LoginUserDTO
    {
        [Display(Prompt ="User name")]
        public string UserName { get; set; }
        [Display(Prompt ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe {  get; set; }
    }
    public class LoginUserDTOValidation : AbstractValidator<LoginUserDTO>
    {
        public LoginUserDTOValidation()
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage("User name is required");
            RuleFor(u => u.UserName).MinimumLength(4).WithMessage("user name must be greater than 4 charactericts long");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Password is reuired");
            RuleFor(u => u.Password).MinimumLength(5).WithMessage("Password must be 5 chrcteristc long");


        }
    }
}
