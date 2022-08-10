using System;

public class GlobalEventManager
{
   public static Action OnEnemyKilled;
   public static Action PlayerDie;
   public static Action SettingsMenu;

   public static void SendEnemyKilled()
   {
      OnEnemyKilled?.Invoke();
   }

   public static void SendPlayerDie()
   {
      PlayerDie?.Invoke();
   }

   public static void SetSettingsMenu()
   {
      SettingsMenu?.Invoke();
   }
}
