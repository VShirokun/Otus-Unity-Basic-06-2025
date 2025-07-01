using Game.Engine;
using UnityEngine;

namespace Game.App
{
    public static class AnalyticsEvents
    {
        public static void LogGameStarted()
        {
            AnalyticsManager.LogEvent("game_started");
        }

        public static void LogGamePaused()
        {
            AnalyticsManager.LogEvent("game_paused");
        }

        public static void LogGameResumed()
        {
            AnalyticsManager.LogEvent("game_resumed");
        }

        public static void LogGameFinished()
        {
            AnalyticsManager.LogEvent("game_resumed");
        }

        public static void LogPickUpItem(PickableItem item)
        {
            AnalyticsManager.LogEvent("pick_up_item", new AnalyticsParameter("item_name", item.Id));
        }

        public static void LogCharacterDeath(GameObject source, int damage)
        {
            AnalyticsManager.LogEvent("character_death",
                new AnalyticsParameter("source", source != null ? source.name : "undefined"),
                new AnalyticsParameter("damage", damage)
            );
        }
        
        public static void LogCheckpointReached(string checkpointName)
        {
            AnalyticsManager.LogEvent("checkpoint_reached", new AnalyticsParameter("checkpoint", checkpointName));
        }
    }
}