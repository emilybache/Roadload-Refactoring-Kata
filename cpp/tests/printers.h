

#ifndef ROADLOAD_REFACTORING_PRINTERS_H
#define ROADLOAD_REFACTORING_PRINTERS_H

#include <ostream>

extern "C"
{
#include "roadload.h"
}

/*
 * This is a printer for a co2Values instance.
 * It prints fields that are present.
 */
std::ostream &operator<<(std::ostream &os, const struct CO2Values *co2Values) {
    os << "Low roadload combined: ";
    if (co2Values->Low_roadload_combined->hasValue) {
        os << co2Values->Low_roadload_combined->value << "\n";
    } else {
        os << "missing\n";
    }

    os << "Mid roadload combined: ";
    if (co2Values->Mid_roadload_combined->hasValue) {
        os << co2Values->Mid_roadload_combined->value << "\n";
    } else {
        os << "missing\n";
    }

    os << "High roadload combined: ";
    if (co2Values->High_roadload_combined->hasValue) {
        os << co2Values->High_roadload_combined->value << "\n";
    } else {
        os << "missing\n";
    }

    return os;
}


#endif //ROADLOAD_REFACTORING_PRINTERS_H
