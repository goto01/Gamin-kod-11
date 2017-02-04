using System.Collections;
using SimpleGame.Engine.Engine.Coroutines;
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
            StartCoroutine(ChangeEnable(true));
        }

        public void HideScene()
        {
            StartCoroutine(ChangeEnable(false));
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

        private IEnumerator ChangeEnable(bool enable)
        {
            yield return new WaitForSeconds(.5f);
            Enable = enable;
        }
    }
}
