using UnityEngine;

public class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
{
   [SerializeField] private T[] _prefabEnemy;
   [SerializeField] private Transform[] _spawnPoints;

   public T GetNewInstance()
   {
      int randomEnemy = 0;
      if (_prefabEnemy.Length > 1)
      {
         randomEnemy = Random.Range(0, _prefabEnemy.Length);
      }
      int randomPoint = Random.Range(0, _spawnPoints.Length);
      return Instantiate(_prefabEnemy[randomEnemy], _spawnPoints[randomPoint].position, Quaternion.identity);
   }
}