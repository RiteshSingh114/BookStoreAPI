using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUp(SignupModel signupModel);
    }
}
