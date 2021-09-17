package codingdojo;

import org.approvaltests.combinations.CombinationApprovals;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class RoadloadTest {
    @Test
    void calculateCO2Values() {

        CombinationApprovals.verifyAllCombinations(this::doCalculateCO2Values,
                new Boolean[]{false, true},
                new Boolean[]{false, true},
                new Double[]{3.5, null},
                new Double[]{3.2, null},
                new Double[]{3.1, null}
        );
    }

    private String doCalculateCO2Values(Boolean isMidPoint, Boolean isSinglePoint,
                                        Double highRoadloadF0, Double midRoadloadF0, Double lowRoadloadF0) {
        var values = new CO2Values();
        values.High_roadload_f0 = highRoadloadF0;
        values.High_roadload_f1 = 10.6575;
        values.High_roadload_f2 = 6.7;
        values.High_roadload_tm = 0.003;
        values.Mid_roadload_f0 = midRoadloadF0;
        values.Mid_roadload_f1 = 9.75;
        values.Mid_roadload_f2 = 5.9;
        values.Mid_roadload_tm = 0.0025;
        values.Low_roadload_f0 = lowRoadloadF0;
        values.Low_roadload_f1 = 8.45;
        values.Low_roadload_f2 = 5.3;
        values.Low_roadload_tm = 0.002;
        values.IsMidPoint = isMidPoint;
        values.IsSinglePoint = isSinglePoint;

        CO2Calculator.calculateCO2Values(values);

        return String.format("(%s, %s, %s)", values.Low_roadload_combined, values.Mid_roadload_combined, values.High_roadload_combined);
    }

}
