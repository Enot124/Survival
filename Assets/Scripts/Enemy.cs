using UnityEngine;
using UnityEngine.AI;
using Interfaces;

public class Enemy : MonoBehaviour,
                     ICanChase,
                     IHaveHealth,
                     ICanAttack
{
   #region ICanMove
   public NavMeshAgent Agent { get => GetComponent<NavMeshAgent>(); }
   private Transform _target;
   public Transform Target { get => _target; }
   public float Distance { get; set; }

   #endregion ICanMove

   #region IHaveHealth
   private float _health = 100f;
   public float Health { get => _health; set => _health = value; }
   public bool IsDied { get; set; }

   #endregion IHaveHealth

   #region ICanAttack
   public float Damage { get => 10f; }
   public float AttackSpeed { get => 0.5f; }
   public float Cooldown { get; set; }
   [SerializeField] private LayerMask _oppositeLayer;
   public LayerMask OppositeLayer { get => _oppositeLayer; }
   [SerializeField] private Transform _attackPoint;
   public Transform AttackPoint { get => _attackPoint; }

   #endregion ICanAttack

   private Animator _animator;
   private Collider _collider;

   private void Start()
   {
      _animator = GetComponent<Animator>();
      _collider = GetComponent<Collider>();
      _target = GameController.Instance.player;
   }

   private void Update()
   {
      if (!IsDied)
      {
         Agent.SetDestination(Target.position);

         Distance = Vector3.Distance(Target.position, transform.position);
         if (Distance < 2f && Time.time > Cooldown)
         {
            _animator.SetTrigger("attack");
         }
      }
   }

   public void TakeDamage(float damage)
   {
      Health -= damage;
      if (Health < 0)
         Die();
   }

   public void Die()
   {
      IsDied = true;
      _collider.enabled = false;
      Agent.enabled = false;
      _animator.SetBool("isDied", true);
      GlobalEventManager.SendEnemyKilled();
      Destroy(gameObject, 5f);
   }

   public void Attack()
   {
      Cooldown = Time.time + 1f / AttackSpeed;

      Vector3 offset = new Vector3(1, 2, 0);
      Collider[] hit = Physics.OverlapBox(AttackPoint.position, transform.localScale,
                                          Quaternion.identity, _oppositeLayer);
      if (hit.Length != 0)
      {
         Player player = hit[0].GetComponent<Player>();
         if (player != null)
         {
            player.TakeDamage(Damage);
         }
      }
   }
}
