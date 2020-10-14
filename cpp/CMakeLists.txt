cmake_minimum_required(VERSION 3.8)
project(roadload_refactoring)

set_property(GLOBAL PROPERTY USE_FOLDERS YES)

# uncomment these lines to enable coverage measurements using gcov
set(CMAKE_C_FLAGS "--coverage")
set(CMAKE_CXX_FLAGS "--coverage")


enable_testing()
add_subdirectory(third_party)
add_subdirectory(src)
add_subdirectory(tests)
