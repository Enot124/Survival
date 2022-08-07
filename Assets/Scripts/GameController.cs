using UnityEngine;

public class GameController : MonoBehaviour
{
   public Transform player;
   public static GameController Instance;
   [SerializeField] private GameObject _deathScreen;

   private void Awake()
   {
      Instance = this;
      GlobalEventManager.PlayerDie += PlayerDie;
   }

   private void OnDisable()
   {
      GlobalEventManager.PlayerDie -= PlayerDie;
   }

   private void PlayerDie()
   {
      _deathScreen.SetActive(true);
   }
}
