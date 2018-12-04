使用两台机器完成游戏后端的部署

1. `219.228.148.128`
   - 部署PostgreSQL
2. `219.228.148.237`
   - 后端暴露端口，供前端访问，实现多人同时在线，并广播消息

## Backend

后端部署在局域网的一台机器上，需要在前端`\Frontend\Assets\BEAssets\backend.conf`指定端口号：

```xml
<?xml version="1.0" encoding="utf-8"?>
<BackendConf xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <host>219.228.148.237</host>
  <port>7777</port>
  <asset_path>E:/MMORPG/Frontend/Assets/BEAssets</asset_path>
  <scenes>
    <string>Level1.asset</string>
  </scenes>
</BackendConf>
```

## DataBase

### 安装 `Npgsql` 

- 官方地址 https://www.nuget.org/packages/Npgsql/

- VS -> Tool -> NuGet Package Manager -> Package Manager Console

  - 输入 `Install-Package Npgsql -Version 4.0.3`
  - 安装完成会在 `Dependencies` 中出现

  ![Npgsql](https://i.loli.net/2018/12/01/5c01fc159c9e3.png)

1. 在需要使用数据库的 C# 文件中使用 `using Npgsql;` 头文件即可。
2. 已在 `PostgreConnect` 中实现 `ConnectPostgresql` 访问数据库时直接调用即可。

使用postgreSQL作为数据库，且数据库在`219.228.148.128`的机器上

### 允许局域网访问

首先需要修改配置文件，允许局域网的机器访问。

首先需要找到这两个配置文件：

1. `pg_hba.conf `
   - Linux机器上很简单，`/etc/data`中
   - 但在Windows上，请[参考这里](https://stackoverflow.com/questions/4465475/where-is-the-postgresql-config-file-postgresql-conf-on-windows)进行设置
2. `postgresql.conf`
   - 在同样的目录下

然后根据[这篇博客](https://blog.csdn.net/shouzang/article/details/81262029)进行设置，确保局域网内其他电脑可以访问

最后需要在防火墙中增加规则，暴露端口号。

使用SQL shell测试：

![54373458686](./Doc/pic/sqlshell.png)



