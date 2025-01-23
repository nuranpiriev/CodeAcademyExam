using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCake.BL.DTOs.UserDTOs
{
    public record RegisterUserDTO
    {
        [Display(Prompt ="Username")]
        public string UserName { get; set; }
        [Display(Prompt ="Password")]
        [DataType(DataType.Password)]
       
        public string Password { get; set; }
        [Display(Prompt ="Confirm Password")] 
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Display(Prompt ="Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAdress {  get; set; }

    }
    public class RegisterUserDTOValidation : AbstractValidator<RegisterUserDTO>
    {
        public RegisterUserDTOValidation()
        {
            RuleFor(u => u.EmailAdress).NotEmpty().WithMessage("Email is required");
            RuleFor(u => u.EmailAdress).EmailAddress().WithMessage("A valid email adress is required");
            RuleFor(u => u.UserName).NotEmpty().WithMessage("User name is required")
            .MinimumLength(4).WithMessage("user name must be greater than 4 charactericts long");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Password is reuired")
            .MinimumLength(5).WithMessage("Password must be 5 chrcteristc long").MinimumLength(5).WithMessage("Password must be 5 chrcteristc long");
            RuleFor(u => u.ConfirmPassword).Equal(u => u.Password).WithMessage("Passwords dont match")
            .WithMessage("Confirm Password is reuired");
            

        } }
}
