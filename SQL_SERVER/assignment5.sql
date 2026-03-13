/*========================================================
SECTION 1 – VIEWS
========================================================*/


/*--------------------------------------------------------
Assignment 1 – Student Department View
--------------------------------------------------------*/

CREATE VIEW vw_StudentDepartment
AS
SELECT 
    s.StudentID,
    s.FirstName + ' ' + s.LastName AS StudentName,
    d.DepartmentName,
    s.AdmissionDate
FROM Students s
INNER JOIN Departments d
ON s.DepartmentID = d.DepartmentID;
GO

-- Retrieve all records
SELECT * FROM vw_StudentDepartment;

-- Filter Computer Science students
SELECT *
FROM vw_StudentDepartment
WHERE DepartmentName = 'Computer Science';

-- Drop View
DROP VIEW vw_StudentDepartment;
GO



/*--------------------------------------------------------
Assignment 2 – Student Course Enrollment View
--------------------------------------------------------*/

CREATE VIEW vw_StudentCourses
AS
SELECT 
    s.FirstName + ' ' + s.LastName AS StudentName,
    c.CourseName,
    e.EnrollmentDate,
    s.StudentID
FROM Students s
INNER JOIN Enrollments e
ON s.StudentID = e.StudentID
INNER JOIN Courses c
ON e.CourseID = c.CourseID;
GO

-- Courses taken by StudentID = 5
SELECT *
FROM vw_StudentCourses
WHERE StudentID = 5;

-- Count courses per student
SELECT StudentName, COUNT(CourseName) AS TotalCourses
FROM vw_StudentCourses
GROUP BY StudentName;

-- Students enrolled after 2024
SELECT *
FROM vw_StudentCourses
WHERE EnrollmentDate > '2024-01-01';



/*--------------------------------------------------------
Assignment 3 – Exam Result View
--------------------------------------------------------*/

CREATE VIEW vw_ExamResults
AS
SELECT 
    s.FirstName + ' ' + s.LastName AS StudentName,
    c.CourseName,
    e.ExamType,
    m.MarksObtained,
    e.ExamID
FROM Students s
INNER JOIN Marks m
ON s.StudentID = m.StudentID
INNER JOIN Exams e
ON m.ExamID = e.ExamID
INNER JOIN Courses c
ON e.CourseID = c.CourseID;
GO

-- Students scoring > 80
SELECT *
FROM vw_ExamResults
WHERE MarksObtained > 80;

-- Top scorers in each exam
SELECT *
FROM vw_ExamResults
WHERE MarksObtained IN
(
SELECT MAX(MarksObtained)
FROM vw_ExamResults
GROUP BY ExamID
);

-- Failed students (<40)
SELECT *
FROM vw_ExamResults
WHERE MarksObtained < 40;



/*--------------------------------------------------------
Assignment 4 – Aggregate View
--------------------------------------------------------*/

CREATE VIEW vw_DepartmentStudentCount
AS
SELECT 
    d.DepartmentName,
    COUNT(s.StudentID) AS TotalStudents
FROM Departments d
LEFT JOIN Students s
ON d.DepartmentID = s.DepartmentID
GROUP BY d.DepartmentName;
GO

-- Departments with more than 10 students
SELECT *
FROM vw_DepartmentStudentCount
WHERE TotalStudents > 10;

-- Sort by highest student count
SELECT *
FROM vw_DepartmentStudentCount
ORDER BY TotalStudents DESC;



/*========================================================
SECTION 2 – STORED PROCEDURES
========================================================*/


/*--------------------------------------------------------
Assignment 1 – Insert Student Procedure
--------------------------------------------------------*/

CREATE PROCEDURE sp_InsertStudent
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@Gender CHAR(1),
@DepartmentID INT,
@AdmissionDate DATE
AS
BEGIN
INSERT INTO Students
(FirstName,LastName,Gender,DepartmentID,AdmissionDate)
VALUES
(@FirstName,@LastName,@Gender,@DepartmentID,@AdmissionDate);
END;
GO

-- Execute Procedure
EXEC sp_InsertStudent 'Rahul','Sharma','M',1,'2025-06-01';

-- Verify
SELECT * FROM Students;



/*--------------------------------------------------------
Assignment 2 – Get Students By Department
--------------------------------------------------------*/

CREATE PROCEDURE sp_GetStudentsByDepartment
@DepartmentID INT
AS
BEGIN
SELECT 
StudentID,
FirstName + ' ' + LastName AS StudentName,
AdmissionDate
FROM Students
WHERE DepartmentID = @DepartmentID;
END;
GO

EXEC sp_GetStudentsByDepartment 2;
EXEC sp_GetStudentsByDepartment 3;



