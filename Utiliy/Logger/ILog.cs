namespace Utiliy.Logger
{
    public interface ILog<T>
    {
        public void Info(string message);
        public void Error(string message);
    }
}
