# 基于插图98的程序框架
![插图98](picture98.jpg)
## 程序框架化分解
- 地图系统
  - 时间限制器
  - 大地图
    - 场景转跳
  - 小地图
    - 线索（类）的派发（实例化）
    - 玩家的寻路系统
  

- 战斗系统
    - 移动系统
      - asdw键盘移动:四个自由度,移动物体为2D贴图
      - 鼠标点击寻路方案
    - 事件动画触发状态机
    - 战斗逻辑行为生成器
    - 伤害判断系统
      - 命中率骰子
      - 命中部位和要害
    - 行动点限制器

- 敌人系统
  - 敌人生成器
  - 敌人行为器

## 地图系统
- 时间限制器：
1. 脚本名：timeLimitation
2. 构造timePass方法，接收外部时间流逝的指令和参数。
   <br/>timeLimitation.timePass(int passedSeconds)
3. 创建一个canvas实例，利用sprite制作简单的计时器
4. 建立一个公共变量，命名为timeRest，将剩余时间赋值给timeRest
5. 要点：避免使用开销过大的脚本生命周期,建议使用协程
6. [参考资料1：实现倒计时的功能](https://blog.csdn.net/qq_42672770/article/details/105603707?utm_medium=distribute.pc_relevant.none-task-blog-title-2&spm=1001.2101.3001.4242)   
7. [参考资料2：sprite动画总结](https://blog.csdn.net/WangHaoDiablo/article/details/52838583?locationNum=10&fps=1)
8. [参考资料3：协程总结](https://blog.csdn.net/yangguihao/article/details/105638453)
9. [参考资料4：获得子物体](https://blog.csdn.net/wangjianxin97/article/details/81704670)

- 棋盘框架
1. 棋盘框架脚本：chessBoardManager
    1. 获得棋盘的大小参数
    2. (封印)动态规划需要渲染的格子
2. 棋盘对象池脚本：blocksPool
    1. 储存<vector2Int,gameobject>映射
    2. 提供外界方法：spawnBlock生成，recycleBlock回收
    3. 设定基本方法：distributeBlock，实例化指定预制体，并且并入映射统一管理
3. 线索派发脚本：cluesCompiler
    1. 序列化了ClueList，提供一个指定位置指定种类的inspector编辑窗口
    2. 自动在游戏开始时完成线索的分配
4. 棋盘系统空物体：chessBoard
5. 实现功能：<br/>
   1. 棋盘主体：根据chessBoardManager脚本获得的boardScale参数（vector2Int），生成大小的棋盘映射，并将其填充到对象池中
   2. 根据相机位置，动态规划需要渲染的blocks
   3. 线索派发器：序列化一个结构体clue的List，命名为clueList，定义结构体，命名为clue，在inspector视窗里提供编辑clue数量，clue位置和clue种类（颜色暂定）的功能
6. [参考资料1：国际象棋案例](https://blog.csdn.net/kmyhy/article/details/82690409)
7. [参考资料2：生成国际象棋棋盘](https://blog.csdn.net/qq_43427963/article/details/98474354?utm_medium=distribute.pc_relevant.none-task-blog-BlogCommendFromBaidu-8.not_use_machine_learn_pai&depth_1-utm_source=distribute.pc_relevant.none-task-blog-BlogCommendFromBaidu-8.not_use_machine_learn_pai)
