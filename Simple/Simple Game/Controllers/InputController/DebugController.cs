using System;
using SimpleGame.Engine.Engine.Core.Domain;
using SimpleGame.Engine.Engine.EntitieSystem.CoreEntities;

namespace Simple_Game.Controllers.InputController
{
    class DebugController : BaseController<DebugController>
    {
        public SimpleTextGameEntity Text { get; set; }

        public override void Start()
        {
            Text.Position = new Vector2(10, 10);
        }

        public override void Update()
        {
            Text.Text = GC.GetTotalMemory(false).ToString();
        }
    }
}
