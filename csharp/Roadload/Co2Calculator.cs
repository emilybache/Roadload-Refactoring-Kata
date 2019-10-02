using System;
using System.Threading;
using System.Threading.Tasks;

namespace Roadload
{
    public class Co2Calculator
    {
        public async Task CalculateEnergyWithLoads(Co2Values co2Values)
        {
            if (!co2Values.IsSinglePoint)
            {
                if (co2Values.LowRoadloadF0.HasValue
                    && co2Values.LowRoadloadF1.HasValue
                    && co2Values.LowRoadloadF2.HasValue
                    && co2Values.LowRoadloadTm.HasValue)
                {
                    var roadloadF1 = Convert.ToDouble(co2Values.LowRoadloadF1);
                    var roadloadTm = Convert.ToDouble(co2Values.LowRoadloadTm);
                    co2Values.LowRoadloadCombined =
                        Convert.ToDouble(co2Values.LowRoadloadF0) * roadloadTm /
                        (1 - Convert.ToDouble(co2Values.LowRoadloadF1)) +
                        Convert.ToDouble(co2Values.LowRoadloadF2) * roadloadTm / roadloadF1;
                }
                else
                {
                    co2Values.LowRoadloadCombined = null;
                }
            }

            if (co2Values.HighRoadloadF0.HasValue
                && co2Values.HighRoadloadF1.HasValue
                && co2Values.HighRoadloadF2.HasValue
                && co2Values.HighRoadloadTm.HasValue)
                co2Values.HighRoadloadCombined = CalculateEnergy(Convert.ToDouble(co2Values.HighRoadloadF0),
                    Convert.ToDouble(co2Values.HighRoadloadF1), Convert.ToDouble(co2Values.HighRoadloadF2),
                    Convert.ToDouble(co2Values.HighRoadloadTm));
            else
                co2Values.HighRoadloadCombined = null;

            if (co2Values.IsMidPoint && !co2Values.IsSinglePoint)
            {
                if (co2Values.MidRoadloadF0.HasValue
                    && co2Values.MidRoadloadF1.HasValue
                    && co2Values.MidRoadloadF2.HasValue
                    && co2Values.MidRoadloadTm.HasValue)
                    co2Values.MidRoadloadCombined =
                        Convert.ToDouble(co2Values.MidRoadloadF0) * Convert.ToDouble(co2Values.MidRoadloadTm) /
                        (1 - Convert.ToDouble(co2Values.MidRoadloadF1)) +
                        Convert.ToDouble(co2Values.MidRoadloadF2) * Convert.ToDouble(co2Values.MidRoadloadTm) /
                        Convert.ToDouble(co2Values.MidRoadloadF1);
                else
                    co2Values.MidRoadloadCombined = null;
            }

            await UpdateCo2Values(co2Values);
        }

        private static async Task UpdateCo2Values(Co2Values co2Values)
        {
            // In reality this code would make a network or database call which is simulated with this sleep
            await Task.Run(SlowAction);
        }

        private static void SlowAction()
        {
            Thread.Sleep(2000);
        }

        public static double CalculateEnergy(double highRoadloadF0, double highRoadloadF1, double highRoadloadF2, double highRoadloadTm)
        {
            return highRoadloadF0 * highRoadloadTm / (1 - highRoadloadF1) + highRoadloadF2 * highRoadloadTm / highRoadloadF1;
        }
    }
}