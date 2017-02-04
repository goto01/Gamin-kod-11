using SimpleGame.Engine.Engine.SDLEventHandler;

namespace SimpleGame.Engine.Engine.Coroutines
{
    public class WaitForSeconds : IWaitFor
    {
        private readonly float _start;
        private readonly float _seconds;

        public WaitForSeconds(float seconds)
        {
            _start = Time.MilliSeconds;
            _seconds = seconds;
        }

        public bool TimeFor()
        {
            return Time.MilliSeconds - _start >= _seconds;
        }
    }
}
