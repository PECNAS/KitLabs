   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	       �� 
TargetType �� Property �� Value��%R   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 36(�6)   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   .+�5    
   �� -   5        $��
StudentBtn��5       $��Student��6#   $��1��65   $��1��6E   6R   �� 5!   
   -   5        $��EventBtn��5!      $��Event��6!   $��3��61   $��1��6A   6N   �� 5"   
   -   5        $��	GroupsBtn��5"      $��Groups��6"   $��1��63   $��3��6C   6P   �� 5#   
   -   5        $��InstructorBtn��5#      $��
Instructor��6&   $��3��6;   $��3��6K   6X   �� 5$   
   -   5        $��
SubjectBtn��5$      $��Subject��6#   $��1��65   $��5��6E   6R   �� 5%   
   -   5        $��TimetableBtn��5%      $��	Timetable��6%   $��3��69   $��5��6I   6V   5&      5'      