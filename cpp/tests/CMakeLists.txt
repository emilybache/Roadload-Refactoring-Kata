set(CMAKE_CXX_STANDARD 17)
set(SOURCE_FILES
        main.cpp
        roadload_tests.cpp printers.h)
add_executable(tests ${SOURCE_FILES} )
target_link_libraries(tests src_library Catch2::Catch2 ApprovalTests::ApprovalTests)

# Work around Ninja in-source build error
# See https://github.com/approvals/ApprovalTests.cpp/blob/master/doc/TroubleshootingMisconfiguredBuild.md#situation-visual-studio-with-visual-c-compiler-clexe
target_compile_options(tests PUBLIC $<$<CXX_COMPILER_ID:MSVC>:/FC>)

add_test(NAME tests COMMAND tests)
