## 12.3

- 熟悉前后端登陆流程
- 在前端新建player类
- 后端实现登陆逻辑

### 问题

- 前端人物无法出现
  - 可能是因为更改了前端的entity的属性

## 12.4

实现了Login功能，包括：

- [x] Register功能（杜云滔）
- [x] 已注册玩家LogIn（杜云滔）
- [x] 登录后从数据库读取玩家基本属性，并展示在前端（speed、intelligence...）（郁思敏）

## 12.5

熟悉聊天流程

## 12.6

在后端实现在线用户统计，并等待前端在点击聊天框时调用（`OnRecFindFriends`）

后端使用`OnlinePlayers`字典存储用户，新增Command`FIND_FRIENDS`。

前端向后端发送请求，