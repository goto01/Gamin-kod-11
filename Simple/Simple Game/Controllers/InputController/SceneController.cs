using System;
using System.Collections;
using SimpleGame.Engine.Engine.Coroutines;
using SimpleGame.Engine.Engine.EntitieSystem;
using Simple_Game.GameEntities.SceneSystem;
using Simple_Game.GameEntities.Staff;
using Simple_Game.GameEntityHandlerSystem;

namespace Simple_Game.Controllers.InputController
{
    class SceneController : BaseController<SceneController>
    {
        private Scene[] _scenes;
        private int _currentSceneIndex = 0;
        private Eye _eye;

        private Scene CurrentScene { get { return _scenes[_currentSceneIndex]; } }
        
        public override void Start()
        {
            _scenes = GameEntityContainer.GetNetities<Scene>();
            _currentSceneIndex = 0;
            _eye = GameEntityContainer.GetEntity<Eye>();
            CurrentScene.ShowScene();
        }

        public override void Update()
        {

        }

        public bool TryToSwitchScene(string variant)
        {
            if (variant.Equals(CurrentScene.TextVariant, StringComparison.InvariantCultureIgnoreCase))
                StartCoroutine(SwitchScene());
            else return false;
            return true;
        }

        public IEnumerator SwitchScene()
        {
            CurrentScene.ActivateScene();
            yield return new WaitForSeconds(1);
            CurrentScene.HideScene();
            _currentSceneIndex ++;
            CurrentScene.ShowScene();
            _eye.Blink();
        }
    }
}
