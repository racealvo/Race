using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelUpApp
{
    public class Race
    {
        private int Rate { get; }
        private int Rest { get; }
        private int Duration { get; }

        /// <summary>
        /// Constructor - assign properties
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="rest"></param>
        /// <param name="duration"></param>
        public Race(int rate, int duration, int rest)
        {
            Rate = rate;
            Rest = rest;
            Duration = duration;
        }

        /// <summary>
        /// Return the distance travelled
        /// </summary>
        /// <param name="raceTime"></param>
        /// <returns></returns>
        public int Distance(int raceTime)
        {
            // length of time to run and rest
            int period = Duration + Rest;

            // number of running cycles in the race
            int periods = raceTime / period;

            // remaining time left in an incomplete cycle
            int remainderInSeconds = raceTime % period;

            // if remaining available run time is greater than duration, contestant runs fully.  Otherwise, calculate the partial run time.
            int lastLength = (remainderInSeconds > Duration) ? (Duration * Rate) : (remainderInSeconds * Rate);

            int length = (periods * Duration * Rate) + lastLength;

            return length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int raceTime = 2503;

            Race Ned   = new Race(rate: 14, duration: 10, rest: 126);
            Race Devin = new Race(rate: 16, duration: 11, rest: 163);

            int nedDistance = Ned.Distance(raceTime);
            int devinDistance = Devin.Distance(raceTime);

            Console.WriteLine("Ned's Distance: {0}", nedDistance);
            Console.WriteLine("Devin's Distance: {0}", devinDistance);

            Console.WriteLine((nedDistance > devinDistance) ? "Ned Wins!" : "Devin Wins!");
        }
    }
}
