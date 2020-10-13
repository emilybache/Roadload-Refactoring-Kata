cmake_minimum_required(VERSION 3.8)
project(roadload_refactoring)

set_property(GLOBAL PROPERTY USE_FOLDERS YES)

enable_testing()
add_subdirectory(third_party)
add_subdirectory(src)
add_subdirectory(tests)
