Twitch-Analysis-App
===
Summary
---

+ Developer - byungjin.dev@gmail.com

This Application is advanced Twitch Analysis Application in Java.

The reason why i make this application, Java's GUI is not good at modern design.

Priod - 2021/06/01 ~

Language - C#, XAML(WPF)

DataBase - MongoDB

+ Why i choose C# WPF for enhancing quality of GUI?
    + So I have two way to enhance UI Design. Electron and WPF Application.
    + But I used to develop JavaScript Application like node.js or Web.
    + At first, I think that i choose Electron but Electron Application is so big in Volume.
    + As that reason, I select C# WPF.

TODO List
---
+ UI Design
    + Whole Layout Design
    + Chat Layout Design
    + Chat Item Design
    + DataBase Tab Design
    + DownLoad Tab Design
    + Analysis Tab Design
    + Download Tab Design
    + Twitch Tab Design
+ ViewModel
    + Chat View
    + Configuration View
    + DataBase Collection View    
    + XLSX Download View
+ Model
    + ~~TCPClient for connecting IRC Server~~
        + ~~Connect IRC Server~~
        + ~~Get Message~~
        + ~~JOIN~~
        + ~~CHAT~~
        + ~~PART~~
        + ~~ChatEvent~~
    + DataBase Interaction
    + Management Chatting
    + ~~Configuration File I/O~~
    + XLSX File Output
+ Write Detail Comment
   
Commit Log
---
+ 1.0.0 - Init Application Setting
   
+ 1.1.0 - Tab
    + created TabViewModel
    + created TabCommand
    + binded XAML to ViewModel
+ 1.1.1 - TODO List
    + create TODO List
   
+ 1.2.0 - Models
    + created IRCClient
        + TcpClient
    + created Configuration
        + File I/O
        + EnviromentKeys
+ 1.2.1 - More Detail
    + READMD DOTO list
   
+ 1.3.0 - Updated Model & ViewModel
    + Model
        + Improved IRCClient
            + chatToChannel
            + Join
            + Part
            + Chat Event
    + ViewModel
        + deleted Types
        + created View(TwitchView)
        + created ViewModel(TwitchViewModel)
        + created Command(ConnectCommand)
   
+ 1.3.2 - ViewModel
    + created Twitch ViewModel
    + created Twitch View

+ 1.4.0
    + fixed cross Thread
    + checked running of Logs Collection
+ 1.4.1
    + Improved README
+ 1.4.21
    + IRCClient
        + allocated TIMEOUT on Connection
+ 1.4.3
    + Improved Folder Structure
+ 1.4.31
    + Updated README
        + writed Developer's name
+ 1.4.4
    + Check Environment
+ 1.4.5
    + ChattingViewModel
        + Binding MessageCollection
    + IRCClient
        + Updated OnChat Event        