/*===========================================================
SQL Server Assignments – Education Domain
===========================================================*/


/*===========================================================
Assignment 1 – Create Tables (DDL)
===========================================================*/

CREATE TABLE Departments(
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100),
    Location VARCHAR(100)
);

CREATE TABLE Teachers(
    TeacherID INT PRIMARY KEY,
    TeacherName VARCHAR(100),
    Email VARCHAR(100),
    DepartmentID INT,
    HireDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Students(
    StudentID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    Gender CHAR(1),
    DepartmentID INT,
    AdmissionDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Courses(
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(100),
    Credits INT,
    DepartmentID INT,
    TeacherID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
    FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID)
);

CREATE TABLE Enrollments(
    EnrollmentID INT PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    EnrollmentDate DATE,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Exams(
    ExamID INT PRIMARY KEY,
    CourseID INT,
    ExamDate DATE,
    ExamType VARCHAR(50),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Marks(
    MarkID INT PRIMARY KEY,
    StudentID INT,
    ExamID INT,
    MarksObtained INT,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);


/*===========================================================
Assignment 2 – Constraints
===========================================================*/

ALTER TABLE Departments
ADD CONSTRAINT UQ_DepartmentName UNIQUE(DepartmentName);

ALTER TABLE Students
ADD CONSTRAINT CHK_Gender CHECK (Gender IN ('M','F'));

ALTER TABLE Courses
ADD CONSTRAINT CHK_Credits CHECK (Credits BETWEEN 1 AND 5);

ALTER TABLE Marks
ADD CONSTRAINT CHK_Marks CHECK (MarksObtained BETWEEN 0 AND 100);

ALTER TABLE Teachers
ADD CONSTRAINT UQ_Email UNIQUE(Email);

ALTER TABLE Enrollments
ADD CONSTRAINT DF_EnrollmentDate DEFAULT GETDATE() FOR EnrollmentDate;


/*===========================================================
Assignment 3 – ALTER TABLE
===========================================================*/

-- Add PhoneNumber column
ALTER TABLE Students
ADD PhoneNumber VARCHAR(15);

-- Add Salary column
ALTER TABLE Teachers
ADD Salary INT;

-- Modify Salary datatype
ALTER TABLE Teachers
ALTER COLUMN Salary DECIMAL(10,2);

-- Add CHECK constraint
ALTER TABLE Teachers
ADD CONSTRAINT CHK_Salary CHECK (Salary > 20000);

-- Drop PhoneNumber column
ALTER TABLE Students
DROP COLUMN PhoneNumber;

-- Rename column
EXEC sp_rename 'Students.FirstName','StudentFirstName','COLUMN';


/*===========================================================
Assignment 4 – Insert Sample Data
===========================================================*/

INSERT INTO Departments VALUES
(1,'Computer Science','Block A'),
(2,'Mechanical','Block B'),
(3,'Electrical','Block C'),
(4,'Civil','Block D'),
(5,'Electronics','Block E');


INSERT INTO Teachers VALUES
(1,'John','john@gmail.com',1,'2022-01-10',50000),
(2,'Ravi','ravi@gmail.com',2,'2021-05-12',45000),
(3,'Anita','anita@gmail.com',1,'2023-03-15',60000),
(4,'Karan','karan@gmail.com',3,'2020-07-01',55000),
(5,'Meena','meena@gmail.com',4,'2019-02-20',48000);


INSERT INTO Students VALUES
(1,'Aman','Sharma','2006-04-12','M',1,'2023-06-01'),
(2,'Anita','Singh','2005-05-10','F',1,'2023-06-01'),
(3,'Rahul','Verma','2006-08-21','M',2,'2023-06-01'),
(4,'Priya','Kumari','2005-11-12','F',3,'2023-06-01'),
(5,'Rohit','Das','2006-02-18','M',2,'2023-06-01');


INSERT INTO Courses VALUES
(1,'Database',4,1,1),
(2,'Operating System',4,1,3),
(3,'Thermodynamics',3,2,2),
(4,'Circuit Theory',3,3,4),
(5,'Structural Design',4,4,NULL);


INSERT INTO Enrollments VALUES
(1,1,1,GETDATE()),
(2,1,2,GETDATE()),
(3,2,1,GETDATE()),
(4,3,3,GETDATE()),
(5,4,4,GETDATE());


INSERT INTO Exams VALUES
(1,1,'2025-01-10','Midterm'),
(2,1,'2025-03-15','Final'),
(3,2,'2025-01-12','Midterm'),
(4,3,'2025-02-20','Final'),
(5,4,'2025-03-01','Midterm');


INSERT INTO Marks VALUES
(1,1,1,85),
(2,1,2,90),
(3,2,1,70),
(4,3,4,60),
(5,4,5,88);


/*===========================================================
Assignment 5 – Filtering Data (WHERE)
===========================================================*/

-- Students from Computer Science department
SELECT * FROM Students
WHERE DepartmentID = 1;

-- Teachers hired after 2022
SELECT * FROM Teachers
WHERE HireDate > '2022-01-01';

-- Students name starts with A
SELECT * FROM Students
WHERE StudentFirstName LIKE 'A%';

-- Courses credits > 3
SELECT * FROM Courses
WHERE Credits > 3;

-- Students born between 2005 and 2008
SELECT * FROM Students
WHERE DateOfBirth BETWEEN '2005-01-01' AND '2008-12-31';

-- Students not from Mechanical department
SELECT * FROM Students
WHERE DepartmentID <> 2;

-- Teachers salary between 40000 and 70000
SELECT * FROM Teachers
WHERE Salary BETWEEN 40000 AND 70000;

-- Courses not taught by teacher 3
SELECT * FROM Courses
WHERE TeacherID <> 3;


/*===========================================================
Assignment 6 – GROUP BY
===========================================================*/

-- Count students per department
SELECT DepartmentID, COUNT(*) AS TotalStudents
FROM Students
GROUP BY DepartmentID;

-- Average marks per exam
SELECT ExamID, AVG(MarksObtained) AS AvgMarks
FROM Marks
GROUP BY ExamID;

-- Students per course
SELECT CourseID, COUNT(StudentID)
FROM Enrollments
GROUP BY CourseID;

-- Max marks per exam
SELECT ExamID, MAX(MarksObtained)
FROM Marks
GROUP BY ExamID;

-- Min marks per exam
SELECT ExamID, MIN(MarksObtained)
FROM Marks
GROUP BY ExamID;

-- Departments having more than 5 students
SELECT DepartmentID, COUNT(*) 
FROM Students
GROUP BY DepartmentID
HAVING COUNT(*) > 5;


/*===========================================================
Assignment 7 – Joins
===========================================================*/

-- Students with department name
SELECT StudentFirstName, DepartmentName
FROM Students
JOIN Departments
ON Students.DepartmentID = Departments.DepartmentID;

-- Courses with teacher names
SELECT CourseName, TeacherName
FROM Courses
JOIN Teachers
ON Courses.TeacherID = Teachers.TeacherID;

-- Student name and enrolled courses
SELECT StudentFirstName, CourseName
FROM Students
JOIN Enrollments ON Students.StudentID = Enrollments.StudentID
JOIN Courses ON Enrollments.CourseID = Courses.CourseID;

-- Students with exam marks
SELECT StudentFirstName, MarksObtained
FROM Students
JOIN Marks ON Students.StudentID = Marks.StudentID;

-- Left join example
SELECT CourseName, TeacherName
FROM Courses
LEFT JOIN Teachers
ON Courses.TeacherID = Teachers.TeacherID;

-- Teachers not assigned to course
SELECT TeacherName
FROM Teachers
WHERE TeacherID NOT IN (SELECT TeacherID FROM Courses);


/*===========================================================
Assignment 8 – Subqueries
===========================================================*/

-- Students with marks greater than average
SELECT *
FROM Marks
WHERE MarksObtained > (SELECT AVG(MarksObtained) FROM Marks);

-- Courses with max credits
SELECT *
FROM Courses
WHERE Credits = (SELECT MAX(Credits) FROM Courses);

-- Students enrolled in more than 2 courses
SELECT StudentID
FROM Enrollments
GROUP BY StudentID
HAVING COUNT(CourseID) > 2;

-- Teachers in same department as John
SELECT *
FROM Teachers
WHERE DepartmentID =
(SELECT DepartmentID FROM Teachers WHERE TeacherName='John');

-- Highest marks in exam
SELECT *
FROM Marks
WHERE MarksObtained =
(SELECT MAX(MarksObtained) FROM Marks);

-- Department with max students
SELECT DepartmentID
FROM Students
GROUP BY DepartmentID
HAVING COUNT(*) >= ALL
(SELECT COUNT(*) FROM Students GROUP BY DepartmentID);


/*===========================================================
Assignment 9 – Views
===========================================================*/

CREATE VIEW vw_StudentInfo
AS
SELECT StudentID, StudentFirstName, DepartmentName
FROM Students
JOIN Departments
ON Students.DepartmentID = Departments.DepartmentID;


CREATE VIEW vw_StudentCourses
AS
SELECT StudentFirstName, CourseName, EnrollmentDate
FROM Students
JOIN Enrollments ON Students.StudentID = Enrollments.StudentID
JOIN Courses ON Enrollments.CourseID = Courses.CourseID;


CREATE VIEW vw_ExamResults
AS
SELECT StudentFirstName, CourseName, ExamType, MarksObtained
FROM Students
JOIN Marks ON Students.StudentID = Marks.StudentID
JOIN Exams ON Marks.ExamID = Exams.ExamID
JOIN Courses ON Exams.CourseID = Courses.CourseID;

-- Query view
SELECT * FROM vw_StudentInfo;

-- Drop view
DROP VIEW vw_StudentInfo;


/*===========================================================
Assignment 10 – Indexes
===========================================================*/

CREATE INDEX idx_LastName
ON Students(LastName);

CREATE INDEX idx_Email
ON Teachers(Email);

CREATE INDEX idx_Enrollment
ON Enrollments(StudentID,CourseID);

CREATE UNIQUE INDEX idx_DepartmentName
ON Departments(DepartmentName);

DROP INDEX idx_LastName ON Students;