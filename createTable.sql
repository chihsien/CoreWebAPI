-- Mysql version BEGIN --------------------------------------------------

CREATE TABLE CYMoto.Breed (
	BreedId INT NOT NULL AUTO_INCREMENT,
	Name VARCHAR(200) NOT NULL,
	CONSTRAINT Breed_PK PRIMARY KEY (BreedId)
)
ENGINE=InnoDB
DEFAULT CHARSET=utf8
COLLATE=utf8_general_ci;


CREATE TABLE CYMoto.Cat (
	CatId INT NOT NULL AUTO_INCREMENT,
	BreedId INT NULL,
	name varchar(200) NULL,
	age INT NULL,
	CONSTRAINT Cat_PK PRIMARY KEY (CatId)
)
ENGINE=InnoDB
DEFAULT CHARSET=utf8
COLLATE=utf8_general_ci;

-- Mysql version End --------------------------------------------------


-- MSSQL BEGIN --------------------------------------------------
CREATE TABLE [dbo].[Breed](
	[BreedId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Breed] PRIMARY KEY CLUSTERED 
(
	[BreedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UX_Breed] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[Cat](
	[CatId] [int] IDENTITY(1,1) NOT NULL,
	[BreedId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_Cat] PRIMARY KEY CLUSTERED 
(
	[CatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Cat]  WITH CHECK ADD  CONSTRAINT [FK_Cat_Breed] FOREIGN KEY([BreedId])
REFERENCES [dbo].[Breed] ([BreedId])
GO
ALTER TABLE [dbo].[Cat] CHECK CONSTRAINT [FK_Cat_Breed]
GO
-- MSSQL END --------------------------------------------------