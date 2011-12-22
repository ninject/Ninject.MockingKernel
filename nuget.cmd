@echo off
set nantfile=Ninject.build
set nantexe=tools\nant\nant.exe
set buildlog=Ninject-Nant-Build.log
set unittestlog=Ninject-Nant-unit-tests.log

%nantexe% -buildfile:%nantfile% nuget-all %1 %2 %3 %4 %5 %6 %7 %8

pause
