using AutoMapper;
using ExamCake.BL.DTOs.UserDTOs;
using ExamCake.BL.Services.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCake.BL.Services.Concrets
{
    public class AccountService : IAccountService
    {
        readonly UserManager<IdentityUser> _userManager;
        readonly SignInManager<IdentityUser> _signInManager;
        readonly IMapper _mapper;

        public AccountService(IMapper mapper, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task RegisterAsync(RegisterUserDTO dto)
        {
            if (await _userManager.FindByNameAsync(dto.UserName) is not null) throw new Exception("something went wrong");

            if (await _userManager.FindByEmailAsync(dto.EmailAdress) is not null) throw new Exception("something went wrong");

            IdentityUser user = _mapper.Map<IdentityUser>(dto);

            IdentityResult res = await _userManager.CreateAsync(user, dto.Password);

            if (!res.Succeeded) throw new Exception("Something went wrong");

            res = await _userManager.AddToRoleAsync(user, "user");

            if (!res.Succeeded) throw new Exception("Something went wrong");
        }

        public async Task LoginAsync(LoginUserDTO dto)
        {
            IdentityUser user = await _userManager.FindByNameAsync(dto.UserName) ?? throw new Exception("Something went wrong!");

            SignInResult res = await _signInManager.PasswordSignInAsync(user, dto.Password, dto.RememberMe, true);

            if (!res.Succeeded) throw new Exception("Something went wrong!");
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }

}
