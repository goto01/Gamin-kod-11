using System;
using System.Collections.Generic;
using SDL2;
using SimpleGame.Engine.Engine.Core;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;

namespace SimpleGame.Engine.Engine.SDLRenderer
{
    public static class Renderer
    {
        private static bool _renderStarted = false;

        public static IntPtr GRenderer { get; private set; }

        public static void InitRenderer(IntPtr window, SDL.SDL_Color _color)
        {
            GRenderer = SDL.SDL_CreateRenderer(window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
            if (GRenderer == null)
            {
                Debug.LogSDLError("Can't create renderer");
                Game.QuitFlag = true;
            }
            SDL.SDL_SetRenderDrawColor(GRenderer, _color.r, _color.g, _color.b, _color.a);
        }

        public static void BeginRender()
        {
            SDL.SDL_RenderClear(GRenderer);

            _renderStarted = true;
        }

        public static void RenderSprites(Queue<RenderableGameEntity> sprites)
        {
            if (!_renderStarted)
            {
                Debug.Log("Try to render before BeginRender()!!!");
                Game.QuitFlag = true;
            }
            while (sprites.Count != 0)
            {
                RenderEntity(sprites.Dequeue());
            }
        }

        public static void RenderEntity(RenderableGameEntity entity)
        {
            if (!_renderStarted)
            {
                Debug.Log("Try to render before BeginRender()!!!");
                Game.QuitFlag = true;
            }
            entity.RenderToRenderer(GRenderer);
        }

        public static void EndRender()
        {
            SDL.SDL_RenderPresent(GRenderer);
            _renderStarted = false;
        }

        public static void DestroyRenderer()
        {
            SDL.SDL_DestroyRenderer(GRenderer);
            GRenderer = default(IntPtr);
        }
    }
}
