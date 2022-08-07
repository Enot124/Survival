namespace Interfaces
{
   public interface ICanShoot
   {
      public float Damage { get; }
      public float FireRate { get; }
      public float Range { get; }
      public float Cooldown { get; set; }
      public int CurrentAmmo { get; set; }
      public int MaxAmmo { get; }
      public void Shoot();
   }
}
