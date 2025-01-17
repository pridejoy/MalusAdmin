USE [MalusAdminTest]
GO
/****** Object:  Table [dbo].[bs_bingwallpaper]    Script Date: 2024/11/7 13:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bs_bingwallpaper](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CopyRight] [nvarchar](max) NULL,
	[GitUrl] [nvarchar](max) NULL,
	[MobileUrl] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[StartDate] [date] NOT NULL,
	[CreatedTime] [datetimeoffset](7) NULL,
	[UpdatedTime] [datetimeoffset](7) NULL,
	[CreatedUserId] [bigint] NULL,
	[CreatedUserName] [nvarchar](20) NULL,
	[UpdatedUserId] [bigint] NULL,
	[UpdatedUserName] [nvarchar](20) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_bs_bingwallpaper] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bs_customer]    Script Date: 2024/11/7 13:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bs_customer](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[OpenID] [varchar](200) NOT NULL,
	[NickName] [varchar](200) NOT NULL,
	[RealName] [varchar](200) NULL,
	[AvatarUrl] [varchar](200) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_bs_customer_UserID] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bs_gallery]    Script Date: 2024/11/7 13:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bs_gallery](
	[ImagesID] [int] IDENTITY(1,1) NOT NULL,
	[ImagesURL] [varchar](255) NOT NULL,
	[ImagesWide] [decimal](18, 4) NOT NULL,
	[ImagesHeiget] [decimal](18, 4) NOT NULL,
	[ImagesSize] [decimal](18, 4) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[VerticalScreen] [bit] NOT NULL,
	[Source] [nvarchar](100) NULL,
	[Examine] [int] NULL,
	[UpdateTime] [datetime] NULL,
	[IsDelete] [bit] NULL,
	[Praise] [int] NULL,
	[DisLike] [int] NULL,
 CONSTRAINT [PK_bs_gallery_ImagesID] PRIMARY KEY CLUSTERED 
(
	[ImagesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bs_miniappsitelink]    Script Date: 2024/11/7 13:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bs_miniappsitelink](
	[MiniAppSiteLinkId] [int] IDENTITY(1,1) NOT NULL,
	[MiniAppId] [varchar](200) NOT NULL,
	[MiniAppUrl] [varchar](200) NOT NULL,
	[MiniAppName] [varchar](200) NOT NULL,
	[Path] [varchar](200) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_bs_miniappsitelink_MiniAppSiteLinkId] PRIMARY KEY CLUSTERED 
(
	[MiniAppSiteLinkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bs_wechatconfig]    Script Date: 2024/11/7 13:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bs_wechatconfig](
	[WechatAppID] [varchar](200) NOT NULL,
	[WechatAppSecret] [varchar](200) NOT NULL,
	[WechatAppName] [varchar](200) NOT NULL,
	[AccessToken] [varchar](200) NOT NULL,
	[ExpireTime] [int] NOT NULL,
	[UpTime] [datetime] NOT NULL,
	[NextUpTime] [datetime] NOT NULL,
	[Res] [varchar](200) NOT NULL,
 CONSTRAINT [PK_bs_wx_config_WechatAppID] PRIMARY KEY CLUSTERED 
(
	[WechatAppID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_log_op_20241101]    Script Date: 2024/11/7 13:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_log_op_20241101](
	[Id] [bigint] NOT NULL,
	[LogType] [varchar](100) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[LogDateTime] [datetime] NULL,
 CONSTRAINT [PK_sys_log_op_20241101_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_sys_config]    Script Date: 2024/11/7 13:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_sys_config](
	[ConfigID] [int] IDENTITY(1,1) NOT NULL,
	[ConfigKey] [nvarchar](50) NULL,
	[ConfigType] [nvarchar](50) NULL,
	[ConfigValue] [nvarchar](max) NULL,
	[ConfigDescribe] [nvarchar](200) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_bs_webconfig] PRIMARY KEY CLUSTERED 
(
	[ConfigID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_sys_menu]    Script Date: 2024/11/7 13:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_sys_menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[MenuType] [int] NOT NULL,
	[MenuName] [nvarchar](20) NULL,
	[RouteName] [nvarchar](100) NOT NULL,
	[RoutePath] [nvarchar](100) NOT NULL,
	[Status] [int] NULL,
	[HideInMenu] [bit] NOT NULL,
	[Sort] [int] NULL,
	[Component] [nvarchar](100) NOT NULL,
	[Icon] [nvarchar](50) NOT NULL,
	[IconType] [int] NOT NULL,
	[KeepAlive] [bit] NULL,
	[Redirect] [nvarchar](200) NULL,
	[Href] [nvarchar](200) NULL,
	[SysCreateUser] [int] NULL,
	[SysCreateTime] [datetime] NOT NULL,
	[SysUpdateUser] [int] NULL,
	[SysUpdateTime] [datetime] NOT NULL,
	[SysDeleteUser] [int] NULL,
	[SysDeleteTime] [datetime] NULL,
	[SysIsDelete] [bit] NULL,
 CONSTRAINT [PK__t_sys_me__3214EC077959FA94] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_sys_onlineuser]    Script Date: 2024/11/7 13:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_sys_onlineuser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ConnectionId] [varchar](200) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[UserName] [varchar](32) NOT NULL,
	[RealName] [varchar](32) NOT NULL,
	[Time] [datetime] NOT NULL,
	[Ip] [varchar](256) NOT NULL,
	[Browser] [varchar](128) NOT NULL,
	[Os] [varchar](128) NOT NULL,
 CONSTRAINT [PK_t_sys_onlineuser_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_sys_role]    Script Date: 2024/11/7 13:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_sys_role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SysCreateUser] [int] NULL,
	[SysCreateTime] [datetime] NULL,
	[SysUpdateUser] [int] NULL,
	[SysUpdateTime] [datetime] NULL,
	[SysDeleteUser] [int] NULL,
	[SysDeleteTime] [datetime] NULL,
	[SysIsDelete] [bit] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Desc] [nvarchar](50) NULL,
	[Status] [bit] NOT NULL,
	[DataRang] [nvarchar](20) NULL,
	[Permission] [nvarchar](200) NULL,
 CONSTRAINT [PK__t_sys_ro__3214EC07073CF5EB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_sys_role_menu]    Script Date: 2024/11/7 13:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_sys_role_menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SysCreateUser] [int] NULL,
	[SysCreateTime] [datetime] NULL,
	[SysUpdateUser] [int] NULL,
	[SysUpdateTime] [datetime] NULL,
	[SysDeleteUser] [int] NULL,
	[SysDeleteTime] [datetime] NULL,
	[SysIsDelete] [bit] NULL,
	[RoleId] [int] NOT NULL,
	[MenuId] [int] NOT NULL,
 CONSTRAINT [PK_t_sys_role_menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_sys_role_permiss]    Script Date: 2024/11/7 13:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_sys_role_permiss](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SysCreateUser] [int] NULL,
	[SysCreateTime] [datetime] NULL,
	[SysUpdateUser] [int] NULL,
	[SysUpdateTime] [datetime] NULL,
	[SysDeleteUser] [int] NULL,
	[SysDeleteTime] [datetime] NULL,
	[SysIsDelete] [bit] NOT NULL,
	[RoleId] [int] NOT NULL,
	[UserPermiss] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_bs_sys_user_button_permiss] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_sys_user]    Script Date: 2024/11/7 13:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_sys_user](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[PassWord] [nvarchar](32) NOT NULL,
	[UserRolesId] [nvarchar](100) NOT NULL,
	[Status] [int] NOT NULL,
	[Avatar] [nvarchar](100) NULL,
	[Tel] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[Remark] [nvarchar](200) NULL,
	[SysCreateUser] [int] NULL,
	[SysCreateTime] [datetime] NULL,
	[SysUpdateUser] [int] NULL,
	[SysUpdateTime] [datetime] NULL,
	[SysDeleteUser] [int] NULL,
	[SysDeleteTime] [datetime] NULL,
	[SysIsDelete] [tinyint] NULL,
	[DeptId] [int] NULL,
	[IsSuperAdmin] [bit] NULL,
 CONSTRAINT [PK__t_sys_us__3214EC0749A204F2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[bs_bingwallpaper] ON 
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6189, N'纳斯卡鲣鸟，沃尔夫岛，加拉帕戈斯群岛，厄瓜多尔 (© Tui De Roy/Minden Pictures)', NULL, N'https://cn.bing.com/th?id=OHR.NazcaBooby_ZH-CN1534931799_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.NazcaBooby_ZH-CN1534931799_1920x1080.jpg', CAST(N'2024-08-21' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6190, N'海洋城日出时的鸟瞰图，马里兰州，美国 (© Kevin Olson/Amazing Aerial Agency)', NULL, N'https://cn.bing.com/th?id=OHR.OceanCityMD_ZH-CN1876928284_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.OceanCityMD_ZH-CN1876928284_1920x1080.jpg', CAST(N'2024-08-22' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6191, N'帕侬蓝寺，武里南府，泰国 (© Banjongseal324/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.PrasatPhanom_ZH-CN0445884858_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.PrasatPhanom_ZH-CN0445884858_1920x1080.jpg', CAST(N'2024-08-23' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6192, N'卡塔丁森林和水域国家纪念碑，佩诺布斯科特县，缅因州，美国 (© Cavan Images/Alamy Stock Photo)', NULL, N'https://cn.bing.com/th?id=OHR.KatahdinWoods_ZH-CN0748954905_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.KatahdinWoods_ZH-CN0748954905_1920x1080.jpg', CAST(N'2024-08-24' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6193, N'急流湖的日出，冰川国家公园，蒙大拿州，美国 (© Jason Savage/Tandem Stills + Motion)', NULL, N'https://cn.bing.com/th?id=OHR.SwiftcurrentLake_ZH-CN1513761894_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.SwiftcurrentLake_ZH-CN1513761894_1920x1080.jpg', CAST(N'2024-08-25' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6194, N'巴尔米拉环礁国家野生动物保护区，中太平洋 (© Ian Shive/Tandem Stills + Motion)', NULL, N'https://cn.bing.com/th?id=OHR.PalmyraAtoll_ZH-CN1814325540_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.PalmyraAtoll_ZH-CN1814325540_1920x1080.jpg', CAST(N'2024-08-26' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6195, N'黑色凯门鳄幼崽，坦博帕塔国家保护区，秘鲁 (© Maxime Aliaga/Minden Pictures)', NULL, N'https://cn.bing.com/th?id=OHR.YoungCaiman_ZH-CN1995433788_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.YoungCaiman_ZH-CN1995433788_1920x1080.jpg', CAST(N'2024-08-27' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6196, N'蒙马特和圣心大教堂，巴黎，法国 (© Tuul & Bruno Morandi/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.ParalympicsParis_ZH-CN9773135851_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.ParalympicsParis_ZH-CN9773135851_1920x1080.jpg', CAST(N'2024-08-28' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6197, N'富利特堡-德拉罗卡，加泰罗尼亚，西班牙 (© Eloi_Omella/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.CastellfollitSpain_ZH-CN2990517626_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.CastellfollitSpain_ZH-CN2990517626_1920x1080.jpg', CAST(N'2024-08-29' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6198, N'鸟头湾的鲸鲨，西巴布亚，印度尼西亚 (© Andy Lerner/Tandem Stills + Motion)', NULL, N'https://cn.bing.com/th?id=OHR.WhaleSharkDay_ZH-CN3334940631_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.WhaleSharkDay_ZH-CN3334940631_1920x1080.jpg', CAST(N'2024-08-30' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6199, N'撒哈拉沙漠的岩层和沙丘，贾奈特，阿尔及利亚 (© Airpano/Amazing Aerial Agency)', NULL, N'https://cn.bing.com/th?id=OHR.DjanetAlgeria_ZH-CN3458706695_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.DjanetAlgeria_ZH-CN3458706695_1920x1080.jpg', CAST(N'2024-08-31' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6200, N'泰晤士河，伦敦，英国 (© Puthipong Worasaran/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.ThamesLondon_ZH-CN3629717426_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.ThamesLondon_ZH-CN3629717426_1920x1080.jpg', CAST(N'2024-09-01' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6201, N'红绿金刚鹦鹉，南马托格罗索州，巴西 (© Ellen Goff/Danita Delimont)', NULL, N'https://cn.bing.com/th?id=OHR.BuracodasAraras_ZH-CN3881985508_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.BuracodasAraras_ZH-CN3881985508_1920x1080.jpg', CAST(N'2024-09-02' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6202, N'迷人的水晶湖，高山湖泊，华盛顿州，美国 (© Mitch Pittman/Tandem Stills + Motion)', NULL, N'https://cn.bing.com/th?id=OHR.AlpineLakes_ZH-CN4537389724_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.AlpineLakes_ZH-CN4537389724_1920x1080.jpg', CAST(N'2024-09-03' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6203, N'乌雕鸮，巴基斯坦 (© zahoor salmi/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.DuskyOwls_ZH-CN4729762831_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.DuskyOwls_ZH-CN4729762831_1920x1080.jpg', CAST(N'2024-09-04' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6204, N'多伦多城市天际线,加拿大 (© Roberto Machado Noa/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.TIFF2024_ZH-CN4896695918_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.TIFF2024_ZH-CN4896695918_1920x1080.jpg', CAST(N'2024-09-05' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6205, N'古老山毛榉树，格莱纳里夫森林公园，安特里姆郡，北爱尔兰 (© Dawid K Photography/Shutterstock)', NULL, N'https://cn.bing.com/th?id=OHR.GlenariffPark_ZH-CN4667558707_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.GlenariffPark_ZH-CN4667558707_1920x1080.jpg', CAST(N'2024-09-06' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6206, N'朱红蜂鸟，圣克鲁斯，加利福尼亚州，美国 (© yhelfman/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.SantaCruzHummer_ZH-CN5448262039_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.SantaCruzHummer_ZH-CN5448262039_1920x1080.jpg', CAST(N'2024-09-07' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6207, N'加泰罗尼亚北部的圣马丁杜卡尼古修道院 ，法国 (© Cyril Gosselin/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.Canigou_ZH-CN6145410455_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.Canigou_ZH-CN6145410455_1920x1080.jpg', CAST(N'2024-09-08' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6208, N'阿根廷和巴西边境的伊瓜苏瀑布 (© AirPano LLC/Amazing Aerial Agency)', NULL, N'https://cn.bing.com/th?id=OHR.IguazuRainbow_ZH-CN6524347982_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.IguazuRainbow_ZH-CN6524347982_1920x1080.jpg', CAST(N'2024-09-09' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6209, N'瓦斯科·达·伽马大桥，里斯本，葡萄牙 (© Achim Thomae/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.BridgeLisbon_ZH-CN6877671644_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.BridgeLisbon_ZH-CN6877671644_1920x1080.jpg', CAST(N'2024-09-10' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6210, N'埃尔茨城堡，德国 (© Allard Schager/Alamy)', NULL, N'https://cn.bing.com/th?id=OHR.EltzCastle_ZH-CN7586749377_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.EltzCastle_ZH-CN7586749377_1920x1080.jpg', CAST(N'2024-09-11' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6211, N'留尼汪岛附近的海豚群，印度洋，法国海外省 (© Joost van Uffelen/Shutterstock)', NULL, N'https://cn.bing.com/th?id=OHR.DolphinReunion_ZH-CN7681290861_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.DolphinReunion_ZH-CN7681290861_1920x1080.jpg', CAST(N'2024-09-12' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6212, N'雷耶斯角国家海岸灯塔，加利福尼亚州，美国 (© RMB Images/Photography by Robert Bowman/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.PointReyes_ZH-CN7781514086_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.PointReyes_ZH-CN7781514086_1920x1080.jpg', CAST(N'2024-09-13' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6213, N'阿胡汤加里基的日出，拉帕·努伊国家公园，复活节岛，智利 (© Piriya Photography/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.RapaNuiSunrise_ZH-CN1220508877_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.RapaNuiSunrise_ZH-CN1220508877_1920x1080.jpg', CAST(N'2024-09-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6214, N'阿科马尼奥海滩，卡拉布里亚，意大利 (© Alessio de Cicco/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.CalabriaPeperoncino_ZH-CN8603617212_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.CalabriaPeperoncino_ZH-CN8603617212_1920x1080.jpg', CAST(N'2024-09-15' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6215, N'日出时的小袋鼠，阿德莱德河，北领地，澳大利亚 (© Jeremy Woodhouse/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.SunriseWallabies_ZH-CN8725891401_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.SunriseWallabies_ZH-CN8725891401_1920x1080.jpg', CAST(N'2024-09-16' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6216, N'月圆之夜的豫园，上海，中国 (© zyxeos30/Gettyimages)', NULL, N'https://cn.bing.com/th?id=OHR.MidAutumnFestival2024_ZH-CN9096556094_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.MidAutumnFestival2024_ZH-CN9096556094_1920x1080.jpg', CAST(N'2024-09-17' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6217, N'郡上八幡城，岐阜县，日本 (© ta2funk ito/500px/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.GujoHachiman_ZH-CN9192289658_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.GujoHachiman_ZH-CN9192289658_1920x1080.jpg', CAST(N'2024-09-18' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6218, N'埃尔博河上空的银河，阿尔伯塔省，加拿大 (© Alan Dyer/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.ElbowRiver_ZH-CN9580175593_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.ElbowRiver_ZH-CN9580175593_1920x1080.jpg', CAST(N'2024-09-19' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6219, N'奥克拉科克岛上的奥克拉科克灯塔，北卡罗来纳州，美国 (© Chansak Joe/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.OcracokeLight_ZH-CN9810840077_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.OcracokeLight_ZH-CN9810840077_1920x1080.jpg', CAST(N'2024-09-20' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6220, N'Oktoberfest in Munich at sunset (© AllesSuper21/iStock/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.MunichBeerfest_ZH-CN0304560562_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.MunichBeerfest_ZH-CN0304560562_1920x1080.jpg', CAST(N'2024-09-21' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6221, N'巴特米尔湖，湖区国家公园，英格兰，英国 (© Alan Novelli/Alamy Stock Photo)', NULL, N'https://cn.bing.com/th?id=OHR.AutumnCumbria_ZH-CN0565958390_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.AutumnCumbria_ZH-CN0565958390_1920x1080.jpg', CAST(N'2024-09-22' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6222, N'海獭，威廉王子湾,阿拉斯加州,美国 (© Gerald Corsi/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.IcebergOtter_ZH-CN0972467238_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.IcebergOtter_ZH-CN0972467238_1920x1080.jpg', CAST(N'2024-09-23' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6223, N'斯卡夫塔山的瀑布，瓦特纳冰川国家公园，冰岛 (© Nopasorn Kowathanakul/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.SkaftafellWaterfall_ZH-CN1766863001_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.SkaftafellWaterfall_ZH-CN1766863001_1920x1080.jpg', CAST(N'2024-09-24' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6224, N'巨型红杉，红杉国家公园，加利福尼亚州，美国 (© Galyna Andrushko/Shutterstock)', NULL, N'https://cn.bing.com/th?id=OHR.GiantSequoias_ZH-CN2666897238_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.GiantSequoias_ZH-CN2666897238_1920x1080.jpg', CAST(N'2024-09-25' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6225, N'蓝斑巨嘴鸟，洛斯戈查尔斯国家公园，哥斯达黎加 (© Oscar Dominguez/Tandem Stills + Motion)', NULL, N'https://cn.bing.com/th?id=OHR.LittleToucanet_ZH-CN2910262009_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.LittleToucanet_ZH-CN2910262009_1920x1080.jpg', CAST(N'2024-09-26' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6226, N'大运河和安康圣母教堂的鸟瞰图，威尼斯，意大利 (© Bachir Moukarzel/Amazing Aerial Agency)', NULL, N'https://cn.bing.com/th?id=OHR.VeniceAerial_ZH-CN4070720525_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.VeniceAerial_ZH-CN4070720525_1920x1080.jpg', CAST(N'2024-09-27' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6227, N'日出时的海滩，海湾岛国家海岸，佛罗里达，美国 (© Tim Fitzharris/Minden Pictures)', NULL, N'https://cn.bing.com/th?id=OHR.FloridaSeashore_ZH-CN4671838639_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.FloridaSeashore_ZH-CN4671838639_1920x1080.jpg', CAST(N'2024-09-28' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6228, N'横跨胡萨托尼克河的西康沃尔廊桥，康涅狄格州，美国 (© pabradyphoto/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.ConnecticutBridge_ZH-CN4957862425_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.ConnecticutBridge_ZH-CN4957862425_1920x1080.jpg', CAST(N'2024-09-29' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6229, N'斯匹次卑尔根岛北部的海象群，斯瓦尔巴群岛，挪威 (© AWL Images/DanitaDelimont)', NULL, N'https://cn.bing.com/th?id=OHR.WalrusNorway_ZH-CN5657804031_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.WalrusNorway_ZH-CN5657804031_1920x1080.jpg', CAST(N'2024-09-30' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6230, N'禾木村的风景，新疆，中国 (© snvv18870020330/Shutterstock)', NULL, N'https://cn.bing.com/th?id=OHR.NationalDay2024_ZH-CN7026189162_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.NationalDay2024_ZH-CN7026189162_1920x1080.jpg', CAST(N'2024-10-01' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6231, N'温德河，布鲁克斯山脉，北极国家野生动物保护区，阿拉斯加州，美国 (© Design Pics/DanitaDelimont)', NULL, N'https://cn.bing.com/th?id=OHR.WindRiverAlaska_ZH-CN7317039321_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.WindRiverAlaska_ZH-CN7317039321_1920x1080.jpg', CAST(N'2024-10-02' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6232, N'阿格拉的泰姬陵，安拉阿巴德，印度 (© Tanarch/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.TajMahalReflection_ZH-CN7498774173_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.TajMahalReflection_ZH-CN7498774173_1920x1080.jpg', CAST(N'2024-10-03' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6233, N'木星的冰卫星木卫二 (© NASA/JPL-Caltech/SETI Institute)', NULL, N'https://cn.bing.com/th?id=OHR.EuropaMoon_ZH-CN0149249980_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.EuropaMoon_ZH-CN0149249980_1920x1080.jpg', CAST(N'2024-10-04' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6234, N'东察沃国家公园的非洲象，肯尼亚 (© Neil Bowman/Minden Pictures)', NULL, N'https://cn.bing.com/th?id=OHR.ElephantTeacher_ZH-CN0543308499_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.ElephantTeacher_ZH-CN0543308499_1920x1080.jpg', CAST(N'2024-10-05' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6235, N'郊狼峡谷拱门中的白杨树，格兰峡谷休闲区，犹他州，美国 (© Stephen Matera/TANDEM Stills + Motion)', NULL, N'https://cn.bing.com/th?id=OHR.CoyoteGulch_ZH-CN2869463336_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.CoyoteGulch_ZH-CN2869463336_1920x1080.jpg', CAST(N'2024-10-06' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6236, N'法属波利尼西亚波拉波拉岛的鸟瞰图 (© GLF Media/Shutterstock)', NULL, N'https://cn.bing.com/th?id=OHR.BoraPapeete_ZH-CN1991283465_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.BoraPapeete_ZH-CN1991283465_1920x1080.jpg', CAST(N'2024-10-07' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6237, N'索拉诺，托斯卡纳，意大利 (© Luigi Vaccarella/eStock Photo)', NULL, N'https://cn.bing.com/th?id=OHR.SoranoItaly_ZH-CN1190725201_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.SoranoItaly_ZH-CN1190725201_1920x1080.jpg', CAST(N'2024-10-08' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6238, N'马布尔附近的白杨树，科罗拉多州，美国 (© Jason Hatfield/TANDEM Stills + Motion)', NULL, N'https://cn.bing.com/th?id=OHR.AspensColorado_ZH-CN0132780533_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.AspensColorado_ZH-CN0132780533_1920x1080.jpg', CAST(N'2024-10-09' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6239, N'索拉诺，托斯卡纳，意大利 (© Luigi Vaccarella/eStock Photo)', NULL, N'https://cn.bing.com/th?id=OHR.SoranoItaly_ZH-CN5842160079_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.SoranoItaly_ZH-CN5842160079_1920x1080.jpg', CAST(N'2024-10-10' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6240, N'黄山云海，安徽省，中国 (© yangyang1991/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.Chongyang2024_ZH-CN4180097837_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.Chongyang2024_ZH-CN4180097837_1920x1080.jpg', CAST(N'2024-10-11' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6241, N'林鸳鸯，魁北克省，加拿大 (© Maxime Riendeau/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.QuebecDuck_ZH-CN0588954873_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.QuebecDuck_ZH-CN0588954873_1920x1080.jpg', CAST(N'2024-10-12' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6242, N'塞维利亚王宫少女庭院，西班牙 (© Danny Lehman/Getty Images)', NULL, N'https://cn.bing.com/th?id=OHR.AlcazarSeville_ZH-CN5581795099_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.AlcazarSeville_ZH-CN5581795099_1920x1080.jpg', CAST(N'2024-10-13' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[bs_bingwallpaper] ([Id], [CopyRight], [GitUrl], [MobileUrl], [Url], [StartDate], [CreatedTime], [UpdatedTime], [CreatedUserId], [CreatedUserName], [UpdatedUserId], [UpdatedUserName], [IsDeleted]) VALUES (6243, N'可可海滩上的渔船，果阿邦，印度 (© Abhinav Sah/Shutterstock)', NULL, N'https://cn.bing.com/th?id=OHR.CocoBeach_ZH-CN7503553722_1080x1920.jpg', N'https://cn.bing.com/th?id=OHR.CocoBeach_ZH-CN7503553722_1920x1080.jpg', CAST(N'2024-10-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[bs_bingwallpaper] OFF
GO
SET IDENTITY_INSERT [dbo].[bs_customer] ON 
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (6, N'os0uq5U219FMd-jbfOGkLF48MJqI', N'郭一', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2022-04-08T19:28:23.310' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1002, N'os0uq5bYdIgCdstT8UB9pQ68r4', N'Forget', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2022-04-22T14:07:28.453' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1004, N'os0uq5b9bdmQG7hbi0pVNsedaj-0', N'芳海', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2022-05-05T22:07:56.317' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1007, N'os0uq5RNCT_foRWnxrEF6lCSlAuU', N'MysticTides', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2022-06-25T11:44:30.910' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1014, N'os0uq5RrNiFAvva2jdwlWUy8T_W0', N'Banza', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2022-09-29T02:52:03.823' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1015, N'os0uq5dXsMXaCtlasRXcbjjLLdmc', N'Rainbowヾ', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2022-09-29T09:47:20.317' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1023, N'os0uq5bNvYzMuUug8gPVSqd6ahJo', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-02-15T10:17:56.297' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1026, N'os0uq5TCxPzFBJXc-X8NoL8IYeDQ', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-02-21T09:43:05.240' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1040, N'os0uq5Z6H7x9Y8TfVntkzwNtQy3w', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-03-07T16:58:11.387' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1051, N'os0uq5UMw68i28XffOwfZjbCXgwk', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-05-08T18:37:18.953' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1053, N'os0uq5Ql625DkGeyUwLa6417X7fU', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-05-08T21:28:13.627' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1159, N'os0uq5dgfNsJlg-aRjfEXIhbVHA4', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-06-08T17:23:19.420' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1176, N'os0uq5QaVfkciqQL_LTcusDmI8ZY', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-06-13T04:22:32.480' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1193, N'os0uq5SlQRhRG_OdBnR7SBeuv-Jc', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-06-22T19:43:16.100' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1199, N'os0uq5UJOU66JVFypuvCt1ykZ16U', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-06-26T20:46:25.977' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1234, N'os0uq5QAxOEoBOcuGpKbtOdlpOqU', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-07-22T09:13:23.600' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1246, N'os0uq5RQ4IcnCO4w79_jRNR0CGuM', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-07-31T20:12:29.080' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1254, N'os0uq5VTHWxjMObuI1Cu02Dyo6TM', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-08-11T09:32:40.700' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1256, N'os0uq5aJ_8OtAa_jl14nh225HqZ8', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-08-15T23:29:10.733' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1264, N'os0uq5TO3n_ZbHVgUeu1VtfiSR3Y', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-08-19T10:32:38.823' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1282, N'os0uq5deGjMCtm8IwNCwYp8SIc', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-09-13T21:03:15.990' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1283, N'os0uq5eTNOypRQBbz60hNFwAjHmY', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-09-14T00:19:47.860' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1291, N'os0uq5V9ZUf4F7Sa1o56w-VnnBdU', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-09-20T00:16:33.817' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1312, N'os0uq5aO-CqEFBtXihLDIQPOzLmw', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-10-08T21:29:46.423' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1317, N'os0uq5adK-f-OIp0SaK_sP2I-Ngw', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-10-12T02:47:54.830' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1322, N'os0uq5bjmxVpYkeV13VHB6eeiQM0', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-10-13T15:52:14.430' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1344, N'os0uq5SDHugndQuKsALgBw7xBLFk', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-11-08T09:41:09.627' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1353, N'os0uq5fqXUf7ALzRmCHxs9aomGF8', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-11-16T15:30:57.397' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1357, N'os0uq5Ze3pdinmTTA8Ub803nEX84', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-11-20T12:00:59.560' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1359, N'os0uq5XwxnQUIpXqDwrTPlpzjyA4', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2023-12-01T15:05:08.013' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1389, N'os0uq5Z3f78QgcWds5GcCTVGA_bk', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-01-06T11:28:49.133' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1396, N'os0uq5WlHvM5vlNjLh61_0p6iIsQ', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-01-09T15:22:58.480' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1399, N'os0uq5ezoyy3GzXvYr2WdEAo3h3M', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-01-10T15:00:42.620' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1404, N'os0uq5WD6Y1iqATuun2futEbj9bY', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-01-17T07:43:30.060' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1415, N'os0uq5Y1e450aTxWQsL5-U7KdT7c', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-02-01T14:47:37.647' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1421, N'os0uq5UCuDMua5n5MH1x4TSHp0S8', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-02-26T14:22:18.733' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1424, N'os0uq5fQKNEOK5V-zoNGSzq9r2DU', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-02-29T15:16:55.920' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1445, N'os0uq5cEJddImRZRbegh_t4OWwIw', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-03-26T14:51:04.780' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1459, N'os0uq5axyNAyhRHny621B4mgbNnQ', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-04-15T02:50:43.550' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1468, N'os0uq5bf8QHBf8pNASUIblBPsBHk', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-04-26T11:57:53.827' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1473, N'os0uq5WwnXTgQfQ_Z8uA9LeubCdg', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-04-29T10:31:23.577' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (1475, N'os0uq5bxxyRBmgkqAOwSOlX7vTyU', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-04-30T12:30:15.770' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (2412, N'os0uq5V0U-ng0rbniUV2nlBDf3vg', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-05-30T11:32:29.633' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (2464, N'os0uq5dNLJx_wsPTnSZS7BmmAFTM', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-07-25T09:15:30.733' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (2479, N'os0uq5S6y-rqGw_UeH7N9Ep7s22U', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-08-07T11:31:06.637' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (2481, N'os0uq5b-V671POnwkENZfO1gFI', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-08-07T17:46:37.573' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (3389, N'os0uq5QvxssjnG7586TEMLyJ6-qI', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-08-20T19:11:09.783' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (3398, N'os0uq5Vx0IlLouW3yGBKSc_C_DaM', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-08-27T07:01:11.830' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (3417, N'os0uq5RCCiSBCkUKKL2JHU88Pxr0', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-09-11T17:48:46.833' AS DateTime))
GO
INSERT [dbo].[bs_customer] ([UserID], [OpenID], [NickName], [RealName], [AvatarUrl], [CreatedDate]) VALUES (3431, N'os0uq5XKh5T3_xJWaoDNJoMNNi9Y', N'微信用户', NULL, N'http://imagesoss.hunji.xyz/conch-net/avatar/1.png', CAST(N'2024-09-20T18:55:33.123' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[bs_customer] OFF
GO
SET IDENTITY_INSERT [dbo].[bs_gallery] ON 
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (8416, N'http://imagesoss.hunji.xyz/randomgril//2019/11/6E29E8E4-963C-4786-BB90-06504EF4BF78.jpeg', CAST(800.0000 AS Decimal(18, 4)), CAST(1200.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, 0, CAST(N'2023-05-30T00:09:06.543' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (9882, N'http://imagesoss.hunji.xyz/randomgril//2021/04/2021040314094387.jpeg', CAST(1000.0000 AS Decimal(18, 4)), CAST(1461.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, 0, CAST(N'2023-05-30T00:09:06.543' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (10075, N'http://imagesoss.hunji.xyz/randomgril//2018/08/2018-08-16_00-19-30.jpg', CAST(1476.0000 AS Decimal(18, 4)), CAST(2191.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, 0, CAST(N'2023-05-30T00:09:06.543' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (11446, N'http://imagesoss.hunji.xyz/randomgril//2018/02/2018-02-09_19-01-47_137.jpg', CAST(1200.0000 AS Decimal(18, 4)), CAST(801.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'RandomGril', 0, NULL, 0, CAST(N'2023-05-30T00:09:06.543' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (11951, N'http://imagesoss.hunji.xyz/randomgril//Other/98s_2017-03-14_13-52-01.png', CAST(600.0000 AS Decimal(18, 4)), CAST(900.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, 0, CAST(N'2023-05-30T00:09:06.543' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (12492, N'http://imagesoss.hunji.xyz/randomgril//2018/03/2018-03-22_02-50-09_137.jpg', CAST(801.0000 AS Decimal(18, 4)), CAST(1200.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, 0, CAST(N'2023-05-30T00:09:06.543' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (13585, N'http://imagesoss.hunji.xyz/randomgril//2017/02/1485958774180280.jpg', CAST(678.0000 AS Decimal(18, 4)), CAST(960.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, 0, CAST(N'2023-05-30T00:09:06.543' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (13644, N'http://imagesoss.hunji.xyz/randomgril//2017/12/2017-12-28_13-06-47_168.jpg', CAST(800.0000 AS Decimal(18, 4)), CAST(1200.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, 0, CAST(N'2023-05-30T00:09:06.543' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (15013, N'http://imagesoss.hunji.xyz/randomgril//2016/10/2016-10-1130.jpg', CAST(947.0000 AS Decimal(18, 4)), CAST(1200.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, 0, CAST(N'2023-05-30T00:09:06.543' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (15660, N'http://imagesoss.hunji.xyz/randomgril//2021/01/2021011111023434.jpeg', CAST(1000.0000 AS Decimal(18, 4)), CAST(1500.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, 0, CAST(N'2023-05-30T00:09:06.543' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (16332, N'http://imagesoss.hunji.xyz/randomgril//2018/01/IMG_4723.jpg', CAST(1024.0000 AS Decimal(18, 4)), CAST(638.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'RandomGril', 0, NULL, 0, CAST(N'2023-05-30T00:09:06.543' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (16457, N'http://imagesoss.hunji.xyz/randomgril//2018/01/2018-01-21_08-57-27_109.jpg', CAST(800.0000 AS Decimal(18, 4)), CAST(1200.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, 0, CAST(N'2023-05-30T00:09:06.543' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (16635, N'http://imagesoss.hunji.xyz/randomgril//2021/08/2021080418220124.jpeg', CAST(1000.0000 AS Decimal(18, 4)), CAST(667.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'RandomGril', 0, NULL, 0, CAST(N'2023-05-30T00:09:06.543' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (18556, N'http://imagesoss.hunji.xyz/mobilewallpaper//BlackGobi01.jpg', CAST(1800.0000 AS Decimal(18, 4)), CAST(3200.0000 AS Decimal(18, 4)), CAST(4656011.0000 AS Decimal(18, 4)), N'手机壁纸', 1, NULL, 0, CAST(N'2023-05-30T00:09:06.543' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (19136, N'http://imagesoss.hunji.xyz/randomgril//Other/99i_2017-02-16_10-14-54.jpg', CAST(750.0000 AS Decimal(18, 4)), CAST(499.0000 AS Decimal(18, 4)), CAST(119647.0000 AS Decimal(18, 4)), N'RandomGril', 0, NULL, NULL, CAST(N'2023-06-07T14:46:05.620' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (19139, N'http://imagesoss.hunji.xyz/randomgril//Other/99i_2017-02-16_11-55-02.jpg', CAST(499.0000 AS Decimal(18, 4)), CAST(750.0000 AS Decimal(18, 4)), CAST(75643.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:46:05.993' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (19425, N'http://imagesoss.hunji.xyz/randomgril//Qifen/9ff79d0a-3678-410b-9c19-fed34e0416b3.jpg', CAST(1448.0000 AS Decimal(18, 4)), CAST(2172.0000 AS Decimal(18, 4)), CAST(396663.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:46:33.620' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (19456, N'http://imagesoss.hunji.xyz/randomgril//Qifen/bfb14095-ca55-429c-a0bd-b5ff9d943357.jpg', CAST(1074.0000 AS Decimal(18, 4)), CAST(1432.0000 AS Decimal(18, 4)), CAST(255039.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:46:35.867' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (19563, N'http://imagesoss.hunji.xyz/randomgril//2017/01/1485007789262543.jpeg', CAST(658.0000 AS Decimal(18, 4)), CAST(986.0000 AS Decimal(18, 4)), CAST(126546.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:46:45.607' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (19587, N'http://imagesoss.hunji.xyz/randomgril//2017/01/1485235651728672.jpg', CAST(640.0000 AS Decimal(18, 4)), CAST(960.0000 AS Decimal(18, 4)), CAST(355416.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:46:48.257' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (19700, N'http://imagesoss.hunji.xyz/randomgril//2017/01/9ap_2017-01-05_02-02-44.jpg', CAST(640.0000 AS Decimal(18, 4)), CAST(960.0000 AS Decimal(18, 4)), CAST(129826.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:47:01.637' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (19766, N'http://imagesoss.hunji.xyz/randomgril//2017/02/1486301616684531.jpeg', CAST(563.0000 AS Decimal(18, 4)), CAST(750.0000 AS Decimal(18, 4)), CAST(78587.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:47:09.867' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (19827, N'http://imagesoss.hunji.xyz/randomgril//2017/02/1486477298382290.jpg', CAST(600.0000 AS Decimal(18, 4)), CAST(900.0000 AS Decimal(18, 4)), CAST(415151.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:47:17.140' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (20244, N'http://imagesoss.hunji.xyz/randomgril//2017/06/1498137226745576.png', CAST(600.0000 AS Decimal(18, 4)), CAST(902.0000 AS Decimal(18, 4)), CAST(971327.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:48:05.890' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (20552, N'http://imagesoss.hunji.xyz/randomgril//2017/11/1509707807984620.jpg', CAST(1200.0000 AS Decimal(18, 4)), CAST(800.0000 AS Decimal(18, 4)), CAST(229540.0000 AS Decimal(18, 4)), N'RandomGril', 0, NULL, NULL, CAST(N'2023-06-07T14:48:53.243' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (20650, N'http://imagesoss.hunji.xyz/randomgril//2017/11/1511184201962137.jpg', CAST(900.0000 AS Decimal(18, 4)), CAST(1200.0000 AS Decimal(18, 4)), CAST(354731.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:49:04.540' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (20944, N'http://imagesoss.hunji.xyz/randomgril//2018/01/2018-01-21_08-57-28_121.jpg', CAST(750.0000 AS Decimal(18, 4)), CAST(1200.0000 AS Decimal(18, 4)), CAST(394934.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:49:40.050' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (21067, N'http://imagesoss.hunji.xyz/randomgril//2018/02/2018-02-12_18-35-22_146.jpg', CAST(800.0000 AS Decimal(18, 4)), CAST(1200.0000 AS Decimal(18, 4)), CAST(366242.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:49:55.027' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (21170, N'http://imagesoss.hunji.xyz/randomgril//2018/03/2018-03-11_21-25-51.jpg', CAST(801.0000 AS Decimal(18, 4)), CAST(1200.0000 AS Decimal(18, 4)), CAST(293685.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:50:07.123' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (21239, N'http://imagesoss.hunji.xyz/randomgril//2018/03/2018-03-19_15-24-55_145.jpg', CAST(1200.0000 AS Decimal(18, 4)), CAST(800.0000 AS Decimal(18, 4)), CAST(128861.0000 AS Decimal(18, 4)), N'RandomGril', 0, NULL, NULL, CAST(N'2023-06-07T14:50:14.360' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (21354, N'http://imagesoss.hunji.xyz/randomgril//2018/04/2018-04-01_20-12-55_171.jpg', CAST(801.0000 AS Decimal(18, 4)), CAST(1200.0000 AS Decimal(18, 4)), CAST(199504.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:50:24.910' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (21374, N'http://imagesoss.hunji.xyz/randomgril//2018/04/2018-04-10_00-38-09.jpg', CAST(800.0000 AS Decimal(18, 4)), CAST(1200.0000 AS Decimal(18, 4)), CAST(137136.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:50:26.923' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (21407, N'http://imagesoss.hunji.xyz/randomgril//2018/04/2018-04-23_18-34-40_104.jpg', CAST(800.0000 AS Decimal(18, 4)), CAST(1200.0000 AS Decimal(18, 4)), CAST(191547.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:50:30.563' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (21504, N'http://imagesoss.hunji.xyz/randomgril//2018/06/2018-06-05_01-41-51.jpg', CAST(800.0000 AS Decimal(18, 4)), CAST(1200.0000 AS Decimal(18, 4)), CAST(243152.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:50:39.157' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (21645, N'http://imagesoss.hunji.xyz/randomgril//2018/08/2018-08-08_17-02-17.jpg', CAST(1633.0000 AS Decimal(18, 4)), CAST(2381.0000 AS Decimal(18, 4)), CAST(579236.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:50:52.500' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (21858, N'http://imagesoss.hunji.xyz/randomgril//2019/01/2019-01-31_01-02-13.jpg', CAST(1000.0000 AS Decimal(18, 4)), CAST(1500.0000 AS Decimal(18, 4)), CAST(135430.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:51:16.410' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (22119, N'http://imagesoss.hunji.xyz/randomgril//2019/09/2019-09-03_00-16-06.jpg', CAST(1000.0000 AS Decimal(18, 4)), CAST(1500.0000 AS Decimal(18, 4)), CAST(588851.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:51:40.360' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (22232, N'http://imagesoss.hunji.xyz/randomgril//2020/02/2020022012380285-scaled.jpeg', CAST(1000.0000 AS Decimal(18, 4)), CAST(1500.0000 AS Decimal(18, 4)), CAST(337541.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:51:51.687' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (22538, N'http://imagesoss.hunji.xyz/randomgril//2021/02/2021020320495385.jpeg', CAST(1000.0000 AS Decimal(18, 4)), CAST(1500.0000 AS Decimal(18, 4)), CAST(357610.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:52:19.417' AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[bs_gallery] ([ImagesID], [ImagesURL], [ImagesWide], [ImagesHeiget], [ImagesSize], [Type], [VerticalScreen], [Source], [Examine], [UpdateTime], [IsDelete], [Praise], [DisLike]) VALUES (22562, N'http://imagesoss.hunji.xyz/randomgril//2021/02/2021022807535648.jpeg', CAST(1000.0000 AS Decimal(18, 4)), CAST(1500.0000 AS Decimal(18, 4)), CAST(238844.0000 AS Decimal(18, 4)), N'RandomGril', 1, NULL, NULL, CAST(N'2023-06-07T14:52:21.667' AS DateTime), 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[bs_gallery] OFF
GO
SET IDENTITY_INSERT [dbo].[bs_miniappsitelink] ON 
GO
INSERT [dbo].[bs_miniappsitelink] ([MiniAppSiteLinkId], [MiniAppId], [MiniAppUrl], [MiniAppName], [Path], [IsDeleted]) VALUES (3, N'wxf3d81a452b88ff4b', N'http://imagesoss.hunji.xyz/tuniao/sitelink/199750c10f5f66cf296ee68be38ca81a.jpg', N'图鸟UI', NULL, 0)
GO
INSERT [dbo].[bs_miniappsitelink] ([MiniAppSiteLinkId], [MiniAppId], [MiniAppUrl], [MiniAppName], [Path], [IsDeleted]) VALUES (4, N'wx76bb942a2810e8e5', N'http://imagesoss.hunji.xyz/tuniao/sitelink/62d614af46577c938b81a71b11a99b03.jpg', N'图鸟壁纸', NULL, 0)
GO
INSERT [dbo].[bs_miniappsitelink] ([MiniAppSiteLinkId], [MiniAppId], [MiniAppUrl], [MiniAppName], [Path], [IsDeleted]) VALUES (5, N'wx13c0ed55c12d2afb', N'http://imagesoss.hunji.xyz/tuniao/sitelink/10aa6cc0cbbebe79437d69a1f4113586.jpg', N'图鸟圈子', NULL, 0)
GO
INSERT [dbo].[bs_miniappsitelink] ([MiniAppSiteLinkId], [MiniAppId], [MiniAppUrl], [MiniAppName], [Path], [IsDeleted]) VALUES (6, N'wx24062428b4883952', N'http://imagesoss.hunji.xyz/tuniao/sitelink/20230510171934.jpg', N'兔兔找图', NULL, 0)
GO
INSERT [dbo].[bs_miniappsitelink] ([MiniAppSiteLinkId], [MiniAppId], [MiniAppUrl], [MiniAppName], [Path], [IsDeleted]) VALUES (7, N'wxcd661761a9f2d61e', N'http://imagesoss.hunji.xyz/tuniao/sitelink/60693b7e4f1e2d19b44b45144a38195d.png', N'柒糖图集', NULL, 0)
GO
INSERT [dbo].[bs_miniappsitelink] ([MiniAppSiteLinkId], [MiniAppId], [MiniAppUrl], [MiniAppName], [Path], [IsDeleted]) VALUES (8, N'wxbd80986c169e97a1', N'http://imagesoss.hunji.xyz/tuniao/sitelink/%E5%BE%AE%E4%BF%A1%E5%9B%BE%E7%89%87_20230531163855.jpg', N'孟夏找图', NULL, 0)
GO
INSERT [dbo].[bs_miniappsitelink] ([MiniAppSiteLinkId], [MiniAppId], [MiniAppUrl], [MiniAppName], [Path], [IsDeleted]) VALUES (9, N'wxe7432f7ecc04f389', N'http://imagesoss.hunji.xyz/tuniao/sitelink/%E6%AF%94%E6%AF%94%E8%BD%BB%E5%A3%81%E7%BA%B8.jpg', N'比比轻壁纸', NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[bs_miniappsitelink] OFF
GO
INSERT [dbo].[bs_wechatconfig] ([WechatAppID], [WechatAppSecret], [WechatAppName], [AccessToken], [ExpireTime], [UpTime], [NextUpTime], [Res]) VALUES (N'wx7560d334dd837f70', N'53874541596056c1a7f294fef3fff8a8', N'迷恋自留地', N'2023-03-07 16:48:32.950', 3600, CAST(N'2023-03-07T16:48:32.950' AS DateTime), CAST(N'2023-03-07T16:48:32.950' AS DateTime), N'3600')
GO
INSERT [dbo].[sys_log_op_20241101] ([Id], [LogType], [Message], [LogDateTime]) VALUES (1854391203676688384, N'后台日志', N'用户Malus登录了系统', CAST(N'2024-11-07T13:11:29.403' AS DateTime))
GO
INSERT [dbo].[sys_log_op_20241101] ([Id], [LogType], [Message], [LogDateTime]) VALUES (1854391659090022400, N'后台日志', N'用户Malus登录了系统', CAST(N'2024-11-07T13:13:18.160' AS DateTime))
GO
INSERT [dbo].[sys_log_op_20241101] ([Id], [LogType], [Message], [LogDateTime]) VALUES (1854391703885189120, N'后台日志', N'用户Malus登录了系统', CAST(N'2024-11-07T13:13:29.097' AS DateTime))
GO
INSERT [dbo].[sys_log_op_20241101] ([Id], [LogType], [Message], [LogDateTime]) VALUES (1854393881416830976, N'后台日志', N'用户Malus登录了系统', CAST(N'2024-11-07T13:22:08.903' AS DateTime))
GO
INSERT [dbo].[sys_log_op_20241101] ([Id], [LogType], [Message], [LogDateTime]) VALUES (1854393910659518464, N'后台日志', N'用户Malus登录了系统', CAST(N'2024-11-07T13:22:15.917' AS DateTime))
GO
INSERT [dbo].[sys_log_op_20241101] ([Id], [LogType], [Message], [LogDateTime]) VALUES (1854393941907083264, N'后台操作', N'用户Malus获取了必应壁纸', CAST(N'2024-11-07T13:22:23.343' AS DateTime))
GO
INSERT [dbo].[sys_log_op_20241101] ([Id], [LogType], [Message], [LogDateTime]) VALUES (1854393950073393152, N'后台操作', N'用户Malus获取了必应壁纸', CAST(N'2024-11-07T13:22:25.313' AS DateTime))
GO
INSERT [dbo].[sys_log_op_20241101] ([Id], [LogType], [Message], [LogDateTime]) VALUES (1854393953860849664, N'后台操作', N'用户Malus获取了必应壁纸', CAST(N'2024-11-07T13:22:26.207' AS DateTime))
GO
INSERT [dbo].[sys_log_op_20241101] ([Id], [LogType], [Message], [LogDateTime]) VALUES (1854393956490678272, N'后台操作', N'用户Malus获取了必应壁纸', CAST(N'2024-11-07T13:22:26.800' AS DateTime))
GO
INSERT [dbo].[sys_log_op_20241101] ([Id], [LogType], [Message], [LogDateTime]) VALUES (1854393961540620288, N'后台操作', N'用户Malus获取了必应壁纸', CAST(N'2024-11-07T13:22:28.013' AS DateTime))
GO
INSERT [dbo].[sys_log_op_20241101] ([Id], [LogType], [Message], [LogDateTime]) VALUES (1854393964141088768, N'后台操作', N'用户Malus获取了必应壁纸', CAST(N'2024-11-07T13:22:28.603' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[t_sys_config] ON 
GO
INSERT [dbo].[t_sys_config] ([ConfigID], [ConfigKey], [ConfigType], [ConfigValue], [ConfigDescribe], [IsDeleted]) VALUES (1, N'tokenExpireTime', N'后台', N'301', N'Token过期时间【分钟】', 0)
GO
INSERT [dbo].[t_sys_config] ([ConfigID], [ConfigKey], [ConfigType], [ConfigValue], [ConfigDescribe], [IsDeleted]) VALUES (2, N'apptime', N'小程序测试参数', N'3', N'测试参数', 0)
GO
SET IDENTITY_INSERT [dbo].[t_sys_config] OFF
GO
SET IDENTITY_INSERT [dbo].[t_sys_menu] ON 
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (9, 0, 2, N'首页', N'home', N'/home', 1, 0, 1, N'layout.base$view.home', N'mdi:monitor-dashboard', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2024-08-01T15:24:01.900' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (10, 0, 1, N'权限管理', N'manage', N'/manage', 1, 0, 5, N'layout.base', N'carbon:cloud-service-management', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2024-09-25T11:04:36.960' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (11, 10, 2, N'用户管理', N'manage_user', N'/manage/user', 1, 0, 1, N'view.manage_user', N'ic:round-manage-accounts', 1, NULL, NULL, NULL, 1, CAST(N'2024-04-25T10:26:00.833' AS DateTime), 0, CAST(N'2024-04-25T10:26:00.833' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (12, 10, 2, N'角色管理', N'manage_role', N'/manage/role', 1, 0, 2, N'view.manage_role', N'carbon:user-role', 1, NULL, NULL, NULL, 1, CAST(N'2024-04-25T10:26:45.897' AS DateTime), 0, CAST(N'2024-04-25T10:26:45.897' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (13, 10, 2, N'菜单管理', N'manage_menu', N'/manage/menu', 1, 0, 3, N'view.manage_menu', N'material-symbols:route', 1, NULL, NULL, NULL, 1, CAST(N'2024-04-25T10:27:20.993' AS DateTime), 0, CAST(N'2024-04-25T10:27:20.993' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (14, 0, 1, N'系统功能', N'function', N'/function', 1, 0, 2, N'layout.base', N'icon-park-outline:all-application', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (15, 14, 2, N'标签页', N'function_tab', N'function_tab', 1, 0, 10, N'view.function_tab', N'ic:round-tab', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (16, 0, 2, N'关于', N'about', N'/about', 1, 0, 9, N'layout.base$view.about', N'fluent:book-information-24-regular', 1, NULL, NULL, NULL, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (17, 14, 2, N'服务监控', N'function_system', N'/function/system', 1, 0, 9, N'view.function_system', N'fluent:send-logging-24-regular', 1, NULL, NULL, NULL, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2024-09-25T11:17:22.180' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (19, 14, 2, N'系统日志', N'function_oplog', N'/function/oplog', 1, 0, 2, N'view.function_oplog', N'mdi:timetable', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2024-09-25T11:17:26.140' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (27, 0, 1, N'插件示例', N'plugin', N'/plugin', 1, 0, 7, N'layout.base', N'clarity:plugin-line', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (28, 27, 2, N'条形码', N'plugin_barcode', N'/plugin/barcode', 1, 0, 0, N'view.plugin_barcode', N'ic:round-barcode', 1, NULL, NULL, NULL, 1, CAST(N'2024-05-11T16:01:12.357' AS DateTime), 0, CAST(N'2024-05-11T16:01:12.357' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (29, 27, 2, N'图表', N'plugin_charts', N'/plugin/charts', 1, 0, 0, N'', N'mdi:chart-areaspline', 1, NULL, NULL, NULL, 1, CAST(N'2024-05-11T16:03:00.033' AS DateTime), 0, CAST(N'2024-05-11T16:03:00.033' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (30, 29, 2, N'ECharts', N'plugin_charts_echarts', N'/plugin/charts/echarts', 1, 0, 0, N'view.plugin_charts_echarts', N'simple-icons:apacheecharts', 1, NULL, NULL, NULL, 1, CAST(N'2024-05-11T16:06:10.410' AS DateTime), 0, CAST(N'2024-05-11T16:06:10.410' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (31, 27, 2, N'剪贴板', N'plugin_copy', N'/plugin/copy', 1, 0, 0, N'view.plugin_copy', N'mdi:clipboard-outline', 1, NULL, NULL, NULL, 1, CAST(N'2024-05-11T16:07:15.243' AS DateTime), 0, CAST(N'2024-05-11T16:07:15.243' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (32, 27, 1, N'编辑器', N'plugin_editor', N'/plugin/editor', 1, 0, 0, N'', N'icon-park-outline:editor', 1, NULL, NULL, NULL, 1, CAST(N'2024-05-11T16:09:51.010' AS DateTime), 0, CAST(N'2024-05-11T16:09:51.010' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (33, 32, 2, N'MD 编辑器', N'plugin_editor_markdown', N'/plugin/editor/markdown', 1, 0, 0, N'view.plugin_editor_markdown', N'ri:markdown-line', 1, NULL, NULL, NULL, 1, CAST(N'2024-05-11T16:10:39.353' AS DateTime), 0, CAST(N'2024-05-11T16:10:39.353' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (34, 32, 2, N'富文本编辑器', N'plugin_editor_quill', N'/plugin/editor/quill', 1, 0, 0, N'view.plugin_editor_quill', N'mdi:file-document-edit-outline', 1, NULL, NULL, NULL, 1, CAST(N'2024-05-11T16:11:24.977' AS DateTime), 0, CAST(N'2024-05-11T16:11:24.977' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (35, 27, 2, N'图标', N'plugin_icon', N'/plugin/icon', 1, 0, 0, N'view.plugin_icon', N'simple-icons:swiper', 1, 1, NULL, NULL, 1, CAST(N'2024-05-11T16:07:15.243' AS DateTime), 0, CAST(N'2024-05-11T16:07:15.243' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (36, 27, 2, N'地图', N'plugin_map', N'/plugin/map', 1, 0, 0, N'view.plugin_map', N'mdi:map', 1, 1, NULL, NULL, 1, CAST(N'2024-05-11T16:07:15.243' AS DateTime), 0, CAST(N'2024-05-11T16:07:15.243' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (37, 27, 2, N'打印', N'plugin_print', N'/plugin/print', 1, 0, 0, N'view.plugin_print', N'mdi:printer', 1, 1, NULL, NULL, 1, CAST(N'2024-05-11T16:07:15.243' AS DateTime), 0, CAST(N'2024-05-11T16:07:15.243' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (38, 27, 2, N'Swiper', N'plugin_swiper', N'/plugin/swiper', 1, 0, 0, N'view.plugin_swiper', N'simple-icons:swiper', 1, 1, NULL, NULL, 1, CAST(N'2024-05-11T16:07:15.243' AS DateTime), 0, CAST(N'2024-05-11T16:07:15.243' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (39, 27, 2, N'视频', N'plugin_video', N'/plugin/video', 1, 0, 0, N'view.plugin_video', N'mdi:video', 1, 1, NULL, NULL, 1, CAST(N'2024-05-11T16:07:15.243' AS DateTime), 0, CAST(N'2024-05-11T16:07:15.243' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (42, 14, 2, N'权限校验', N'function_toggle-auth', N'/function/function_toggle-auth', 1, 0, 0, N'view.function_toggle-auth', N'ic:round-construction', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2024-08-01T15:24:22.163' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (43, 14, 2, N'在线用户', N'function_online-user', N'/function/online-user', 1, 0, 0, N'view.function_online-user', N'material-symbols:nest-wake-on-approach-outline', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2024-09-25T11:17:28.587' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (44, 0, 1, N'其他数据', N'datamanage', N'/datamanage', 1, 0, 5, N'layout.base', N'eos-icons:config-map', 1, NULL, NULL, NULL, 0, CAST(N'2024-09-25T10:37:19.443' AS DateTime), 1, CAST(N'2024-09-25T10:37:19.443' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (45, 44, 2, N'用户', N'datamanage_user', N'/datamanage/user', 1, 0, 1, N'view.datamanage_user', N'fluent-color:people-16', 1, NULL, NULL, NULL, 0, CAST(N'2024-09-25T10:40:17.750' AS DateTime), 1, CAST(N'2024-09-25T10:40:17.750' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (46, 0, 1, N'系统管理', N'sysmanage', N'/sysmanage', 1, 0, 5, N'layout.base', N'material-symbols:auto-awesome-mosaic-sharp', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2024-09-25T11:12:51.453' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (47, 46, 2, N'服务监控', N'sysmanage_systemstatus', N'/sysmanage/systemstatus', 1, 0, 0, N'view.sysmanage_systemstatus', N'fluent:send-logging-24-regular', 1, NULL, NULL, NULL, 1, CAST(N'2024-09-25T11:09:22.990' AS DateTime), 0, CAST(N'2024-09-25T11:09:22.990' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (48, 46, 2, N'系统日志', N'sysmanage_oplog', N'/sysmanage/oplog', 1, 0, 0, N'view.sysmanage_oplog', N'mdi:timetable', 1, NULL, NULL, NULL, 1, CAST(N'2024-09-25T11:15:53.840' AS DateTime), 1, CAST(N'2024-09-26T15:08:39.807' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (49, 46, 2, N'在线用户', N'sysmanage_online-user', N'/sysmanage/online-user', 1, 0, 0, N'view.sysmanage_online-user', N'material-symbols:nest-wake-on-approach-outline', 1, NULL, NULL, NULL, 1, CAST(N'2024-09-25T11:16:46.123' AS DateTime), 0, CAST(N'2024-09-25T11:16:46.123' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (50, 46, 2, N'字典管理', N'sysmanage_dic', N'/sysmanage/dic', 1, 0, 0, N'view.sysmanage_dic', N'material-symbols:dictionary-sharp', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2024-09-25T13:09:25.297' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (51, 46, 2, N'令牌管理', N'sysmanage_token', N'/sysmanage/token', 1, 0, 0, N'view.sysmanage_token', N'material-symbols:contextual-token-outline', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2024-09-26T14:34:24.463' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (52, 46, 2, N'缓存管理', N'sysmanage_cache', N'/sysmanage/cache', 1, 0, 0, N'view.sysmanage_cache', N'material-symbols:cached-rounded', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2024-09-25T13:38:47.697' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (53, 46, 2, N'参数配置', N'sysmanage_config', N'/sysmanage/config', 1, 0, 0, N'view.sysmanage_config', N'hugeicons:configuration-01', 1, NULL, NULL, NULL, 1, CAST(N'2024-09-26T14:54:27.103' AS DateTime), 0, CAST(N'2024-09-26T14:54:27.103' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (54, 0, 1, N'日志管理', N'syslog', N'/syslog', 1, 0, 5, N'layout.base', N'material-symbols:receipt-long', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2024-09-26T14:59:04.570' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (55, 54, 2, N'操作日志', N'syslog_logop', N'/syslog/logop', 1, 0, 0, N'view.syslog_logop', N'material-symbols:receipt-long', 1, NULL, NULL, NULL, 1, CAST(N'2024-09-26T15:02:14.157' AS DateTime), 0, CAST(N'2024-09-26T15:02:14.157' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (56, 54, 2, N'访问日志', N'syslog_logvis', N'/syslog/logvis', 1, 0, 0, N'view.syslog_logvis', N'material-symbols:receipt-long', 1, NULL, NULL, NULL, 1, CAST(N'2024-09-26T15:03:20.773' AS DateTime), 0, CAST(N'2024-09-26T15:03:20.773' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (57, 54, 2, N'异常日志', N'syslog_logerr', N'/syslog/logerr', 1, 0, 0, N'view.syslog_logerr', N'material-symbols:receipt-long', 1, NULL, NULL, NULL, 1, CAST(N'2024-09-26T15:04:38.383' AS DateTime), 0, CAST(N'2024-09-26T15:04:38.383' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (58, 46, 2, N'个人中心', N'sysmanage_usercenter', N'/sysmanage/usercenter', 1, 1, 0, N'view.sysmanage_usercenter', N'ph:user-circle', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2024-10-09T16:06:45.313' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (59, 0, 1, N'图库管理', N'gallery', N'/gallery', 1, 0, 4, N'layout.base', N'solar:gallery-wide-bold', 1, 1, NULL, NULL, 0, CAST(N'2024-10-11T09:10:26.450' AS DateTime), 1, CAST(N'2024-10-11T09:10:26.450' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (60, 59, 2, N'必应壁纸', N'gallery_bing', N'/gallery/bing', 1, 0, 0, N'view.gallery_bing', N'solar:gallery-round-line-duotone', 1, 1, NULL, NULL, 1, CAST(N'2024-10-11T09:12:54.703' AS DateTime), 0, CAST(N'2024-10-11T09:12:54.703' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (61, 59, 2, N'上传壁纸', N'gallery_upload', N'/gallery/upload', 1, 0, 0, N'view.gallery_upload', N'solar:gallery-send-bold', 1, 1, NULL, NULL, 1, CAST(N'2024-10-11T09:13:54.837' AS DateTime), 0, CAST(N'2024-10-11T09:13:54.837' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (62, 59, 2, N'壁纸列表', N'gallery_list', N'/gallery/list', 1, 0, 0, N'view.gallery_list', N'material-symbols:gallery-thumbnail', 1, 1, NULL, NULL, 1, CAST(N'2024-10-11T09:16:28.947' AS DateTime), 0, CAST(N'2024-10-11T09:16:28.947' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (63, 59, 2, N'壁纸分类', N'gallery_category', N'/gallery/category', 1, 0, 0, N'view.gallery_category', N'clarity:image-gallery-line', 1, 1, NULL, NULL, 1, CAST(N'2024-10-11T09:30:19.100' AS DateTime), 0, CAST(N'2024-10-11T09:30:19.100' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (64, 59, 2, N'图库瀑布', N'gallery_waterfall', N'/gallery/waterfall', 1, 0, 0, N'view.gallery_waterfall', N'lineicons:gallery', 1, 1, NULL, NULL, 0, CAST(N'2024-10-12T15:40:38.050' AS DateTime), 1, CAST(N'2024-10-12T15:40:38.050' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (65, 27, 2, N'Excel', N'plugin_excel', N'/plugin/excel', 1, 0, 0, N'view.plugin_excel', N'ri:file-excel-2-line', 1, 1, NULL, NULL, 1, CAST(N'2024-10-14T13:19:06.240' AS DateTime), 0, CAST(N'2024-10-14T13:19:06.240' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (66, 27, 2, N'PDF 预览', N'plugin_pdf', N'/plugin/pdf', 1, 0, 25, N'view.plugin_pdf', N'uiw:file-pdf', 1, 1, NULL, NULL, 0, CAST(N'2024-10-14T13:19:39.803' AS DateTime), 1, CAST(N'2024-10-14T13:19:39.803' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (67, 27, 2, N'打字机', N'plugin_typeit', N'/plugin/typeit', 1, 0, 26, N'view.plugin_typeit', N'mdi:typewriter', 1, 1, NULL, NULL, 0, CAST(N'2024-10-14T13:20:18.307' AS DateTime), 1, CAST(N'2024-10-14T13:20:18.307' AS DateTime), 0, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[t_sys_menu] OFF
GO
SET IDENTITY_INSERT [dbo].[t_sys_onlineuser] ON 
GO
INSERT [dbo].[t_sys_onlineuser] ([Id], [ConnectionId], [UserId], [UserName], [RealName], [Time], [Ip], [Browser], [Os]) VALUES (1329, N'd_8nn5ks9gtV6FyNlF7HlQ', 1, N'admin', N'Malus', CAST(N'2024-10-10T09:56:36.707' AS DateTime), N'0.0.0.1', N'Chrome129', N'Windows10')
GO
INSERT [dbo].[t_sys_onlineuser] ([Id], [ConnectionId], [UserId], [UserName], [RealName], [Time], [Ip], [Browser], [Os]) VALUES (1334, N'TS1FL-iZbUXJa-OUYkXsNA', 1, N'admin', N'Malus', CAST(N'2024-10-10T09:58:41.020' AS DateTime), N'0.0.0.1', N'Chrome129', N'Windows10')
GO
INSERT [dbo].[t_sys_onlineuser] ([Id], [ConnectionId], [UserId], [UserName], [RealName], [Time], [Ip], [Browser], [Os]) VALUES (1335, N'Ssvy_IIvR_lOHjXFnjjRjQ', 1, N'admin', N'Malus', CAST(N'2024-10-10T10:14:25.580' AS DateTime), N'127.0.0.1', N'Chrome129', N'Windows10')
GO
INSERT [dbo].[t_sys_onlineuser] ([Id], [ConnectionId], [UserId], [UserName], [RealName], [Time], [Ip], [Browser], [Os]) VALUES (1341, N'cwPJlcLkZoxpeb5HBkx7FQ', 1, N'admin', N'Malus', CAST(N'2024-10-10T10:21:30.800' AS DateTime), N'0.0.0.1', N'Edge129', N'Windows10')
GO
INSERT [dbo].[t_sys_onlineuser] ([Id], [ConnectionId], [UserId], [UserName], [RealName], [Time], [Ip], [Browser], [Os]) VALUES (1396, N'mHI55tQap9SfxbzjedD57g', 1, N'admin', N'Malus', CAST(N'2024-10-11T13:24:14.727' AS DateTime), N'0.0.0.1', N'Edge129', N'Windows10')
GO
INSERT [dbo].[t_sys_onlineuser] ([Id], [ConnectionId], [UserId], [UserName], [RealName], [Time], [Ip], [Browser], [Os]) VALUES (1413, N'W4GywOe8tOeumSeJeOlewQ', 1, N'admin', N'Malus', CAST(N'2024-10-11T14:02:21.917' AS DateTime), N'0.0.0.1', N'Edge129', N'Windows10')
GO
INSERT [dbo].[t_sys_onlineuser] ([Id], [ConnectionId], [UserId], [UserName], [RealName], [Time], [Ip], [Browser], [Os]) VALUES (1533, N'YwM6e1ySD7ody86VBEJ0wg', 1, N'admin', N'Malus', CAST(N'2024-10-14T10:22:42.110' AS DateTime), N'127.0.0.1', N'Chrome129', N'Windows10')
GO
INSERT [dbo].[t_sys_onlineuser] ([Id], [ConnectionId], [UserId], [UserName], [RealName], [Time], [Ip], [Browser], [Os]) VALUES (1553, N'e6ghCxbyzb6JEl6bSlPWOg', 1, N'admin', N'Malus', CAST(N'2024-10-14T13:49:08.473' AS DateTime), N'0.0.0.1', N'Chrome129', N'Windows10')
GO
INSERT [dbo].[t_sys_onlineuser] ([Id], [ConnectionId], [UserId], [UserName], [RealName], [Time], [Ip], [Browser], [Os]) VALUES (1554, N'bnmdFoME7B8HlvgH5MAnfg', 1, N'admin', N'Malus', CAST(N'2024-10-14T16:23:58.650' AS DateTime), N'0.0.0.1', N'Chrome129', N'Windows10')
GO
SET IDENTITY_INSERT [dbo].[t_sys_onlineuser] OFF
GO
SET IDENTITY_INSERT [dbo].[t_sys_role] ON 
GO
INSERT [dbo].[t_sys_role] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [Name], [Desc], [Status], [DataRang], [Permission]) VALUES (1, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, N'超级管理员', N'超级管理员', 1, N'全部', N'')
GO
INSERT [dbo].[t_sys_role] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [Name], [Desc], [Status], [DataRang], [Permission]) VALUES (15, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, N'测试角色', N'测试角色【忽动】', 1, NULL, NULL)
GO
INSERT [dbo].[t_sys_role] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [Name], [Desc], [Status], [DataRang], [Permission]) VALUES (16, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, N'销售', N'4567890', 1, NULL, NULL)
GO
INSERT [dbo].[t_sys_role] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [Name], [Desc], [Status], [DataRang], [Permission]) VALUES (17, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 2, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, N'测试', N'测试角色', 1, NULL, NULL)
GO
INSERT [dbo].[t_sys_role] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [Name], [Desc], [Status], [DataRang], [Permission]) VALUES (48, 1, CAST(N'2024-09-25T11:44:07.017' AS DateTime), 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, N'去去去', N'企鹅额问问', 1, NULL, NULL)
GO
INSERT [dbo].[t_sys_role] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [Name], [Desc], [Status], [DataRang], [Permission]) VALUES (49, 1, CAST(N'2024-09-25T19:13:15.400' AS DateTime), 0, NULL, 0, NULL, 0, N'信息管理员', N'信息管理员，用于基础信息管理', 1, NULL, NULL)
GO
INSERT [dbo].[t_sys_role] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [Name], [Desc], [Status], [DataRang], [Permission]) VALUES (50, 2, CAST(N'2024-10-05T21:50:55.947' AS DateTime), 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, N'777', N'66666', 1, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[t_sys_role] OFF
GO
SET IDENTITY_INSERT [dbo].[t_sys_role_menu] ON 
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (110, 0, CAST(N'2024-04-30T14:57:56.043' AS DateTime), 0, NULL, 0, NULL, 0, 3, 9)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (111, 0, CAST(N'2024-04-30T14:57:56.043' AS DateTime), 0, NULL, 0, NULL, 0, 3, 14)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (112, 0, CAST(N'2024-04-30T14:57:56.043' AS DateTime), 0, NULL, 0, NULL, 0, 3, 15)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (113, 0, CAST(N'2024-04-30T14:57:56.043' AS DateTime), 0, NULL, 0, NULL, 0, 3, 10)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (114, 0, CAST(N'2024-04-30T14:57:56.043' AS DateTime), 0, NULL, 0, NULL, 0, 3, 11)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (115, 0, CAST(N'2024-04-30T14:57:56.043' AS DateTime), 0, NULL, 0, NULL, 0, 3, 12)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (116, 0, CAST(N'2024-04-30T14:57:56.043' AS DateTime), 0, NULL, 0, NULL, 0, 3, 13)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (117, 0, CAST(N'2024-04-30T14:57:56.043' AS DateTime), 0, NULL, 0, NULL, 0, 3, 16)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (118, 0, CAST(N'2024-04-30T14:57:56.043' AS DateTime), 0, NULL, 0, NULL, 0, 3, 17)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1065, 1, CAST(N'2024-05-13T09:58:23.837' AS DateTime), 0, NULL, 0, NULL, 0, 9, 27)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1066, 1, CAST(N'2024-05-13T09:58:23.837' AS DateTime), 0, NULL, 0, NULL, 0, 9, 28)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1067, 1, CAST(N'2024-05-13T09:58:23.837' AS DateTime), 0, NULL, 0, NULL, 0, 9, 29)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1068, 1, CAST(N'2024-05-13T09:58:23.837' AS DateTime), 0, NULL, 0, NULL, 0, 9, 30)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1069, 1, CAST(N'2024-05-13T09:58:23.837' AS DateTime), 0, NULL, 0, NULL, 0, 9, 31)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1070, 1, CAST(N'2024-05-13T09:58:23.837' AS DateTime), 0, NULL, 0, NULL, 0, 9, 32)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1071, 1, CAST(N'2024-05-13T09:58:23.837' AS DateTime), 0, NULL, 0, NULL, 0, 9, 33)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1072, 1, CAST(N'2024-05-13T09:58:23.837' AS DateTime), 0, NULL, 0, NULL, 0, 9, 34)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1073, 1, CAST(N'2024-05-13T09:58:23.837' AS DateTime), 0, NULL, 0, NULL, 0, 9, 35)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1074, 1, CAST(N'2024-05-13T09:58:23.837' AS DateTime), 0, NULL, 0, NULL, 0, 9, 36)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1075, 1, CAST(N'2024-05-13T09:58:23.837' AS DateTime), 0, NULL, 0, NULL, 0, 9, 37)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1076, 1, CAST(N'2024-05-13T09:58:23.837' AS DateTime), 0, NULL, 0, NULL, 0, 9, 38)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1077, 1, CAST(N'2024-05-13T09:58:23.837' AS DateTime), 0, NULL, 0, NULL, 0, 9, 39)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1078, 1, CAST(N'2024-05-13T09:58:23.837' AS DateTime), 0, NULL, 0, NULL, 0, 9, 16)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1082, 1, CAST(N'2024-05-14T13:55:58.397' AS DateTime), 0, NULL, 0, NULL, 0, 12, 9)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1083, 1, CAST(N'2024-05-14T13:55:58.397' AS DateTime), 0, NULL, 0, NULL, 0, 12, 11)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1084, 1, CAST(N'2024-05-14T13:55:58.397' AS DateTime), 0, NULL, 0, NULL, 0, 12, 16)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1085, 1, CAST(N'2024-05-14T13:55:58.397' AS DateTime), 0, NULL, 0, NULL, 0, 12, 14)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1086, 1, CAST(N'2024-05-14T13:55:58.397' AS DateTime), 0, NULL, 0, NULL, 0, 12, 17)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1087, 1, CAST(N'2024-05-14T13:55:58.397' AS DateTime), 0, NULL, 0, NULL, 0, 12, 10)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1114, 1, CAST(N'2024-05-28T11:07:45.803' AS DateTime), 0, NULL, 0, NULL, 0, 15, 16)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1115, 1, CAST(N'2024-05-28T11:07:45.803' AS DateTime), 0, NULL, 0, NULL, 0, 15, 27)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1116, 1, CAST(N'2024-05-28T11:07:45.803' AS DateTime), 0, NULL, 0, NULL, 0, 15, 28)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1117, 1, CAST(N'2024-05-28T11:07:45.803' AS DateTime), 0, NULL, 0, NULL, 0, 15, 29)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1118, 1, CAST(N'2024-05-28T11:07:45.803' AS DateTime), 0, NULL, 0, NULL, 0, 15, 30)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1119, 1, CAST(N'2024-05-28T11:07:45.803' AS DateTime), 0, NULL, 0, NULL, 0, 15, 31)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1120, 1, CAST(N'2024-05-28T11:07:45.803' AS DateTime), 0, NULL, 0, NULL, 0, 15, 32)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1121, 1, CAST(N'2024-05-28T11:07:45.803' AS DateTime), 0, NULL, 0, NULL, 0, 15, 33)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1122, 1, CAST(N'2024-05-28T11:07:45.803' AS DateTime), 0, NULL, 0, NULL, 0, 15, 34)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1123, 1, CAST(N'2024-05-28T11:07:45.803' AS DateTime), 0, NULL, 0, NULL, 0, 15, 35)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1124, 1, CAST(N'2024-05-28T11:07:45.803' AS DateTime), 0, NULL, 0, NULL, 0, 15, 36)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1125, 1, CAST(N'2024-05-28T11:07:45.803' AS DateTime), 0, NULL, 0, NULL, 0, 15, 37)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1126, 1, CAST(N'2024-05-28T11:07:45.803' AS DateTime), 0, NULL, 0, NULL, 0, 15, 38)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1127, 1, CAST(N'2024-05-28T11:07:45.803' AS DateTime), 0, NULL, 0, NULL, 0, 15, 39)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1128, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 9)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1129, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 14)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1130, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 15)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1131, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 17)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1132, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 19)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1133, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 42)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1134, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 43)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1135, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 10)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1136, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 11)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1137, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 12)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1138, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 13)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1139, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 27)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1140, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 28)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1141, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 29)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1142, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 30)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1143, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 31)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1144, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 32)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1145, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 33)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1146, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 34)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1147, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 35)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1148, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 36)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1149, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 37)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1150, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 38)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1151, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 39)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1152, 1, CAST(N'2024-08-02T13:58:51.170' AS DateTime), 0, NULL, 0, NULL, 0, 1, 16)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1155, 1, CAST(N'2024-09-26T10:50:05.403' AS DateTime), 0, NULL, 0, NULL, 0, 49, 16)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1156, 1, CAST(N'2024-09-26T10:50:05.403' AS DateTime), 0, NULL, 0, NULL, 0, 49, 27)
GO
SET IDENTITY_INSERT [dbo].[t_sys_role_menu] OFF
GO
SET IDENTITY_INSERT [dbo].[t_sys_role_permiss] ON 
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (4, 0, CAST(N'2024-04-19T10:16:08.510' AS DateTime), 0, NULL, 0, NULL, 0, 2, N'api:SysMenu:Add')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (5, 0, CAST(N'2024-04-19T10:16:08.510' AS DateTime), 0, NULL, 0, NULL, 0, 2, N'api:SysMenu:MenuTreeList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (12, 0, CAST(N'2024-04-23T10:59:18.837' AS DateTime), 0, NULL, 0, NULL, 0, 5, N'api:SysMenu:MenuTreeList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (13, 0, CAST(N'2024-04-23T10:59:18.837' AS DateTime), 0, NULL, 0, NULL, 0, 5, N'api:SysMenu:Add')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (14, 0, CAST(N'2024-04-23T10:59:18.837' AS DateTime), 0, NULL, 0, NULL, 0, 5, N'api:SysMenu:Update')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (15, 0, CAST(N'2024-04-23T10:59:18.837' AS DateTime), 0, NULL, 0, NULL, 0, 5, N'api:SysMenu:Delete')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (16, 0, CAST(N'2024-04-23T10:59:18.837' AS DateTime), 0, NULL, 0, NULL, 0, 5, N'api:SysRole:PageList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (17, 0, CAST(N'2024-04-23T10:59:18.837' AS DateTime), 0, NULL, 0, NULL, 0, 5, N'api:SysRole:Add')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (18, 0, CAST(N'2024-04-23T10:59:18.837' AS DateTime), 0, NULL, 0, NULL, 0, 5, N'api:SysRole:Delete')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (19, 0, CAST(N'2024-04-23T10:59:18.837' AS DateTime), 0, NULL, 0, NULL, 0, 5, N'api:SysRole:Update')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (22, 0, CAST(N'2024-04-23T13:50:47.410' AS DateTime), 0, NULL, 0, NULL, 0, 4, N'api:SysUser:Update')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (23, 0, CAST(N'2024-04-23T13:50:47.410' AS DateTime), 0, NULL, 0, NULL, 0, 4, N'api:SysUser:Delete')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (24, 0, CAST(N'2024-04-23T13:50:47.410' AS DateTime), 0, NULL, 0, NULL, 0, 4, N'api:SysUser:Add')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (25, 0, CAST(N'2024-04-23T13:50:47.410' AS DateTime), 0, NULL, 0, NULL, 0, 4, N'api:SysUser:PageList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (26, 0, CAST(N'2024-04-23T13:50:47.410' AS DateTime), 0, NULL, 0, NULL, 0, 4, N'api:SysRolePermission:AddUserButtonPermiss')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (27, 0, CAST(N'2024-04-23T13:50:47.410' AS DateTime), 0, NULL, 0, NULL, 0, 4, N'api:SysRolePermission:GetRoleButen')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (28, 0, CAST(N'2024-04-23T13:50:47.410' AS DateTime), 0, NULL, 0, NULL, 0, 4, N'api:SysRole:Update')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (29, 0, CAST(N'2024-04-23T13:50:47.410' AS DateTime), 0, NULL, 0, NULL, 0, 4, N'api:SysRole:Delete')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (30, 0, CAST(N'2024-04-23T13:50:47.410' AS DateTime), 0, NULL, 0, NULL, 0, 4, N'api:SysRole:Add')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (31, 0, CAST(N'2024-04-23T13:50:47.410' AS DateTime), 0, NULL, 0, NULL, 0, 4, N'api:SysRole:PageList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (32, 0, CAST(N'2024-04-23T13:50:47.410' AS DateTime), 0, NULL, 0, NULL, 0, 4, N'api:SysMenu:Delete')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (33, 0, CAST(N'2024-04-23T13:50:47.410' AS DateTime), 0, NULL, 0, NULL, 0, 4, N'api:SysMenu:Update')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (34, 0, CAST(N'2024-04-23T13:50:47.410' AS DateTime), 0, NULL, 0, NULL, 0, 4, N'api:SysMenu:Add')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1051, 1, CAST(N'2024-05-15T09:41:16.100' AS DateTime), 0, NULL, 0, NULL, 0, 12, N'api:SysUser:PageList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1068, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysMenu:MenuTreeList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1069, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysMenu:Add')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1070, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysMenu:Update')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1071, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysMenu:Delete')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1072, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysRole:PageList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1073, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysRole:Add')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1074, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysRole:Delete')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1075, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysRole:Update')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1076, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysRoleMenu:Get')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1077, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysRoleMenu:Set')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1078, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysRolePermission:GetRoleButen')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1079, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysRolePermission:AddUserButtonPermiss')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1080, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysUser:PageList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1081, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysUser:Add')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1082, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysUser:Delete')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1083, 1, CAST(N'2024-05-23T16:39:00.130' AS DateTime), 0, NULL, 0, NULL, 0, 9, N'api:SysUser:Update')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1084, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysMenu:MenuTreeList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1085, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysMenu:Add')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1086, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysMenu:Update')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1087, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysMenu:Delete')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1088, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysOnlineUser:PageList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1089, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysOnlineUser:ForceOffline')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1090, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysOnlineUser:SendMsgToOne')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1091, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRole:PageList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1092, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRole:Add')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1093, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRole:Delete')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1094, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRole:Update')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1095, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRoleMenu:Get')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1096, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRoleMenu:Set')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1097, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRolePermission:GetRoleButen')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1098, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRolePermission:AddUserButtonPermiss')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1099, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysUser:PageList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1100, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysUser:Add')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1101, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysUser:Delete')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1102, 1, CAST(N'2024-08-01T16:33:42.893' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysUser:Update')
GO
SET IDENTITY_INSERT [dbo].[t_sys_role_permiss] OFF
GO
SET IDENTITY_INSERT [dbo].[t_sys_user] ON 
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (1, N'admin', N'Malus', N'3FDE6BB0541387E4EBDADF7C2FF31123', N'[1]', 1, NULL, N'18888888889', N'188888888@163.com', NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2024-10-08T10:22:12.313' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, 1, 1)
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (2, N'pridejoy', N'管理员', N'E10ADC3949BA59ABBE56E057F20F883E', N'[15,1,17,16]', 1, NULL, N'18888888888', N'18888888888@163.com', NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, 2, 0)
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (46, N'121我', N'21213', N'8A373F4ECBC59038E3CFA8AA8E31FF65', N'[15]', 1, NULL, N'211212323', N'12饿1321', NULL, 1, CAST(N'2024-09-25T09:28:30.970' AS DateTime), 1, CAST(N'2024-10-08T10:22:59.117' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, NULL, 0)
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (47, N'测试测试测试测试测试测试测试测试', N'测试', N'E10ADC3949BA59ABBE56E057F20F883E', N'[1]', 1, NULL, N'12345678910', N'123@qq.com', NULL, 2, CAST(N'2024-09-29T17:17:03.553' AS DateTime), 1, CAST(N'2024-10-08T10:22:57.797' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, NULL, 0)
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (48, N'ZZC', N'ZZZ', N'E10ADC3949BA59ABBE56E057F20F883E', N'[15]', 1, NULL, N'ZZZ', N'ZZZ', NULL, 2, CAST(N'2024-10-16T22:45:31.620' AS DateTime), 0, CAST(N'2024-10-16T22:45:31.620' AS DateTime), 0, NULL, 0, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[t_sys_user] OFF
GO
/****** Object:  Index [IX_bs_bingwallpaper_startdate]    Script Date: 2024/11/7 13:27:06 ******/
ALTER TABLE [dbo].[bs_bingwallpaper] ADD  CONSTRAINT [IX_bs_bingwallpaper_startdate] UNIQUE NONCLUSTERED 
(
	[StartDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[t_sys_config] ADD  CONSTRAINT [DF_bs_webconfig_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[t_sys_menu] ADD  CONSTRAINT [DF__t_sys_men__IsHid__52593CB8]  DEFAULT ((0)) FOR [HideInMenu]
GO
ALTER TABLE [dbo].[t_sys_menu] ADD  CONSTRAINT [DF__t_sys_menu__Sort__5812160E]  DEFAULT ((0)) FOR [Sort]
GO
ALTER TABLE [dbo].[t_sys_menu] ADD  CONSTRAINT [DF__t_sys_men__IsIfr__5441852A]  DEFAULT ((0)) FOR [Icon]
GO
ALTER TABLE [dbo].[t_sys_menu] ADD  CONSTRAINT [DF__t_sys_men__IsAff__5535A963]  DEFAULT ((0)) FOR [IconType]
GO
ALTER TABLE [dbo].[t_sys_menu] ADD  CONSTRAINT [DF__t_sys_men__IsKee__534D60F1]  DEFAULT ((1)) FOR [KeepAlive]
GO
ALTER TABLE [dbo].[t_sys_menu] ADD  CONSTRAINT [DF_menu_SysCreateTime]  DEFAULT (getdate()) FOR [SysCreateTime]
GO
ALTER TABLE [dbo].[t_sys_menu] ADD  CONSTRAINT [DF_menu_SysUpdateTime]  DEFAULT (getdate()) FOR [SysUpdateTime]
GO
ALTER TABLE [dbo].[t_sys_menu] ADD  CONSTRAINT [DF__t_sys_men__SysIs__5165187F]  DEFAULT ((0)) FOR [SysIsDelete]
GO
ALTER TABLE [dbo].[t_sys_role] ADD  CONSTRAINT [DF__t_sys_rol__SysCr__778AC167]  DEFAULT (getdate()) FOR [SysCreateTime]
GO
ALTER TABLE [dbo].[t_sys_role] ADD  CONSTRAINT [DF__t_sys_rol__SysIs__787EE5A0]  DEFAULT ((0)) FOR [SysIsDelete]
GO
ALTER TABLE [dbo].[t_sys_role] ADD  CONSTRAINT [DF__t_sys_rol__Statu__797309D9]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[t_sys_role_menu] ADD  CONSTRAINT [DF_t_sys_role_menu_SysCreateTime]  DEFAULT (getdate()) FOR [SysCreateTime]
GO
ALTER TABLE [dbo].[t_sys_role_menu] ADD  CONSTRAINT [DF_t_sys_role_menu_SysIsDelete]  DEFAULT ((0)) FOR [SysIsDelete]
GO
ALTER TABLE [dbo].[t_sys_role_permiss] ADD  CONSTRAINT [DF_bs_sys_user_button_permiss_SysCreateTime]  DEFAULT (getdate()) FOR [SysCreateTime]
GO
ALTER TABLE [dbo].[t_sys_role_permiss] ADD  CONSTRAINT [DF_bs_sys_user_button_permiss_SysIsDelete]  DEFAULT ((0)) FOR [SysIsDelete]
GO
ALTER TABLE [dbo].[t_sys_user] ADD  CONSTRAINT [DF__t_sys_use__Statu__6477ECF3]  DEFAULT ('10') FOR [Status]
GO
ALTER TABLE [dbo].[t_sys_user] ADD  CONSTRAINT [DF__t_sys_use__SysCr__619B8048]  DEFAULT (getdate()) FOR [SysCreateTime]
GO
ALTER TABLE [dbo].[t_sys_user] ADD  CONSTRAINT [DF__t_sys_use__SysUp__628FA481]  DEFAULT (getdate()) FOR [SysUpdateTime]
GO
ALTER TABLE [dbo].[t_sys_user] ADD  CONSTRAINT [DF__t_sys_use__SysIs__6383C8BA]  DEFAULT ((0)) FOR [SysIsDelete]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'bs_bingwallpaper', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原本链接' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'bs_bingwallpaper', @level2type=N'COLUMN',@level2name=N'MobileUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原本链接' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'bs_bingwallpaper', @level2type=N'COLUMN',@level2name=N'Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'bs_bingwallpaper', @level2type=N'COLUMN',@level2name=N'CreatedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'bs_bingwallpaper', @level2type=N'COLUMN',@level2name=N'UpdatedTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'bs_bingwallpaper', @level2type=N'COLUMN',@level2name=N'CreatedUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'bs_bingwallpaper', @level2type=N'COLUMN',@level2name=N'CreatedUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改者Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'bs_bingwallpaper', @level2type=N'COLUMN',@level2name=N'UpdatedUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改者名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'bs_bingwallpaper', @level2type=N'COLUMN',@level2name=N'UpdatedUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'软删除标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'bs_bingwallpaper', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_log_op_20241101', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配置类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_config', @level2type=N'COLUMN',@level2name=N'ConfigType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级菜单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_menu', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单类型1 .目录 2.菜单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_menu', @level2type=N'COLUMN',@level2name=N'MenuType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_menu', @level2type=N'COLUMN',@level2name=N'MenuName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路由名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_menu', @level2type=N'COLUMN',@level2name=N'RouteName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路由路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_menu', @level2type=N'COLUMN',@level2name=N'RoutePath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_menu', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'隐藏菜单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_menu', @level2type=N'COLUMN',@level2name=N'HideInMenu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_menu', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页面组件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_menu', @level2type=N'COLUMN',@level2name=N'Component'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_menu', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_menu', @level2type=N'COLUMN',@level2name=N'IconType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'连接Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_onlineuser', @level2type=N'COLUMN',@level2name=N'ConnectionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_onlineuser', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_onlineuser', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_onlineuser', @level2type=N'COLUMN',@level2name=N'RealName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'连接时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_onlineuser', @level2type=N'COLUMN',@level2name=N'Time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'连接IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_onlineuser', @level2type=N'COLUMN',@level2name=N'Ip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_onlineuser', @level2type=N'COLUMN',@level2name=N'Browser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作系统' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_onlineuser', @level2type=N'COLUMN',@level2name=N'Os'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_role_menu', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_role_permiss', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户访问接口的权限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_sys_role_permiss', @level2type=N'COLUMN',@level2name=N'UserPermiss'
GO
