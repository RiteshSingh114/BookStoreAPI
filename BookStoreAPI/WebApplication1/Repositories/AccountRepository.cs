using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<Users> _userManager;
        public AccountRepository(UserManager<Users> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> SignUp(SignupModel signupModel)
        {
            var user = new Users
            {
                FirstName = signupModel.FirstName,
                LastName = signupModel.Lastname,
                Email = signupModel.Email,
                UserName = signupModel.Email,
            };

            return await _userManager.CreateAsync(user, signupModel.Password);
        }
    }
}
