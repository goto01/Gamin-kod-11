using SimpleGame.Engine.Engine.Core;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;

namespace Simple_Game.Controllers
{
    public abstract class BaseController<T> : GameEntitySingleton<T> where T : SimpleGameEntity, new()
    {
    }
}
