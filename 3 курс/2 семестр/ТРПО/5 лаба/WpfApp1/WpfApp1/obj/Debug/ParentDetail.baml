   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.ParentDetail   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � 
ResizeMode$  NoResize=�5   	   $	��810��5	   	   $
��1440��6   ���#ECF0F3 � WindowStartupLocation$ CenterScreen=�5   	    � Title$ ParentDetail��5   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$	 290��6&   �� 5       � �� �#0a14516+   �� 5       � �� �#0a14516,   �� 5       � ��$ 28(�6)   �� 5       � �� �#FFFFFF6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��.15* �6   �� 5      $	��.7* �6   �� 5      $
��.15* �6   .+�5   
   �� $��0��6   ���#0A1451 �� Orientation$ 
Horizontal=�67   $��Center=�6P   .+�5      �� -   5        $��КУРАТОРЫ��5      6(   �� 5      -   5        $��СТУДЕНТЫ��5      6(   �� 5       -   5        $ ��ПРЕПОДАВАТЕЛИ��5       6-   �� 5!      -   5        $��РОДИТЕЛИ��5!      6(   �� 5"      $��ЗАЧЁТКИ��6   5#      �� 5%   
   $��1��6   .+�5&      �� $��Source/avatar guest.png��6   $	��416��65   $	��433��6B   �� 5'      -   5        $
��Name��5'      $��36(�6$   $
��Bold"�62   $#��Бусов Владислав��6E   	 �� Left$		 721��6\   

 �� Top$
 97��6n   $
��Left=�6~   $��Center=�6�   $	��470��6�   �� 5(      -   5         � Cursor$
 Hand��5(      $��Source/edit.png��65   $��22��6N   $��20��6Y   $		 698��6e   $	
 111��6w   $
��Left=�6�   $��Center=�6�    J� RenderTransformOrigin$ 	0.6,0.117&�6�   �� 5)      -   5        $��Phone��5)      $��24(�6%   $��Light"�63   $��+79196395387��6F   $		 726��6Z   $	
 150��6l   $
��Left=�6}   $��Center=�6�   $	��230��6�   �� 5*      -   5        $
 Hand��5*      $��Source/edit.png��66   $��22��6O   $��20��6Z   $		 698��6f   $	
 162��6x   $
��Left=�6�   $��Center=�6�   �� 5+      -	   5        $��Email��5+      $��24(�6%   $��Light"�63   $��
15.07.2006��6F   $		 730��6X   $	
 182��6j   $
��Left=�6{   $��Center=�6�   $	��165��6�   �� 5,      -
   5        $
 Hand��5,      $��Source/edit.png��66   $��22��6O   $��20��6Z   $		 698��6f   $	
 188��6x   $
��Left=�6�   $��Center=�6�   �� 5-      -   5        $��	Workplace��5-      $��24(�6)   $��Light"�67   $
��4338��6J   $		 730��6V   $	
 214��6h   $
��Left=�6y   $��Center=�6�   $��79��6�   �� 5.      -   5        $
 Hand��5.      $��Source/edit.png��6:   $��22��6S   $��20��6^   $		 698��6j   $	
 220��6|   $
��Left=�6�   $��Center=�6�   �� 5/      -   5         ��Name$ Name_Копировать��5/      $��20(�61   $
��Bold"�6?   $		 610��6Q   $	
 150��6c   $��83��6t   $
��Left=�6   $��Center=�6�   �� 6�    � Language$ ru-ru�6�   $�Номер:��6�   6�   �� 50      -   5        $  Name_Копировать1��50      $��20(�62   $
��Bold"�6@   $		 610��6R   $	
 185��6d   $��72��6u   $
��Left=�6�   $��Center=�6�   �� 6�   $�
Почта��6�   �� 6�   $ ru-ru�6�   $�:��6�   6�   �� 51      -   5        $  Name_Копировать2��51      $��20(�62   $
��Bold"�6@   $		 610��6R   $	
 214��6d   $��74��6u   $
��Left=�6�   $��Center=�6�   �� 6�   $ ru-ru�6�   $�Группа:��6�   6�   52      �� 54   
   $��2��6   ���#0A145158      59      5:      