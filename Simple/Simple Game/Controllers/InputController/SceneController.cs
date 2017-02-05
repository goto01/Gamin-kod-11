using System;
using System.Collections;
using SimpleGame.Engine.Engine.Coroutines;
using SimpleGame.Engine.Engine.EntitieSystem;
using SimpleGame.Engine.Engine.EntitieSystem.CoreEntities;
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

        public SimpleTextGameEntity Credits { get; set; }
        public SimpleTextGameEntity CreditsNewLine { get; set; }

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
            if (_currentSceneIndex == _scenes.Length) return false;
            if (CurrentScene.CompareVariatn(variant))
                StartCoroutine(SwitchScene());
            else return false;
            return true;
        }

        public IEnumerator SwitchScene()
        {
            CurrentScene.ActivateScene();
            yield return new WaitForSeconds(2);
            CurrentScene.HideScene();
            _currentSceneIndex ++;
            if (_currentSceneIndex == _scenes.Length)
                Call(() =>
                {
                    Credits.Text = "Доброе утро";
                    CreditsNewLine.Text = "Спасибо за сны...";
                }, .5f);
            else
                CurrentScene.ShowScene();
            _eye.Blink();
        }
    }
}
