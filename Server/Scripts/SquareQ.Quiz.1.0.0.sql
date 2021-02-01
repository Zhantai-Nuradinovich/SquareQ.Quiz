/*  
Create SquareQQuiz table
*/

CREATE TABLE [dbo].[SquareQQuiz](
	[QuizId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256),
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_SquareQQuiz] PRIMARY KEY CLUSTERED 
  (
	[QuizId] ASC
  )
)
GO

CREATE TABLE [dbo].[SquareQQuestion](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[QuizID] [int] NOT NULL,
	[Text] [nvarchar](256) NOT NULL,
	[QuestionType] [nvarchar](256) NOT NULL,
	[PicturePath] [nvarchar](256),
	[SecondsForPicture] [int],
  CONSTRAINT [PK_SquareQQuestion] PRIMARY KEY CLUSTERED 
  (
	[QuestionId] ASC
  )
)
GO

CREATE TABLE [dbo].[SquareQAnswer](
	[AnswerId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionID] [int] NOT NULL,
	[Text] [nvarchar](256) NOT NULL,
	[IsCorrect] [bit] DEFAULT 0 NOT NULL,
  CONSTRAINT [PK_SquareQQuestionType] PRIMARY KEY CLUSTERED 
  (
	[AnswerId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[SquareQQuiz] WITH CHECK ADD CONSTRAINT [FK_SquareQQuiz_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SquareQQuestion] WITH CHECK ADD CONSTRAINT [FK_SquareQQuestion_Quiz] FOREIGN KEY([QuizID])
REFERENCES [dbo].SquareQQuiz ([QuizId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SquareQAnswer] WITH CHECK ADD CONSTRAINT [FK_SquareQAnswer_Question] FOREIGN KEY([QuestionID])
REFERENCES [dbo].SquareQQuestion ([QuestionId])
ON DELETE NO ACTION
GO