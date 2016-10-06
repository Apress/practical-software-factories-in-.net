@echo off
if exist SoftwareFactorySchemaItemTemplate.zip del SoftwareFactorySchemaItemTemplate.zip /F
if exist SoftwareFactorySchemaProjectTemplate.zip del SoftwareFactorySchemaProjectTemplate.zip /F

cd SoftwareFactorySchemaItemTemplate
"C:\Program Files\ZipGenius 6\zg.exe" -add "..\SoftwareFactorySchemaItemTemplate.zip" C9 R1 K0 +*.*
cd..

cd SoftwareFactorySchemaProjectTemplate
"C:\Program Files\ZipGenius 6\zg.exe" -add "..\SoftwareFactorySchemaProjectTemplate.zip" C9 R1 K0 +*.*
cd..