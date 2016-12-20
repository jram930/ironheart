using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public class JobConstants
    {
        public const int NUM_JOBS = 9;
    }

    public enum Job
    {
        FARMER = 0,
        ROYALTY = 1,
        MINER = 2,
        WARRIOR = 3,
        MERCHANT = 4,
        CRAFTSMAN = 5,
        CHILD = 6,
        TEACHER = 7,
        CRIMINAL = 8
    }
}
