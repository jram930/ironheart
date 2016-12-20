using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public static class EventFactory
    {
        #region Members

        private static Random theRandom = new Random(DateTime.Now.ToString().GetHashCode());

        #endregion

        #region Public Methods

        public static IWorldEvent GenerateRandomEvent()
        {
            int chance = theRandom.Next(0, EventTypeConstants.NUM_EVENT_TYPES);
            var randomEvent = (EventType)chance;
            IWorldEvent worldEvent;

            switch(randomEvent)
            {
                case EventType.COUP:
                    worldEvent = new CoupEvent();
                    break;
                case EventType.DISCOVERY:
                    worldEvent = new DiscoveryEvent();
                    break;
                case EventType.EARTHQUAKE:
                    worldEvent = new EarthquakeEvent();
                    break;
                case EventType.FAMINE:
                    worldEvent = new FamineEvent();
                    break;
                case EventType.FIRE:
                    worldEvent = new FireEvent();
                    break;
                case EventType.FLOOD:
                    worldEvent = new FloodEvent();
                    break;
                case EventType.HURRICANE:
                    worldEvent = new HurricaneEvent();
                    break;
                case EventType.MIRACLE:
                    worldEvent = new MiracleEvent();
                    break;
                case EventType.PLAGUE:
                    worldEvent = new PlagueEvent();
                    break;
                case EventType.TORNADO:
                    worldEvent = new TornadoEvent();
                    break;
                case EventType.WAR:
                    worldEvent = new WarEvent();
                    break;
                default:
                    // Shouldn't happen, but just in case, spawn an innocent event.
                    worldEvent = new DiscoveryEvent();
                    break;
            }

            return worldEvent;
        }

        #endregion
    }
}
