@echo off

echo Removing old MSSQl container
docker rm -f uniwebshopdb

echo Removing old MSSQL volume
docker volume rm uniwebshopdb

call create_db.bat

@echo on