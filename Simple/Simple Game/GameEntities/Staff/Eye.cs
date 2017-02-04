using SimpleGame.Engine.Engine.AnimationSystem;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;

namespace Simple_Game.GameEntities.Staff
{
    class Eye : AnimatedGameEntity
    {
        public Eye(Sprite sprite, Animator animator) : base(sprite, animator)
        {

        }

        public override void Start()
        {
            _animator.PlayAnimation("open");
        }

        public void Blink()
        {
            _animator.PlayAnimation("close");
        }
    }
}
