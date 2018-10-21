/*!
* 文件名称：AppSoft2.0.IO 数据库初始化脚本
* 文件作者：百小僧
* 编写日期：2016年02月23日
* 版权所有：百签软件有限公司
* 企业官网：http://www.baisoft.org
* 开源协议：GPL v2 License
* 文件描述：一切从简，只为了更懒！
*/
USE [AppSoft2.0.IO]
GO

-- #### UserCoreEntity 用户核心表

IF(OBJECT_ID('App_UserCoreEntity','U') IS NOT NULL)
	DROP TABLE [App_UserCoreEntity]
GO
CREATE TABLE [App_UserCoreEntity]
(
	[UserID] INT IDENTITY(1000,1) PRIMARY KEY NOT NULL,	-- 用户ID
	[No] VARCHAR(32) DEFAULT(''),	-- 用户编号
	[GUID] VARCHAR(50) NOT NULL DEFAULT(''),	-- 用户唯一标识ID
	[Account] NVARCHAR(50) NOT NULL DEFAULT(''),	-- 用户账号
	[Password] CHAR(32) NOT NULL DEFAULT(''),	-- 登录密码，MD5小写32位加密
	[Picture] NVARCHAR(512) DEFAULT(''),	-- 用户头像，Json数组，存储格式为[{"large":"large.jpg"},{"medium":"medium.jpg"},{"small":"small.jpg"}]
	[JoinTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 加入时间
	[JoinIPAddress] VARCHAR(16) NOT NULL DEFAULT('127.0.0.1'),	-- 加入IP地址
	[CurrentLoginTime]  DATETIME DEFAULT(GETDATE()),	-- 当前登录时间
	[CurrentLoginIPAddress] VARCHAR(16) DEFAULT('127.0.0.1'),	-- 当前登录人IP地址
	[LoginCount] INT DEFAULT(0),	-- 登录次数
	[LastLoginTime]  DATETIME DEFAULT(GETDATE()),	-- 最后登录时间
	[LastLoginIPAddress] VARCHAR(16) DEFAULT('127.0.0.1'),	-- 最后登录IP地址
	[UpdateUser] INT DEFAULT(0),	-- 最后更新人
	[UpdateIPAddress] VARCHAR(16) DEFAULT('127.0.0.1'),	-- 最后更新人IP地址
	[UpdateTime] DATETIME DEFAULT(GETDATE()),	-- 最后更新时间
	[UpdateCount] INT DEFAULT(0),	-- 更新次数
	[CreateUser] INT DEFAULT(0),	-- 创建人
	[CreateIPAddress] VARCHAR(16) DEFAULT('127.0.0.1'),	--创建人IP地址
	[CreateTime] DATETIME DEFAULT(GETDATE()),	-- 创建时间
	[IsDel] BIT NOT NULL DEFAULT(0),	-- 是否删除
	[IsExpire] BIT NOT NULL DEFAULT(0),	-- 是否过期
	[RongCloudToken] NVARCHAR(512) DEFAULT('')	-- 即时通讯融云Token
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'用户ID', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'UserID';
EXEC sp_addextendedproperty N'MS_Description', N'用户编号', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'No';
EXEC sp_addextendedproperty N'MS_Description', N'用户唯一标识ID', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'GUID';
EXEC sp_addextendedproperty N'MS_Description', N'用户账号', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'Account';
EXEC sp_addextendedproperty N'MS_Description', N'登录密码，MD5小写32位加密', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'Password';
EXEC sp_addextendedproperty N'MS_Description', N'用户头像，Json数组，存储格式为[{"large":"large.jpg"},{"medium":"medium.jpg"},{"small":"small.jpg"}]，MD5小写32位加密', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'Picture';
EXEC sp_addextendedproperty N'MS_Description', N'加入时间', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'JoinTime';
EXEC sp_addextendedproperty N'MS_Description', N'加入IP地址', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'JoinIPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'最后登录时间', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'LastLoginTime';
EXEC sp_addextendedproperty N'MS_Description', N'最后登录IP地址', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'LastLoginIPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'当前登录时间', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'CurrentLoginTime';
EXEC sp_addextendedproperty N'MS_Description', N'当前登录人IP地址', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'CurrentLoginIPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'登录次数', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'LoginCount';
EXEC sp_addextendedproperty N'MS_Description', N'最后更新人', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'UpdateUser';
EXEC sp_addextendedproperty N'MS_Description', N'最后更新人IP地址', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'UpdateIPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'最后更新时间', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'更新次数', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'UpdateCount';
EXEC sp_addextendedproperty N'MS_Description', N'创建人', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'CreateUser';
EXEC sp_addextendedproperty N'MS_Description', N'创建人IP地址', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'CreateIPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'是否删除', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'IsDel';
EXEC sp_addextendedproperty N'MS_Description', N'是否过期', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'IsExpire';
EXEC sp_addextendedproperty N'MS_Description', N'即时通讯融云Token', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'RongCloudToken';
GO
SET IDENTITY_INSERT App_UserCoreEntity ON
INSERT dbo.App_UserCoreEntity(UserID,No ,GUID ,Account ,Password ,Picture ,JoinTime ,JoinIPAddress ,CurrentLoginTime ,CurrentLoginIPAddress ,LoginCount ,LastLoginTime ,LastLoginIPAddress ,UpdateUser ,UpdateIPAddress ,UpdateTime ,UpdateCount ,CreateUser ,CreateIPAddress ,CreateTime ,IsDel ,IsExpire ,RongCloudToken) VALUES  (1000,'WINU001' ,NEWID() ,'admin' ,'21232f297a57a5a743894a0e4a801fc3' ,'[{"large":""},{"medium":""},{"small":""}]' , GETDATE() ,'113.117.138.170' ,NULL ,NULL ,0 , NULL ,NULL,0 ,NULL ,NULL,0 ,0 ,NULL ,GETDATE() ,0 ,0 ,'');
SET IDENTITY_INSERT App_UserCoreEntity OFF
GO

-- #### ModuleFunctionEntity 功能模块菜单

IF(OBJECT_ID('ModuleFunctionEntity','U') IS NOT NULL)
	DROP TABLE [ModuleFunctionEntity]
GO
CREATE TABLE [ModuleFunctionEntity]
(
	[ModuleFunctionID] INT IDENTITY(1000,1) PRIMARY KEY NOT NULL,	-- 功能模块ID
	[ModuleFunctionName] NVARCHAR(32) NOT NULL DEFAULT(''),	-- 功能模块名称
	[ModuleFunctionDescribe] NVARCHAR(255) DEFAULT(''),	-- 功能模块描述
	[ModuleFunctionType] VARCHAR(50) DEFAULT(''),	-- 功能模块类型：（root,top,module，function）
	[IsMVC_URL] BIT DEFAULT(1),	-- 是否是MVC地址格式,
	[Area] NVARCHAR(100) DEFAULT(''),	-- 区域
	[Controller] NVARCHAR(100) DEFAULT(''),	-- 控制器
	[Action] NVARCHAR(100) DEFAULT(''),	-- 行为
	[Id] NVARCHAR(255) DEFAULT(''),	-- ID参数
	[PluginName] NVARCHAR(100) DEFAULT(''),	-- 插件名称
	[IsPlugin] BIT NOT NULL DEFAULT(0),	-- 是否是插件
	[Method] VARCHAR(32) DEFAULT('GET'),	-- 请求方式（GET，POST，HEAD，PUT，DELETE）
	[CustomUrl] NVARCHAR(255) DEFAULT('javascript(void);'),	-- 自定义地址
	[IsAjax] BIT DEFAULT(0),	-- 是否是Ajax请求
	[AjaxCode] TEXT DEFAULT(''),	-- Ajax代码
    [ModuleFunctionIco] NVARCHAR(255) DEFAULT(''),	-- 模块图标class或image图片
	[ModuleFunctionIcoType] VARCHAR(10),	-- 图标类型（iconfont,image)
	[GUID] VARCHAR(50) NOT NULL DEFAULT(''),	-- 唯一标识ID
	[UpdateUser] INT DEFAULT(0),	-- 最后更新人
	[UpdateIPAddress] VARCHAR(16) DEFAULT('127.0.0.1'),	-- 最后更新人IP地址
	[UpdateTime] DATETIME DEFAULT(GETDATE()),	-- 最后更新时间
	[UpdateCount] INT DEFAULT(0),	-- 更新次数
	[CreateUser] INT DEFAULT(0),	-- 创建人
	[CreateIPAddress] VARCHAR(16) DEFAULT('127.0.0.1'),	--创建人IP地址
	[CreateTime] DATETIME DEFAULT(GETDATE()),	-- 创建时间
	[IsEnable] BIT DEFAULT(1),	-- 是否启用
	[ModuleFunctionParentID] INT DEFAULT(-1)	-- 父功能模块ID
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'功能模块ID', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'ModuleFunctionID';
EXEC sp_addextendedproperty N'MS_Description', N'功能模块名称', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'ModuleFunctionName';
EXEC sp_addextendedproperty N'MS_Description', N'功能模块描述', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'ModuleFunctionDescribe';
EXEC sp_addextendedproperty N'MS_Description', N'功能模块类型：（root,top,module，function）', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'ModuleFunctionType';
EXEC sp_addextendedproperty N'MS_Description', N'是否是MVC地址格式', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'IsMVC_URL';
EXEC sp_addextendedproperty N'MS_Description', N'区域', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'Area';
EXEC sp_addextendedproperty N'MS_Description', N'控制器', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'Controller';
EXEC sp_addextendedproperty N'MS_Description', N'行为', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'Action';
EXEC sp_addextendedproperty N'MS_Description', N'ID参数', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'Id';
EXEC sp_addextendedproperty N'MS_Description', N'插件名称', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'PluginName';
EXEC sp_addextendedproperty N'MS_Description', N'是否是插件', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'IsPlugin';
EXEC sp_addextendedproperty N'MS_Description', N'请求方式（GET，POST，HEAD，PUT，DELETE）', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'Method';
EXEC sp_addextendedproperty N'MS_Description', N'自定义地址', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'CustomUrl';
EXEC sp_addextendedproperty N'MS_Description', N'是否是Ajax请求', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'IsAjax';
EXEC sp_addextendedproperty N'MS_Description', N'Ajax代码', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'AjaxCode';
EXEC sp_addextendedproperty N'MS_Description', N'模块图标class或image图片', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'ModuleFunctionIco';
EXEC sp_addextendedproperty N'MS_Description', N'图标类型（iconfont,image)', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'ModuleFunctionIcoType';
EXEC sp_addextendedproperty N'MS_Description', N'唯一标识ID', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'GUID';
EXEC sp_addextendedproperty N'MS_Description', N'最后更新人', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'UpdateUser';
EXEC sp_addextendedproperty N'MS_Description', N'最后更新人IP地址', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'UpdateIPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'最后更新时间', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'更新次数', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'UpdateCount';
EXEC sp_addextendedproperty N'MS_Description', N'创建人', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'CreateUser';
EXEC sp_addextendedproperty N'MS_Description', N'创建人IP地址', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'CreateIPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'是否启用', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'IsEnable';
EXEC sp_addextendedproperty N'MS_Description', N'父功能模块ID', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'ModuleFunctionParentID';
GO
SET IDENTITY_INSERT ModuleFunctionEntity ON
INSERT INTO dbo.ModuleFunctionEntity(ModuleFunctionID, ModuleFunctionName ,ModuleFunctionDescribe,ModuleFunctionType ,IsMVC_URL ,Area ,Controller ,Action ,Id ,PluginName ,IsPlugin ,Method ,CustomUrl ,IsAjax ,AjaxCode ,ModuleFunctionIco ,ModuleFunctionIcoType ,GUID ,UpdateUser ,UpdateIPAddress ,UpdateTime ,UpdateCount ,CreateUser ,CreateIPAddress ,CreateTime ,IsEnable ,ModuleFunctionParentID) VALUES  ( 0,N'根模块' ,N'','root',0 ,N'' ,N'' ,N'' ,N'' ,N'' ,0 ,'' ,N'javascript:void(0);' ,0 ,'' ,N'' ,'iconfont' ,NEWID() ,0 , '' , GETDATE() , 0 ,0 , '' , GETDATE() ,1 ,-1);
INSERT INTO dbo.ModuleFunctionEntity(ModuleFunctionID, ModuleFunctionName ,ModuleFunctionDescribe,ModuleFunctionType ,IsMVC_URL ,Area ,Controller ,Action ,Id ,PluginName ,IsPlugin ,Method ,CustomUrl ,IsAjax ,AjaxCode ,ModuleFunctionIco ,ModuleFunctionIcoType ,GUID ,UpdateUser ,UpdateIPAddress ,UpdateTime ,UpdateCount ,CreateUser ,CreateIPAddress ,CreateTime ,IsEnable ,ModuleFunctionParentID) VALUES  ( 1000,N'站点管理' ,N'','top',0 ,N'' ,N'' ,N'' ,N'' ,N'' ,0 ,'' ,N'javascript:void(0);' ,0 ,'' ,N'' ,'iconfont' ,NEWID() ,0 , '' , GETDATE() , 0 ,0 , '' , GETDATE() ,1 ,0);
INSERT INTO dbo.ModuleFunctionEntity(ModuleFunctionID, ModuleFunctionName ,ModuleFunctionDescribe,ModuleFunctionType ,IsMVC_URL ,Area ,Controller ,Action ,Id ,PluginName ,IsPlugin ,Method ,CustomUrl ,IsAjax ,AjaxCode ,ModuleFunctionIco ,ModuleFunctionIcoType ,GUID ,UpdateUser ,UpdateIPAddress ,UpdateTime ,UpdateCount ,CreateUser ,CreateIPAddress ,CreateTime ,IsEnable ,ModuleFunctionParentID) VALUES  ( 1001,N'即时通讯' ,N'','top',0 ,N'' ,N'' ,N'' ,N'' ,N'' ,0 ,'' ,N'javascript:void(0);' ,0 ,'' ,N'' ,'iconfont' ,NEWID() ,0 , '' , GETDATE() , 0 ,0 , '' , GETDATE() ,1 ,0);
INSERT INTO dbo.ModuleFunctionEntity(ModuleFunctionID, ModuleFunctionName ,ModuleFunctionDescribe,ModuleFunctionType ,IsMVC_URL ,Area ,Controller ,Action ,Id ,PluginName ,IsPlugin ,Method ,CustomUrl ,IsAjax ,AjaxCode ,ModuleFunctionIco ,ModuleFunctionIcoType ,GUID ,UpdateUser ,UpdateIPAddress ,UpdateTime ,UpdateCount ,CreateUser ,CreateIPAddress ,CreateTime ,IsEnable ,ModuleFunctionParentID) VALUES  ( 1002,N'用户权限' ,N'','top',0 ,N'' ,N'' ,N'' ,N'' ,N'' ,0 ,'' ,N'javascript:void(0);' ,0 ,'' ,N'' ,'iconfont' ,NEWID() ,0 , '' , GETDATE() , 0 ,0 , '' , GETDATE() ,1 ,0);
INSERT INTO dbo.ModuleFunctionEntity(ModuleFunctionID, ModuleFunctionName ,ModuleFunctionDescribe,ModuleFunctionType ,IsMVC_URL ,Area ,Controller ,Action ,Id ,PluginName ,IsPlugin ,Method ,CustomUrl ,IsAjax ,AjaxCode ,ModuleFunctionIco ,ModuleFunctionIcoType ,GUID ,UpdateUser ,UpdateIPAddress ,UpdateTime ,UpdateCount ,CreateUser ,CreateIPAddress ,CreateTime ,IsEnable ,ModuleFunctionParentID) VALUES  ( 1003,N'控制面板' ,N'','top',0 ,N'' ,N'' ,N'' ,N'' ,N'' ,0 ,'' ,N'javascript:void(0);' ,0 ,'' ,N'' ,'iconfont' ,NEWID() ,0 , '' , GETDATE() , 0 ,0 , '' , GETDATE() ,1 ,0);
INSERT INTO dbo.ModuleFunctionEntity(ModuleFunctionID, ModuleFunctionName ,ModuleFunctionDescribe,ModuleFunctionType ,IsMVC_URL ,Area ,Controller ,Action ,Id ,PluginName ,IsPlugin ,Method ,CustomUrl ,IsAjax ,AjaxCode ,ModuleFunctionIco ,ModuleFunctionIcoType ,GUID ,UpdateUser ,UpdateIPAddress ,UpdateTime ,UpdateCount ,CreateUser ,CreateIPAddress ,CreateTime ,IsEnable ,ModuleFunctionParentID) VALUES  ( 1004,N'模块菜单' ,N'','module',1 ,N'ModuleFunction' ,N'Default' ,N'Index' ,N'' ,N'' ,0 ,'GET' ,N'javascript:void(0);' ,0 ,'' ,N'' ,'iconfont' ,NEWID() ,0 , '' , GETDATE() , 0 ,0 , '' , GETDATE() ,1 ,1003);
SET IDENTITY_INSERT ModuleFunctionEntity OFF
GO