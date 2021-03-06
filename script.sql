USE [AdmissionDb]
GO
/****** Object:  Table [dbo].[Mark]    Script Date: 3/9/2018 10:35:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mark](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](50) NOT NULL,
	[RollNo] [int] NOT NULL,
	[Math] [int] NOT NULL,
	[English] [int] NOT NULL,
	[Bangla] [int] NOT NULL,
	[Physics] [int] NOT NULL,
	[Chemistry] [int] NOT NULL,
	[Biology] [int] NOT NULL,
	[Religion] [int] NOT NULL,
	[Higher_math] [int] NOT NULL,
	[Agriculture] [int] NOT NULL,
	[Philosophy] [int] NOT NULL,
	[ICT] [int] NOT NULL,
 CONSTRAINT [PK_AdmissionForm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 3/9/2018 10:35:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
