namespace SimpleGame.Engine.Engine.Core.Domain
{
    public struct Vector2
    {
        private float _x;
        private float _y;

        public float X { get { return _x; } set { _x = value; } }
        public float Y { get { return _y; } set { _y = value; } }

        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }
    }
}
