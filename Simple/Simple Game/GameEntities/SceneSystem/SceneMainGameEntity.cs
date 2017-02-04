using SimpleGame.Engine.Engine.AnimationSystem;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.EntitieSystem.Entities;

namespace Simple_Game.GameEntities.SceneSystem
{
    class SceneMainGameEntity : SceneGameEntity
    {
        public SceneMainGameEntity(Sprite sprite, Animator animator) : base(sprite, animator)
        {

        }

        public override void Start()
        {
            _animator.PlayAnimation("idle");
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
