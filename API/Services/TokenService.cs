using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService (IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        // This function creates a JWT token for a given user using the provided user information.
        public string CreateToken(AppUser user)
        {
            // Create a list of claims, which are individual pieces of information about the user.
            var claims = new List<Claim>
            {
                 // Add a claim representing the user's username as a "NameId" claim.
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };

            // Create signing credentials for the token using a cryptographic key and the HMACSHA512 signature algorithm.
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            // Create a token descriptor that defines the properties of the token to be generated.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // Set the claims that will be included in the token.
                Subject = new ClaimsIdentity(claims),

                // Set the expiration time for the token. In this case, the token will expire after 7 days from the current time.
                Expires = DateTime.Now.AddDays(7),

                // Set the signing credentials to be used when creating the token's digital signature.
                SigningCredentials = creds
            };

            // Create an instance of the JwtSecurityTokenHandler, which is used to create and manipulate JWT tokens.
            var tokenHandler = new JwtSecurityTokenHandler();

            // Create a JWT token based on the provided token descriptor.
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Write the token as a string and return it.
            return tokenHandler.WriteToken(token);
        }
    }
}
