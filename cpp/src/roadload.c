#include <MacTypes.h>
#include "roadload.h"

double doubleValue(const struct CO2Value* value) {
    return value->value;
}

double CalculateEnergy(double highRoadloadF0, double highRoadloadF1, double highRoadloadF2, double highRoadloadTm)
{
    return ((highRoadloadF0 * highRoadloadTm) / (1 - highRoadloadF1)) + ((highRoadloadF2 * highRoadloadTm) / (highRoadloadF1));
}

void update_low_roadload_combined(struct CO2Values* co2Values, double value)
{
    co2Values->Low_roadload_combined->value = value;
    co2Values->Low_roadload_combined->hasValue = true;
}

void update_mid_roadload_combined(struct CO2Values* co2Values, double value)
{
    co2Values->Mid_roadload_combined->value = value;
    co2Values->Mid_roadload_combined->hasValue = true;
}

void update_high_roadload_combined(struct CO2Values* co2Values, double value)
{
    co2Values->High_roadload_combined->value = value;
    co2Values->High_roadload_combined->hasValue = true;
}

void clear_high_roadload_combined(struct CO2Values* co2Values)
{
    co2Values->High_roadload_combined->value = 0;
    co2Values->High_roadload_combined->hasValue = false;
}

void clear_mid_roadload_combined(struct CO2Values* co2Values)
{
    co2Values->Mid_roadload_combined->value = 0;
    co2Values->Mid_roadload_combined->hasValue = false;
}

void clear_low_roadload_combined(struct CO2Values* co2Values)
{
    co2Values->Low_roadload_combined->value = 0;
    co2Values->Low_roadload_combined->hasValue = false;
}

void calculateEnergyWithLoads(struct CO2Values *co2Values) {
    if (!co2Values->IsSinglePoint)
    {
        if (co2Values->Low_roadload_f0->hasValue
            && co2Values->Low_roadload_f1->hasValue
            && co2Values->Low_roadload_f2->hasValue
            && co2Values->Low_roadload_tm->hasValue)
        {
            double roadloadF1 = doubleValue(co2Values->Low_roadload_f1);
            double roadloadTm = doubleValue(co2Values->Low_roadload_tm);
            update_low_roadload_combined(co2Values,
                                        ((doubleValue(co2Values->Low_roadload_f0) * roadloadTm) /
                     (1 - doubleValue(co2Values->Low_roadload_f1))) +
                    ((doubleValue(co2Values->Low_roadload_f2) * roadloadTm) / (roadloadF1)));
        }
        else
        {
            clear_low_roadload_combined(co2Values);
        }
    }

    if (co2Values->High_roadload_f0->hasValue
        && co2Values->High_roadload_f1->hasValue
        && co2Values->High_roadload_f2->hasValue
        && co2Values->High_roadload_tm->hasValue)
    {
        update_high_roadload_combined(co2Values, CalculateEnergy(doubleValue(co2Values->High_roadload_f0),
                                                           doubleValue(co2Values->High_roadload_f1), doubleValue(co2Values->High_roadload_f2),
                                                           doubleValue(co2Values->High_roadload_tm)));
    }
    else
    {
        clear_high_roadload_combined(co2Values);
    }

    if (co2Values->IsMidPoint && !co2Values->IsSinglePoint)
    {
        if (co2Values->Mid_roadload_f0->hasValue
            && co2Values->Mid_roadload_f1->hasValue
            && co2Values->Mid_roadload_f2->hasValue
            && co2Values->Mid_roadload_tm->hasValue)
        {
            update_mid_roadload_combined(co2Values, ((doubleValue(co2Values->Mid_roadload_f0) * doubleValue(co2Values->Mid_roadload_tm)) /
                     (1 - doubleValue(co2Values->Mid_roadload_f1))) +
                    ((doubleValue(co2Values->Mid_roadload_f2) * doubleValue(co2Values->Mid_roadload_tm)) /
                     doubleValue(co2Values->Mid_roadload_f1)));
        }
        else
        {
            clear_mid_roadload_combined(co2Values);
        }
    }
}


