using SimpleGame.Engine.Engine.EntitieSystem.Entities;

namespace Simple_Game.GameEntities.SceneSystem
{
    class Scene : SimpleGameEntity
    {
        public string TextVariant { get; private set; }

        public Scene(string variant)
        {
            TextVariant = variant;
        }

        public override void Start()
        {
            
        }

        public override void Update()
        {

        }
    }
}
