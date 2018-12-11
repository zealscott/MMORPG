## 登录与注册

首先在数据库新建数据表，在后端新建用于数据库处理的文件夹`DB`。

![54408024390](./Doc/pic/dblist.png)

主要的处理逻辑为`OnRecvLogin.cs`、`OnRecvRegister.cs`，在这两个文件中实现访问数据库，并进行身份验证的逻辑。

- [x] 实现于2018.12.3


- [x] 更新与2018.12.4

## 聊天与历史记录

主要实现了单人聊天、群聊功能，同时保证历史记录的同步与恢复，好友在线消息提醒。

1. 实现后端向前端发送在线好友，将在线好友信息保存在`OnlinePlayers`字典中
   - 在前端新建一个消息`SFINDFRINDS`，后端在`OnRecvPlayerEnter`时发送玩家属性，并发送在线玩家。
2. 使用线程池每隔一段时间就将消息sync到数据库中，需要尽可能实现前台进程

### Reference

1. [Unity点击鼠标绑定事件](https://www.cnblogs.com/isayes/p/6370168.html)
2. [C#多线程实现](https://www.cnblogs.com/luxiaoxun/p/3280146.html)
3. [前台进程与后台进程区别](https://www.c-sharpcorner.com/UploadFile/ff0d0f/working-of-thread-and-foreground-background-thread-in-C-Sharp730/)

