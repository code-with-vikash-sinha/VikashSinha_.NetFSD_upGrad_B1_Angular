/*========================================================
SECTION 1 – TRIGGERS
========================================================*/


/*--------------------------------------------------------
Assignment 1 – Student Insert Audit Trigger
--------------------------------------------------------*/

-- Step 1 : Audit Table

CREATE TABLE StudentAudit
(
AuditID INT IDENTITY(1,1) PRIMARY KEY,
StudentID INT,
ActionType VARCHAR(20),
ActionDate DATETIME
);

-- Step 2 : Trigger

CREATE TRIGGER trg_StudentInsertAudit
ON Students
AFTER INSERT
AS
BEGIN

INSERT INTO StudentAudit (StudentID, ActionType, ActionDate)
SELECT StudentID,'INSERT',GETDATE()
FROM inserted;

END;
GO

-- Test Trigger
INSERT INTO Students
VALUES (101,'Rahul','Sharma','2005-06-10','M',1,'2025-06-01');

SELECT * FROM StudentAudit;



/*--------------------------------------------------------
Assignment 2 – Prevent Deleting Students with Enrollments
--------------------------------------------------------*/

CREATE TRIGGER trg_PreventStudentDelete
ON Students
INSTEAD OF DELETE
AS
BEGIN

IF EXISTS
(
SELECT 1
FROM Enrollments e
JOIN deleted d
ON e.StudentID = d.StudentID
)

BEGIN
RAISERROR('Student has course enrollments and cannot be deleted',16,1);
ROLLBACK TRANSACTION;
END

ELSE
BEGIN
DELETE FROM Students
WHERE StudentID IN (SELECT StudentID FROM deleted);
END

END;
GO



/*--------------------------------------------------------
Assignment 3 – Update Marks Audit Trigger
--------------------------------------------------------*/

CREATE TABLE MarksAudit
(
AuditID INT IDENTITY(1,1) PRIMARY KEY,
StudentID INT,
ExamID INT,
OldMarks INT,
NewMarks INT,
UpdatedDate DATETIME
);

CREATE TRIGGER trg_UpdateMarksAudit
ON Marks
AFTER UPDATE
AS
BEGIN

INSERT INTO MarksAudit
(StudentID,ExamID,OldMarks,NewMarks,UpdatedDate)

SELECT
d.StudentID,
d.ExamID,
d.MarksObtained,
i.MarksObtained,
GETDATE()

FROM deleted d
JOIN inserted i
ON d.MarkID = i.MarkID;

END;
GO



/*========================================================
SECTION 2 – EXCEPTION HANDLING
========================================================*/


/*--------------------------------------------------------
Assignment 1 – Insert Student with TRY CATCH
--------------------------------------------------------*/

CREATE PROCEDURE sp_AddStudent
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@DepartmentID INT,
@Gender CHAR(1),
@AdmissionDate DATE
AS
BEGIN

BEGIN TRY

INSERT INTO Students
(FirstName,LastName,DepartmentID,Gender,AdmissionDate)
VALUES
(@FirstName,@LastName,@DepartmentID,@Gender,@AdmissionDate);

PRINT 'Student inserted successfully';

END TRY

BEGIN CATCH

PRINT ERROR_MESSAGE();

END CATCH

END;
GO



/*--------------------------------------------------------
Assignment 2 – Marks Validation Procedure
--------------------------------------------------------*/

CREATE PROCEDURE sp_InsertMarks
@StudentID INT,
@ExamID INT,
@MarksObtained INT
AS
BEGIN

IF @MarksObtained < 0 OR @MarksObtained > 100
BEGIN
RAISERROR('Invalid Marks',16,1);
RETURN;
END

INSERT INTO Marks
(StudentID,ExamID,MarksObtained)
VALUES
(@StudentID,@ExamID,@MarksObtained);

END;
GO



/*--------------------------------------------------------
Assignment 3 – Safe Delete Student
--------------------------------------------------------*/

CREATE PROCEDURE sp_DeleteStudent
@StudentID INT
AS
BEGIN

BEGIN TRY

DELETE FROM Students
WHERE StudentID = @StudentID;

PRINT 'Student deleted';

END TRY

BEGIN CATCH

PRINT ERROR_MESSAGE();

END CATCH

END;
GO



/*========================================================
SECTION 3 – CURSORS
========================================================*/


/*--------------------------------------------------------
Assignment 1 – Display Students using Cursor
--------------------------------------------------------*/

CREATE PROCEDURE sp_DisplayStudentsCursor
AS
BEGIN

DECLARE @StudentID INT
DECLARE @StudentName VARCHAR(100)

