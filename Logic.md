# 前端部分

1. 在 `Frontend\Assets\3DGamekit\Scripts\Common\Command.cs` 中定义事件，以 S 开头的是 Server 端的操作，以 C 开头的是 Client 端的操作，如 `S_PLAYER_ENTER` 和 `C_PLAYER_ENTER` 相呼应。

2. 在 `Frontend\Assets\3DGamekit\Scripts\Network\Incoming\Incoming.cs` 中注册 Server 端的事件

   ~~~c#
   // S_xxxx为定义的服务器端的事件， realizedFunction为该事件的实现函数
   register.Register(Command.S_xxxx, realizedFunction);
   ~~~

3. 在上一步骤的同级目录下，新建 `realizedFunction.cs` 实现函数，可以模仿其他事件的实现。

# 后端部分

## Unity

- 如何看哪个代码绑定了哪个GameObject？

  - 在代码的start中，添加输出：

  - ```shell
    Debug.Log(this.name);
    ```

  - 再次运行即可看见命令行输出

## 程序运行

`Backend\Program.cs` 为程序主入口

在`Backend\Network\Server.cs`中，启动端口，并一直循环等待用户接入（`setup`）

## 注册事件

1. 在 `Backend\Network\Incoming\Incoming.cs` 中注册 Client 端的事件

   ~~~c#
   // C_xxxx为定义的服务器端的事件， realizeFunction为该事件的实现函数
   register.Register(Command.C_xxxx, realizeFunction);
   ~~~

2. 在上一步骤的同级目录下，新建 `realizeFunction.cs` 实现函数，可以模仿其他事件的实现。

   - 需要注意的是，`OnRecvLogin.cs` & `OnRecvRegister.cs` 两个文件还没有完全实现，需要等数据库连接之后，添加读写数据库的操作。


## 登录游戏

1. `OnRecLogin.cs`
   - 首先，系统会去`Frontend\Assets\BEAssets\Level1.asset`文件中找到对应的初始坐标，然后在`World.Instance.EntityData["Ellen"]`中初始化角色信息，之后再在数据库中读入当前角色信息进行更新。
2. `OnRecEnter.cs`
   - ​


### 完善RoadMap

- 主要实现 UI 位于 `Frontend\Assets\3DGamekit\Scripts\Game\UI` 
- 如需要实现商城交易，则实现 `CartGridUI.cs` 下 `OnBuyButtonClicked` 函数。

