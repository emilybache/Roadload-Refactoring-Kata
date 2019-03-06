Calculate Road Load Refactoring Kata
====================================

Summary: Your job is to get this code under test, to enable you to refactor it and add a new feature, detailed below. You have some test data available, also detailed below.

Backstory
--------- 

This code represents a small piece of a larger system. The aim of the whole system is to calculate CO2 emissions for a vehicle. The emissions in part depend on the weight of the load the vehicle is carrying - the 'Road Load'. This piece of code does some preliminary calculations which will be used later on as part of the full calculation. The 'CO2Values' data is originally obtained from the manufacturer's specification for the vehicle. The exact details of what they represent is not important. For test purposes, you have been given some sample values for a typical family saloon car:

Sample Test Data
----------------

	High_roadload_f0 = 3.5
	High_roadload_f1 = 10.6575
	High_roadload_f2 = 6.7
	High_roadload_tm = 0.003
	Mid_roadload_f0 = 3.2
	Mid_roadload_f1 = 9.75
	Mid_roadload_f2 = 5.9
	Mid_roadload_tm = 0.0025
	Low_roadload_f0 = 3.1
	Low_roadload_f1 = 8.45
	Low_roadload_f2 = 5.3
	Low_roadload_tm = 0.002


New feature
------------

The emissions specialists would like to change the details of the calculation for the low load case, adding a new factor 'Low_roadload_f3'. This is a new value available from the manufacturer which should be included as an additional field in 'CO2Values'. A sample value for it:

	Low_roadload_f3 = 8.25

The calculation formula for 'Low_roadload_combined' should be changed to:

	((Low_roadload_f0 * Low_roadload_tm) / (1 - Low_roadload_f1)) + ((Low_roadload_f2 * Low_roadload_tm) / (Low_roadload_f3)) 

This calculation is very similar to the existing one except you use the new 'f3' value in the calculation instead of 'f1' in one place. The calculations for Mid and High Road Load should not be altered.
