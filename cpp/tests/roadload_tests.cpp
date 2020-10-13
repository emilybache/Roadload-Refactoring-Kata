
#include <climits>

#include "catch2/catch.hpp"
#include "ApprovalTests.hpp"
#include <string>

extern "C"
{
#include "roadload.h"
}

TEST_CASE ("foobar") {

    const CO2Values *co2Values = new CO2Values();
    int result = calculateEnergyWithLoads(co2Values);
    REQUIRE(result != 0);
}