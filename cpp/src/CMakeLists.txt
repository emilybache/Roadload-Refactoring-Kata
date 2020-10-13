add_library(src_library
        roadload.h
        roadload.c
        )
target_include_directories(src_library
        PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}
        )
