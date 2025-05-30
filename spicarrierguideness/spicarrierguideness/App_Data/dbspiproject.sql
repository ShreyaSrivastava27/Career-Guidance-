USE [Project]
GO
/****** Object:  Table [dbo].[tbl_reg]    Script Date: 08/04/2018 21:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_reg](
	[name] [varchar](100) NULL,
	[qualification] [varchar](100) NULL,
	[emailid] [varchar](120) NOT NULL,
	[passwd] [varchar](100) NULL,
	[address] [varchar](200) NULL,
	[gender] [varchar](50) NULL,
	[mobno] [varchar](20) NULL,
	[profile] [varchar](60) NULL,
	[rdt] [varchar](40) NULL,
 CONSTRAINT [PK_tbl_reg] PRIMARY KEY CLUSTERED 
(
	[emailid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_question]    Script Date: 08/04/2018 21:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_question](
	[qid] [int] IDENTITY(1,1) NOT NULL,
	[question] [varchar](400) NULL,
	[questionby] [varchar](120) NULL,
	[qdt] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_question] PRIMARY KEY CLUSTERED 
(
	[qid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_notification]    Script Date: 08/04/2018 21:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_notification](
	[nid] [int] IDENTITY(1,1) NOT NULL,
	[nmsg] [varchar](max) NULL,
	[ndt] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_notification] PRIMARY KEY CLUSTERED 
(
	[nid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_login]    Script Date: 08/04/2018 21:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_login](
	[UserId] [varchar](120) NOT NULL,
	[Passwd] [varchar](100) NULL,
	[UserType] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_login] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_feedback]    Script Date: 08/04/2018 21:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_feedback](
	[title] [varchar](200) NULL,
	[msg] [varchar](max) NULL,
	[rdt] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_contact]    Script Date: 08/04/2018 21:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_contact](
	[name] [varchar](100) NULL,
	[address] [varchar](250) NULL,
	[mobno] [varchar](20) NULL,
	[msg] [varchar](max) NULL,
	[rdt] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_answer]    Script Date: 08/04/2018 21:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_answer](
	[aid] [int] IDENTITY(1,1) NOT NULL,
	[qid] [int] NULL,
	[answer] [varchar](max) NULL,
	[answerby] [varchar](120) NULL,
	[ansdt] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_answer] PRIMARY KEY CLUSTERED 
(
	[aid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
