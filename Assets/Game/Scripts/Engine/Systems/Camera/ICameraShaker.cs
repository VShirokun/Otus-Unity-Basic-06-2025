namespace Game.Engine
{
    public interface ICameraShaker
    {
        void SetShake(string shakeType, float magnitude, float frequency, float seconds);
    }
}