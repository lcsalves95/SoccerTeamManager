# Wait to be sure that SQL Server came up
sleep 15s

/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Password123 -d master -i create-database.sql