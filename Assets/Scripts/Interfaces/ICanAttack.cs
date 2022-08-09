using UnityEngine;

namespace Interfaces
{
   public interface ICanAttack
   {
      public float Damage { get; }
      public float AttackSpeed { get; }
      public float Cooldown { get; set; }
      public LayerMask OppositeLayer { get; }
      public Transform AttackPoint { get; }
      public Vector3 AttackRange { get; }
      public void Attack();

   }
}
