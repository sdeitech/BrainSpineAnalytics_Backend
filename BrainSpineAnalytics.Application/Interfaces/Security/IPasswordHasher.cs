namespace BrainSpineAnalytics.Application.Interfaces.Security
{
 public interface IPasswordHasher
 {
 string Hash(string password);
 bool Verify(string password, string passwordHash);
 bool IsLegacyHash(string passwordHash);
 }
}
