using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;

namespace Token.Models.JWT
{
    public class JWT : IJWT
    {
        string _key;
        public JWT(string key)
        {
            _key = key;
        }

        //JWT.io
        public string Authenticate(string username, string password)
        {
            KitapDbContext db = new KitapDbContext();
            Kullanici kullanici =  db.Kullanicilar.Where(x=>x.kullaniciAdi==username && x.Sifre==password).SingleOrDefault();

            string result = null;

            if (kullanici != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var bytKey = Encoding.UTF8.GetBytes(_key);

                var tokenDesc = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, username) }),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDesc);
                result = tokenHandler.WriteToken(token);
            }

            return result;
        }
    }
}