/*--------------------------------------------------------
Assignment 3 – Course Enrollment Procedure
--------------------------------------------------------*/

CREATE PROCEDURE sp_EnrollStudent
@StudentID INT,
@CourseID INT
AS
BEGIN
INSERT INTO Enrollments
(StudentID,CourseID,EnrollmentDate)
VALUES
(@StudentID,@CourseID,GETDATE());
END;
GO

EXEC sp_EnrollStudent 3,2;



/*--------------------------------------------------------
Assignment 4 – Student Marks Procedure
--------------------------------------------------------*/

CREATE PROCEDURE sp_GetStudentMarks
@StudentID INT
AS
BEGIN
SELECT
s.FirstName + ' ' + s.LastName AS StudentName,
c.CourseName,
e.ExamType,
m.MarksObtained
FROM Students s
INNER JOIN Marks m
ON s.StudentID = m.StudentID
INNER JOIN Exams e
ON m.ExamID = e.ExamID
INNER JOIN Courses c
ON e.CourseID = c.CourseID
WHERE s.StudentID = @StudentID;
END;
GO

EXEC sp_GetStudentMarks 1;



/*--------------------------------------------------------
Assignment 5 – Update Student Marks
--------------------------------------------------------*/

CREATE PROCEDURE sp_UpdateMarks
@MarkID INT,
@NewMarks INT
AS
BEGIN
UPDATE Marks
SET MarksObtained = @NewMarks
WHERE MarkID = @MarkID;

SELECT * FROM Marks
WHERE MarkID = @MarkID;
END;
GO

EXEC sp_UpdateMarks 2,95;



/*--------------------------------------------------------
Assignment 6 – Delete Enrollment
--------------------------------------------------------*/

CREATE PROCEDURE sp_DeleteEnrollment
@EnrollmentID INT
AS
BEGIN
DELETE FROM Enrollments
WHERE EnrollmentID = @EnrollmentID;
END;
GO

EXEC sp_DeleteEnrollment 5;



/*========================================================
SECTION 3 – USER DEFINED FUNCTIONS
========================================================*/


/*--------------------------------------------------------
Assignment 1 – Grade Function (Scalar)
--------------------------------------------------------*/

CREATE FUNCTION fn_GetGrade(@Marks INT)
RETURNS VARCHAR(10)
AS
BEGIN

DECLARE @Grade VARCHAR(10);

IF @Marks >= 90
SET @Grade='A';
ELSE IF @Marks >=75
SET @Grade='B';
ELSE IF @Marks >=60
SET @Grade='C';
ELSE
SET @Grade='Fail';

RETURN @Grade;

END;
GO

-- Example Use
SELECT 
StudentID,
MarksObtained,
dbo.fn_GetGrade(MarksObtained) AS Grade
FROM Marks;



/*--------------------------------------------------------
Assignment 2 – Student Age Function
--------------------------------------------------------*/

CREATE FUNCTION fn_GetStudentAge(@DOB DATE)
RETURNS INT
AS
BEGIN

RETURN DATEDIFF(YEAR,@DOB,GETDATE());

END;
GO

SELECT
FirstName,
DateOfBirth,
dbo.fn_GetStudentAge(DateOfBirth) AS Age
FROM Students;



/*--------------------------------------------------------
Assignment 3 – Total Marks Function
--------------------------------------------------------*/

CREATE FUNCTION fn_GetTotalMarks(@StudentID INT)
RETURNS INT
AS
BEGIN

DECLARE @Total INT;

SELECT @Total = SUM(MarksObtained)
FROM Marks
WHERE StudentID = @StudentID;

RETURN @Total;

END;
GO

SELECT
StudentID,
dbo.fn_GetTotalMarks(StudentID) AS TotalMarks
FROM Students;



/*--------------------------------------------------------
Assignment 4 – Student Courses Function (Table Valued)
--------------------------------------------------------*/

CREATE FUNCTION fn_GetStudentCourses(@StudentID INT)
RETURNS TABLE
AS
RETURN
(
SELECT
c.CourseName,
e.EnrollmentDate
FROM Enrollments e
INNER JOIN Courses c
ON e.CourseID = c.CourseID
WHERE e.StudentID = @StudentID
);
GO

SELECT *
FROM dbo.fn_GetStudentCourses(1);



/*--------------------------------------------------------
Assignment 5 – Department Students Function
--------------------------------------------------------*/

CREATE FUNCTION fn_GetDepartmentStudents(@DepartmentID INT)
RETURNS TABLE
AS
RETURN
(
SELECT
StudentID,
FirstName + ' ' + LastName AS StudentName,
AdmissionDate
FROM Students
WHERE DepartmentID = @DepartmentID
);
GO

SELECT *
FROM dbo.fn_GetDepartmentStudents(1);