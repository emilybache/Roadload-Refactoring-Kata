#ifndef ROADLOAD_H
#define ROADLOAD_H

#include <stdbool.h>

struct CO2Value {
	double value;
	bool isActive;
};

struct CO2Values {

	CO2Value Low_roadload_f0;
};

unsigned int calculateEnergyWithLoads(const struct CO2Values *co2Values);


#endif // ROADLOAD_H