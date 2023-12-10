namespace EnemyState
{
    public abstract class State<T>
    {
        public abstract void Enter(T entity);
        public abstract void Update(T entity);
        public abstract void Eixt(T entity);
    }
}