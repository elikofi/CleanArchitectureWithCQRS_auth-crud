using Application.Common.Interfaces.Services;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    //public class BCryptPasswordHasher<TUser> : IPasswordHasher<User> where TUser : class
    //{
    //    public string HashPassword(TUser user, string password)
    //    {
    //        return BCrypt.Net.BCrypt.HashPassword(password, 12);
    //    }

    //    public PasswordVerificationResult VerifyHashedPassword(
    //      TUser user, string hashedPassword, string providedPassword)
    //    {
    //        var isValid = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);

    //        if (isValid && BCrypt.Net.BCrypt.PasswordNeedsRehash(hashedPassword, 12))
    //        {
    //            return PasswordVerificationResult.SuccessRehashNeeded;
    //        }

    //        return isValid ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
    //    }
    //}
}



//// verifying a hashed password

//var verificationResult = passwordHasher.VerifyHashedPassword(user, hashedPasswordFromDatabase, providedPassword);

//if (verificationResult == PasswordVerificationResult.Success)
//{
//    // Password is correct
//}
//else if (verificationResult == PasswordVerificationResult.SuccessRehashNeeded)
//{
//    // Password is correct, but needs to be rehashed
//    // You can rehash and update the password in your storage
//}
//else
//{
//    // Password is incorrect
//}