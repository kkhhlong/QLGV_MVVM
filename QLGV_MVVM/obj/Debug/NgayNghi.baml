   M S B A M L   `   `   `  ����D  @QLGV_MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QLGV_MVVM	QLGV_MVVM  5   	       QLGV_MVVM.NgayNghi   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:QLGV_MVVM     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignFont#���   5	   
     MaterialDesignBody#���  5
      $
��Bold"�5      
�������$��13(�5        
NgayNghiVM  � DataContext#  [ 5   	    � Title$ NgayNghi��5   	   $	��520��6   $	��700��6'    � 
ResizeMode$ NoResize=�63   .��5      ]� .+�5   
   �� 
���   �$��2 0 2 0q�6&   $	��524��6B   $��Stretch=�6N    �� Padding$ 50q�6j   ._�5      � $��	0 10 0 0 q�6    � ColumnDefinitions 5      �� 5      $��50 �6'   �� 5      $��50 �6'   �� 5      $��50 �6'   �� 5      $��50 �6'   �� 5      $��50 �6'   �� 5      $��50 �6'   �� 5      $��50 �6'   �� 5      $��50 �6'    � RowDefinitions 5      �� 5      $��60 �6$   �� 5      $��60 �6$   �� 5       $��30 �6$   �� 5!      $��60 �6$   �� 5"      $��27 �6$   �� 5#      $��80 �6$   �� 5$      $��60 �6$   .+�5&      �� $��0��6   $��1��6%   $��6��65   $��20(�6I   $��Center=�6X   .��6u   $"Thêm ngày nghỉ toàn trường6�   �� 5(      $��Medium"�6   $��18(�6-   $��5q�6;   $��40��6H   $��2��6T   $��4��6a   $��1��6q   .��6�   Đến6�   � 5+      $��Center=�6   $��0 0 0 10q�6:   $��1��6L   $��1��6Z   $��6��6j   .+�5-      �� $
��90px��6   $��5 5 15 5q�6l   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tiết Bắt Đầu��6~    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6+   �� *
TietBatDau+ �� UpdateSourceTrigger$ PropertyChanged=�6�   (  "System.Windows.Controls.DatePicker  54      $��Center=�6!   $	��120��6`   $��	5 5 15 -7q�6l   $ Ngày bắt đầu��6    ( $MaterialDesignFloatingHintDatePicker#��[ 6�      SelectedDate 6<   �� *
NgayBatDau+6�   5:      � 5<      $��Center=�6   $��0 0 0 10q�6:   $��3��6L   $��1��6Z   $��6��6j   .+�5>      �� $
��90px��6   $��5 5 15 5q�6m   $ Tiết kết thúc��6   #��[ 6�   ��6+   �� *TietKetThuc+$ PropertyChanged=�6�     5E      $��Center=�6#   $	��120��6c   $��	5 5 15 -7q�6o   $ Ngày kết thúc��6�   #��[ 6�    6>   �� *NgayKetThuc+6�   5K      �� 5N      $
��Bold"�6   $��4��6,   $��4��6@   $��2��6M   .��6]   
Ghi Chú6f   �� 5O      
�������$��5��6E   $��5��6R   $��2��6f   $��2q�6v   $��13(�6�   $��5q�6�   	 �� TextAlignment$
	 Left=�6�   
 �� TextWrapping$

 Wrap=�6�   $��1,0,50,0q�6�   ��6-   �� *GhiChu+6�   �� 5Q      $��6��64   $��4��6A   $��2��6Q   $��40��6e   $��0 0 7 0q�6r   
�������$��2q�6�   $��15(�6�   $
��Bold"�6�   ��6   �� *ILuu+.��6�   Nghỉ6�   �� 5R      $��6��65   $��2��6B   $��2��6R   $��40��6f   $��0 0 7 0q�6s   
�������$��2q�6�   $��15(�6�   $
��Bold"�6�   ��6   �� *IUndo+.��6�   	Đi Học6�   5T      5U      5W      5X      