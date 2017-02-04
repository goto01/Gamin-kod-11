using System.Security.Cryptography.X509Certificates;

namespace SimpleGame.Engine.Engine.Coroutines
{
    public interface IWaitFor
    {
        bool TimeFor();
    }
}
