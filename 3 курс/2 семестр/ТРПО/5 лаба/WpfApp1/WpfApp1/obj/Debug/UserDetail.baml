   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.UserDetail   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � 
ResizeMode$  NoResize=�5   	   $	��810��5	   	   $
��1440��6   ���#ECF0F3 � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
UserDetail��5   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$	 290��6&   �� 5       � �� �#0a14516+   �� 5       � �� �#0a14516,   �� 5       � ��$ 28(�6)   �� 5       � �� �#FFFFFF6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��.15* �6   �� 5      $	��.7* �6   �� 5      $
��.15* �6   .+�5   
   �� $��0��6   ���#0A1451 �� Orientation$ 
Horizontal=�67   $��Center=�6P   .+�5      �� -   5        $��КУРАТОРЫ��5      6(   �� 5      -   5        $��СТУДЕНТЫ��5      6(   �� 5       -   5        $ ��ПРЕПОДАВАТЕЛИ��5       6-   �� 5!      -   5        $��РОДИТЕЛИ��5!      6(   �� 5"      $��ЗАЧЁТКИ��6   5#      �� 5%   
   $��1��6   .+�5&      �� $��Source/avatar guest.png��6   $	��416��65   $	��394��6B   $
��Left=�6N   $��Center=�6i   �� 5'      -   5        $
��Name��5'      $��36(�6$   $
��Bold"�62   $#��Бусов Владислав��6E   	 �� Left$		 430��6\   

 �� Top$
 97��6n   �� 5(      -   5         � Cursor$
 Hand��5(      $��Source/edit.png��65   $��20��6N   $��20��6Y   $		 404��6e   $	
 111��6w   $��Center=�6�   $	��Top=�6�    J� RenderTransformOrigin$ 	0.6,0.117&�6�   �� 5)      -   5        $��Phone��5)      $��24(�6%   $��Light"�63   $��+79196395387��6F   $		 571��6Z   $	
 150��6l   $
��Left=�6}   $��Center=�6�   $	��320��6�   �� 5*      -   5        $
 Hand��5*      $��Source/edit.png��66   $��21��6O   $��20��6Z   $		 538��6f   $	
 162��6x   $
��Left=�6�   $��Center=�6�   �� 5+      -	   5        $��BDate��5+      $��24(�6%   $��Light"�63   $��
15.07.2006��6F   $		 578��6X   $	
 182��6j   $
��Left=�6{   $��Center=�6�   $	��229��6�   �� 5,      -
   5        $
 Hand��5,      $��Source/edit.png��66   $��21��6O   $��20��6Z   $		 538��6f   $	
 188��6x   $
��Left=�6�   $��Center=�6�   �� 5-      -   5        $��Group��5-      $��24(�6%   $��Light"�63   $
��4338��6F   $		 578��6R   $	
 214��6d   $
��Left=�6u   $��Center=�6�   $	��108��6�   �� 5.      -   5        $
 Hand��5.      $��Source/edit.png��66   $��21��6O   $��20��6Z   $		 538��6f   $	
 220��6x   $
��Left=�6�   $��Center=�6�   �� 5/      -   5        $��Curator��5/      $��24(�6'   $��Light"�65   $��Гимадеев И.Ф.��6H   $		 578��6]   $	
 246��6o   $
��Left=�6�   $��Center=�6�   $	��323��6�   �� 50      -   5        $
 Hand��50      $��Source/edit.png��68   $��21��6Q   $��20��6\   $		 538��6h   $	
 252��6z   $
��Left=�6�   $��Center=�6�   �� 51      -   5        $��Parent��51      $��24(�6&   $��Light"�64   $��Гимадеев И.Ф.��6G   $		 578��6\   $	
 278��6n   $	��712��6   $
��Left=�6�   $��Center=�6�   �� 52      -   5        $
 Hand��52      $��/Source/edit.png��67   $��21��6Q   $��20��6\   $		 538��6h   $	
 285��6z   $��Center=�6�   $��Center=�6�   �� 53      -   5         ��Name$  Phone_Копировать��53      $��20(�62   $
��Bold"�6@   $		 424��6R   $	
 151��6d   $	��114��6u   $��Center=�6�   $��Center=�6�   �� 6�    � Language$ ru-ru�6�   $�Телефон:��6�   6�   �� 54      -   5        $! Phone_Копировать1��54      $��20(�63   $
��Bold"�6A   $		 424��6S   $	
 182��6e   $	��114��6v   $��Center=�6�   $	��Top=�6�   �� 6�   $ ru-ru�6�   $�	Д. Р. :��6�   6�   �� 55      -   5        $! Phone_Копировать2��55      $��20(�63   $
��Bold"�6A   $		 424��6S   $	
 215��6e   $	��114��6v   $��Center=�6�   $	��Top=�6�   �� 6�   $ ru-ru�6�   $�Группа:��6�   6�   �� 56      -   5        $! Phone_Копировать3��56      $��20(�63   $
��Bold"�6A   $		 424��6S   $	
 245��6e   $	��114��6v   $��Center=�6�   $	��Top=�6�   �� 6�   $ ru-ru�6�   $�Куратор:��6�   6�   �� 57      -   5        $! Phone_Копировать4��57      $��20(�63   $
��Bold"�6A   $		 424��6S   $	
 280��6e   $	��114��6v   $��Center=�6�   $	��Top=�6�   �� 6�   $ ru-ru�6�   $�Родители��6�   �� 6�   $�:��6�   6�   58      �� 5:   
   $��2��6   ���#0A14515>      5?      5@      