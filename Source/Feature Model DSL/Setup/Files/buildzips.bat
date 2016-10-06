@echo off
if exist FeatureModelItemTemplate_CS.zip del FeatureModelItemTemplate_CS.zip /F
if exist FeatureModelItemTemplate_VB.zip del FeatureModelItemTemplate_VB.zip /F

cd FeatureModelItemTemplate_CS
"C:\Program Files\ZipGenius 6\zg.exe" -add "..\FeatureModelItemTemplate_CS.zip" C9 R1 K0 +*.*
cd..

cd FeatureModelItemTemplate_VB
"C:\Program Files\ZipGenius 6\zg.exe" -add "..\FeatureModelItemTemplate_VB.zip" C9 R1 K0 +*.*
cd..
