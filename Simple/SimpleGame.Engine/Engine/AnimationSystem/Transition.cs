namespace SimpleGame.Engine.Engine.AnimationSystem
{
    public class Transition
    {
        public Animation From { get; private set; }
        public Animation To { get; private set; }

        public Transition(Animation from, Animation to)
        {
            From = from;
            To = to;
        }
    }
}
