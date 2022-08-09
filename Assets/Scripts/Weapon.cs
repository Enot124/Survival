using UnityEngine;
using Interfaces;

public class Weapon : MonoBehaviour,
                      ICanShoot
{
   [SerializeField] private ParticleSystem _flash;
   [SerializeField] private AudioClip _shotAudio;
   [SerializeField] private AudioSource _audioSource;
   [SerializeField] private Camera _camera;
   private Animator _animator;
   private bool isShoot = true;

   #region ICanShoot
   public float Damage { get => 30f; }
   public float FireRate { get => 8f; }
   public float Range { get => 100f; }
   public float Cooldown { get; set; }
   public int CurrentAmmo { get; set; }
   public int MaxAmmo { get => 30; }
   #endregion ICanShoot

   private void Start()
   {
      _animator = GetComponent<Animator>();
      CurrentAmmo = MaxAmmo;
      GlobalEventManager.PlayerDie += StopShoot;
   }

   private void OnDisable()
   {
      GlobalEventManager.PlayerDie -= StopShoot;
   }

   private void Update()
   {
      if (isShoot)
      {
         if (Input.GetButton("Fire1"))
         {
            TryShoot();
         }
         if (Input.GetKeyDown("F") && (CurrentAmmo != MaxAmmo))
         {
            Invoke("Reload", 3f);
         }
      }
   }

   private void TryShoot()
   {
      if ((Time.time > Cooldown) && (CurrentAmmo > 0))
         Shoot();

      if (CurrentAmmo <= 0)
         Invoke("Reload", 3f);
   }

   public void Shoot()
   {
      _animator.SetTrigger("isShoot");
      _flash.Play();
      _audioSource.PlayOneShot(_shotAudio);
      Cooldown = Time.time + 1f / FireRate;
      CurrentAmmo--;

      RaycastHit hit;
      if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, Range))
      {
         Enemy enemy = hit.transform.GetComponent<Enemy>();
         if (enemy != null)
         {
            enemy.TakeDamage(Damage);
         }
      }
   }

   private void Reload()
   {
      CurrentAmmo = MaxAmmo;
   }

   private void StopShoot()
   {
      isShoot = false;
   }
}