using System;

namespace SimpleGame.Engine.Engine.Helpers
{
	public static class EventHelper
	{
		public static void Raise(this EventHandler e, object sender)
		{
            e?.Invoke(sender, EventArgs.Empty);
        }
	}
}
