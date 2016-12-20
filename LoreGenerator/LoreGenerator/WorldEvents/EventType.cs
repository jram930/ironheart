using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public class EventTypeConstants
    {
        public const int NUM_EVENT_TYPES = 11;
    }

    /// <summary>
    /// Types of events that can randomly occur in the world.
    /// </summary>
    public enum EventType
    {
        WAR = 0,
        COUP = 1,
        PLAGUE = 2,
        FAMINE = 3,
        FLOOD = 4,
        FIRE = 5,
        HURRICANE = 6,
        TORNADO = 7,
        DISCOVERY = 8,
        MIRACLE = 9,
        EARTHQUAKE = 10
    }
}
