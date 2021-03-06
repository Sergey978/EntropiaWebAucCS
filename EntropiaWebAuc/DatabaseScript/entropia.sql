USE [Entropia]
GO
ALTER TABLE [dbo].[StandartItems] DROP CONSTRAINT [FK_StandartItems_StandartItemCategories]
GO
ALTER TABLE [dbo].[SelectedStandartItems] DROP CONSTRAINT [FK_SelectedStandartItems_StandartItems]
GO
ALTER TABLE [dbo].[SelectedStandartItems] DROP CONSTRAINT [FK_SelectedStandartItems_AspNetUsers]
GO
ALTER TABLE [dbo].[RoleOptions] DROP CONSTRAINT [FK_RoleOption_ToAspNetRoles]
GO
ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_Messages_AspNetUsers]
GO
ALTER TABLE [dbo].[CustomItems] DROP CONSTRAINT [FK_CustomItems_AspNetUsers]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
/****** Object:  Table [dbo].[StandartItems]    Script Date: 12.03.2018 21:00:46 ******/
DROP TABLE [dbo].[StandartItems]
GO
/****** Object:  Table [dbo].[StandartItemCategories]    Script Date: 12.03.2018 21:00:46 ******/
DROP TABLE [dbo].[StandartItemCategories]
GO
/****** Object:  Table [dbo].[SelectedStandartItems]    Script Date: 12.03.2018 21:00:46 ******/
DROP TABLE [dbo].[SelectedStandartItems]
GO
/****** Object:  Table [dbo].[RoleOptions]    Script Date: 12.03.2018 21:00:46 ******/
DROP TABLE [dbo].[RoleOptions]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 12.03.2018 21:00:46 ******/
DROP TABLE [dbo].[Messages]
GO
/****** Object:  Table [dbo].[CustomItems]    Script Date: 12.03.2018 21:00:46 ******/
DROP TABLE [dbo].[CustomItems]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12.03.2018 21:00:46 ******/
DROP TABLE [dbo].[AspNetUsers]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12.03.2018 21:00:46 ******/
DROP TABLE [dbo].[AspNetUserRoles]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12.03.2018 21:00:46 ******/
DROP TABLE [dbo].[AspNetUserLogins]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12.03.2018 21:00:46 ******/
DROP TABLE [dbo].[AspNetUserClaims]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12.03.2018 21:00:46 ******/
DROP TABLE [dbo].[AspNetRoles]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12.03.2018 21:00:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12.03.2018 21:00:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12.03.2018 21:00:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12.03.2018 21:00:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12.03.2018 21:00:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomItems]    Script Date: 12.03.2018 21:00:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [decimal](5, 2) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[Chosed] [bit] NULL,
	[BeginQuantity] [int] NULL,
	[Markup] [decimal](6, 2) NULL,
	[PurchasePrice] [decimal](8, 2) NULL,
	[Step] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Messages]    Script Date: 12.03.2018 21:00:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SenderId] [nvarchar](128) NULL,
	[SenderEmail] [nvarchar](50) NULL,
	[SenderName] [nvarchar](50) NULL,
	[Date] [datetime] NOT NULL DEFAULT (getutcdate()),
	[RecId] [nvarchar](128) NOT NULL,
	[Title] [nvarchar](128) NOT NULL,
	[Text] [nvarchar](512) NOT NULL,
	[Sent] [bit] NULL,
	[Read] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleOptions]    Script Date: 12.03.2018 21:00:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleOptions](
	[Id] [nvarchar](128) NOT NULL,
	[AmountPoints] [int] NULL,
	[AmountStandartItems] [int] NULL,
	[AmountCustomItems] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SelectedStandartItems]    Script Date: 12.03.2018 21:00:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SelectedStandartItems](
	[UserId] [nvarchar](128) NOT NULL,
	[ItemId] [int] NOT NULL,
	[BeginQuantity] [int] NULL,
	[Step] [int] NULL,
	[Markup] [decimal](5, 2) NULL,
	[PurchasePrice] [decimal](8, 2) NULL,
 CONSTRAINT [PK_SelectedStandartItems] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StandartItemCategories]    Script Date: 12.03.2018 21:00:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StandartItemCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ParentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StandartItems]    Script Date: 12.03.2018 21:00:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StandartItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [decimal](16, 2) NOT NULL,
	[CategoryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'SuperAdmin')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'110ea0b3-299e-4adc-a37e-9ed7368e3060', N'Default')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2caea1de-a413-4708-bb19-7db3ec4033ff', N'Silver User')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'94a2bffb-cd35-46e0-8b98-ec41f71cf2db', N'Gold User')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f43f6d2f-5517-481c-9e55-d83f69fd5b6a', N'Bronze User')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0c58199f-9a6f-414e-b710-bd9de47efe7c', N'1')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3a456cc2-13de-473c-a5d8-4d937f679c58', N'110ea0b3-299e-4adc-a37e-9ed7368e3060')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4547d849-baef-4a5f-a715-993713a0ff3b', N'110ea0b3-299e-4adc-a37e-9ed7368e3060')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e8cdd79e-83fd-454a-ae73-31a382606e78', N'110ea0b3-299e-4adc-a37e-9ed7368e3060')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0c58199f-9a6f-414e-b710-bd9de47efe7c', N'admin@mail.ru', 1, N'AFBG4/kXqf2dUBt1l/OutapgZAciCb4FrwtAsEE+b13aGimHVF8FEQYg3STHwo3vng==', N'd8be3b39-9468-4947-95f9-e16be05f0823', NULL, 0, 0, NULL, 1, 0, N'admin@mail.ru')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3a456cc2-13de-473c-a5d8-4d937f679c58', N'serg@mail.ru', 1, N'AFBG4/kXqf2dUBt1l/OutapgZAciCb4FrwtAsEE+b13aGimHVF8FEQYg3STHwo3vng==', N'3009417c-2e11-4c59-b962-d9042f4fb669', NULL, 0, 0, NULL, 1, 0, N'serg@mail.ru')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4547d849-baef-4a5f-a715-993713a0ff3b', N'serg2@mail.ru', 1, N'AMXCPeZj1Q93SUOL4pHIi158jLRdgDM8M3sMMQ/l95eutPeyHAFVNHHwMPwcidfLIg==', N'f9708d0f-7f0c-449a-bc3b-cf8324c3c00e', NULL, 0, 0, NULL, 1, 0, N'serg2@mail.ru')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e8cdd79e-83fd-454a-ae73-31a382606e78', N'sergey978@mail.ru', 1, N'ACNpSajkw7TcXjOtVMn6FGXYhbLCqEobNro5x7QoGHQo4ZnTKGdAzQLYCMBNjt/OAA==', N'c5dd21d4-0be1-4fcb-a78a-682130d9e62d', NULL, 0, 0, NULL, 1, 0, N'sergey978@mail.ru')
