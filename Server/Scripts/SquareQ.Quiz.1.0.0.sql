/*  
Create SquareQQuiz table
*/

CREATE TABLE [dbo].[SquareQQuiz](
	[QuizId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[QuizType] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
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

CREATE TABLE [dbo].[SquareQQuizItem](
	[QuizItemId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[QuizID] [int] NOT NULL,
	[Question] [nvarchar](256) NOT NULL,
	[PicturePath] [nvarchar](256) NOT NULL,
	[Answers] [nvarchar](256) NOT NULL,
	[RightAnswer] [nvarchar](256) NOT NULL,
	[QuestionType] [nvarchar](256) NOT NULL,
  CONSTRAINT [PK_SquareQQuizItem] PRIMARY KEY CLUSTERED 
  (
	[QuizItemId] ASC
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

ALTER TABLE [dbo].[SquareQQuizItem] WITH CHECK ADD CONSTRAINT [FK_SquareQQuizItem_Quiz] FOREIGN KEY([QuizID])
REFERENCES [dbo].SquareQQuiz ([QuizId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SquareQQuizItem] WITH CHECK ADD CONSTRAINT [FK_SquareQQuizItem_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE NO ACTION
GO