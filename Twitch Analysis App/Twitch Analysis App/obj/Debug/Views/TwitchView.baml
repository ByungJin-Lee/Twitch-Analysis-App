   M S B A M L   `   `   `  ����N  JTwitch Analysis App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Twitch_Analysis_App.ViewModelsTwitch_Analysis_App.ViewModels  5      E'clr-namespace:Twitch_Analysis_App.ViewsTwitch_Analysis_App.Views  5      c6clr-namespace:Twitch_Analysis_App.ViewModels.Converter(Twitch_Analysis_App.ViewModels.Converter  5      K*clr-namespace:Twitch_Analysis_App.SelectorTwitch_Analysis_App.Selector  5	      M+clr-namespace:Twitch_Analysis_App.StructureTwitch_Analysis_App.Structure  5
      *    $Twitch_Analysis_App.Views.TwitchView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      C
ViewModels,clr-namespace:Twitch_Analysis_App.ViewModels     5      9local'clr-namespace:Twitch_Analysis_App.Views     5      M
Converters6clr-namespace:Twitch_Analysis_App.ViewModels.Converter     5      ?Selector*clr-namespace:Twitch_Analysis_App.Selector     5	      A	Structure+clr-namespace:Twitch_Analysis_App.Structure     5
        � 	Resources  5      K  ETwitch_Analysis_App.ViewModels.Converter.BooleanToColorBrushConverter   WarningToBrushConverter   	TrueBrush   
FalseBrushG  ATwitch_Analysis_App.ViewModels.Converter.BooleanToStringConverter  ConnectToStringConverter   
TrueString   FalseString  JoinToStringConverter  Log_Left �� StringFormat �� CornerRadius �� Padding �� 	Converter  	Log_Right  Style_Log_Left	 �� 
TargetType
 �� Property �� Value �� 
TargetType ��Name  Style_Log_Right6  0Twitch_Analysis_App.Selector.LogTemplateSelector  LogTemplateSelector   LeftTemplate   RightTemplate   PropertyToCheck   PropertyValue3  -Twitch_Analysis_App.Selector.LogStyleSelector  LogStyleSelector   	LeftStyle   
RightStyle   PropertyToCheck   PropertyValue��%�  &	        &	 5     &	 l     &	 �     7   &	 �    7   &	 �    &	 T    '��     '�� i    &	 �    7  7  &	 �    7  7    5   
    �#FFCCCB �#90EE905   0     5   
   $ 
Disconnect��6O   $ Connect��6g     5   
   $
 Exit��6L   $
 Join��6^   �� 5   
   .R�5      �� $	��0,1q�6   .+�5      ]� .+�5      �� $
��Bold"�68   
���������6    �� *Source+6J   �� 5      $��5,0,0,0q�6    $��Bottom=�61   
�������$��9(�6�   ��6_   �� *Time+$ hh:mm:ss��6�   5      �� 5      $ 5��5      $	 8,2q�5       $��0q�5!      ��5      �� *	Warning+8   ._�5"      �� $
��Wrap=�69   $��2,1,1,2q�6M   
���   ���6    �� *	Content+6^   5#      5$      5%      �� 5'   
   .R�5(      �� $	��0,1q�6   .+�5)      ]� .+�5*      �� $��Right=�6    
�������$��5,0,0,0q�6O   $��Bottom=�6`   $��9(�6�   ��6{   �� *Time+$ hh:mm:ss��6�   �� 5+      $��Right=�6    
�������$
��Bold"�6g   ��6O   �� *Source+6g   5,      �� 5-      $ 5��5.      $	 8,2q�5/      $��0q�50      ��5-      �� *	Warning+8   ._�51      �� $
��Wrap=�69   $��2,1,1,2q�6M   
���   ���6    �� *	Content+6^   52      53      54      �� 57   
   "	 ��6'   .�58      �� 
 � �� 59      �� 5:      " ��6&   .R�5;      �� $ PART_ListBoxItem��6+   $
��Left=�5<   #   $��5,0,20,5q�5=   #   5>      5@      5A      �� 5B   
   "	 ��6(   .�5C      �� 
 � �� 5D      �� 5E      " ��6&   .R�5F      �� $ PART_ListBoxItem��6+   $��Right=�5G   #   $��20,0,5,5q�5H   #   5I      5K      5L      �� 5N   
   "	 ��6   .�5O      �� 
 � ��
 ���� 6+   5P      �� 5Q   
   "	 ��6   .�5R      �� 
 � ��
 �����6+   5S        5U   
   8   8  $ Warning��5W   +   $
 True��6E     5Y   
   8   8  $ Warning��5[   (   $
 True��6B   5]      .��5`      �  � ColumnDefinitions 5b   
   �� 5c      �� 5d       � RowDefinitions 5f   
   �� 5g      $��25 �6   �� 5h      .+�5m   
   � $��0,5,5,0q�6    5o      �� 5p      �� 5q      .+�5v      �� -   5         ��Name$ 
channelTxt��5w      $�� ��5v      .��5w   %     5x       �� 	Resources��%�   '��       �� 5y      "	 ��6   .�5z      �� 
 � ��
 �����67    5{      ���� 5|      '��       "	 ��6$   .�5}   "   �� 
 �@��CornerRadius$ 4��6A   5~      5      5�      5�      .��6%   5�      � 5�      $��1��6    5�      �� 5�      �� 5�        5�       	 Key �� Triggers P� Property P� Value��%�  '��       �� 5�      "	 ��6   .�5�      �� 
 � �� �#00067   �� 5�      
 � �� �#fff67   �� 5�      
 � ��$ 2,0,0,0q�63    5�      ���� 5�      '��       "	 ��6$   .�5�   "   �� 
 �@��CornerRadius$ 4��6A   5�      �� 5�      con	   5�   "   ���� 5�   &   '��       "	 ��6,    5�   *   P� 5�   .    �@J�IsMouseOver . . �5�   2   �� 
 � ��
 �  ��6O   5�   /   5�   '   5�   #   5�      5�      5�      5�      .+�5�      �� ��6   ��  �� Path$ 	IsConnect� 
 TwitchViewModel �� Source# [
 # [ ��5�      �� $ connectCommand�# [
 �� 5�      $��1��5�      ��5�      �� $ IsJoin�# [
 # [ ��5�      �� $ enterCommand�# [
 ��5�      �� $
 Text� �� ElementName$ 
channelTxt��5�      5�      �� 5�   
   $��1��6   $��0��6   #��[ 5�      $��0,5,5,0q�6N   #��[ 5�      ��5�      �� $ LogCollection�# [
 5�      5�      5�      