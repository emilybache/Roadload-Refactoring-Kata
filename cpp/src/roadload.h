#ifndef ROADLOAD_H
#define ROADLOAD_H

#include <stdbool.h>

struct CO2Value {
    double value;
    bool hasValue;
};

struct CO2Values {
    struct CO2Value* High_roadload_f0;
    struct CO2Value* High_roadload_f1;
    struct CO2Value* High_roadload_f2;
    struct CO2Value* High_roadload_tm;
    struct CO2Value* High_roadload_combined;

    struct CO2Value* Mid_roadload_f0;
    struct CO2Value* Mid_roadload_f1;
    struct CO2Value* Mid_roadload_f2;
    struct CO2Value* Mid_roadload_tm;
    struct CO2Value* Mid_roadload_combined;

    struct CO2Value* Low_roadload_f0;
    struct CO2Value* Low_roadload_f1;
    struct CO2Value* Low_roadload_f2;
    struct CO2Value* Low_roadload_tm;
    struct CO2Value* Low_roadload_combined;

    bool IsMidPoint;
    bool IsSinglePoint;
};

void calculateEnergyWithLoads(struct CO2Values *co2Values);


#endif // ROADLOAD_H