using UnityEngine;

public class GameController : MonoBehaviour
{
   public Transform player;
   public static GameController s_instance;
   [SerializeField] private GameObject _deathScreen;
   [SerializeField] private GameObject _settingsScreen;

   private void Awake()
   {
      s_instance = this;
      GlobalEventManager.PlayerDie += PlayerDie;
      GlobalEventManager.SettingsMenu += SetSettingsMenu;
   }

   private void OnDisable()
   {
      GlobalEventManager.PlayerDie -= PlayerDie;
      GlobalEventManager.SettingsMenu -= SetSettingsMenu;
   }

   private void PlayerDie()
   {
      _deathScreen.SetActive(true);
   }

   public void SetSettingsMenu()
   {
      _settingsScreen.SetActive(ActiveSettingsMenu(_settingsScreen.activeInHierarchy));
   }

   private bool ActiveSettingsMenu(bool active)
   {
      if (!active)
         Cursor.lockState = CursorLockMode.Confined;
      else
         Cursor.lockState = CursorLockMode.Locked;
      return !active;
   }
}
