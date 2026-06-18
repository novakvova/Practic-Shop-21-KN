@echo off

REM ==== API ====
cd WebStoreMVC
docker build -t college-mvc .
docker tag college-mvc:latest novakvova/college-mvc:latest
docker push novakvova/college-mvc:latest

echo DONE
pause