GO
SET IDENTITY_INSERT [dbo].[CustomItems] ON 

GO
INSERT [dbo].[CustomItems] ([Id], [Name], [Price], [UserId], [Chosed], [BeginQuantity], [Markup], [PurchasePrice], [Step]) VALUES (2013, N'reerr', CAST(0.02 AS Decimal(5, 2)), N'3a456cc2-13de-473c-a5d8-4d937f679c58', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CustomItems] ([Id], [Name], [Price], [UserId], [Chosed], [BeginQuantity], [Markup], [PurchasePrice], [Step]) VALUES (2014, N'test1', CAST(0.05 AS Decimal(5, 2)), N'0c58199f-9a6f-414e-b710-bd9de47efe7c', 1, 100, CAST(5.00 AS Decimal(6, 2)), CAST(102.30 AS Decimal(8, 2)), 5)
GO
INSERT [dbo].[CustomItems] ([Id], [Name], [Price], [UserId], [Chosed], [BeginQuantity], [Markup], [PurchasePrice], [Step]) VALUES (3014, N'test Custom Item2', CAST(0.05 AS Decimal(5, 2)), N'3a456cc2-13de-473c-a5d8-4d937f679c58', 1, 1000, CAST(3.00 AS Decimal(6, 2)), CAST(105.00 AS Decimal(8, 2)), 1)
GO
INSERT [dbo].[CustomItems] ([Id], [Name], [Price], [UserId], [Chosed], [BeginQuantity], [Markup], [PurchasePrice], [Step]) VALUES (3015, N'Muscle Oil', CAST(0.03 AS Decimal(5, 2)), N'3a456cc2-13de-473c-a5d8-4d937f679c58', 1, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[CustomItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

GO
INSERT [dbo].[Messages] ([Id], [SenderId], [SenderEmail], [SenderName], [Date], [RecId], [Title], [Text], [Sent], [Read]) VALUES (12, NULL, N'qwe@mail.ru', N'wqre', CAST(N'2018-01-16 06:28:05.713' AS DateTime), N'0c58199f-9a6f-414e-b710-bd9de47efe7c', N'err', N'erwer', 0, 0)
GO
INSERT [dbo].[Messages] ([Id], [SenderId], [SenderEmail], [SenderName], [Date], [RecId], [Title], [Text], [Sent], [Read]) VALUES (13, NULL, N'wewr', N'wqre', CAST(N'2018-01-16 06:28:29.510' AS DateTime), N'0c58199f-9a6f-414e-b710-bd9de47efe7c', N'err', N'erwer', 0, 0)
GO
INSERT [dbo].[Messages] ([Id], [SenderId], [SenderEmail], [SenderName], [Date], [RecId], [Title], [Text], [Sent], [Read]) VALUES (14, NULL, N'serg@mail.ru', N'sergey', CAST(N'2018-01-16 06:41:04.150' AS DateTime), N'0c58199f-9a6f-414e-b710-bd9de47efe7c', N'df', N'df', 0, 1)
GO
INSERT [dbo].[Messages] ([Id], [SenderId], [SenderEmail], [SenderName], [Date], [RecId], [Title], [Text], [Sent], [Read]) VALUES (15, NULL, N'serg233@mail.ru', N'Sergio', CAST(N'2018-03-09 12:24:33.317' AS DateTime), N'0c58199f-9a6f-414e-b710-bd9de47efe7c', N'test message for admin', N'tratyytat', 0, 1)
GO
INSERT [dbo].[Messages] ([Id], [SenderId], [SenderEmail], [SenderName], [Date], [RecId], [Title], [Text], [Sent], [Read]) VALUES (16, NULL, N'test@mail.ri', N'test', CAST(N'2018-03-11 15:01:42.880' AS DateTime), N'0c58199f-9a6f-414e-b710-bd9de47efe7c', N'test message for admin3333333333333333333', N'test message for admintest message for admintest message for admintest message for admintest message for admintest message for admintest message for admin', 0, 1)
GO
INSERT [dbo].[Messages] ([Id], [SenderId], [SenderEmail], [SenderName], [Date], [RecId], [Title], [Text], [Sent], [Read]) VALUES (17, NULL, N'test2ADMIN@SDD.ERR', N'test', CAST(N'2018-03-11 16:00:19.507' AS DateTime), N'0c58199f-9a6f-414e-b710-bd9de47efe7c', N'RRR', N'RRRR', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Messages] OFF
GO
INSERT [dbo].[RoleOptions] ([Id], [AmountPoints], [AmountStandartItems], [AmountCustomItems]) VALUES (N'1', 200, 15, 15)
GO
INSERT [dbo].[RoleOptions] ([Id], [AmountPoints], [AmountStandartItems], [AmountCustomItems]) VALUES (N'110ea0b3-299e-4adc-a37e-9ed7368e3060', 200, 5, 5)
GO
INSERT [dbo].[SelectedStandartItems] ([UserId], [ItemId], [BeginQuantity], [Step], [Markup], [PurchasePrice]) VALUES (N'0c58199f-9a6f-414e-b710-bd9de47efe7c', 1, 500, 3, CAST(5.00 AS Decimal(5, 2)), CAST(105.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[SelectedStandartItems] ([UserId], [ItemId], [BeginQuantity], [Step], [Markup], [PurchasePrice]) VALUES (N'3a456cc2-13de-473c-a5d8-4d937f679c58', 1, 1200, 2, CAST(3.00 AS Decimal(5, 2)), CAST(102.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[SelectedStandartItems] ([UserId], [ItemId], [BeginQuantity], [Step], [Markup], [PurchasePrice]) VALUES (N'3a456cc2-13de-473c-a5d8-4d937f679c58', 3, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[StandartItemCategories] ON 

GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (1, N'Materials', NULL)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (3, N'Resources', NULL)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (4, N'Enmatter Elements', 8)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (5, N'Mineral Ore', 3)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (6, N'Animal Oils', 1)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (8, N'Refined Resurces', NULL)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (9, N'Metal Ingots', 8)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (10, N'Raw Energy Marres', 3)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (11, N'Components', NULL)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (12, N'Electronic Components', 11)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (13, N'Enhancer Components', 11)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (14, N'Crafting Components', 13)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (15, N'Socket Components', 13)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (16, N'Tier Components', 13)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (17, N'Generic Component', 11)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (18, N'Mechanical Components', 11)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (19, N'Metal Components', 11)
GO
INSERT [dbo].[StandartItemCategories] ([Id], [Name], [ParentId]) VALUES (20, N'Robot Components', 11)
GO
SET IDENTITY_INSERT [dbo].[StandartItemCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[StandartItems] ON 

GO
INSERT [dbo].[StandartItems] ([Id], [Name], [Price], [CategoryId]) VALUES (1, N'Muscle Oil', CAST(0.05 AS Decimal(16, 2)), 6)
GO
INSERT [dbo].[StandartItems] ([Id], [Name], [Price], [CategoryId]) VALUES (3, N'Iron Ing', CAST(0.07 AS Decimal(16, 2)), 9)
GO
INSERT [dbo].[StandartItems] ([Id], [Name], [Price], [CategoryId]) VALUES (4, N'Oil', CAST(0.07 AS Decimal(16, 2)), 4)
GO
SET IDENTITY_INSERT [dbo].[StandartItems] OFF
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CustomItems]  WITH CHECK ADD  CONSTRAINT [FK_CustomItems_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomItems] CHECK CONSTRAINT [FK_CustomItems_AspNetUsers]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_AspNetUsers] FOREIGN KEY([RecId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_AspNetUsers]
GO
ALTER TABLE [dbo].[RoleOptions]  WITH CHECK ADD  CONSTRAINT [FK_RoleOption_ToAspNetRoles] FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleOptions] CHECK CONSTRAINT [FK_RoleOption_ToAspNetRoles]
GO
ALTER TABLE [dbo].[SelectedStandartItems]  WITH CHECK ADD  CONSTRAINT [FK_SelectedStandartItems_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SelectedStandartItems] CHECK CONSTRAINT [FK_SelectedStandartItems_AspNetUsers]
GO
ALTER TABLE [dbo].[SelectedStandartItems]  WITH CHECK ADD  CONSTRAINT [FK_SelectedStandartItems_StandartItems] FOREIGN KEY([ItemId])
REFERENCES [dbo].[StandartItems] ([Id])
GO
ALTER TABLE [dbo].[SelectedStandartItems] CHECK CONSTRAINT [FK_SelectedStandartItems_StandartItems]
GO
ALTER TABLE [dbo].[StandartItems]  WITH CHECK ADD  CONSTRAINT [FK_StandartItems_StandartItemCategories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[StandartItemCategories] ([Id])
GO
ALTER TABLE [dbo].[StandartItems] CHECK CONSTRAINT [FK_StandartItems_StandartItemCategories]
GO
