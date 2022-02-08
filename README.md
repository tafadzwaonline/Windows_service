# Windows_service
This is a simple windows sevice that selects details from table 1 and insert the sames details in table 2.

How to Install
1.Run powershell as administrator
2.New-Service -Name "windows_service1" -BinaryPathName C:\Users\Kahwai\source\repos\Windows_service\Windows_service\bin\Debug\Windows_service.exe



table 1: Company_Profile

USE Windowss
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Company_Profile](
	[ProfileID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[Location] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NULL,
	[website] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Isprocessed] [bit] NULL,
 CONSTRAINT [PK_Company_Profile] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



table 2: Company_Profile_Approved

USE Windowss
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Company_Profile_Approved](
	[ProfileID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[Location] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NULL,
	[website] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Isprocessed] [bit] NULL,
 CONSTRAINT [PK_Company_Profile_Approved] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO





