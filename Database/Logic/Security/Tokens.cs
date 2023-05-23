using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;

namespace Logic.Security;

public class Tokens
{
    private readonly IConfiguration _config;

    public Tokens(IConfiguration config)
    {
        _config = config;
    }

    public string CreateToken(User dto)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, dto.Name)
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            "kf8hBP8MdnU3vZTI9dZqiehaJ2ePCybw14zPDjUi"
        ));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}