   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	   5clr-namespace:WpfApp1.TemplatesWpfApp1.Templates  5	   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   .ucclr-namespace:WpfApp1.Templates     5	   	   -   5          � 
ResizeMode$  NoResize=�5   	    � Title$ 
MainWindow��5   	   $	��600��6   $	��900��6)    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  '��       �� 5   
   " ��6   .�5      ��  � �� �#E8EEFC6+   �� 5       � ��$ 22(�6)   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$	 180��6&   �� 5       � ��$
 0, 4q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 10��6!   #��z��5   !   ._�5      �� #��z��6/   #��z��5   /   5      5      5      �� 5       � ��$ 40��6'   5      5       .��5!      �  � ColumnDefinitions 5"   
   �� 5#      $��* �6   �� 5$      $	��.3* �6   	 � RowDefinitions	 5&   
   �� 5'      $
��.24* �6   �� 5(      $��* �6   .+�5+   
   � $��0��6   $��0��5,      ���#E8EEFC$��Stretch=�5.      $��Stretch=�5/      .+�50      �� $��НАЗВАНИЕ��6   $��30(�51      $��
Montserrat)�52      $��Light"�53      $��280, 35, 0, 0q�54      55      � 57   
   $��0��6   $��1��58      ���#E8EEFC.+�5:      �� $��ЛОГОТИП��6   $��30(�5;      $��
Montserrat)�5<      $��Light"�5=      $��40, 35, 0, 0q�5>      5?      � 5A   
   $��1��6   $��1��5B      
 � Orientation$
 Vertical=�5C      ��5D      �� 5E       �� ImageSource$ Resources/backimage.png��6    j� Stretch$
 Fill=�5F      .+�5H      �� $��Resources/logo.png��6   $��80��5I      $��60, 20q�5J      �� 5K      $��Фамилия Имя��6   ���#FFFFFF$��22(�5M      $��Light"�5N       �� TextAlignment$ Center=�5O      �� 5Q      .+�5R      �� -   5        $��StudentsBtn��5R      $��Учащиеся��5S      5T      �� 5U      -   5        $��InstructorsBtn��5U      $��Инструкторы��5V      5W      �� 5X      -   5        $��
TicketsBtn��5X      $��Билеты��5Y      5Z      �� 5[      -   5        $��CarsBtn��5[      $��Машины��5\      5]      �� 5^      -   5        $��	ExportBtn��5^      $��Экспорт��5_      5`      5a      5b      � 5d   
   -   5        $��WidgetPlace��5f      $��1��5d      $��0��5e      $��Center=�5g      $��Center=�5h      .+�5i      !   WpfApp1.Templates.DBLoading  6   5j      5m      5n      