using System.Security.Cryptography;
using GymWatch.Infrastructure.Extensions;
using GymWatch.Infrastructure.IServices.Enryption;

namespace GymWatch.Infrastructure.Services.Enryption;

public class Encrypter : IEncrypter
{
    private static readonly int DeriveBytesIterationsCount = 10000;
    private static readonly int SaltSize = 40;
    
    public string GetSalt(string value)
    {
        if (value.Empty()) throw new ArgumentException("Can not generate salt from an empty value.", nameof(value));


        var random = new Random();
        var saltBytes = new byte[DeriveBytesIterationsCount];
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(saltBytes);

        return Convert.ToBase64String(saltBytes);
    }

    public string GetHash(string value, string salt)
    {
        if (value.Empty()) throw new ArgumentException("Can not generate hash from an empty value.", nameof(value));
        if (salt.Empty()) throw new ArgumentException("Can not use empty salt from an hashing value.", nameof(value));

        var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationsCount);

        return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));

    }

    public (string, string) GetHashAndSalt(string value)
    {
        var salt = GetSalt(value);
        var hash = GetHash(value, salt);
        
        return (hash, salt);
    }


    private static byte[] GetBytes(string value)
    {
        var bytes = new byte[value.Length * sizeof(char)];
        Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
        
        return bytes;
    }
}