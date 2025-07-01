namespace Game.Engine
{
    public interface IEntity
    {
        T Get<T>() where T : class;
    }
}