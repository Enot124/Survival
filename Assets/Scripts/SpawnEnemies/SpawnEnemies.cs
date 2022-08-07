using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
   [SerializeField] private ZombieFactory _zombieFactory;
   private bool _isSpawn = true;

   private void Start()
   {
      StartCoroutine(MakeWave());
      GlobalEventManager.PlayerDie += StopSpawn;
   }

   private void OnDisable()
   {
      GlobalEventManager.PlayerDie -= StopSpawn;
   }

   private IEnumerator MakeWave()
   {
      while (_isSpawn)
      {
         var Zombie = _zombieFactory.GetNewInstance();
         yield return new WaitForSeconds(2f);
      }
   }

   private void StopSpawn()
   {
      _isSpawn = false;
   }
}
