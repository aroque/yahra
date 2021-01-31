IF DB_ID('YAHRA_DB') IS NULL
	CREATE DATABASE YAHRA_DB;

use YAHRA_DB;

IF OBJECT_ID('department') IS NULL
	CREATE TABLE department(
		id integer,
		name nvarchar(50) NOT NULL,
		CONSTRAINT pk_department PRIMARY KEY (id)
	);

IF OBJECT_ID('employee_status') IS NULL
	CREATE TABLE employee_status(
		id integer,
		name nvarchar(50) not null,
		CONSTRAINT pk_employee_status PRIMARY KEY (id)
	);

IF OBJECT_ID('employee') IS NULL
	CREATE TABLE employee(
		id integer identity,
		first_name nvarchar(50) not null,
		surname nvarchar(50) not null,
		email nvarchar(255) not null,
		date_of_birth date not null,
		department_id integer not null,
		employee_status_id integer not null,
		CONSTRAINT pk_employee PRIMARY KEY (id),
		CONSTRAINT fk_employee_department FOREIGN KEY (department_id) REFERENCES department (id),
		CONSTRAINT fk_employee_employee_status FOREIGN KEY (employee_status_id) REFERENCES employee_status (id)
	);

INSERT INTO department VALUES (1, 'HR');
INSERT INTO department VALUES (2, 'IT');
INSERT INTO department VALUES (3, 'Marketing');

INSERT INTO employee_status VALUES (1, 'Approved');
INSERT INTO employee_status VALUES (2, 'Pending');
INSERT INTO employee_status VALUES (3, 'Disabled');

INSERT INTO employee VALUES('André', 'Roque', 'andreroque@email.pt', '1988-07-26', 2, 2);
INSERT INTO employee VALUES('André', 'Alves', 'andrealves@email.pt', '1988-07-26', 1, 1);

SELECT * FROM department;
SELECT * FROM employee_status;
SELECT * FROM employee;

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'TestUser')
BEGIN
	CREATE LOGIN TestUser WITH PASSWORD = 'test'
    CREATE USER TestUser FOR LOGIN TestUser
    EXEC sp_addrolemember N'db_owner', N'TestUser'
END;
GO