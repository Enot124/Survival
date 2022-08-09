using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
   [SerializeField] private EnemyFactory _enemyFactory;
   [SerializeField] private float _spawnSpeed = 3f;
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
         var Zombie = _enemyFactory.GetNewInstance();
         yield return new WaitForSeconds(_spawnSpeed);
      }
   }

   private void StopSpawn()
   {
      _isSpawn = false;
   }
}
