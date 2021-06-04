Twitch-Analysis-App
===
Summary
---

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
+ ViewModel
    + Chat View
    + Configuration View
    + DataBase Collection View    
    + XLSX Download View
+ Model
    + TCPClient for connecting IRC Server
    + DataBase Interaction
    + Management Chatting
    + Configuration File I/O
    + XLSX File Output

Commit Log
---
+ 1.0.0 - Init Application Setting

+ 1.1.0 - Tab
    + created TabViewModel
    + created TabCommand
    + binded XAML to ViewModel

+ 1.1.1 - TODO List
    + create TODO List