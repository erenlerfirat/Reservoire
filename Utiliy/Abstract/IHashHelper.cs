namespace Utiliy.Abstract
{
    public interface IHashHelper
    {
        public string Encrypt(string value);
        public bool Validate(string raw, string hash);
    }
}
