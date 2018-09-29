#!/bin/bash

scriptDir=$(dirname -- "$(readlink -f -- "$BASH_SOURCE")")
mono  ${scriptDir}/GitVersion.exe /updateassemblyinfo /output buildserver

echo "$GitVersion_Major"
echo "$GitVersion_Minor"
echo "$GitVersion_Patch"
echo "$GitVersion_PreReleaseTag"
echo "$GitVersion_PreReleaseTagWithDash"
echo "$GitVersion_PreReleaseLabel"
echo "$GitVersion_PreReleaseNumber"
echo "$GitVersion_BuildMetaData"
echo "$GitVersion_BuildMetaDataPadded"
echo "$GitVersion_FullBuildMetaData"
echo "$GitVersion_MajorMinorPatch"
echo "$GitVersion_SemVer"
echo "$GitVersion_LegacySemVer"
echo "$GitVersion_LegacySemVerPadded"
echo "$GitVersion_AssemblySemVer"
echo "$GitVersion_FullSemVer"
echo "$GitVersion_InformationalVersion"
echo "$GitVersion_BranchName"
echo "$GitVersion_Sha"
echo "$GitVersion_NuGetVersionV2"
echo "$GitVersion_NuGetVersion"
echo "$GitVersion_CommitsSinceVersionSource"
echo "$GitVersion_CommitsSinceVersionSourcePadded"
echo "$GitVersion_CommitDate"