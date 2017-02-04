using System;
using System.Collections;
using SDL2;
using SimpleGame.Engine.Engine.Core;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;
using Simple_Game.Controllers.InputController;

namespace Simple_Game.GameEntities.Text
{
    class InputTextEntity : TextGameEntity
    {
        public InputTextEntity(IntPtr font, SDL.SDL_Color solidColor, string text) : base(font, solidColor, text)
        {
        }

        public override void Start()
        {
            
        }

        public override void Update()
        {
            UpdateContent();
            SetFirstCharToUpper();
            if (InputController.Instance.GetEnterDown()) UpdateEnter();
        }

        private void UpdateEnter()
        {
            if (!SceneController.Instance.TryToSwitchScene(_text))
                StartCoroutine(Shake());
            else 
                StartCoroutine(Reset());
        }

        private void UpdateContent()
        {
            var keys = InputController.Instance.GetDownKeys();
            for (var index = 0; index < keys.Count; index++) Text += keys[index];

            if (_text.Length != 0 && InputController.Instance.GetBackspaceDown()) _text = _text.Substring(0, _text.Length - 1);
        }

        private void SetFirstCharToUpper()
        {
            if (string.IsNullOrEmpty(_text)) return;
            var chars = _text.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            _text = new string(chars);
        }

        private IEnumerator Reset()
        {
            while (!string.IsNullOrEmpty(_text))
            {
                _text = _text.Substring(0, _text.Length - 1);
                yield return null;
            }
        }

        private IEnumerator Shake()
        {
            int time = 0;
            Vector2 origin = Position;
            var random = new Random();
            while (time++ < 20)
            {
                Position = origin + new Vector2((float) random.Next(-10, 10), (float) random.Next(-10, 10));
                yield return null;
            }
        }
    }
}
