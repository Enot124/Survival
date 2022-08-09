using UnityEngine;
using TMPro;

public class DeathScreen : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _deathText;
   [SerializeField] private GUIController _guiController;

   private void OnEnable()
   {
      _deathText.text = "You lasted " + _guiController.time + "\nYou killed " + _guiController.scoreCount + " monsters";
      Cursor.lockState = CursorLockMode.Confined;
   }
}
