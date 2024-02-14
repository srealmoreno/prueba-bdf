#!/bin/bash

# Entry point for initializing the container
# mssql-server-linux

function wait_engine(){
	for i in {1..60}; do
		/opt/mssql-tools/bin/sqlcmd -h -1 -t 1 -U sa -P "${SA_PASSWORD}" -Q "SET NOCOUNT ON; Select SUM(state) from sys.databases" > /dev/null 2>&1
		if [ $? -eq 0 ]; then
			return
		fi
		sleep 1
	done

	echo "SQL Server took more than 60 seconds to start up or one or more databases are not in an ONLINE state" >&2
	exit 1
}

function import_sql_files() {
	# Check if the /docker-entrypoint-initdb.d directory exists
	if ! [ -d "/docker-entrypoint-initdb.d" ]; then
		return
	fi

	# Loop through all the files in the /docker-entrypoint-initdb.d directory
	# (Recursively) and execute them
	for FILE in /docker-entrypoint-initdb.d/**/*.sql; do
		echo "Executing SQL file: $FILE"
		/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -d master -i $FILE
		if [ $? -ne 0 ]; then
			echo "Error occurred while executing SQL file: $FILE" >&2
			exit 1
		fi
	done
}


function initialize_database() {
	# Check if already initialized
	if [ -f /var/opt/mssql/.initialized ]; then
		return
	fi

	touch /var/opt/mssql/.initialized

	# Wait for the SQL Server to start
	wait_engine
	# Import the SQL files
	import_sql_files

	echo "Database initialization complete"
}

initialize_database &

# Start SQL Server
/opt/mssql/bin/sqlservr
