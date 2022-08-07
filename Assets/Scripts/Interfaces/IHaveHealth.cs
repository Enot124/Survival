namespace Interfaces
{
   public interface IHaveHealth
   {
      public float Health { get; set; }
      public bool IsDied { get; set; }
      public void TakeDamage(float damage);
      public void Die();
   }
}
