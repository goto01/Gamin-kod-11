namespace SimpleGame.Engine.Engine.EntitieSystem.Entities
{
    public abstract class EntitiesContainerEntity : SimpleGameEntity
    {
        private GameEntity[] _children;

        public GameEntity[] Children
        {
            get { return _children; }
            set { _children = value; }
        }

        public override void Start()
        {
            UpdateChildrenEnable();
        }

        public override void Update()
        {
            UpdateChildrenEnable();
        }

        private void UpdateChildrenEnable()
        {
            for (var index = 0; index < _children.Length; index++) _children[index].Enable = Enable;
        }

        public EntitiesContainerEntity(GameEntity[] children)
        {
            _children = children;
        }
    }
}
