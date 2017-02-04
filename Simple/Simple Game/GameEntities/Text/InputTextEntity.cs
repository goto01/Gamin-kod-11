using System;
using SDL2;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;

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

        }
    }
}
