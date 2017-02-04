using System;
using SDL2;
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
            var keys = InputController.Instance.GetDownKeys();
            for (var index = 0; index < keys.Count; index++) Text += keys[index];

            SetFirstCharToUpper();
        }

        private void SetFirstCharToUpper()
        {
            if (string.IsNullOrEmpty(_text)) return;
            var chars = _text.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            _text = new string(chars);
        }
    }
}
