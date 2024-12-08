@echo off

echo Creating MSSQL volume

echo Starting MSSQL in docker...
docker run --name uniwebshopdb -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=1Secure*Password1" -v uniwebshopdb:/var/opt/mssql -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

echo Waiting for MSSQL to start...

:CHECK_CONNECTION
timeout 2 > nul
echo Attempting to connect to MSSQL...
docker exec uniwebshopdb /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 1Secure*Password1 -Q "SELECT 1" > nul 2>&1
if errorlevel 1 (
    echo MSSQL not yet available, retrying...
    goto CHECK_CONNECTION
) else (
    echo MSSQL is now available.
)

REM echo Applying migrations...
REM cd UniWebShop.DataAccess
REM dotnet ef database update

@echo on
