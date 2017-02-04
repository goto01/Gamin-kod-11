using System;
using System.Collections;
using System.Linq;
using SimpleGame.Engine.Engine.Coroutines;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;

namespace Simple_Game.GameEntities.SceneSystem
{
    class Scene : EntitiesContainerEntity
    {
        public SceneMainGameEntity MainGameEntity { get; private set; }
        public string[] TextVariants { get; private set; }

        public Scene(string[] variants, SpriteGameEntity[] children, SceneMainGameEntity mainGameEntity) : base(children)
        {
            TextVariants = variants;
            MainGameEntity = mainGameEntity;
        }

        public bool CompareVariatn(string variant)
        {
            return TextVariants.Any(x => x.Equals(variant, StringComparison.InvariantCultureIgnoreCase));
        }

        public void ShowScene()
        {
            StartCoroutine(ChangeEnable(true));
        }

        public void ActivateScene()
        {
            MainGameEntity?.Activate();
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
