 namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class CollectableBehavior : VSBehavior
    {
        private Collectable _collectable;

        public void Init(Collectable a_collectable)
        {
            _collectable = a_collectable;
            _collectable.Collected += OnCollect;
              
        }

        protected virtual void OnCollect()
        {
            _collectable.Collected -= OnCollect;
            gameObject.SetActive(false);
        }

    }
}