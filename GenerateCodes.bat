@setlocal EnableDelayedExpansion

@set curdir=%~dp0
@set jenneyexec=%curdir%/Jenny/Jenny/Jenny.exe

echo %curdir%

@echo =========Generate Battle Logic Codes=========
@cd %curdir%/BattleLogic
@%jenneyexec% gen BattleLogic.properties
@echo =========Generate Battle Logic Codes Finished!=========
@echo.

@echo =========Generate Battle View============
@cd %curdir%/BattleView
@%jenneyexec% gen BattleView.properties
@echo =========Generate Battle View Codes Finished!=========
@echo.

if NOT ["%errorlevel%"]==["0"] (
    pause
    exit /b %errorlevel%
)