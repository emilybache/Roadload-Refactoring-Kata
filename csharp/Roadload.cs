using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace roadload
{
    public class CO2Calculator
    {
        public async Task CalculateEnergyWithLoads(CO2Values co2Values)
        {
            calculateCO2Values(co2Values);

            await UpdateCo2Values(co2Values);
        }

        public static void calculateCO2Values(CO2Values co2Values)
        {
            if (!co2Values.IsSinglePoint)
            {
                if (co2Values.Low_roadload_f0.HasValue
                    && co2Values.Low_roadload_f1.HasValue
                    && co2Values.Low_roadload_f2.HasValue
                    && co2Values.Low_roadload_tm.HasValue)
                {
                    var roadloadF1 = Convert.ToDouble(co2Values.Low_roadload_f1);
                    var roadloadTm = Convert.ToDouble(co2Values.Low_roadload_tm);
                    co2Values.Low_roadload_combined =
                        ((Convert.ToDouble(co2Values.Low_roadload_f0) * roadloadTm) /
                         (1 - Convert.ToDouble(co2Values.Low_roadload_f1))) +
                        ((Convert.ToDouble(co2Values.Low_roadload_f2) * roadloadTm) / (roadloadF1));
                }
                else
                {
                    co2Values.Low_roadload_combined = null;
                }
            }

            if (co2Values.High_roadload_f0.HasValue
                && co2Values.High_roadload_f1.HasValue
                && co2Values.High_roadload_f2.HasValue
                && co2Values.High_roadload_tm.HasValue)
            {
                co2Values.High_roadload_combined = CalculateEnergy(Convert.ToDouble(co2Values.High_roadload_f0),
                    Convert.ToDouble(co2Values.High_roadload_f1), Convert.ToDouble(co2Values.High_roadload_f2),
                    Convert.ToDouble(co2Values.High_roadload_tm));
            }
            else
            {
                co2Values.High_roadload_combined = null;
            }

            if (co2Values.IsMidPoint && !co2Values.IsSinglePoint)
            {
                if (co2Values.Mid_roadload_f0.HasValue
                    && co2Values.Mid_roadload_f1.HasValue
                    && co2Values.Mid_roadload_f2.HasValue
                    && co2Values.Mid_roadload_tm.HasValue)
                {
                    co2Values.Mid_roadload_combined =
                        ((Convert.ToDouble(co2Values.Mid_roadload_f0) * Convert.ToDouble(co2Values.Mid_roadload_tm)) /
                         (1 - Convert.ToDouble(co2Values.Mid_roadload_f1))) +
                        ((Convert.ToDouble(co2Values.Mid_roadload_f2) * Convert.ToDouble(co2Values.Mid_roadload_tm)) /
                         Convert.ToDouble(co2Values.Mid_roadload_f1));
                }
                else
                {
                    co2Values.Mid_roadload_combined = null;
                }
            }
        }

        private static async Task UpdateCo2Values(CO2Values co2Values)
        {
            // In reality this code would make a network or database call which is simulated with this sleep
            await Task.Run((Action) SlowAction);
        }

        private static void SlowAction()
        {
            Thread.Sleep(2000);
        }

        public static double CalculateEnergy(double highRoadloadF0, double highRoadloadF1, double highRoadloadF2, double highRoadloadTm)
        {
            return ((highRoadloadF0 * highRoadloadTm) / (1 - highRoadloadF1)) + ((highRoadloadF2 * highRoadloadTm) / (highRoadloadF1));

        }
    }
}
