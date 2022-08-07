using UnityEngine;
using TMPro;

public class GUIController : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _time;
   internal string time;
   [SerializeField] private TextMeshProUGUI _score;
   internal int scoreCount = 0;
   [SerializeField] private TextMeshProUGUI _ammo;
   [SerializeField] private Weapon _weapon;

   private void Start()
   {
      GlobalEventManager.OnEnemyKilled += EnemyKilled;
   }

   void Update()
   {
      time = TimeFormat.Format(Time.time);
      _time.text = time;
      _ammo.text = _weapon.CurrentAmmo + "/" + _weapon.MaxAmmo;
   }

   private void EnemyKilled()
   {
      scoreCount++;
      _score.text = scoreCount.ToString();
   }
}
