SolutionFile = BattleCore.sln

Compiler = MSBuild.exe /t:Build /p:Platform=Any\ CPU

ConfigDebug = /p:Configuration=Debug
ConfigRelease = /p:Configuration=Release

BuildDir = Build
BuildDebugDir = $(BuildDir)/Debug
BuildReleaseDir = $(BuildDir)/Release

OutputDir = Output
ProjectOutputDir = ../SFrameworkProject/Assets/Bundles/Assemblies

Assemblies = Battle.*

all: release

debug: clean debug_build prepare_debug_binary

release: clean release_build prepare_release_binary

clean:
	rm -rf $(BuildDir)
	rm -rf $(OutputDir)

debug_build:
	$(Compiler) $(ConfigDebug) $(SolutionFile)

release_build:
	$(Compiler) $(ConfigRelease) $(SolutionFile)

prepare_debug_binary:
	mkdir -p $(OutputDir)
	cp -rfv $(BuildDebugDir)/$(Assemblies) $(OutputDir)

prepare_release_binary:
	mkdir -p $(OutputDir)
	cp -rfv $(BuildReleaseDir)/$(Assemblies) $(OutputDir)

deploy:
	cp -rfv $(OutputDir)/$(Assemblies) $(ProjectOutputDir)

.PHONY:
	debug release clean debug_build release_build prepare_debug_binary prepare_release_binary deploy

