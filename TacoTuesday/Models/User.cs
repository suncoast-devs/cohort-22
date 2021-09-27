using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace TacoTuesday.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must provide your name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "You must provide your email")]
        public string Email { get; set; }

        [JsonIgnore]
        public string HashedPassword { get; set; }

        // Define a property for being able to _set_ a password
        //
        // someUserObject.Password = "secret";
        // Console.WriteLine(someUserObject.Password);   // this FAILS
        public string Password
        {
            // Define only the `set` aspect of the property
            set
            {
                // When set, use the PasswordHasher to encrypt the password
                // and store the result in our HashedPassword
                this.HashedPassword = new PasswordHasher<User>().HashPassword(this, value);
            }
        }

        // Add a method that can validate this user's password
        //
        // bool isLoggedIn = someUserObject.IsValidPassword("sekret"); // false
        // bool isLoggedIn = someUserObject.IsValidPassword("secret"); // true
        public bool IsValidPassword(string password)
        {
            // Look to see if this password, and the user's hashed password can match
            var passwordVerification = new PasswordHasher<User>().VerifyHashedPassword(this, this.HashedPassword, password);

            // Return True if the verification was a success
            return passwordVerification == PasswordVerificationResult.Success;
        }
    }
}