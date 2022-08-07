using UnityEngine;

public class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
{
   [SerializeField] private T _prefabEnemy;
   [SerializeField] private Transform[] _spawnPoints;

   public T GetNewInstance()
   {
      int random = Random.Range(0, _spawnPoints.Length);
      return Instantiate(_prefabEnemy, _spawnPoints[random].position, Quaternion.identity);
   }
}