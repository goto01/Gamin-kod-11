using System;
using SDL2;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.Core.SDLHelpers;

namespace SimpleGame.Engine.Engine.EntitieSystem.Entities
{
    public abstract class TextGameEntity : SpriteGameEntity
    {
        private IntPtr _font;
        protected string _text;
        private SDL.SDL_Color _solidColor;

        public string Text
        {
            get { return _text;}
            set { _text = value; }
        }

        public TextGameEntity(IntPtr font, SDL.SDL_Color solidColor, string text) : base(null)
        {
            _font = font;
            _solidColor = solidColor;
            _text = text;
        }

        public override void RenderToRenderer(IntPtr renderer)
        {
            var surface = SDL_ttf.TTF_RenderUTF8_Solid(_font, _text, _solidColor);
            if (surface == default (IntPtr)) return;
            var surfaceStructure = MarshalHelper.GetObjectFromPointer<SDL.SDL_Surface>(surface);
            var textrue = new Texture(SDL.SDL_CreateTextureFromSurface(renderer, surface), surfaceStructure.w, surfaceStructure.h, 2);
            _sprite = new Sprite(textrue);
            SDL.SDL_FreeSurface(surface);
            base.RenderToRenderer(renderer);
        }
    }
}
