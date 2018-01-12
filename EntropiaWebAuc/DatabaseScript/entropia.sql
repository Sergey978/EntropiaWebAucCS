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
/****** Object:  Table [dbo].[StandartItems]    Script Date: 12.01.2018 17:17:00 ******/
DROP TABLE [dbo].[StandartItems]
GO
/****** Object:  Table [dbo].[StandartItemCategories]    Script Date: 12.01.2018 17:17:00 ******/
DROP TABLE [dbo].[StandartItemCategories]
GO
/****** Object:  Table [dbo].[SelectedStandartItems]    Script Date: 12.01.2018 17:17:00 ******/
DROP TABLE [dbo].[SelectedStandartItems]
GO
/****** Object:  Table [dbo].[RoleOptions]    Script Date: 12.01.2018 17:17:00 ******/
DROP TABLE [dbo].[RoleOptions]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 12.01.2018 17:17:00 ******/
DROP TABLE [dbo].[Messages]
GO
/****** Object:  Table [dbo].[CustomItems]    Script Date: 12.01.2018 17:17:00 ******/
DROP TABLE [dbo].[CustomItems]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12.01.2018 17:17:00 ******/
DROP TABLE [dbo].[AspNetUsers]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12.01.2018 17:17:00 ******/
DROP TABLE [dbo].[AspNetUserRoles]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12.01.2018 17:17:00 ******/
DROP TABLE [dbo].[AspNetUserLogins]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12.01.2018 17:17:00 ******/
DROP TABLE [dbo].[AspNetUserClaims]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12.01.2018 17:17:00 ******/
DROP TABLE [dbo].[AspNetRoles]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12.01.2018 17:17:00 ******/
DROP TABLE [dbo].[__MigrationHistory]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12.01.2018 17:17:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12.01.2018 17:17:00 ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12.01.2018 17:17:00 ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12.01.2018 17:17:00 ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12.01.2018 17:17:00 ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12.01.2018 17:17:00 ******/
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
/****** Object:  Table [dbo].[CustomItems]    Script Date: 12.01.2018 17:17:00 ******/
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
/****** Object:  Table [dbo].[Messages]    Script Date: 12.01.2018 17:17:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [bigint] NOT NULL,
	[SenderId] [nvarchar](128) NULL,
	[SenderEmail] [nvarchar](50) NULL,
	[SenderName] [nvarchar](50) NULL,
	[Date] [timestamp] NOT NULL,
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
/****** Object:  Table [dbo].[RoleOptions]    Script Date: 12.01.2018 17:17:00 ******/
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
/****** Object:  Table [dbo].[SelectedStandartItems]    Script Date: 12.01.2018 17:17:00 ******/
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
/****** Object:  Table [dbo].[StandartItemCategories]    Script Date: 12.01.2018 17:17:00 ******/
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
/****** Object:  Table [dbo].[StandartItems]    Script Date: 12.01.2018 17:17:00 ******/
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
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201707211551272_InitialCreate', N'EntropiaWebaucCS.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5CDB6EE436127D5F60FF41D0D3EEC269F99219CC1AED044EDBDE3532BE60DA93DDB7015B62B789912845A21C1B41BE6C1FF693F20B294AD48D175DBAE5EE7610209816C953C5E221592C16FDFBFFFE3FFDFE39F0AD271C2724A467F6D1E4D0B63075438FD0D5999DB2E5371FECEFBFFBEB5FA6975EF06CFD54D43BE1F5A0254DCEEC47C6A253C749DC471CA0641210370E9370C9266E1838C80B9DE3C3C37F3A47470E06081BB02C6BFA29A58C0438FB013F67217571C452E4DF841EF613F11D4AE619AA758B029C44C8C567F62565711811F41FBC40A93B9B4FF226B675EE1304EACCB1BFB42D4469C81003654F3F27780E4DE86A1EC107E43FBC4418EA2D919F60D189D3AA7ADFFE1C1EF3FE3855C302CA4D13160603018F4E84811CB9F95A66B64B038209C16084BDF05E67663CB3AF3D9C7DFA14FA600059E0E9CC8F79E533FBA614719E44B7984D8A86931CF22A06B85FC2F8EBA48E7860F56E775012EA7872C8FF3BB066A9CFD2189F519CB218F907D67DBAF089FB237E7908BF627A7672B4589E7C78F71E7927EFBFC527EFEA3D85BE42BDC607F8740F6CC131E8869765FF6DCB69B673E48665B35A9BDC2AC025981BB675839E3F62BA628F306B8E3FD8D61579C65EF14590EB33253095A0118B53F8799BFA3E5AF8B82C775A65F2FFB7483D7EF77E14A9B7E889ACB2A197E4C3C489615E7DC27E569A3C92289F5E8DF1FE22AA5DC561C07F37F995977E998769ECF2CE84C62A0F285E61D6D46EEA54E4ED45690E353EAD0BD4FDA736D754A5B7B62AEFD03A33A110B1EDD950E8FBBA727B33EE3C8A60F0326A718BB411CEB0634D2488034BAE5891E8A82F892874EECFBC265E0688F8232C8A3DA48053B2247180CB5EFE100205111DACF33D4A125813BC7FA3E4B14575F8E708AACFB19BC640D5394341F4EAD2EE1F438A6FD360C167C0F6648D36340FBF8457C865617C4979AB8DF13E86EED7306597D4BB400C7F666E01C87F3E90A03FC028EA9CBB2E4E922B2033F66621F8DC05E0356527C783E1F82AB56BA764E62312E8BD12693DFD5254AD3C137D0DC53B3154D379286DAA7E0C5784F653B5A86A5635AFD1A9AAA83654550ED64F5351D3AC6856A153CFBCD6683E5F3642E33B7D19ECFE7B7D9B6DDEA6B5A066C639AC90F85F98E2189631EF1E3186635A8D409F756317CE42367C5CE8ABEF4D99A49F909F8E2D6AADD9902D02E3CF860C76FF6743A6267C7E221EF74A7A1C858ACA00DFABBEFE94D53DE724CDB63D1D1ADDDCB6F0EDAC01A6E9729E24A14BB259A00982891046537FF0E1ACEE7846DE1B3926021D03A213BEE5C117E89B2D93EA8E5E601F336C9DBB79907086121779AA19A143DE00C58A1D55A358151B692AF70F4526301DC7BC11E287A004662AA14C9D1684BA24427EA795A4963DB730DEF752865C7281234CB9C04E4BF411AE0F8570054A39D2A0745968EAD418D74E4483D76A1AF32E17B61A772542B1154E76F8CE065E0AFFED5588D96EB12D90B3DD247D143086F57641507156E94B00F9E0B26F04954E4C06820A976A2B046D5A6C07046D9AE4CD11343FA2F61D7FE9BCBA6FF46C1E94B7BFADB79A6B07DC6CD863CFA899FB9ED086410B1CABF4BC58F042FCCC348733D0539CCF12E1EACA14E1E073CC9A219BCADFD5FAA14E3B884CA236C08A681DA0E24250015226D400E58A585EAB76C28B18005BC4DD5A61C5DA2FC1D638A062D72F466B15CDD7A732397B9D3ECA9E956C5048DEEBB050C3D110425EBC9A1DEF6114535C56354C1F5F7888375CEB98188C16037578AE0623159D19DD4A0535BBADA473C886B8641B5949729F0C562A3A33BA950447BB8DA4710A06B8051B99A8B9858F34D98A4847B9DB946553274F9A121FA68E21BB6A7A83A288D0552DDB4A7CB1E679AAD5EC9BF9F0F4A320C770DC449385546A5B4A62618C56582A05D1A0E91589137681185A201EE7997981524DBBB71A96FF42647DFB5407B1D8078ADAFCDFE252D8708DDFD870558F44005D413703EED664B1740D09F4CD2D9E02877C146BC2F7B3D04F036AF6B2CCADF34BBC7AFBFC8B8A307524FD152F4A3199E2EB36EDDF6B74D49931E648959ECCFAA3658630D9BCF043EB5637F9A66694225455473185AF76367A269766F888C92EE3F001EB44789D1926F254EA00E2D3408C5AAA8302562BEB8FDACC46A963364BFA234A29277548A9688096F5C4928692F582B5F00C16D5D7E82F414D25A9A3ABA5FD9135492575684DF11AD81A9DE5B2FEA89ABC933AB0A6B83F76958422AFA47BBC87190F329B6D62F98177B35DCC80F13ACBE2389B60ED5EBF0E54FB3C104BDCDC2B60E2FB5E52CA78EADB8C5279B063334A1930CC6B50E35ABCB904B5DEE59B311B77DD8D65BEEDAEDF8C378CB8AF4A0FE5E4275729A5972740E9A43715A7AEEEC736CA312CAF625B8519618B7F49180E26BCC264FEB33FF309E60B7A51E10651B2C409CBF33BECE3C3A363E9A9CEFE3C9B7192C4F335A756D3DB99E6986D21558B3EA1D87D44B19A38B1C1D3920A5489495F530F3F9FD9BF66AD4EB3F006FF57F6F9C0BA4E3E53F2730A050F718AADDFD444D07152EDDBCF5C7BFA30A2BF55AFFFFB256F7A60DDC530634EAD43C996EB8C70F3B9C4206DF2A61B68B3F6238AB73BA11AEF12B4A8D28458FF19C282B0519E20145AFE2D40CF7F1FAA9AF699C146889AA70463E18D6242D3538175B08CCF043CF8C9B26702C33AAB7F36B08E6AC62703840E07931F0CF45F868A963BDC6A3407A36D2C49999D3B13AE37CABEDCF5DEA4E4656F34D1D5DCEB01701BE457AFC18C37969A3CDAEEA8C93C1E0D7B97D47EF574E37DC930AE723F769B58BCCD5CE2965BA23F550AF11E24BD699278769F28BC6DAE9982B97B9E6D392C1D78CFC82652BB769FF4BB6DB299C2BC7B4EB641A9BD7BC6B55DED9F3B665AEF2D74E789BA6ACE91E15246170BEE4AC4CD03E770C25F844082DCA3CCDF4FEA33BF4CC22AB218055655CC42CD2967B26065E22872951AED6287F5556CF8AD9D1575DAC51A1235DB648BF5BF55B6A8D32EDB90FEB88B14626D02A22EADBB631D6BCB897A4B29C38D9E7464A877F9ACAD37EC6F29437814A334668FE18EF8ED24048F629231A7CE800460F5BA17F6CEDA5F6084FD3B21AB0A82FF3D468ADDC6AE59D6B9A6CBB0D8BC258D8A2A5284E60633E4C1967A1E33B2442E83621E63CE1E8067713B7ED3B1C0DE35BD4B599432E8320E167E23E0C59D8036F959967353E7E95D94FD2D9331BA006A121E9BBFA33FA4C4F74ABDAF3431210304F72E4444978F25E391DDD54B89741BD29E40C27CA553F48083C807B0E48ECED1135E4737A0DF47BC42EE4B15013481740F44D3ECD30B8256310A128151B5879FC0612F78FEEE0F1E6F7E9B88540000, N'6.1.3-40302')
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201708141025000_InitialCreate', N'EntropiaWebAuc.Areas.Default.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5CDB6EE436127D5F60FF41D0D3EEC269F992194C8CEE1974DAF6AE91F105D39E64DF066C89DD1646A21489726C04F9B23CE493F20B294AD48D175DBAD51707018269A978AA583C248BA5A2FFFCFD8FF18767DF339E7014BB01999827A363D3C0C40E1C97AC26664297DFBC333FBCFFE73FC6978EFF6CFC98CB9D31396849E289F94869786E59B1FD887D148F7CD78E823858D2911DF8167202EBF4F8F83BEBE4C4C200610296618C3F2584BA3E4E7FC0CF59406C1CD20479378183BD983F8737F314D5B8453E8E4364E38979496814842EFA092FA6893D9A4618945EE0254A3C3ACA9A9BC6D473119836C7DED23410210145140C3FFF1CE3393427AB79080F90F7F01262905B222FC6BC43E7A578D7BE1D9FB2BE5965C31CCA4E621AF83D014FCEB8B32CB1F95A2E370B67823BC1792E7D61BD4E5D3A31AF1D9C3EFA1478E00051E1F9CC8B98F0C4BC29544CE3F016D351DE7094415E4500F74B107D1D55118F8CCEED8E0A729D8E8ED97F47C60C463489F084E08446C83B32EE9385E7DA3FE09787E02B2693B393C5F2ECDD9BB7C8397BFB2D3E7B53ED29F415E46A0FE0D13D300747601B5E16FD370DABDECE121B16CD2A6D32AF0097609E98C60D7AFE88C98A3EC20C3A7D671A57EE3376F2279C5C9F890BD30A1AD128819FB789E7A185878BF756A34EF6FF06ADA76FDE0EA2F5163DB9AB74E805FD30712298579FB097BE8D1FDD309B5EB5F1FEC2C5AEA2C067BFEBFCCADE7E99074964B3CE045A910714AD30AD5B37B64AF276A234831A9ED639EAE1539B592AD35B29CA3AB4CE4CC855EC7A36E4F66E576F67C64DC310062FA516F34813E13AEC5E2301EEC8A8372AE974D2954E04BAF9775E1D2F7DE47A032C8F1DB440A8B274231F17BDFC3E003222D2DBE67B14C7B03A38FF43F16383E9F0CF014C9F633B8980B4738AFC70EBDAEE1F03826F137FC1E6C2EE740D36340FBF0457C8A641744958AB8DF13E06F6D720A197C4B940147FA6760EC87E3EB87E778041CC99DA368EE32B203376660144E239E035A167A7BDE1D81AB5EFF064E621D757C727C26AFA25172D6314B58414A768C454B14A93A91F83954BBA999A8BEA4DCD245A4DE5627D4D6560DD2CE5927A435381563B33A9C1A2BF7484860FFF52D8C38FFF36DBBC756B41C58D735821F17F31C1112C63CE3DA21447A41C812EEBC63E828574F898D2ADEF4DA9A61F91970CAD6AADD9902E02C3CF8614F6F067436A263C7E721D1695743814E5C200DF495E7DDE6A9F738265BB9E0EB56EEE5AF96ED600DD7499C67160BBE92C50A4C37832A36E3FC470467B6623EB8D981D818E01D15DB6E5C113E89B2992EA8E5C600F536C4CED2C5D3843B18D1CD98DD021A78761F98EAA30ACCC92D48DFB8FA413988E23D608B143500C33D525549E162EB1DD1079AD5E125A76DCC258DF0B1DE29B0B1C62C214B67AA28B727552841950E81106A5CD4363ABC2B866226AA256DD98B785B0E5B84BB98A9D70B22576D6F092C76F5B2166B3C77640CE66977431409BE0DB0741F959A52B01C483CBA1115438316908CA43AA9D10B4EEB13D10B4EE925747D0EC88DA75FC85F3EAA1D1B37E50DEFDB6DEE8AE3D70B3E68F03A366167B421B0A2D7024D3F362C15EE267AA389C819DFC7C16F35057A408039F635A4FD994F1AE320EB59A414412350196446B01E59F0625206942F5302ECFE5355AC7A3881EB079DEAD1196AFFD026C85033276F513694550FF21552467A7D347D1B3820D12C93B1D162A380A42888B57BDE31D9CA2CBCBCA8EE9120BF789862B1DE383D1E0A096C855E3A4BC33837B29A766BB975401599F906C232F09E193C64B796706F712E768BB931441418FB0602317D5B7F081265B9EE928769BE2DDD8CA4AA9F883B1A5A9B91ADFA03074C9AA5283C59F18F3AC006BF6CDBC7F21929F615876ACA8472AAC2D34D120422B2CBC05D560E9951BC5F40251B4402CCF33737C494CB9B76A96FF5C6575FB940731DF077269F66FFE51B8C307FDDAE62B47271CF40ABAECB31027CDAB2B08A16E6EB02239E4A14891CA9F055EE2137DC4A56F9D7DD0ABB6CF9EC808634BB05F8AA824F749716F7D2C3A8D943C4BB6356A4584B3FEC8E92174FECFE3D3EA08E862563D4A9EC2AAA2E8D25A7B1B495DA8B3D9E8896165FFC16B45D8CECCE3B52C5500FEA82746A51C4202ABBCEB8E5AAF58A962D6DF744714CA52AA90C2AB1E56568B4F6A46565FAC85A7F1A85AA2BB06B9DCA48A2EBFED8EAC283CA9422B5EAF81ADB0597CD71D55519B520556BCEE8E5D16AA88ABEA01EF6DDAC3CE709B5B7640DE6C77D3606C67891C6673ACD40154812A8F7B62F12FFD12187F7E90F4D29E1287A3579628D98C5E1A0CFDDA54FBA45E5F9A1AEB00F498B5EFE4B5E5BFA94E408FD78FC45BA58A746A14450AEDC5E95138258EF989ADFDFA8E7484CB444C2377236CFD2F31C5FE88098CE63F7B33CFC56CA1CF056E10719738A6596D88797A7C722A5CF8399CCB37561C3B9EE2C4ABBB81531FB31D9479912714D98F28928B2E36B8A052824AF9EC6BE2E0E789F96BDAEA3C4D8DB07FA58F8F8CEBF833717F4EE0C5439460E337B988749882FDE673D9815EAFE8EED5EBFF7FC99A1E197711CC9873E358F0E53A235CBF74D1CB9AACE906D6AC7D15E3F54EA8DA9D0625AA3021D6BFC2B070E920D717722BFFE5A3E77FF7354D7945612344C53584A1F00671A1EE9AC13A58DA2B060EFCA4E915837E9D555F3958C734ED750397F407132F1B745F86F2967BDC6A1487A45D2C49A99F5B8BB537AADCDCF7DE24D5746F34D1E5BAED1E701BD466AFC18C5756D63CD8EEA8A85A1E0C7B9FD4DE7AA9F2A15427977523FB2D4ADE651D72C397A4BF55F9F10114CC290A80F65F64BC6BAEE912BB075EA9D9AF94F8C0C8C6CBC2F65F30BC6BB2E9D2BC074EB65E65C107C6B57DED9F7B665AE72D74EF45BE72BD92E6038D2A17DC56C49B25CEE184BF088004594499DDBD54578DE9949564D12A2C45F44AF5E56AA26269E2487A258966B5FDFACA37FCC6CE729966B59A22CF26DD7CFD6FD4CD659A756B4A27F7517EAC2C5E549584B7AC634D7553AFA9DCB8D69396EAF6B698B5F16BFB6BAA2E1EC429B5D9A3F946FC7A8A890771C99053A747F1B0FCB917F6CECADF7484FD3B76572504FB0B8F04DBB55DB390B926CB20DFBC058B7211214373832972604B9D46D45D229BC26B96634E2F8FA7793BF6A563819D6B7297D030A1D065EC2FBC5AC28B05014DFAD30AE9BACDE3BB30FD3B28437401CC74596EFE8E7C9FB89E53D87DA5C80969205874C133BA6C2C29CBECAE5E0AA4DB807404E2EE2B82A207EC871E80C577648E9EF03AB601FD3EE215B25FCA0CA00EA47D20EA6E1F5FB86815213FE618657BF8091C76FCE7F77F015AF732F8DA540000, N'6.1.3-40302')
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
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0c58199f-9a6f-414e-b710-bd9de47efe7c', N'admin@mail.ru', 1, N'AL/X48vmL35n8mGDA337uC648w30mFKdAH8F+Kp529OL+08/8TuQtUWHBNFLc0jMSg==', N'd8be3b39-9468-4947-95f9-e16be05f0823', NULL, 0, 0, NULL, 1, 0, N'admin@mail.ru')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3a456cc2-13de-473c-a5d8-4d937f679c58', N'serg@mail.ru', 1, N'AFBG4/kXqf2dUBt1l/OutapgZAciCb4FrwtAsEE+b13aGimHVF8FEQYg3STHwo3vng==', N'3009417c-2e11-4c59-b962-d9042f4fb669', NULL, 0, 0, NULL, 1, 0, N'serg@mail.ru')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4547d849-baef-4a5f-a715-993713a0ff3b', N'serg2@mail.ru', 1, N'AMXCPeZj1Q93SUOL4pHIi158jLRdgDM8M3sMMQ/l95eutPeyHAFVNHHwMPwcidfLIg==', N'f9708d0f-7f0c-449a-bc3b-cf8324c3c00e', NULL, 0, 0, NULL, 1, 0, N'serg2@mail.ru')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e8cdd79e-83fd-454a-ae73-31a382606e78', N'sergey978@mail.ru', 1, N'ACNpSajkw7TcXjOtVMn6FGXYhbLCqEobNro5x7QoGHQo4ZnTKGdAzQLYCMBNjt/OAA==', N'c5dd21d4-0be1-4fcb-a78a-682130d9e62d', NULL, 0, 0, NULL, 1, 0, N'sergey978@mail.ru')
GO
SET IDENTITY_INSERT [dbo].[CustomItems] ON 

