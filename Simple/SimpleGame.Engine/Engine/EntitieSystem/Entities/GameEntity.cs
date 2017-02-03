namespace SimpleGame.Engine.Engine.EntitieSystem.Entities
{
    public abstract class GameEntity
    {
        public abstract bool Renderable{ get; }

        public bool Enable { get; set; }

        public GameEntity()
        {
            Enable = true;
        }

        public abstract void Start();

        public abstract void Update();
    }
}
