   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp1.TemplatesWpfApp1.Templates  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WpfApp1.Templates     5   	   -   5          � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � 	Resources 5       �� 
TargetType �� Property �� Value��%8  '��       �� 5   
   " ��6   .�5      ��  � ��$ 10, 0q�6'   �� 5       � ��$	 100��6&   �� 5       � ��$ 35��6'   �� 5       � ��
 � ���6+   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ DemiBold"�6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��.15* �6   �� 5      $��* �6   �� 5      $
��.15* �6    � ColumnDefinitions 5   
   �� 5      -   5         �Name$ WidthCol��5   )   $��* �6   6)   .+�5    
   � 
��� � �$��0��5!      $��0��5"      $��Stretch=�5#      $��Stretch=�5$      .+�5%      �� -   5        $��	PageTitle��5*      $��Главная��5%      $��22(�5&      $
��Bold"�5'      
�������$��360, 0, 0, 0q�5)      5*      5+      � 5-   
   -   5        $��WidgetPlace��50      $��Center=�5-      $��Center=�5.      $��1��5/      .+�51      !   WpfApp1.Templates.DBLoading  6    52      � 53   
   $��2��6   $��Center=�54      $��Center=�55      .+�56      �� -   5        $��MainBtn��56   '   ${�False��6   $��Главная��66   6H   �� 57      -   5        $��UsersBtn��57   '   ${�False��6   $��Пользователи��67   6N   �� 58      -   5        $��ItemsBtn��58   '   ${�False��6   $��Товары��67   6H   �� 59      -   5        $��BuiesBtn��59   '   ${�False��6   $��Покупки��67   6I   �� 5:      -	   5        $��	ExportBtn��5:   '   ${�False��6   $��Экспорт��68   6J   �� 5;      -
   5        $��AuthBtn��5;      $��
Войти��6$   ${�false��64   6F   5<      5=      5>      