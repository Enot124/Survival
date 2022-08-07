using UnityEngine;

public class MainMenu : MonoBehaviour
{
   [SerializeField] private GameObject _levelPanel;

   public void OpenLevels()
   {
      _levelPanel.SetActive(true);
   }

   public void CloseLevels()
   {
      _levelPanel.SetActive(false);
   }
}
