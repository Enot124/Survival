using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarGUI : MonoBehaviour
{
   [SerializeField] private Slider _sliderHealth;
   [SerializeField] private TextMeshProUGUI _health;
   [SerializeField] private Player _player;

   private void Start()
   {
      _sliderHealth.maxValue = _player.Health;
   }
   private void Update()
   {
      SetHealthValue((int)_player.Health);
   }

   public void SetHealthValue(int health)
   {
      _sliderHealth.value = health;
      _health.text = health.ToString();
   }
}
