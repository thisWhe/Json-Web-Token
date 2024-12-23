using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Projec12_JwtToken.JWT
{
    public class TokenGenerator
    {
        public string GenereateJwtToken(string username, string email, string name, string surname)
        { // securityKey Token için oluşturdugumuz imza gibi key olusturmak gibi
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                ("20Derste20ProjeToken+-*/1234tokenJWT"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); // securityKeyi ve token olustururken sifreleme algoritmasını tutuyo 
            var claimExample = new[] // bu dizi ise tokenın temel parametlerimizi tutuyo
            {                        // sub id icin kullanılan parametre
                new Claim(JwtRegisteredClaimNames.Sub,username), // id
                new Claim(JwtRegisteredClaimNames.Email,email),
                new Claim(JwtRegisteredClaimNames.GivenName,name),  // given name isim 
                new Claim(JwtRegisteredClaimNames.FamilyName,surname), // familyname soyad
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

            };

            var token = new JwtSecurityToken( // bu token değişkeni ise tokenımızın yayıncısını ve dinleyicisini
                issuer: "localhost", // token yayıncısı yani kim tarafından olusturuldu
                audience: "localhost", // token dinleyicisi kim dinliyo
                claims: claimExample, // bu tokenın parametreleri nereden geliyo claimExampledan geliyor
                expires: DateTime.Now.AddMinutes(5), // token ne zamana kadar gecerli
                signingCredentials: credentials); // tokenın sifreleme algoritmasının i neler
            
            return new JwtSecurityTokenHandler().WriteToken(token); // tokenımız olustu
        }

        public string GenereateJwtToken2(string username)
        { // securityKey Token için oluşturdugumuz imza gibi key olusturmak gibi
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                ("20Derste20ProjeToken+-*/1234tokenJWT"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); // securityKeyi ve token olustururken sifreleme algoritmasını tutuyo 
            var claimExample = new[] // bu dizi ise tokenın temel parametlerimizi tutuyo
            {                        // sub id icin kullanılan parametre
                new Claim(JwtRegisteredClaimNames.Sub,username), // id
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

            };

            var token = new JwtSecurityToken( // bu token değişkeni ise tokenımızın yayıncısını ve dinleyicisini
                issuer: "localhost", // token yayıncısı yani kim tarafından olusturuldu
                audience: "localhost", // token dinleyicisi kim dinliyo
                claims: claimExample, // bu tokenın parametreleri nereden geliyo claimExampledan geliyor
                expires: DateTime.Now.AddMinutes(5), // token ne zamana kadar gecerli
                signingCredentials: credentials); // tokenın sifreleme algoritmasının i neler

            return new JwtSecurityTokenHandler().WriteToken(token); // tokenımız olustu
        }


    }
}
