using System;
using SimpleGame.Engine.Engine.AnimationSystem;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;
using SimpleGame.Engine.Engine.SDLEventHandler;

namespace Simple_Game.GameEntities.SceneSystem
{
    class SceneGameEntity : AnimatedGameEntity
    {
        private float _flyDistance = 10;
        private float _speed = 5;
        private Vector2 _origin;
        private int _delta = -1;

        private float Offset { get { return _speed*Time.DeltaTime*_delta; } }

        public float FlyDistance
        {
            get { return _flyDistance; }
            set { _flyDistance = value; }
        }

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public SceneGameEntity(Sprite sprite, Animator aniamtor = null) : base(sprite, aniamtor)
        {
        }

        public override void Start()
        {
            _origin = Position;
        }

        public override void Update()
        {
            base.Update();
            TranslateVertical(Offset);
            if (Math.Abs(_origin.Y - Position.Y) > _flyDistance) _delta *= -1;
            TranslateVertical(Offset);
        }
    }
}
