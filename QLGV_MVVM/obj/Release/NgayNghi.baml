   M S B A M L   `   `   `  ���� D  @QLGV_MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QLGV_MVVM	QLGV_MVVM      QLGV_MVVM.NgayNghi   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:QLGV_MVVM     V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignFont#���     MaterialDesignBody#���  $
��Bold"����#9e9e9e$��13(�  
NgayNghiVM  � DataContext#  [  � Title$ NgayNghi��$	��520��$	��700�� � 
ResizeMode$ NoResize=�.��]� .+��� 
���   �$��2 0 2 0q�$	��524��$��Stretch=� �� Padding$ 50q�._�� $��	0 10 0 0 q� � ColumnDefinitions �� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 � � RowDefinitions �� $��60 ��� $��60 ��� $��30 ��� $��60 ��� $��27 ��� $��80 ��� $��60 �.+��� $��0��$��1��$��6��$��23(�.��$"Thêm ngày nghỉ toàn trường(� $��3��$��4��$��1��$
��Left=�$	��186��$��50�� � 	Resources :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property	 �� Value��%i   '        �� "  .���  � ��$	 Ngày Bắt Đầu����  � ��$	 2q���  � ��$		 100��.��(  "System.Windows.Controls.DatePicker  $��0q�
   SelectedDate
 �� *
NgayBatDau+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��Medium"�$��18(�$��5q�$��40��$��2��$��4��$��1��.��Đến�� $��Medium"�$��18(�$��5q�$��40��$��1��$��1��$��1��.��	Tiết:�� $��0 0 5 0q�$��2q�$��18(�$��5q� �� TextAlignment$ Center=�$��40��$��1��$��2������ *
TietBatDau+(� $��3��$��4��$��3��$
��Left=�$	��186��$��50�� ��%}   '        �� "  .���  � ��$	 Ngày Kết Thúc����  � ��$	 3q���  � ��$	 2q���  � ��$		 100��.��  $��0q�
 �� *NgayKetThuc+�� $��Medium"�$��18(�$��5q�$��40��$��3��$��1��$��1��.��	Tiết:�� $��0 0 5 0q�$��2q�$��18(�$��5q�$ Center=�$��40��$��3��$��2������ *TietKetThuc+�� $
��Bold"�$��4��$��4��$��2��.��
Ghi Chú�� $��5��$��5��$��2��$��2q�$��13(�$��5q�$
 Left=� �� TextWrapping$
 Wrap=�$��1,0,50,0q����� *GhiChu+�� $��6��$��4��$��2��$��40��$��0 0 7 0q�
�������$��2q�$��15(�$
��Bold"����� *ILuu+.��Nghỉ�� $��6��$��2��$��2��$��40��$��0 0 7 0q�
�������$��2q�$��15(�$
��Bold"����� *IUndo+.��	Đi Học