using UnityEngine;
using Interfaces;

public class Player : MonoBehaviour,
                      IHaveHealth
{
   private float _health = 100f;
   public float Health { get => _health; set => _health = value; }
   public bool IsDied { get; set; }

   public void TakeDamage(float damage)
   {
      Debug.Log("Damaged " + damage);
      Health -= damage;
      if (Health < 0)
      {
         Health = 0;
         Die();
      }
   }

   public void Die()
   {
      IsDied = true;
      GlobalEventManager.PlayerDie();
   }
}
