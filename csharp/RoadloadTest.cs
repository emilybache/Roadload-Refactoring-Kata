using System;
using ApprovalTests;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace roadload
{
    [UseReporter(typeof(DiffReporter))]
    [TestClass]
    public class RoadloadTest
    {
        [TestMethod]
        public void CalculateCO2Values()
        {            
            CombinationApprovals.VerifyAllCombinations(doCalculateCO2Values,
                new bool[]{false, true}, 
                new bool[]{false, true},
                new double?[] {3.5, null},
                new double?[] { 3.2, null },
                new double?[] { 3.1, null }
                );
        }

        private static string doCalculateCO2Values(bool isMidPoint, bool isSinglePoint, 
            double? highRoadloadF0, double? midRoadloadF0, double? lowRoadloadF0)
        {
            var values = new CO2Values()
            {
                High_roadload_f0 = highRoadloadF0,
                High_roadload_f1 = 10.6575,
                High_roadload_f2 = 6.7,
                High_roadload_tm = 0.003,
                Mid_roadload_f0 = midRoadloadF0,
                Mid_roadload_f1 = 9.75,
                Mid_roadload_f2 = 5.9,
                Mid_roadload_tm = 0.0025,
                Low_roadload_f0 = lowRoadloadF0,
                Low_roadload_f1 = 8.45,
                Low_roadload_f2 = 5.3,
                Low_roadload_tm = 0.002,
            };

            values.IsMidPoint = isMidPoint;
            values.IsSinglePoint = isSinglePoint;

            CO2Calculator.calculateCO2Values(values);
        
            return $"({values.Low_roadload_combined}, {values.Mid_roadload_combined}, {values.High_roadload_combined})";
        }
    }
}
