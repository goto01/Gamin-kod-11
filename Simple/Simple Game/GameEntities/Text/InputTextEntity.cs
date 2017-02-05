using System;
using System.Collections;
using SDL2;
using SimpleGame.Engine.Engine.Core;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.Coroutines;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;
using Simple_Game.Controllers.InputController;

namespace Simple_Game.GameEntities.Text
{
    class InputTextEntity : TextGameEntity
    {
        private bool _handling;
        private bool _shaking;

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
            if (_handling) return;
            if (!_shaking && !SceneController.Instance.TryToSwitchScene(_text))
            {
                StartCoroutine(Shake());
                Call(() => StartCoroutine(Reset()), .3f);
            }
            else 
            {
                StartCoroutine(Move());
            }
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
                yield return new WaitForSeconds(.01f);
            }
        }

        private IEnumerator Shake()
        {
            _shaking = true;
            int time = 0;
            Vector2 origin = Position;
            var random = new Random();
            while (time++ < 20)
            {
                Position = origin + new Vector2((float) random.Next(-10, 10), (float) random.Next(-10, 10));
                yield return new WaitForSeconds(.01f);
            }
            Position = origin;
            _shaking = false;
        }

        private IEnumerator Move()
        {
            _handling = true;
            var origin = Position;
            while (Math.Abs(Position.Y - origin.Y) < 20)
            {
                TranslateVertical(-2);
                yield return null;
            }
            yield return new WaitForSeconds(1);
            while (!string.IsNullOrEmpty(_text))
            {
                _text = _text.Substring(0, _text.Length - 1);
                yield return new WaitForSeconds(.01f);
            }
            Position = origin;
            _handling = false;
        }
    }
}
