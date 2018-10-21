### AppSoft2.0.IO不仅仅一个通用系统框架，更是你编程生涯的伴侣，可以让你编程效率有着事半功倍效果！

*****

> AppSoft2.0.IO 摒弃了Entity Framework，采用[SqlSugar](https://github.com/sunkaixuan/SqlSugar)框架，[SqlSugar](https://github.com/sunkaixuan/SqlSugar)是众多.NET ORM框架中性能最接近ADO.NET，并且开发效率超越Entity Framework的ORM框架！

***** 



### AppSoft2.0 IO 系统设计及技术框架：

*****

#### 项目整体架构

* N层架构（抽象工厂，自动工厂，OOP，AOP）
* **ASP.NET MVC 5/Web API2.1**
* **.NET Framework 4.6.1**
* **MVC 插件式开发，支持热拔插**
* [Autofac](https://github.com/autofac/Autofac) | [文档说明](http://docs.autofac.org/en/latest/)
* [SqlSugar](https://github.com/sunkaixuan/SqlSugar) | [文档说明](http://www.cnblogs.com/sunkaixuan/p/4649904.html)
* [Redis](https://github.com/MSOpenTech/redis) | [文档说明](http://www.cnblogs.com/yangecnu/p/Introduct-Redis-in-DotNET.html)
* [Log4Net](https://logging.apache.org/log4net/)
* [Quartz.Net](http://www.quartz-scheduler.net/)
* [Lucence.NET](http://lucence.net/)
* [NPOI](http://npoi.codeplex.com/)
* [SuperWebSocket](https://github.com/kerryjiang/SuperWebSocket)
* [Senparc.Weixin.MP](https://github.com/JeffreySu/WeiXinMPSDK) | [系列教程](http://www.cnblogs.com/szw/archive/2013/05/14/weixin-course-index.html)
* [AutoMapper](https://github.com/AutoMapper/AutoMapper)
* [CraigsUtilityLibrary](https://github.com/JaCraig/Craig-s-Utility-Library) | [官网说明](http://jacraig.github.io/Craig-s-Utility-Library/)
* i18n
* E-RBAC
* WorkFlow
* [RazorEngine](https://github.com/Antaris/RazorEngine) | [文档说明](http://www.cnblogs.com/huangxincheng/p/3644313.html)
* [FluentValidation](https://github.com/JeremySkinner/FluentValidation) | [文档教程1](http://www.cnblogs.com/asxinyu/p/dotnet_Opensource_project_FluentValidation_1.html) | [文档教程2](http://www.cnblogs.com/asxinyu/p/dotnet_Opensource_project_FluentValidation_2.html)
* SQL Server 2005 + 

*****

### AppSoft2.0.IO 系统架构设计图：

*****

![输入图片说明](http://git.oschina.net/uploads/images/2016/0212/023235_1173f9d3_526496.jpeg "在这里输入图片标题")

*****

### AppSoft2.0.IO 目录结构

*****

```
AppSoft2.0.IO  解决方案目录
├─App.Entity                                        数据表对应实体模型
├─App.IRepository                                   数据表对应仓储接口
├─App.IServices                                     数据表对应服务接口
├─App.Library                                       常用公共类库,都有使用示例
├─App.ORM                                           ORM框架类库，如EF，SqlSugar
├─App.App.PluginFactory                             插件管理器，实现插件机制
├─App.Repository                                    数据表对应仓储实例类
├─App.RESTful API                                   RESTful API接口项目
├─App.Services                                      数据表对应服务实例类
├─App.Site                                          网站项目
├─README.md	                                      README文件
```

*****

### 其他附件图：

*****

* MVC请求机制简图

![输入图片说明](http://git.oschina.net/uploads/images/2016/0215/122618_acffb4e2_526496.png "在这里输入图片标题")

*****

* MVC整体请求流程图

![输入图片说明](http://git.oschina.net/uploads/images/2016/0215/122652_ebf12c84_526496.png "在这里输入图片标题")

*****

* 工厂创建类和视图引擎类的作用介绍（插件实现原理）

![输入图片说明](http://git.oschina.net/uploads/images/2016/0215/122731_a4241ebf_526496.png "在这里输入图片标题")

*****
