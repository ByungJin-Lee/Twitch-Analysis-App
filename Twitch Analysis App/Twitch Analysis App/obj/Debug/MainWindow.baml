   M S B A M L   `   `   `  ����N  JTwitch Analysis App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Twitch_Analysis_App.ViewModelsTwitch_Analysis_App.ViewModels  5   	   c6clr-namespace:Twitch_Analysis_App.ViewModels.Converter(Twitch_Analysis_App.ViewModels.Converter  5   	   E'clr-namespace:Twitch_Analysis_App.ViewsTwitch_Analysis_App.Views  5   	   9!clr-namespace:Twitch_Analysis_AppTwitch_Analysis_App  5	   	   M+clr-namespace:Twitch_Analysis_App.StructureTwitch_Analysis_App.Structure  5
   	   $    Twitch_Analysis_App.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   C
ViewModels,clr-namespace:Twitch_Analysis_App.ViewModels     5   	   M
Converters6clr-namespace:Twitch_Analysis_App.ViewModels.Converter     5   	   9Views'clr-namespace:Twitch_Analysis_App.Views     5   	   3local!clr-namespace:Twitch_Analysis_App     5	   	   A	Structure+clr-namespace:Twitch_Analysis_App.Structure     5
   	     � Title$  
MainWindow��5   	   $	��600��6   $	��900��6)    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   ���#181735 � 	Resources 5      1  +Twitch_Analysis_App.ViewModels.TabViewModel   TabViewModel6  0Twitch_Analysis_App.ViewModels.ChattingViewModel  ChatViewModelK  ETwitch_Analysis_App.ViewModels.Converter.BooleanToColorBrushConverter   BooleanToColorBrushConverter   	TrueBrush   
FalseBrushG  ATwitch_Analysis_App.ViewModels.Converter.BooleanToStringConverter  BooleanToONOFFConverter   
TrueString   FalseString��%�   &	        &	      &	 &     &	 W       5   
   6"     5   
   6'     5   
    �#90EE90 �#FFCCCB6k     5   
   $ ON��6N   $	 OFF��6^   5      .��5       �  5#   
     tabRadioButton �� 
TargetType	 �� Triggers
 P� Property P� Value �� Property �� Value  ChattingTemplate  DefaultChatTitleBrush �� StringFormat �� Padding �� CornerRadius  DefaultChatBrush��%�  &	       &	      7  7  7  �� 5$      " 	�65   .R�5%      �� #��z��6#   	 5&      P� 5'      
 �@d�	IsChecked$ falseY�5)      . �5*      ��  � ��
 �����5,      5-      P� 5.      
 �@d�	IsChecked$
 trueY�50      . �51      ��  � ��
 �����53      54      56      �� 58      .R�59      �� .+�5:      ]� .+�5;      �� 8��  ��6X   �� *Name+�� 5<      $��4,0,0,0q�6$   8�� $��9(�6�   $��Bottom=�6�   ��6i   �� *Time+$ hh:mm:ss��6�   5=      �� 5>      $	 5,1q�6   $ 5��6+   $��0,2,0,0q�6<   8�� $��0q�5@      ._�5A      �� $
��Wrap=�6:   ��6$   �� *Chat+6:   5B      5C      5D      5F       � RowDefinitions 5K   
   �� 5L      $��25 �6   �� 5M       � ColumnDefinitions 5P   
   �� 5Q      $��2* �6   �� 5R      $��1* �6   .+�5W   
   � -   5        ���#0F0F2D$��2��5X       5[      �� 5\      �� 5]      �� 5^      �� 5_      �� 5`      �� 5a      �� 5b      �� 5c      �� 5d      .+�5i      	� #��[ 6   $��Twitch��5j      $��Center=�5k      $��Center=�5l      $��Assets/Fonts/#Dosis)�5m      $��Medium"�5n      $��0��5q       d� 	IsChecked$
 TrueY�5r      ��5o      ��  �� Path$ 
TabCommand� �� Source# [  ��5p      ��  �� RelativeSource �� *Self+5t      	� 5v      #��[ 6   $��Analysis��5w      $��Center=�5x      $��Center=�5y      $��Assets/Fonts/#Dosis)�5z      $��Medium"�5{      $��1��5~      $ FalseY�5      ��5|      �� $ 
TabCommand�# [  ��5}      ��  �� *Self+5�      	� 5�      #��[ 6   $��Configuration��5�      $��Center=�5�      $��Center=�5�      $��Assets/Fonts/#Dosis)�5�      $��Medium"�5�      $��2��5�      ��5�      �� $ 
TabCommand�# [  ��5�      ��  �� *Self+5�      	� 5�      #��[ 6   $��Download��5�      $��Center=�5�      $��Center=�5�      $��Assets/Fonts/#Dosis)�5�      $��Medium"�5�      $��3��5�      ��5�      �� $ 
TabCommand�# [  ��5�      ��  �� *Self+5�      �� 5�      $��Chatting��6   
�������$��6��5�      $��Center=�5�      $��Center=�5�      $��Assets/Fonts/#Dosis)�5�      $��Medium"�5�      �� 5�      $��4��6   $��Assets/Fonts/#Dosis)�6(   $��Center=�6I   $��Center=�6d   $��Connect��6�   ��6�   �� $ 	IsConnect�  TwitchViewModel# [  �� 	Converter# [ �� 5�      $��5��6   $��Assets/Fonts/#Dosis)�6(   $��Center=�6I   $��Center=�6d   $
��Join��6�   ��6�   �� $ IsJoin�# [ # [ �� 5�      $��7��6   $��Assets/Fonts/#Dosis)�6(   ���#fff$��Center=�6[   $��Center=�6v   ��6�   �� $ Channel�# [ � 5�      $��8��6   $��0��6#   $��2,2,2,2q�60    5�      �� 5�      �� 5�      .+�5�      �� -   5        $��_��5�      
�������$��0��5�      $
��Bold"�5�      ��5�      �� 5�       �� 
TargetType" ��6    .�5�      ��  � ��$ Assets/Fonts/#Dosis)�6G   �� 5�       � ��
 ����6;   �� 5�       �@�Cursor$
 Hand��67   5�      5�      �� 5�      -   5        $��X��5�      
�������$��1��5�      $
��Bold"�5�      ��5�      �� 5�      " ��6    .�5�      ��  � ��$ Assets/Fonts/#Dosis)�6G   �� 5�       � �� �#FE65846;   �� 5�       �@�Cursor$
 Hand��67   5�      5�      5�      5�      � 5�   
   $��1��6   $��5,5,5,5q�5�      .+�5�      �� ��5�      �� $	 Tab�# [  5�      �� 5�   
   
�������$��1q�5�      $��1��5�      $��1��5�      $	��5,5q�5�      ���#000051._�5�      �� $��0��6   
������ #��[ 5�      $��0q�5�      ��5�      �� $ Messages�# [ 5�      5�      5�      5�      