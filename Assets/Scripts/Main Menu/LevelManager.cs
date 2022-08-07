using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public void LoadLevel(int levelIndex)
   {
      SceneManager.LoadScene(levelIndex);
   }

}
