USE [MalusAdmin]
GO
/****** Object:  Table [dbo].[t_sys_dept]    Script Date: 2024/6/11 10:30:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_sys_dept](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Status] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_sys_dict_data]    Script Date: 2024/6/11 10:30:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_sys_dict_data](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Value1] [nvarchar](200) NULL,
	[Value2] [nvarchar](200) NULL,
	[Value3] [nvarchar](200) NULL,
	[Status] [tinyint] NULL,
	[Sort] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_sys_dict_type]    Script Date: 2024/6/11 10:30:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_sys_dict_type](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Status] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_sys_menu]    Script Date: 2024/6/11 10:30:50 ******/
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
/****** Object:  Table [dbo].[t_sys_onlineuser]    Script Date: 2024/6/11 10:30:50 ******/
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
/****** Object:  Table [dbo].[t_sys_role]    Script Date: 2024/6/11 10:30:50 ******/
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
/****** Object:  Table [dbo].[t_sys_role_menu]    Script Date: 2024/6/11 10:30:50 ******/
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
/****** Object:  Table [dbo].[t_sys_role_permiss]    Script Date: 2024/6/11 10:30:50 ******/
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
/****** Object:  Table [dbo].[t_sys_user]    Script Date: 2024/6/11 10:30:50 ******/
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
SET IDENTITY_INSERT [dbo].[t_sys_menu] ON 
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (9, 0, 2, N'首页', N'home', N'/home', 1, 0, 1, N'layout.base$view.home', N'mdi:monitor-dashboard', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (10, 0, 1, N'系统管理', N'manage', N'/manage', 1, 0, 5, N'layout.base', N'carbon:cloud-service-management', 1, NULL, NULL, NULL, 1, CAST(N'2024-04-25T10:25:19.950' AS DateTime), 0, CAST(N'2024-04-25T10:25:19.950' AS DateTime), 0, NULL, 0)
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
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (17, 14, 2, N'服务监控', N'function_system', N'/function/system', 1, 0, 9, N'view.function_system', N'fluent:send-logging-24-regular', 1, NULL, NULL, NULL, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (19, 14, 2, N'系统日志', N'function_oplog', N'/function/oplog', 1, 0, 2, N'view.function_oplog', N'mdi:timetable', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
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
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (42, 14, 2, N'权限校验', N'function_toggle-auth', N'/function/function_toggle-auth', 1, 0, 0, N'view.function_toggle-auth', N'ic:round-construction', 1, NULL, NULL, NULL, 1, CAST(N'2024-05-23T14:50:11.820' AS DateTime), 0, CAST(N'2024-05-23T14:50:11.820' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_menu] ([Id], [ParentId], [MenuType], [MenuName], [RouteName], [RoutePath], [Status], [HideInMenu], [Sort], [Component], [Icon], [IconType], [KeepAlive], [Redirect], [Href], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete]) VALUES (43, 14, 2, N'在线用户', N'function_online-user', N'/function/online-user', 1, 0, 0, N'view.function_online-user', N'material-symbols:nest-wake-on-approach-outline', 1, NULL, NULL, NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[t_sys_menu] OFF
GO
SET IDENTITY_INSERT [dbo].[t_sys_role] ON 
GO
INSERT [dbo].[t_sys_role] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [Name], [Desc], [Status], [DataRang], [Permission]) VALUES (1, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, N'管理员', N'管理员', 1, N'全部', N'')
GO
INSERT [dbo].[t_sys_role] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [Name], [Desc], [Status], [DataRang], [Permission]) VALUES (15, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, N'测试角色', N'测试角色【忽动】', 1, NULL, NULL)
GO
INSERT [dbo].[t_sys_role] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [Name], [Desc], [Status], [DataRang], [Permission]) VALUES (16, 1, CAST(N'2024-06-01T22:00:58.770' AS DateTime), 0, NULL, 0, NULL, 0, N'销售', N'', 1, NULL, NULL)
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
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1090, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 9)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1091, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 14)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1092, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 15)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1093, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 10)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1094, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 11)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1095, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 12)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1096, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 13)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1097, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 16)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1098, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 17)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1099, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 19)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1100, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 42)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1101, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 27)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1102, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 28)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1103, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 29)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1104, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 30)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1105, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 31)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1106, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 32)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1107, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 33)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1108, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 34)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1109, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 35)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1110, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 36)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1111, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 37)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1112, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 38)
GO
INSERT [dbo].[t_sys_role_menu] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [MenuId]) VALUES (1113, 1, CAST(N'2024-05-28T11:04:01.820' AS DateTime), 0, NULL, 0, NULL, 0, 1, 39)
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
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1052, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysMenu:MenuTreeList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1053, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysMenu:Add')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1054, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysMenu:Update')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1055, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysMenu:Delete')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1056, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRole:PageList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1057, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRole:Add')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1058, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRole:Delete')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1059, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRole:Update')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1060, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRoleMenu:Get')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1061, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRoleMenu:Set')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1062, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRolePermission:GetRoleButen')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1063, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysRolePermission:AddUserButtonPermiss')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1064, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysUser:PageList')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1065, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysUser:Add')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1066, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysUser:Delete')
GO
INSERT [dbo].[t_sys_role_permiss] ([Id], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [RoleId], [UserPermiss]) VALUES (1067, 1, CAST(N'2024-05-23T16:38:51.153' AS DateTime), 0, NULL, 0, NULL, 0, 1, N'api:SysUser:Update')
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
SET IDENTITY_INSERT [dbo].[t_sys_role_permiss] OFF
GO
SET IDENTITY_INSERT [dbo].[t_sys_user] ON 
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (1, N'admin', N'Malus', N'3FDE6BB0541387E4EBDADF7C2FF31123', N'[1,15,16]', 1, NULL, N'18888888888', N'18888888888@163.com', NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, 1, 0)
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (2, N'pridejoy', N'管理员', N'E10ADC3949BA59ABBE56E057F20F883E', N'[15,1]', 1, NULL, N'18888888888', N'18888888888@163.com', NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, 2, 0)
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (6, N'test3', N'test3', N'E10ADC3949BA59ABBE56E057F20F883E', N'[12]', 1, NULL, N'1863771111', N'514324468@qq.com', NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, NULL, 0)
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (9, N'11', N'11', N'E10ADC3949BA59ABBE56E057F20F883E', N'[]', 1, NULL, N'11', N'11', NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (10, N'2', N'2', N'E10ADC3949BA59ABBE56E057F20F883E', N'[15]', 1, NULL, N'', N'', NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (11, N'11', N'22', N'E10ADC3949BA59ABBE56E057F20F883E', N'[]', 1, NULL, N'33', N'131', NULL, 1, CAST(N'2024-06-06T14:57:12.990' AS DateTime), 0, CAST(N'2024-06-06T14:57:12.990' AS DateTime), 0, NULL, 0, NULL, 0)
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (12, N'66', N'66', N'E10ADC3949BA59ABBE56E057F20F883E', N'[1]', 1, NULL, N'', N'', NULL, 1, CAST(N'2024-06-07T06:23:55.130' AS DateTime), 0, CAST(N'2024-06-07T06:23:55.130' AS DateTime), 0, NULL, 0, NULL, 0)
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (13, N'7', N'7', N'E10ADC3949BA59ABBE56E057F20F883E', N'[1]', 1, NULL, N'', N'', NULL, 1, CAST(N'2024-06-07T06:24:02.107' AS DateTime), 0, CAST(N'2024-06-07T06:24:02.107' AS DateTime), 0, NULL, 0, NULL, 0)
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (14, N'8', N'8', N'E10ADC3949BA59ABBE56E057F20F883E', N'[1]', 1, NULL, N'', N'', NULL, 1, CAST(N'2024-06-07T06:24:11.960' AS DateTime), 0, CAST(N'2024-06-07T06:24:11.960' AS DateTime), 0, NULL, 0, NULL, 0)
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (15, N'9', N'9', N'E10ADC3949BA59ABBE56E057F20F883E', N'[1]', 0, NULL, N'', N'', NULL, 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0, NULL, 0)
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (16, N'99', N'99', N'E10ADC3949BA59ABBE56E057F20F883E', N'[1]', 1, NULL, N'', N'', NULL, 1, CAST(N'2024-06-07T06:24:25.610' AS DateTime), 0, CAST(N'2024-06-07T06:24:25.610' AS DateTime), 0, NULL, 0, NULL, 0)
GO
INSERT [dbo].[t_sys_user] ([Id], [Account], [Name], [PassWord], [UserRolesId], [Status], [Avatar], [Tel], [Email], [Remark], [SysCreateUser], [SysCreateTime], [SysUpdateUser], [SysUpdateTime], [SysDeleteUser], [SysDeleteTime], [SysIsDelete], [DeptId], [IsSuperAdmin]) VALUES (17, N'99', N'99', N'E10ADC3949BA59ABBE56E057F20F883E', N'[1]', 1, NULL, N'', N'', NULL, 1, CAST(N'2024-06-07T06:24:33.017' AS DateTime), 0, CAST(N'2024-06-07T06:24:33.017' AS DateTime), 0, NULL, 0, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[t_sys_user] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Name]    Script Date: 2024/6/11 10:30:50 ******/
ALTER TABLE [dbo].[t_sys_dept] ADD  CONSTRAINT [UC_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[t_sys_dept] ADD  DEFAULT ((0)) FOR [ParentId]
GO
ALTER TABLE [dbo].[t_sys_dept] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[t_sys_dict_data] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[t_sys_dict_data] ADD  DEFAULT ((0)) FOR [Sort]
GO
ALTER TABLE [dbo].[t_sys_dict_type] ADD  DEFAULT ((1)) FOR [Status]
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
