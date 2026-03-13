use sqlAssignments;
CREATE TABLE Worker (
	WORKER_ID INT PRIMARY KEY IDENTITY(1,1),
	FIRST_NAME VARCHAR(25),
	LAST_NAME VARCHAR(25),
	SALARY INT,
	JOINING_DATE DATETIME,
	DEPARTMENT CHAR(25)
);
CREATE TABLE Bonus (
	WORKER_REF_ID INT,
	BONUS_AMOUNT INT,
	BONUS_DATE DATETIME,
	FOREIGN KEY (WORKER_REF_ID)
		REFERENCES Worker(WORKER_ID)
        ON DELETE CASCADE
);
CREATE TABLE Title (
	WORKER_REF_ID INT,
	WORKER_TITLE CHAR(25),
	AFFECTED_FROM DATETIME,
	FOREIGN KEY (WORKER_REF_ID)
		REFERENCES Worker(WORKER_ID)
        ON DELETE CASCADE
);

insert into Worker(FIRST_NAME,LAST_NAME,SALARY,JOINING_DATE,DEPARTMENT)
values
    ('Monika' , 'Arora' , 100000 ,    '2014-02-20  09:00:00' , 'HR'),
	('Niharika' , 'Verma',	80000,	'2014-06-11  09:00:00',	'Admin'),
	('Vishal',	'Singhal',	300000,	'2014-02-20  09:00:00',	'HR'),
    ('Amitabh',	'Singh',	500000,	'2014-02-20  09:00:00',	'Admin'),
    ('Vivek' ,	'Bhati',	500000,	'2014-06-11  09:00:00',	'Admin'),
    ('Vipul' ,	'Diwan',	200000,	'2014-06-11  09:00:00',	'Account'),
    ('Satish' ,	'Kumar'	,   5000,	'2014-01-20  09:00:00',	'Account'),
    ('Geetika',	'Chauhan',	90000,	'2014-04-11  09:00:00',	'Admin');
	select * from Worker;

	insert into Bonus(WORKER_REF_ID,BONUS_DATE,BONUS_AMOUNT)
	values
	   ( 1	,'2016-02-20 00:00:00',	5000),
       (2	,'2016-06-11 00:00:00',	3000),
       (3	,'2016-02-20 00:00:00',	4000),
       (1	,'2016-02-20 00:00:00',	4500), 
       (2,	'2016-06-11 00:00:00',	3500);
       select * from Bonus;

	insert into Title(WORKER_REF_ID,WORKER_TITLE,AFFECTED_FROM)
	values
	   (1, 'Manager', '2016-02-20 00:00:00'),
       (2, 'Executive', '2016-06-11 00:00:00'),
       (8, 'Executive', '2016-06-11 00:00:00'),
       (5, 'Manager', '2016-06-11 00:00:00'),
       (4, 'Asst. Manager', '2016-06-11 00:00:00'),
       (7, 'Executive', '2016-06-11 00:00:00'),
       (6, 'Lead', '2016-06-11 00:00:00'),
       (3, 'Lead', '2016-06-11 00:00:00');
     select * from Title;

	 
-- 1 Fetch FIRST_NAME with alias WORKER_NAME
SELECT FIRST_NAME AS WORKER_NAME FROM Worker;

-- 2 FIRST_NAME in upper case
SELECT UPPER(FIRST_NAME) FROM Worker;

-- 3 Unique DEPARTMENT values
SELECT DISTINCT DEPARTMENT FROM Worker;

-- 4 First three characters of FIRST_NAME
SELECT SUBSTRING(FIRST_NAME,1,3) FROM Worker;

-- 5 Position of alphabet 'a' in 'Amitabh'
SELECT CHARINDEX('a','Amitabh');

-- 6 Remove right side spaces
SELECT RTRIM(FIRST_NAME) FROM Worker;

-- 7 Remove left side spaces
SELECT LTRIM(DEPARTMENT) FROM Worker;

-- 8 Unique department with length
SELECT DISTINCT DEPARTMENT, LEN(DEPARTMENT) AS LENGTH
FROM Worker;

-- 9 Replace 'a' with 'A'
SELECT REPLACE(FIRST_NAME,'a','A')
FROM Worker;

-- 10 Combine FIRST_NAME and LAST_NAME
SELECT FIRST_NAME + ' ' + LAST_NAME AS COMPLETE_NAME
FROM Worker;

-- 11 Order by FIRST_NAME ascending
SELECT *
FROM Worker
ORDER BY FIRST_NAME ASC;

-- 12 Order by FIRST_NAME ASC and DEPARTMENT DESC
SELECT *
FROM Worker
ORDER BY FIRST_NAME ASC, DEPARTMENT DESC;

-- 13 Workers with first name Vipul and Satish
SELECT *
FROM Worker
WHERE FIRST_NAME IN ('Vipul','Satish');

-- 14 Excluding Vipul and Satish
SELECT *
FROM Worker
WHERE FIRST_NAME NOT IN ('Vipul','Satish');

-- 15 Workers from Admin department
SELECT *
FROM Worker
WHERE DEPARTMENT = 'Admin';

-- 16 FIRST_NAME containing 'a'
SELECT *
FROM Worker
WHERE FIRST_NAME LIKE '%a%';

-- 17 FIRST_NAME ending with 'a'
SELECT *
FROM Worker
WHERE FIRST_NAME LIKE '%a';

-- 18 FIRST_NAME ending with 'h' and 6 characters
SELECT *
FROM Worker
WHERE FIRST_NAME LIKE '_____h';

-- 19 Salary between 100000 and 500000
SELECT *
FROM Worker
WHERE SALARY BETWEEN 100000 AND 500000;

-- 20 Workers joined in Feb 2014
SELECT *
FROM Worker
WHERE MONTH(JOINING_DATE) = 2
AND YEAR(JOINING_DATE) = 2014;

-- 21 Workers with salary between 50000 and 100000
SELECT FIRST_NAME, SALARY
FROM Worker
WHERE SALARY BETWEEN 50000 AND 100000;

-- 22 Count workers per department
SELECT DEPARTMENT, COUNT(*) AS TOTAL_WORKERS
FROM Worker
GROUP BY DEPARTMENT
ORDER BY TOTAL_WORKERS DESC;

-- 23 Workers who are Managers
SELECT W.*
FROM Worker W
JOIN Title T
ON W.WORKER_ID = T.WORKER_REF_ID
WHERE T.WORKER_TITLE = 'Manager';

-- 24 Current date and time
SELECT GETDATE() AS CURRENT_DATE_TIME;

-- 25 Top 10 records
SELECT TOP 10 *
FROM Worker;