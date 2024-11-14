namespace GymWatch.Infrastructure.IServices.Enryption;

public interface IEncrypter
{
    string GetSalt(string value);
    string GetHash(string value, string salt);
    (string, string) GetHashAndSalt(string value);
}

