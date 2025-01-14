using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using API.Data;

namespace API._____LOGIN_____.Services_Token;

public class Services_Token
{
    private readonly string _secretKey;
    private readonly string _issuer;
    private readonly string _audience;

    public Services_Token(Data_Token tokenSettings)
    {
        if (string.IsNullOrWhiteSpace(tokenSettings.SecretKey))
        {
            throw new ArgumentException("La clé secrète est obligatoire.", nameof(tokenSettings.SecretKey));
        }

        _secretKey = tokenSettings.SecretKey;
        _issuer = tokenSettings.Issuer ?? "http://localhost";
        _audience = tokenSettings.Audience ?? "http://localhost";
    }

    public string GenerateToken(string userId, string username)
    {
        // Créer la clé de sécurité
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Définir les claims du token
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId), // User ID
            new Claim(JwtRegisteredClaimNames.UniqueName, username), // Username
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Unique ID
        };

        // Créer le token JWT
        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1), // Expiration dans 1 heure
            signingCredentials: credentials
        );

        // Retourner le token sous forme de chaîne
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}