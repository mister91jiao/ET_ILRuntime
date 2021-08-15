# 基于 ET(Commits1532版本)的接入ILRuntimeV1.6.7热更

### 参考引用了一下大佬的代码
[最弱的菜鸡] https://gitee.com/JFZN/et6.0-ilruntime

[神女阿芙萝狄] https://github.com/zeusgame1/ET

[烟雨迷离半世殇] https://www.lfzxb.top/et-6-with-ilruntime/

[字母哥Binary] Unity内打程序集思路

# 本工程特点
尽可能维持了ET原有的代码结构

保留了ET自带的Demo

编码状态下使用四个程序集约束开发，运行时一键将四个程序集下的代码编译成一个总程序集用于热更

转表工具和Proto生成代码工具都已进行修改，无需手动修改生成出来的代码

提供了Mono运行时和ILRuntime下一键切换的开关

# 使用方法
1. 确保 Global 物体下的Init勾选了ILRuntimeMode
2. 打开工具(Tools/打卡服务器选项)
3. 点击构建DLL(ps. 构建完成的DLL在Unity\Temp\MyAssembly下，会自动Copy到工程的Resources/Code里)
4. 点击刷新资源
5. 每次修改代码后需要重复3.4.两个步骤

# 待完善问题
1. ILRuntime模式下"ObjectWait.Wait<T>"方法会有CancellationToken重复取消问题，导致AI系统可能会有Bug
2. 代码结构缺乏整理
3. 一些宏定义也需要进一步整理

# 相关链接

[ET框架] https://github.com/egametang/ET
