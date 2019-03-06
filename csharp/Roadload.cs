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
            if (!co2Values.IsSinglePoint)
            {
                if (co2Values.Low_roadload_f0.HasValue
                    && co2Values.Low_roadload_f1.HasValue
                    && co2Values.Low_roadload_f2.HasValue
                    && co2Values.Low_roadload_tm.HasValue)
                {
                    co2Values.Low_roadload_combined = CalculateEnergy(Convert.ToDouble(co2Values.Low_roadload_f0),
                        Convert.ToDouble(co2Values.Low_roadload_f1), Convert.ToDouble(co2Values.Low_roadload_f2),
                        Convert.ToDouble(co2Values.Low_roadload_tm));
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
                    co2Values.Mid_roadload_combined = CalculateEnergy(Convert.ToDouble(co2Values.Mid_roadload_f0),
                        Convert.ToDouble(co2Values.Mid_roadload_f1), Convert.ToDouble(co2Values.Mid_roadload_f2),
                        Convert.ToDouble(co2Values.Mid_roadload_tm));
                }
                else
                {
                    co2Values.Mid_roadload_combined = null;
                }

            }

            await UpdateCo2Values(co2Values);
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

        public static double CalculateEnergy(double RoadloadF0, double RoadloadF1, double RoadloadF2, double RoadloadTm)
        {
            return ((RoadloadF0 * RoadloadTm) / (1 - RoadloadF1)) + ((RoadloadF2 * RoadloadTm) / (RoadloadF1));

        }
    }
}