DECLARE student_cursor CURSOR
FOR
SELECT StudentID, FirstName + ' ' + LastName
FROM Students

OPEN student_cursor

FETCH NEXT FROM student_cursor INTO @StudentID,@StudentName

WHILE @@FETCH_STATUS = 0
BEGIN

PRINT 'StudentID: ' + CAST(@StudentID AS VARCHAR)
PRINT 'StudentName: ' + @StudentName

FETCH NEXT FROM student_cursor INTO @StudentID,@StudentName

END

CLOSE student_cursor
DEALLOCATE student_cursor

END;
GO



/*--------------------------------------------------------
Assignment 2 – Total Marks per Student using Cursor
--------------------------------------------------------*/

CREATE PROCEDURE sp_CalculateStudentTotalMarks
AS
BEGIN

DECLARE @StudentID INT
DECLARE @StudentName VARCHAR(100)
DECLARE @TotalMarks INT

DECLARE student_cursor CURSOR
FOR
SELECT StudentID, FirstName + ' ' + LastName
FROM Students

OPEN student_cursor

FETCH NEXT FROM student_cursor INTO @StudentID,@StudentName

WHILE @@FETCH_STATUS = 0
BEGIN

SELECT @TotalMarks = SUM(MarksObtained)
FROM Marks
WHERE StudentID = @StudentID

PRINT 'Student: ' + @StudentName
PRINT 'Total Marks: ' + ISNULL(CAST(@TotalMarks AS VARCHAR),'0')

FETCH NEXT FROM student_cursor INTO @StudentID,@StudentName

END

CLOSE student_cursor
DEALLOCATE student_cursor

END;
GO



/*--------------------------------------------------------
Assignment 3 – Update Course Credits using Cursor
--------------------------------------------------------*/

CREATE PROCEDURE sp_UpdateCourseCredits
AS
BEGIN

DECLARE @CourseID INT
DECLARE @Credits INT

DECLARE course_cursor CURSOR
FOR
SELECT CourseID, Credits
FROM Courses
WHERE Credits < 3

OPEN course_cursor

FETCH NEXT FROM course_cursor INTO @CourseID,@Credits

WHILE @@FETCH_STATUS = 0
BEGIN

UPDATE Courses
SET Credits = Credits + 1
WHERE CourseID = @CourseID

FETCH NEXT FROM course_cursor INTO @CourseID,@Credits

END

CLOSE course_cursor
DEALLOCATE course_cursor

END;
GO



/*========================================================
SECTION 4 – TRANSACTIONS
========================================================*/


/*--------------------------------------------------------
Assignment 1 – Student Enrollment Transaction
--------------------------------------------------------*/

CREATE PROCEDURE sp_EnrollStudentTransaction
@StudentID INT,
@CourseID INT
AS
BEGIN

BEGIN TRANSACTION

BEGIN TRY

INSERT INTO Enrollments
(StudentID,CourseID,EnrollmentDate)
VALUES
(@StudentID,@CourseID,GETDATE());

COMMIT TRANSACTION

PRINT 'Enrollment Successful'

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION

PRINT ERROR_MESSAGE()

END CATCH

END;
GO



/*--------------------------------------------------------
Assignment 2 – Record Exam Marks Transaction
--------------------------------------------------------*/

CREATE PROCEDURE sp_RecordExamMarks
@StudentID INT,
@ExamID INT,
@Marks INT
AS
BEGIN

BEGIN TRANSACTION

BEGIN TRY

INSERT INTO Marks
(StudentID,ExamID,MarksObtained)
VALUES
(@StudentID,@ExamID,@Marks);

UPDATE Exams
SET ExamDate = GETDATE()
WHERE ExamID = @ExamID;

COMMIT TRANSACTION

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION

PRINT ERROR_MESSAGE();

END CATCH

END;
GO



/*--------------------------------------------------------
Assignment 3 – Transfer Student Department
--------------------------------------------------------*/

CREATE PROCEDURE sp_TransferStudentDepartment
@StudentID INT,
@NewDepartmentID INT
AS
BEGIN

BEGIN TRANSACTION

BEGIN TRY

IF NOT EXISTS
(
SELECT 1
FROM Departments
WHERE DepartmentID = @NewDepartmentID
)

BEGIN
RAISERROR('Department does not exist',16,1);
ROLLBACK TRANSACTION;
RETURN;
END

UPDATE Students
SET DepartmentID = @NewDepartmentID
WHERE StudentID = @StudentID

COMMIT TRANSACTION

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION
PRINT ERROR_MESSAGE()

END CATCH

END;
GO