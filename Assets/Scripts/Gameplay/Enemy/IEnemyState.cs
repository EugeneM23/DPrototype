namespace Gameplay
{
    public interface IEnemyState
    {
        public void Tick();
        void Exit();
        public void Enter();
    }
}