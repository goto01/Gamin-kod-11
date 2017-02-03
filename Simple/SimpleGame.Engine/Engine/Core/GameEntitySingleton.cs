using SimpleGame.Engine.Engine.EntitieSystem.Entities;

namespace SimpleGame.Engine.Engine.Core
{
    public abstract class GameEntitySingleton<T> : SimpleGameEntity
        where T: GameEntity, new()
    {
        private static T _instance;

        public static T Instance => _instance ?? (_instance = new T());
    }
}
