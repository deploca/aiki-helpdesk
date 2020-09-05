#!/bin/bash

# Copy deploy folder contents
mkdir ./_publish
cp ./deploca-package.yml ./_publish/

# Publish Api Project
cd ./src/Aiki-HelpDesk-Admin-WebAPI
dotnet publish -c Release -o ../../_publish/webapi --self-contained false
cd ..
cd ..

# Publish UI
cd ./src/Aiki-HelpDesk-Admin-UI
npm install
npm run build
cd ..
cd ..

echo Publish finished successfully
