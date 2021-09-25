namespace Interfaces
{
    public interface IDamageReceiver
    {
        public void TakeDamage(int value);
        public bool TryDie();
    }
}