namespace SimpleGame.Engine.Engine.EntitieSystem.Entities
{
    public abstract class SimpleGameEntity : GameEntity
    {
        public override bool Renderable { get { return false; } }
    }
}
