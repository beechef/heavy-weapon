namespace Runtime.Interfaces
{
    public interface IEffect
    {
        public void OnStart();
        public void OnUpdate();
        public void OnEnd();
    }
}