GO
INSERT [dbo].[CustomItems] ([Id], [Name], [Price], [UserId], [Chosed], [BeginQuantity], [Markup], [PurchasePrice], [Step]) VALUES (4, N'test Custom Item2', CAST(0.02 AS Decimal(5, 2)), N'0c58199f-9a6f-414e-b710-bd9de47efe7c', NULL, 1000, CAST(3.00 AS Decimal(6, 2)), CAST(104.00 AS Decimal(8, 2)), 2)
GO
INSERT [dbo].[CustomItems] ([Id], [Name], [Price], [UserId], [Chosed], [BeginQuantity], [Markup], [PurchasePrice], [Step]) VALUES (2013, N'reerr', CAST(0.02 AS Decimal(5, 2)), N'3a456cc2-13de-473c-a5d8-4d937f679c58', NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[CustomItems] OFF
GO
INSERT [dbo].[RoleOptions] ([Id], [AmountPoints], [AmountStandartItems], [AmountCustomItems]) VALUES (N'1', 200, 15, 15)
GO
INSERT [dbo].[RoleOptions] ([Id], [AmountPoints], [AmountStandartItems], [AmountCustomItems]) VALUES (N'110ea0b3-299e-4adc-a37e-9ed7368e3060', 200, 10, 10)
GO
INSERT [dbo].[SelectedStandartItems] ([UserId], [ItemId], [BeginQuantity], [Step], [Markup], [PurchasePrice]) VALUES (N'0c58199f-9a6f-414e-b710-bd9de47efe7c', 1, 500, 3, CAST(5.00 AS Decimal(5, 2)), CAST(105.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[SelectedStandartItems] ([UserId], [ItemId], [BeginQuantity], [Step], [Markup], [PurchasePrice]) VALUES (N'0c58199f-9a6f-414e-b710-bd9de47efe7c', 3, 1000, 5, CAST(3.00 AS Decimal(5, 2)), CAST(102.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[SelectedStandartItems] ([UserId], [ItemId], [BeginQuantity], [Step], [Markup], [PurchasePrice]) VALUES (N'3a456cc2-13de-473c-a5d8-4d937f679c58', 1, NULL, NULL, NULL, NULL)
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
