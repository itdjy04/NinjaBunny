# NinjaBunny — 忍者兔子

> **2D 横向卷轴平台跳跃游戏 / 2D Side-Scrolling Platformer**
>
> 操控忍者兔子穿越充满陷阱的关卡，运用二段跳、墙壁跳跃、冲刺和 Pogo 弹跳抵达终点旗帜！
> Control a ninja bunny through treacherous levels using double jumps, wall jumps, dashes, and the pogo ability!

---

## 目录 / Table of Contents

- [游戏简介 / Summary](#游戏简介--summary)
- [操作说明 / Gameplay](#操作说明--gameplay)
- [关卡一览 / Levels](#关卡一览--levels)
- [游戏机制 / Mechanics](#游戏机制--mechanics)
- [开发环境 / Development](#开发环境--development)
- [项目结构 / Project Structure](#项目结构--project-structure)

---

## 游戏简介 / Summary

**中文**

NinjaBunny 是一款快节奏的 2D 横向卷轴动作冒险游戏。玩家将操控一只忍者兔子，穿越一系列充满致命陷阱和障碍的关卡。面对恐怖的地刺、旋转锯片、移动平台以及刺球发射器等挑战，你需要运用流畅的移动机制——二段跳、墙壁跳跃、冲刺以及独特的 "Pogo" 弹跳能力，才能征服 NinjaBunny 的重重考验！

**English**

NinjaBunny is an action-packed 2D side-scrolling adventure! Take control of a ninja rabbit as you navigate through treacherous levels teeming with deadly traps and formidable obstacles. Master double jumps, wall jumps, dashes, and the unique "pogo" ability to bounce off perilous obstacles and emerge victorious!

---

## 操作说明 / Gameplay

| 操作 / Action         | 按键 / Key          | 说明 / Description                       |
|-----------------------|----------------------|-------------------------------------------|
| 左右移动 / Move       | ← → / A D          | 控制角色水平移动 / Lateral movement       |
| 跳跃 / Jump           | 空格 / Space        | 按住时间越长跳得越高 / Hold for higher jump |
| 二段跳 / Double Jump  | 空中再按空格         | 空中执行第二次跳跃 / Second jump mid-air   |
| 墙壁跳跃 / Wall Jump  | 贴墙时按空格         | 从墙壁反弹跳起 / Rebound off walls         |
| 冲刺 / Dash           | Shift                | 快速水平冲刺，有冷却 / Burst of speed      |
| Pogo 弹跳 / Pogo      | 鼠标左键(空中)       | 弹开障碍物避免伤害 / Bounce off obstacles  |

---

## 关卡一览 / Levels

| 关卡 / Level | 场景 / Scene | 主题风格 / Theme | 描述 / Description |
|-------------|-------------|-----------------|-------------------|
| 教程关 / Tutorial | Scene 0 | 经典草地 / Classic Grassland | 引导玩家学习全部操作 / Learn all mechanics |
| 第一关 / Level 1 | Scene 1 | 粉橙天空 / Pink-Orange Sky | 纵向攀爬测试精准跳跃 / Vertical climbing challenge |
| 第二关 / Level 2 | Scene 2 | 白棕云朵 / White-Brown Cloud | 移动平台横向跨越 / Moving platforms traversal |
| 第三关 / Level 3 | Scene 3 | 地下迷宫 / Underground Maze | 狭窄通道 + 大量陷阱 / Tight corridors + traps |
| 胜利关 / Victory | Scene 4 | 庆祝场景 / Celebration | 通关庆祝，可选择重玩 / Victory celebration |

---

## 游戏机制 / Mechanics

### 核心移动系统 / Core Movement System

- **土狼时间 / Coyote Time** — 离开平台后 0.15 秒内仍可起跳 / Brief grace period after leaving a ledge
- **跳跃缓冲 / Jump Buffer** — 提前按下的跳跃键在落地时自动触发 / Queues jump input for 0.1s after landing
- **跳跃截断 / Jump Cut** — 松开跳跃键削减上升速度，实现可变跳跃高度 / Variable jump height by releasing space
- **下落重力增强 / Fall Gravity** — 下落时重力增加 1.2 倍，减少漂浮感 / Faster falling for precise landings

### Pogo 弹跳系统 / Pogo System

灵感来源于《空洞骑士》的下劈机制。玩家在空中可触发 Pogo OverlapBox 检测，碰撞到可弹跳对象时获得向上的速度脉冲并触发屏幕特效。

Inspired by *Hollow Knight*'s down-strike mechanic. Trigger a Pogo OverlapBox mid-air to bounce off obstacles with screen effects.

### 刺球发射器 / Spike Ball Shooter

发射器持续跟踪玩家位置，通过 `Mathf.Atan2` 计算角度、`Quaternion.RotateTowards` 平滑旋转，发射时暂时解除自身与子弹的碰撞避免卡弹。

The shooter tracks the player using `Mathf.Atan2` for angle calculation, rotates smoothly via `Quaternion.RotateTowards`, and temporarily disables self-projectile collision on fire.

### 航点巡逻系统 / Waypoint Follower

通用移动组件，挂载于锯片和移动平台。维护一个航点数组，抵达当前目标后切换到下一航点，循环巡逻。

A generic movement component for saws and platforms. Cycles through waypoints using `Vector2.MoveTowards`.

### 屏幕特效 / Screen Effects

- **冻结 / Freeze** — `Time.timeScale = 0` 实现瞬间暂停 / Instant pause via time scale
- **震动 / Shake** — 相机位置叠加随机偏移模拟震动 / Random offset on camera position

---

## 开发环境 / Development

| 项目 / Item         | 详情 / Detail                        |
|--------------------|--------------------------------------|
| 游戏引擎 / Engine  | Unity 2022.3                         |
| 编程语言 / Language | C#                                   |
| 美术资源 / Art     | Pixel Adventure 1 (Unity Asset Store) |
| 音效 / Audio       | Pixabay (BGM), Mixkit (SFX)          |
| 版本管理 / VCS     | Git + GitHub                         |

---

## 项目结构 / Project Structure

```
NinjaBunny-main/
├── README.md                   # 本文件
├── media/                      # 截图与演示 GIF
│   ├── Level1.png
│   ├── PlayerAnimator.png
│   ├── CoyoteTime.gif
│   └── ...
└── NinjaBunny/                  # Unity 项目目录
    ├── Assets/
    │   └── NinjaBunny/
    │       └── Scripts/
    │           ├── PlayerController.cs     # 玩家控制器
    │           ├── CameraController.cs     # 镜头控制器
    │           ├── SpikeBallShooterController.cs  # 刺球发射器
    │           ├── WaypointFollower.cs     # 航点巡逻
    │           ├── StickyPlatform.cs       # 粘性平台
    │           ├── LevelController.cs      # 关卡控制
    │           └── MenuScripts/            # 菜单脚本
    └── ProjectSettings/
```

---

## 更多作品 / More Projects

如果感兴趣，欢迎访问我的 [GitHub 主页](https://github.com/itdjy04) 查看更多项目！
Feel free to visit my [GitHub profile](https://github.com/itdjy04) for more projects!

---

*NinjaBunny — 用 Unity 2022 + C# 开发 / Developed with Unity 2022 + C#*
