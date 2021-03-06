CREATE DATABASE [UniversityDB]
GO

USE [UniversityDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Students_GetNoOfCourses]
(
	@StudentID uniqueidentifier
)
RETURNS int
AS
BEGIN
	DECLARE @result int

	SELECT @result = COUNT(c.CourseID)
	FROM Students s
		LEFT JOIN Enrollments e ON e.StudentID = s.StudentID
		LEFT JOIN Courses c ON c.CourseID = e.CourseID
	WHERE s.StudentID = @StudentID

	RETURN @result
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseID] [uniqueidentifier] NOT NULL,
	[CourseName] [nvarchar](50) NOT NULL,
	[DepartmentID] [uniqueidentifier] NULL,
	[Credits] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID] [uniqueidentifier] NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollments](
	[StudentID] [uniqueidentifier] NOT NULL,
	[CourseID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Enrollments] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](150) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[BirthDay] [date] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentsAndCourse]
AS
SELECT s.StudentID,
		s.LastName,
		COUNT(c.CourseID) as NoOfCourses
FROM Students s
	LEFT JOIN Enrollments e ON e.StudentID = s.StudentID
	LEFT JOIN Courses c ON c.CourseID = e.CourseID
GROUP BY s.StudentID, s.LastName
GO

ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Department]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollments_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enrollments_Courses]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollments_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enrollments_Students]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Students_Insert]
(
	@StudentID uniqueidentifier,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Address nvarchar(150),
	@City nvarchar(50),
	@Country nvarchar(50),
	@PhoneNumber nvarchar(50),
	@EmailAddress nvarchar(50),
	@BirthDay datetime
)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Students VALUES(	@StudentID ,
									@FirstName,
									@LastName,
									@Address,
									@City,
									@Country,
									@PhoneNumber,
									@EmailAddress,
									@BirthDay)
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Students_ReadAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT StudentID,
			FirstName,
			LastName,
			[Address],
			City,
			Country,
			PhoneNumber,
			EmailAddress,
			BirthDay
	FROM Students
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Students_ReadById] 
(
	@StudentID uniqueidentifier
)
AS
BEGIN
	SELECT StudentID,
			FirstName,
			LastName,
			[Address],
			City,
			Country,
			PhoneNumber,
			EmailAddress,
			BirthDay
	FROM Students
	WHERE StudentID = @StudentID
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Courses_ReadAll
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CourseID,
			CourseName,
			DepartmentID,
			Credits
	FROM Courses 
END
GO
