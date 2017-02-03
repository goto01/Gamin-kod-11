using System;
using SDL2;

namespace SimpleGame.Engine.Engine.Core.Domain
{
    public class Sprite
    {
        private Texture _texture;
        private SDL.SDL_Rect _sourceRect;
        private SDL.SDL_Rect _destinationRect;

        public Texture Texture { get { return _texture;} }
        public IntPtr SDLTexture { get { return _texture.SDLTexture; } }
        public SDL.SDL_Rect SourceRect { get { return _sourceRect; } }

        public SDL.SDL_Rect DestinationRect
        {
            get { return _destinationRect; }
            set { _destinationRect = value; }
        }
        
        public Sprite(Texture texture) : this(texture, 
            new SDL.SDL_Rect() { x = 0, y = 0, w = texture.Width, h = texture.Height})
        {

        }

        public Sprite(Texture texture, SDL.SDL_Rect sourceRect) : this(texture, sourceRect, new SDL.SDL_Rect() {x=0, y =0, w = sourceRect.w, h = sourceRect.h})
        {
            
        }

        public Sprite(Texture texture, SDL.SDL_Rect sourceRect, SDL.SDL_Rect destinationRect)
        {
            _texture = texture;
            _sourceRect = sourceRect;
            _destinationRect = destinationRect;
        }
    }
}
