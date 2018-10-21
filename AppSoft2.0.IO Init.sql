/*!
* �ļ����ƣ�AppSoft2.0.IO ���ݿ��ʼ���ű�
* �ļ����ߣ���Сɮ
* ��д���ڣ�2016��02��23��
* ��Ȩ���У���ǩ������޹�˾
* ��ҵ������http://www.baisoft.org
* ��ԴЭ�飺GPL v2 License
* �ļ�������һ�дӼ�ֻΪ�˸�����
*/
USE [AppSoft2.0.IO]
GO

-- #### UserCoreEntity �û����ı�

IF(OBJECT_ID('App_UserCoreEntity','U') IS NOT NULL)
	DROP TABLE [App_UserCoreEntity]
GO
CREATE TABLE [App_UserCoreEntity]
(
	[UserID] INT IDENTITY(1000,1) PRIMARY KEY NOT NULL,	-- �û�ID
	[No] VARCHAR(32) DEFAULT(''),	-- �û����
	[GUID] VARCHAR(50) NOT NULL DEFAULT(''),	-- �û�Ψһ��ʶID
	[Account] NVARCHAR(50) NOT NULL DEFAULT(''),	-- �û��˺�
	[Password] CHAR(32) NOT NULL DEFAULT(''),	-- ��¼���룬MD5Сд32λ����
	[Picture] NVARCHAR(512) DEFAULT(''),	-- �û�ͷ��Json���飬�洢��ʽΪ[{"large":"large.jpg"},{"medium":"medium.jpg"},{"small":"small.jpg"}]
	[JoinTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- ����ʱ��
	[JoinIPAddress] VARCHAR(16) NOT NULL DEFAULT('127.0.0.1'),	-- ����IP��ַ
	[CurrentLoginTime]  DATETIME DEFAULT(GETDATE()),	-- ��ǰ��¼ʱ��
	[CurrentLoginIPAddress] VARCHAR(16) DEFAULT('127.0.0.1'),	-- ��ǰ��¼��IP��ַ
	[LoginCount] INT DEFAULT(0),	-- ��¼����
	[LastLoginTime]  DATETIME DEFAULT(GETDATE()),	-- ����¼ʱ��
	[LastLoginIPAddress] VARCHAR(16) DEFAULT('127.0.0.1'),	-- ����¼IP��ַ
	[UpdateUser] INT DEFAULT(0),	-- ��������
	[UpdateIPAddress] VARCHAR(16) DEFAULT('127.0.0.1'),	-- ��������IP��ַ
	[UpdateTime] DATETIME DEFAULT(GETDATE()),	-- ������ʱ��
	[UpdateCount] INT DEFAULT(0),	-- ���´���
	[CreateUser] INT DEFAULT(0),	-- ������
	[CreateIPAddress] VARCHAR(16) DEFAULT('127.0.0.1'),	--������IP��ַ
	[CreateTime] DATETIME DEFAULT(GETDATE()),	-- ����ʱ��
	[IsDel] BIT NOT NULL DEFAULT(0),	-- �Ƿ�ɾ��
	[IsExpire] BIT NOT NULL DEFAULT(0),	-- �Ƿ����
	[RongCloudToken] NVARCHAR(512) DEFAULT('')	-- ��ʱͨѶ����Token
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'�û�ID', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'UserID';
EXEC sp_addextendedproperty N'MS_Description', N'�û����', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'No';
EXEC sp_addextendedproperty N'MS_Description', N'�û�Ψһ��ʶID', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'GUID';
EXEC sp_addextendedproperty N'MS_Description', N'�û��˺�', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'Account';
EXEC sp_addextendedproperty N'MS_Description', N'��¼���룬MD5Сд32λ����', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'Password';
EXEC sp_addextendedproperty N'MS_Description', N'�û�ͷ��Json���飬�洢��ʽΪ[{"large":"large.jpg"},{"medium":"medium.jpg"},{"small":"small.jpg"}]��MD5Сд32λ����', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'Picture';
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'JoinTime';
EXEC sp_addextendedproperty N'MS_Description', N'����IP��ַ', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'JoinIPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'����¼ʱ��', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'LastLoginTime';
EXEC sp_addextendedproperty N'MS_Description', N'����¼IP��ַ', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'LastLoginIPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'��ǰ��¼ʱ��', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'CurrentLoginTime';
EXEC sp_addextendedproperty N'MS_Description', N'��ǰ��¼��IP��ַ', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'CurrentLoginIPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'��¼����', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'LoginCount';
EXEC sp_addextendedproperty N'MS_Description', N'��������', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'UpdateUser';
EXEC sp_addextendedproperty N'MS_Description', N'��������IP��ַ', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'UpdateIPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'������ʱ��', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'���´���', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'UpdateCount';
EXEC sp_addextendedproperty N'MS_Description', N'������', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'CreateUser';
EXEC sp_addextendedproperty N'MS_Description', N'������IP��ַ', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'CreateIPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'�Ƿ�ɾ��', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'IsDel';
EXEC sp_addextendedproperty N'MS_Description', N'�Ƿ����', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'IsExpire';
EXEC sp_addextendedproperty N'MS_Description', N'��ʱͨѶ����Token', N'user', N'dbo', N'table', N'App_UserCoreEntity', N'column', N'RongCloudToken';
GO
SET IDENTITY_INSERT App_UserCoreEntity ON
INSERT dbo.App_UserCoreEntity(UserID,No ,GUID ,Account ,Password ,Picture ,JoinTime ,JoinIPAddress ,CurrentLoginTime ,CurrentLoginIPAddress ,LoginCount ,LastLoginTime ,LastLoginIPAddress ,UpdateUser ,UpdateIPAddress ,UpdateTime ,UpdateCount ,CreateUser ,CreateIPAddress ,CreateTime ,IsDel ,IsExpire ,RongCloudToken) VALUES  (1000,'WINU001' ,NEWID() ,'admin' ,'21232f297a57a5a743894a0e4a801fc3' ,'[{"large":""},{"medium":""},{"small":""}]' , GETDATE() ,'113.117.138.170' ,NULL ,NULL ,0 , NULL ,NULL,0 ,NULL ,NULL,0 ,0 ,NULL ,GETDATE() ,0 ,0 ,'');
SET IDENTITY_INSERT App_UserCoreEntity OFF
GO

-- #### ModuleFunctionEntity ����ģ��˵�

IF(OBJECT_ID('ModuleFunctionEntity','U') IS NOT NULL)
	DROP TABLE [ModuleFunctionEntity]
GO
CREATE TABLE [ModuleFunctionEntity]
(
	[ModuleFunctionID] INT IDENTITY(1000,1) PRIMARY KEY NOT NULL,	-- ����ģ��ID
	[ModuleFunctionName] NVARCHAR(32) NOT NULL DEFAULT(''),	-- ����ģ������
	[ModuleFunctionDescribe] NVARCHAR(255) DEFAULT(''),	-- ����ģ������
	[ModuleFunctionType] VARCHAR(50) DEFAULT(''),	-- ����ģ�����ͣ���root,top,module��function��
	[IsMVC_URL] BIT DEFAULT(1),	-- �Ƿ���MVC��ַ��ʽ,
	[Area] NVARCHAR(100) DEFAULT(''),	-- ����
	[Controller] NVARCHAR(100) DEFAULT(''),	-- ������
	[Action] NVARCHAR(100) DEFAULT(''),	-- ��Ϊ
	[Id] NVARCHAR(255) DEFAULT(''),	-- ID����
	[PluginName] NVARCHAR(100) DEFAULT(''),	-- �������
	[IsPlugin] BIT NOT NULL DEFAULT(0),	-- �Ƿ��ǲ��
	[Method] VARCHAR(32) DEFAULT('GET'),	-- ����ʽ��GET��POST��HEAD��PUT��DELETE��
	[CustomUrl] NVARCHAR(255) DEFAULT('javascript(void);'),	-- �Զ����ַ
	[IsAjax] BIT DEFAULT(0),	-- �Ƿ���Ajax����
	[AjaxCode] TEXT DEFAULT(''),	-- Ajax����
    [ModuleFunctionIco] NVARCHAR(255) DEFAULT(''),	-- ģ��ͼ��class��imageͼƬ
	[ModuleFunctionIcoType] VARCHAR(10),	-- ͼ�����ͣ�iconfont,image)
	[GUID] VARCHAR(50) NOT NULL DEFAULT(''),	-- Ψһ��ʶID
	[UpdateUser] INT DEFAULT(0),	-- ��������
	[UpdateIPAddress] VARCHAR(16) DEFAULT('127.0.0.1'),	-- ��������IP��ַ
	[UpdateTime] DATETIME DEFAULT(GETDATE()),	-- ������ʱ��
	[UpdateCount] INT DEFAULT(0),	-- ���´���
	[CreateUser] INT DEFAULT(0),	-- ������
	[CreateIPAddress] VARCHAR(16) DEFAULT('127.0.0.1'),	--������IP��ַ
	[CreateTime] DATETIME DEFAULT(GETDATE()),	-- ����ʱ��
	[IsEnable] BIT DEFAULT(1),	-- �Ƿ�����
	[ModuleFunctionParentID] INT DEFAULT(-1)	-- ������ģ��ID
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ģ��ID', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'ModuleFunctionID';
EXEC sp_addextendedproperty N'MS_Description', N'����ģ������', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'ModuleFunctionName';
EXEC sp_addextendedproperty N'MS_Description', N'����ģ������', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'ModuleFunctionDescribe';
EXEC sp_addextendedproperty N'MS_Description', N'����ģ�����ͣ���root,top,module��function��', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'ModuleFunctionType';
EXEC sp_addextendedproperty N'MS_Description', N'�Ƿ���MVC��ַ��ʽ', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'IsMVC_URL';
EXEC sp_addextendedproperty N'MS_Description', N'����', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'Area';
EXEC sp_addextendedproperty N'MS_Description', N'������', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'Controller';
EXEC sp_addextendedproperty N'MS_Description', N'��Ϊ', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'Action';
EXEC sp_addextendedproperty N'MS_Description', N'ID����', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'Id';
EXEC sp_addextendedproperty N'MS_Description', N'�������', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'PluginName';
EXEC sp_addextendedproperty N'MS_Description', N'�Ƿ��ǲ��', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'IsPlugin';
EXEC sp_addextendedproperty N'MS_Description', N'����ʽ��GET��POST��HEAD��PUT��DELETE��', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'Method';
EXEC sp_addextendedproperty N'MS_Description', N'�Զ����ַ', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'CustomUrl';
EXEC sp_addextendedproperty N'MS_Description', N'�Ƿ���Ajax����', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'IsAjax';
EXEC sp_addextendedproperty N'MS_Description', N'Ajax����', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'AjaxCode';
EXEC sp_addextendedproperty N'MS_Description', N'ģ��ͼ��class��imageͼƬ', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'ModuleFunctionIco';
EXEC sp_addextendedproperty N'MS_Description', N'ͼ�����ͣ�iconfont,image)', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'ModuleFunctionIcoType';
EXEC sp_addextendedproperty N'MS_Description', N'Ψһ��ʶID', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'GUID';
EXEC sp_addextendedproperty N'MS_Description', N'��������', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'UpdateUser';
EXEC sp_addextendedproperty N'MS_Description', N'��������IP��ַ', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'UpdateIPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'������ʱ��', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'���´���', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'UpdateCount';
EXEC sp_addextendedproperty N'MS_Description', N'������', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'CreateUser';
EXEC sp_addextendedproperty N'MS_Description', N'������IP��ַ', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'CreateIPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'�Ƿ�����', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'IsEnable';
EXEC sp_addextendedproperty N'MS_Description', N'������ģ��ID', N'user', N'dbo', N'table', N'ModuleFunctionEntity', N'column', N'ModuleFunctionParentID';
GO
SET IDENTITY_INSERT ModuleFunctionEntity ON
INSERT INTO dbo.ModuleFunctionEntity(ModuleFunctionID, ModuleFunctionName ,ModuleFunctionDescribe,ModuleFunctionType ,IsMVC_URL ,Area ,Controller ,Action ,Id ,PluginName ,IsPlugin ,Method ,CustomUrl ,IsAjax ,AjaxCode ,ModuleFunctionIco ,ModuleFunctionIcoType ,GUID ,UpdateUser ,UpdateIPAddress ,UpdateTime ,UpdateCount ,CreateUser ,CreateIPAddress ,CreateTime ,IsEnable ,ModuleFunctionParentID) VALUES  ( 0,N'��ģ��' ,N'','root',0 ,N'' ,N'' ,N'' ,N'' ,N'' ,0 ,'' ,N'javascript:void(0);' ,0 ,'' ,N'' ,'iconfont' ,NEWID() ,0 , '' , GETDATE() , 0 ,0 , '' , GETDATE() ,1 ,-1);
INSERT INTO dbo.ModuleFunctionEntity(ModuleFunctionID, ModuleFunctionName ,ModuleFunctionDescribe,ModuleFunctionType ,IsMVC_URL ,Area ,Controller ,Action ,Id ,PluginName ,IsPlugin ,Method ,CustomUrl ,IsAjax ,AjaxCode ,ModuleFunctionIco ,ModuleFunctionIcoType ,GUID ,UpdateUser ,UpdateIPAddress ,UpdateTime ,UpdateCount ,CreateUser ,CreateIPAddress ,CreateTime ,IsEnable ,ModuleFunctionParentID) VALUES  ( 1000,N'վ�����' ,N'','top',0 ,N'' ,N'' ,N'' ,N'' ,N'' ,0 ,'' ,N'javascript:void(0);' ,0 ,'' ,N'' ,'iconfont' ,NEWID() ,0 , '' , GETDATE() , 0 ,0 , '' , GETDATE() ,1 ,0);
INSERT INTO dbo.ModuleFunctionEntity(ModuleFunctionID, ModuleFunctionName ,ModuleFunctionDescribe,ModuleFunctionType ,IsMVC_URL ,Area ,Controller ,Action ,Id ,PluginName ,IsPlugin ,Method ,CustomUrl ,IsAjax ,AjaxCode ,ModuleFunctionIco ,ModuleFunctionIcoType ,GUID ,UpdateUser ,UpdateIPAddress ,UpdateTime ,UpdateCount ,CreateUser ,CreateIPAddress ,CreateTime ,IsEnable ,ModuleFunctionParentID) VALUES  ( 1001,N'��ʱͨѶ' ,N'','top',0 ,N'' ,N'' ,N'' ,N'' ,N'' ,0 ,'' ,N'javascript:void(0);' ,0 ,'' ,N'' ,'iconfont' ,NEWID() ,0 , '' , GETDATE() , 0 ,0 , '' , GETDATE() ,1 ,0);
INSERT INTO dbo.ModuleFunctionEntity(ModuleFunctionID, ModuleFunctionName ,ModuleFunctionDescribe,ModuleFunctionType ,IsMVC_URL ,Area ,Controller ,Action ,Id ,PluginName ,IsPlugin ,Method ,CustomUrl ,IsAjax ,AjaxCode ,ModuleFunctionIco ,ModuleFunctionIcoType ,GUID ,UpdateUser ,UpdateIPAddress ,UpdateTime ,UpdateCount ,CreateUser ,CreateIPAddress ,CreateTime ,IsEnable ,ModuleFunctionParentID) VALUES  ( 1002,N'�û�Ȩ��' ,N'','top',0 ,N'' ,N'' ,N'' ,N'' ,N'' ,0 ,'' ,N'javascript:void(0);' ,0 ,'' ,N'' ,'iconfont' ,NEWID() ,0 , '' , GETDATE() , 0 ,0 , '' , GETDATE() ,1 ,0);
INSERT INTO dbo.ModuleFunctionEntity(ModuleFunctionID, ModuleFunctionName ,ModuleFunctionDescribe,ModuleFunctionType ,IsMVC_URL ,Area ,Controller ,Action ,Id ,PluginName ,IsPlugin ,Method ,CustomUrl ,IsAjax ,AjaxCode ,ModuleFunctionIco ,ModuleFunctionIcoType ,GUID ,UpdateUser ,UpdateIPAddress ,UpdateTime ,UpdateCount ,CreateUser ,CreateIPAddress ,CreateTime ,IsEnable ,ModuleFunctionParentID) VALUES  ( 1003,N'�������' ,N'','top',0 ,N'' ,N'' ,N'' ,N'' ,N'' ,0 ,'' ,N'javascript:void(0);' ,0 ,'' ,N'' ,'iconfont' ,NEWID() ,0 , '' , GETDATE() , 0 ,0 , '' , GETDATE() ,1 ,0);
INSERT INTO dbo.ModuleFunctionEntity(ModuleFunctionID, ModuleFunctionName ,ModuleFunctionDescribe,ModuleFunctionType ,IsMVC_URL ,Area ,Controller ,Action ,Id ,PluginName ,IsPlugin ,Method ,CustomUrl ,IsAjax ,AjaxCode ,ModuleFunctionIco ,ModuleFunctionIcoType ,GUID ,UpdateUser ,UpdateIPAddress ,UpdateTime ,UpdateCount ,CreateUser ,CreateIPAddress ,CreateTime ,IsEnable ,ModuleFunctionParentID) VALUES  ( 1004,N'ģ��˵�' ,N'','module',1 ,N'ModuleFunction' ,N'Default' ,N'Index' ,N'' ,N'' ,0 ,'GET' ,N'javascript:void(0);' ,0 ,'' ,N'' ,'iconfont' ,NEWID() ,0 , '' , GETDATE() , 0 ,0 , '' , GETDATE() ,1 ,1003);
SET IDENTITY_INSERT ModuleFunctionEntity OFF
GO