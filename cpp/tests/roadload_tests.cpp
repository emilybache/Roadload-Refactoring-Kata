
#include <climits>

#include "catch2/catch.hpp"
#include "ApprovalTests.hpp"
#include <string>

#include "printers.h"

extern "C"
{
#include "roadload.h"
}

TEST_CASE ("calculateEnergyWithLoads") {

    // These are the sample test data values listed in the README file
    auto *co2Values = new CO2Values();
    co2Values->High_roadload_f0 = new CO2Value{.value=3.5, .hasValue=true};
    co2Values->High_roadload_f1 = new CO2Value{.value=10.6575, .hasValue=true};
    co2Values->High_roadload_f2 = new CO2Value{.value=6.7, .hasValue=true};
    co2Values->High_roadload_tm = new CO2Value{.value=0.003, .hasValue=true};
    co2Values->Mid_roadload_f0 = new CO2Value{.value=3.2, .hasValue=true};
    co2Values->Mid_roadload_f1 = new CO2Value{.value=9.75, .hasValue=true};
    co2Values->Mid_roadload_f2 = new CO2Value{.value=5.9, .hasValue=true};
    co2Values->Mid_roadload_tm = new CO2Value{.value=0.0025, .hasValue=true};
    co2Values->Low_roadload_f0 = new CO2Value{.value=3.1, .hasValue=true};
    co2Values->Low_roadload_f1 = new CO2Value{.value=8.45, .hasValue=true};
    co2Values->Low_roadload_f2 = new CO2Value{.value=5.3, .hasValue=true};
    co2Values->Low_roadload_tm = new CO2Value{.value=0.002, .hasValue=true};

    // These are the values we will check afterwards
    co2Values->Low_roadload_combined = new CO2Value{.value=0, .hasValue=false};
    co2Values->Mid_roadload_combined = new CO2Value{.value=0, .hasValue=false};
    co2Values->High_roadload_combined = new CO2Value{.value=0, .hasValue=false};

    calculateEnergyWithLoads(co2Values);

    ApprovalTests::Approvals::verify(co2Values);
}