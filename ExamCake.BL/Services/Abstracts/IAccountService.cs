using ExamCake.BL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCake.BL.Services.Abstracts
{
    public interface IAccountService
    {
        Task LoginAsync(LoginUserDTO dto);
        Task RegisterAsync(RegisterUserDTO dto);
        Task LogoutAsync();
    }
}
