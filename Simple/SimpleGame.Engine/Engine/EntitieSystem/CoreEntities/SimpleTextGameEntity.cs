using System;
using SDL2;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;

namespace SimpleGame.Engine.Engine.EntitieSystem.CoreEntities
{
    public class SimpleTextGameEntity: TextGameEntity

{
        public SimpleTextGameEntity(IntPtr font, SDL.SDL_Color solidColor, string text) : base(font, solidColor, text)
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
