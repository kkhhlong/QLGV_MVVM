   M S B A M L   `   `   `  ���� D  @QLGV_MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QLGV_MVVM	QLGV_MVVM      QLGV_MVVM.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:QLGV_MVVM     V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -   $��
mainWindow��  � Icon$"  Picture/Artua-Wall-E-Eve.ico�� 
  MainVM � DataContext# [    MaterialDesignFont#���    MaterialDesignBody#���  $
��Bold"����#9e9e9e$��13(� � Title$ Giảng Viên�� � 	Resources ��%    .���  � RowDefinitions �� $��1* �$��70���� $��5* �$	��200��.+��  � ColumnDefinitions �� $��1* ��� $��1* �.+�]� .+�#  MaterialDesignThemes.Wpf.Card  $��5 5 5 5q�+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth4=�$��0��.���� $��65��$��0,10,10.2,10q�$��Right=�$��0��.+�]� $��Right=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  $��Center=��  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ AccountSearch=�$��42��$��50���� -   $��search��$	��Top=�$��Right=�$��55��$	��300��$��
 10 5 10 5q�$��	0 0 0 10 q�$��15(�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nhập tên giảng viên������ *TimTenGiangVien+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=��� $��0��$��Center=�$��0��$��5 5 0 0q�.+���  � ToolTip$( "Thêm ngày nghỉ toàn trường��$��4q�$��3��$	��Top=�$��Right=�$ Depth3=�$	��100��$��40������ *	INgayNghi+.��  $��Center=�$��Center=�$
 Plus=�$��42��$��50���� $) #Thêm dữ liệu bằng file Excel��$ Depth3=�$	��Top=�$��40��$	��100��$��Right=� � Cursor$
 Hand��$��0��$��2��$��4q����� *
ILuuDuLieu+.��  $��Center=�$��Center=�$ 	FileExcel=�$��42��$��50��� $��1�� �� $	��73* �.+�  $��5 5 5 5q�$ Depth4=�.��� $��85��.+��� $��70��$��10 10 10 10q�$��Center=�$��Center=�$R��LD:\Code\C#\WPF\ĐỒ ÁN\T_Manager-master\T_Manager\picture\huflit-logo2.png��� $��1�� �� $��1* �$	��400���� $��1* �.+�� $��0��.+�  $��5 5 5 5q�$	��470��$ Depth4=�.���� ��.  $��10q�.���� -   $��listview��$
��Auto=�
������ $��0q� �� SelectedItem �� *SelectedGiangVien+$	 TwoWay=�$
 PropertyChanged=����� *ListGiangVien+���� .R��� .+��� $��tenGv������ *TenGiangVien+�� $
��maGv������ *maGiangVien+� $��1��.+�  $��5 5 5 5q�$	��470��$ Depth4=�.���� ��.  $��10q�.���� -   $��
listviewMh��$
��Auto=� �� *LopHocSelected+���� *
ListLopHoc+���� .R��� .+��� $��tenGv������ *MonHoc.tenMonHoc+�� $
��maGv������ *
NoiDungLop+