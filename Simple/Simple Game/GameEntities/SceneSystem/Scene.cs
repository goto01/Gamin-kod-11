using SimpleGame.Engine.Engine.EntitieSystem.Entities;

namespace Simple_Game.GameEntities.SceneSystem
{
    class Scene : EntitiesContainerEntity
    {
        public SceneMainGameEntity MainGameEntity { get; private set; }
        public string TextVariant { get; private set; }

        public Scene(string variant, SpriteGameEntity[] children, SceneMainGameEntity mainGameEntity) : base(children)
        {
            TextVariant = variant;
            MainGameEntity = mainGameEntity;
        }

        public void ShowScene()
        {
            Enable = true;
        }

        public void HideScene()
        {
            Enable = false;
        }

        public override void Start()
        {
            Enable = false;
            base.Start();
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
