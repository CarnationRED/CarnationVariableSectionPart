﻿# CarnationVariableSectionPart
 
Using Unity2019.2.2f1 VisualStudio2019

2020.3.5：基本功能有了，这几天主要在小修小补，搞编辑器中物体联动的算法，中间推翻了一次。

和PP这个mod对比了一下，流畅度真不一样。903parts，pp加载慢不说，打开飞船，显示出来后还要卡一次，时间和加载本身差不多。点了发射后，pp版本直接加载不出了，用我的mod可以达到10帧，加载也很快。

 使用：
 
    1.对着零件按P开启编辑，拖动手柄改变形状和扭转    
    2.按Ctrl+P，可以复制当前编辑的零件形状到鼠标指着的另外一个零件
    3.小键盘1379可以对零件进行偏移
    4.调整圆角大小时，试试按住左Shift、左Ctrl、左Alt，有惊喜
 TO-DOs:
 
    1.√ 动态计算油箱本体重量 
    2.√ 计算更新重心位置 
    3.打开编辑手柄后，显示一个面板可以拖动、输入尺寸，提供接口来更换贴图、切换参数
    4.√ 更新模型切线数据、添加支持法线贴图
    5.异步生成模型
    6.√ 计算更新干重、干Cost
    7.切换油箱类型
    8.曲面细分（是不是有点高大上，手动滑稽）
    9.堆叠起来的两个零件，截面形状编辑可以联动
    10.（有可能会做的）零件接缝处的法线统一化，这个有时候可以提高观感
    11.（也可能会做的）提供形状不一样的圆角，现在只有纯圆的，按照目前算法添加新形状不是特别难
    12.切分零件、合并零件，且不改变形状
    13.RO\RF
    14.√ 隐藏堆叠部件的相邻Mesh
 BUG:
 
    1.兼容性几乎没测试，欢迎提出！！
