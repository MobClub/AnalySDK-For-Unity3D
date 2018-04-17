# AnalySDK For Unity3D
### 本插件是基于[AnalySDK](http://analysdk.mob.com/)(又称Mob统计分析SDK)对于Unity3D进行插件扩充支持。目的是方便Unity开发者使用AnalySDK。

**当前支持的 AnalySDK 版本**

- iOS v1.1.1
- Android v1.1.0

**集成文档**

- [iOS](http://wiki.mob.com/analysdk-ios-for-unity3d/)
- [Android](http://wiki.mob.com/analysdk-android-for-cocos2d-x/)

- - - - - - - - - - - -
### 一、下载AnalySDK的Unity3D工具类
打开Github下载AnalySDK-For-Unity3D项目，下载完成后直接使用AnalySDK.unitypackage导入到您的Unity项目即可使用。

注意该操作可能会覆盖您原来已经存在的文件！

### 二、挂载AnalySDK脚本
![](http://wiki.mob.com/wp-content/uploads/2018/03/%E6%97%A0%E6%A0%87%E9%A2%98.png)
(可以在我们的官网上注册应用得到MobAppKey及MobAppSecret,注意记得开启统计分析模块)

### 三、调用接口

##### 1.事件埋点

```
Hashtable custom = new Hashtable ();
custom.Add ("key1", "value1");
custom.Add ("key2", "value2");
AnalySDK.trackEvent ("CustomEvent", custom);
```

每个事件应有独立的事件名称,并且传入自定义的字典参数用于统计你需要统计的数据,（事件名称创建成功后不可修改，建议使用26个字母与数字的组合，事件上传成功会在Mob统计后台项目里查看并添加描述，方便管理）

![](http://wiki.mob.com/wp-content/uploads/2018/03/1-1.png)
**建议埋点的代码,应该部署于例如点击、特殊事件等一些业务场景发生的地方。**

添加地理位置信息(可选)

```
LocationService location = new LocationService ();
AnalySDK.setLocation(location);
```
一旦添加了地理位置信息,所有的统计事件均会自动带上此位置信息

##### 2.用户事件
**支持三种用户事件:用户注册,用户登录,用户修改信息**

###### (1)用户注册

```
ALSDKUser user = new ALSDKUser ("YourUserId","YourRegType","YourRegChannel", ALSDKUser.ActionType.Reg);
 user.age = 18;
 user.nickName = "UserNickName"; 
//...更多字段请参考该类文件 Hashtable customTable = new Hashtable ();
 customTable.Add ("k1", "v1");
 customTable.Add ("k2", "v2");
 user.customProperties = customTable;
 Hashtable hash = user.HashtableValue ();
 AnalySDK.userRegist (user); 
```

###### (2)用户登录

```
ALSDKUser user = new ALSDKUser ("YourUserId","YourLoginType","YourLoginChannel", ALSDKUser.ActionType.Login); 
user.age = 18; 
user.nickName = "UserNickName"; 
//...更多字段请参考该类文件
 AnalySDK.userLogin (user); 
```

###### (3)用户更新信息

```
ALSDKUser user = new ALSDKUser ("YourUserId"); 
user.age = 18; 
user.nickName = "UserNickName"; 
//...更多字段请参考该类文件
 AnalySDK.userUpdate (user); 
```

##### 3、角色事件
 **[更适用于游戏使用]**
 
###### (1)角色创建

```
ALSDKRole role = new ALSDKRole ("YourUserId", "YourRoleId"); 
role.roLevel = 100; 
role.roVip = “bigViP";

//...更多字段请参考该类文件
 AnalySDK.roleCreate (role);
```

###### (2)角色登录

```
ALSDKRole role = new ALSDKRole ("YourUserId", "YourRoleId"); 
role.roLevel = 100; 
role.roVip = "bigViP"; 
//...更多字段请参考该类文件 
AnalySDK.roleLogin (role);
```

###### (3)角色更新信息

```
ALSDKRole role = new ALSDKRole ("YourUserId", "YourRoleId"); 
role.roLevel = 100; 
role.roVip = "bigViP";
 //...更多字段请参考该类文件
 AnalySDK.roleUpdate (role);
```

##### 4、付费事件

```
ALSDKPayEvent payEvent = new ALSDKPayEvent (); 
payEvent.payMoney = 10000; 
payEvent.payContent = "购买月卡"; 
//...更多字段请参考该类文件
 AnalySDK.trackPayEvent (payEvent);
```

***注意：Mob统计游戏专版为游戏行业做了垂直化定制，提供了3类共7个事件作为特殊事件；
强烈建议您调用SDK提供的方法直接埋点，这样将为您自动生成LTV、ARPU、ARRPU等游戏版专属数据分析模型***。[查看详情](http://wiki.mob.com/%E6%B8%B8%E6%88%8F%E7%89%88%E5%BB%BA%E8%AE%AE%E5%9F%8B%E7%82%B9%E4%BA%8B%E4%BB%B6/)

- - - - - - - - - - - -
集成中如遇到任何技术问题,欢迎咨询免费技术支持
QQ:4006852216
电话:400-685-2216




