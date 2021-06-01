#!/bin/bash
cd /opt/ccs/bin/
rm JudgeOnPremise *.dll *.deps.json *.pdb *.runtimeconfig.json
cd /usr/local/src/acm.xylab.fun/src/OnPremise/
dotnet clean -c Release
dotnet publish -o /opt/ccs/bin/ -c Release
