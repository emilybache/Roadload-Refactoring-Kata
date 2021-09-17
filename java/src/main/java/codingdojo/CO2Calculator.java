package codingdojo;

public class CO2Calculator {

    public void calculateEnergyWithLoads(CO2Values co2Values) {
        calculateCO2Values(co2Values);
        updateCo2Values(co2Values);
    }

    void updateCo2Values(CO2Values co2Values) {
        // In reality this code would make a network or database call which is simulated with this sleep
        try {
            Thread.sleep(2000);
        } catch (InterruptedException ignored) {
        }
    }

    static void calculateCO2Values(CO2Values co2Values) {
        if (!co2Values.IsSinglePoint) {
            if (co2Values.Low_roadload_f0 != null
                    && co2Values.Low_roadload_f1 != null
                    && co2Values.Low_roadload_f2 != null
                    && co2Values.Low_roadload_tm != null) {
                var roadloadF1 = co2Values.Low_roadload_f1;
                var roadloadTm = (co2Values.Low_roadload_tm);
                co2Values.Low_roadload_combined =
                        (((co2Values.Low_roadload_f0) * roadloadTm) /
                                (1 - (co2Values.Low_roadload_f1))) +
                                (((co2Values.Low_roadload_f2) * roadloadTm) / (roadloadF1));
            } else {
                co2Values.Low_roadload_combined = null;
            }
        }

        if (co2Values.High_roadload_f0 != null
                && co2Values.High_roadload_f1 != null
                && co2Values.High_roadload_f2 != null
                && co2Values.High_roadload_tm != null) {
            co2Values.High_roadload_combined = calculateEnergy((co2Values.High_roadload_f0),
                    (co2Values.High_roadload_f1), (co2Values.High_roadload_f2),
                    (co2Values.High_roadload_tm));
        } else {
            co2Values.High_roadload_combined = null;
        }

        if (co2Values.IsMidPoint && !co2Values.IsSinglePoint) {
            if (co2Values.Mid_roadload_f0 != null
                    && co2Values.Mid_roadload_f1 != null
                    && co2Values.Mid_roadload_f2 != null
                    && co2Values.Mid_roadload_tm != null) {
                co2Values.Mid_roadload_combined =
                        (((co2Values.Mid_roadload_f0) * (co2Values.Mid_roadload_tm)) /
                                (1 - (co2Values.Mid_roadload_f1))) +
                                (((co2Values.Mid_roadload_f2) * (co2Values.Mid_roadload_tm)) /
                                        (co2Values.Mid_roadload_f1));
            } else {
                co2Values.Mid_roadload_combined = null;
            }
        }
    }


    public static double calculateEnergy(double highRoadloadF0, double highRoadloadF1, double highRoadloadF2, double highRoadloadTm) {
        return ((highRoadloadF0 * highRoadloadTm) / (1 - highRoadloadF1)) + ((highRoadloadF2 * highRoadloadTm) / (highRoadloadF1));

    }
}
