   M S B A M L   `   `   `  ���� D  @AutoChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:AutoChart;assembly=AutoChart	AutoChart  M IInjectorMainWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:InjectorMainWindow.ValueChangedInjectorMainWindow.ValueChanged 7 clr-namespace:InjectorMainWindowInjectorMainWindow O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem #   InjectorMainWindow.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     >Mychart*clr-namespace:AutoChart;assembly=AutoChart     Achanges-clr-namespace:InjectorMainWindow.ValueChanged     J FMahApps.Metro, Version=1.6.0.362, Culture=neutral, PublicKeyToken=null;controls,http://metro.mahapps.com/winfx/xaml/controls  :d2http://schemas.microsoft.com/expression/blend/2008  5extra)http://metro.mahapps.com/winfx/xaml/extra  c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj	 fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  	 =list,http://schemas.microsoft.com/winfx/2006/xaml     2local clr-namespace:InjectorMainWindow     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9system&clr-namespace:System;assembly=mscorlib     -   $
��main��  � Title$  注射器自动化软件��$	��800��$	��600�� � 	Resources  �� MergedDictionaries �� Source   DescriptionHeaderStyle �� 
TargetType �� Property �� Value  MetroValidationPopup �� BasedOn2  ,MahApps.Metro.Controls.CustomValidationPopup  DataGridStyle&   System.Windows.Controls.DataGrid # MetroExpanderCollapseStoryboard �� 
TargetName	 �� TargetProperty	
 W� To g� Duration R� KeyTime  System.Windows.Visibility   	Collapsed R� Value  menuitem �� Triggers P� Property P� Value  row  col  uniformgridtemp A� Columns K� IsItemsHost A� Rows6  0InjectorMainWindow.ValueChanged.ValueDescChanged  gridside   DesValue��  �� $I Cpack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml?��� $F @pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml?��� $G Apack://application:,,,/MahApps.Metro;component/Styles/Colors.xaml?��� $M Gpack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml?��� $R Lpack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml?��� $ Resources\Icons.xaml?�%�  &	        '  =     7  &	 ~     &	 �     &	 D    &	 �    &	 �    &	 �    &	 #    �� " ��.���  � ��$ 22(���  � ��$ Center=��� 8   "  .��� " �@ CloseOnMouseLeftButtonDown .  �� "  .���  � ��$ Stretch=��� .��W� $ 
ExpandSite��$	 (UIElement.Opacity)�$
 0X�$ 0:0:0.1D�T� $ 
ExpandSite��$	 (UIElement.Visibility)�..�i� $ 0:0:0.1��# Z �� " ��.���  � �� �#ededed P�  �@J�IsMouseOver . . ���  � ��
 �������  �@�Cursor$
 Hand����13����8���� " �����  � �� �� .R�A� # �   . # �    $ 55Q�.���� -   $��
mainLayout�����#ededed.+��  �� Left$ 50������  �� ElementName$
 main�� �� Path$ ActualWidth� �� 	Converter# [ ���� $ 
mainLayout��$ ActualHeight� � RowDefinitions �� $��30 ��� $	��67* ��� $	��23* � � ColumnDefinitions �� $��50 ��� $	��73* ��� $
��622* �.+�� $��3��$��0,0,-0.2,0.4q� �� �� $��* �.+���  �� Orientation$ 
Horizontal=�$��2��$��
0,0,-0.2,0q�.+��� -   $��5,1,1,1q�$ 
Horizontal=�#��[ .+��� $��5q�$��Resources\link.png���� $��5q�$��Center=�$��连接���� -   $��5,1,1,1q�$ 
Horizontal=�#��[ .+��� $��5q�$��Resources\dislink.png���� $��5q�$��Center=�$��断开连接���� $��	0,0,0,0.4q�$��50��.+��� -   $��29��$��
0,0,-0.4,0q�.��左灯�� $��	0,0,0,0.4q�$��50��.+��� -   $��29��$��
0,0,-0.4,0q�.��右灯�� $��	0,0,0,0.4q�$��57��.+��� -   $��29��$��
0,0,-0.2,0q�.��全部归位�� $��200,0,0,0.4q�$	��200��.+�]� $��29��.+��� $��3q�$��电机速度��$��13(��� -    ��Name$ sv�� �� AutoToolTipPlacement$ TopLeft=� �� AutoToolTipPrecision$ 0��  �� IsSnapToTickEnabled  . ! � Maximum$! 9Q�" � Minimum$" 1Q�# � SmallChange$# 1Q�$ �� TickFrequency$$ 1Q�$	��125��% �� TickPlacement$% BottomRight=��� $��	3,3,3,2.8q�$��13(�$��20������ $ sv��$ Value�=  7MahApps.Metro.Controls.MetroAnimatedSingleRowTabControl  -	   $��pages��$��3��$��0,30,-0.2,0.4q�$��3������ .���  � y�$ 	Collapsed=�.@��� $��图表��.���  ��  �� $
��200* ��� $
��400* ��� $
��100* �.+��� $��0��.+��� $��左右平台A��$��
0,0,-0.4,0q�.���� $ Vertical=�.+��� $��40��$ 
Horizontal=�.+��� $��1号推头水平:��$��18(�$��	20,10,0,1q��� -
   & ��Name$& 
distanceAX��$��18(�$��1,10,0,1q����� $ Value��� $��2号推头压板:��$��18(�$	��104��$��
160,10,0,1q��� -   $& ElectriclDisA��$��18(�$��1,10,1,1q�$��50������ $ Value��� $ 
Horizontal=�.+��� $��10,0,0,0q�$	��270��.+��� -   $��70��$��70��$��10,1,190,20q�.���� $��Resources\left.png���� -   $��70��$��70��$��106,-103,0,7q�.���� $��Resources\Right.png���� -   $��70��$��70��$��82,-210,118,-100q�.���� $��Resources\refresh.png���� $	��438��.+��� -   $��	0,0,366,0q�$��70��$��70��.���� $��Resources\suoxiao.png���� -   $��70��$��70��$��-220,-70,1,3q�.���� $��Resources\refresh.png���� -   $��-76,-74,0,0q�$��70��$��70��.���� $��Resources\kuoda.png���� $��1��.+��� $��左右平台B��$��0,0,0,0q�.���� $��3q�.+��� $��3q�$��40��$ 
Horizontal=�.+��� $��3号注射器水平:��$��18(�$��	20,10,0,5q��� -   $& 
distanceBX��$��18(�$��
10,10,10,5q�$��65������ $ Value��� $��4号注射器夹持:��$��18(�$	��125��$��	50,10,0,1q��� -   $& ElectriclDisB��$��18(�$��1,10,1,1q�$��50������ $ Value��� $��5号注射器垂直:��$��18(�$��	60,10,0,5q��� -   $& 	distanceZ��$��18(�$��	10,10,0,5q�$��62������ $ Value��� $ 
Horizontal=�.+��� $��20,0,0,0q�$��Stretch=�$	��221��.+��� -   $��70��$��70��$��	1,1,148,1q�.���� $��Resources\left.png���� -   $��70��$��70��$��142,-70,0,1q�.���� $��Resources\Right.png���� -   $��70��$��70��$��73,-225,75,-152q�.���� $��Resources\refresh.png���� $��40,0,0,0q�$	��220��.+��� -   $��70��$��70��$��	0,0,150,0q�.���� $��Resources\suoxiao.png���� -   $��70��$��70��$��
-5,-70,0,0q�.���� $��Resources\refresh.png���� -   $��70��$��143,-70,4.4,0q�$��70��.���� $��Resources\kuoda.png���� $��60,0,0,0q�$��79��.+��� -   $��70��$��70��$��1,1,1,3q�.���� $��Resources\up.png���� -   $��70��$��70��$��1,0,1,3q�.���� $��Resources\refresh.png���� -   $��70��$��70��$��1,1,1,3q�.���� $��Resources\down.png���� $ 
Horizontal=�$
��0,10q�$��2��.+��� -   $	��com��$��0q����#444444$	��130��$��Center=�$��Center=�$��
0,0,0,21.6q���Z� ���� $
 main��$ ExitComs��� -   $��40��$��5,0,0,0q�$��Center=�$	��Top=����� $��Resources\refresh.png���� $��40,0,0,0q�$	��Top=�$��
服务器:���� -    $��ipbox��$	��100��$��5,0,0,0q�$	��Top=�$��Center=�*  $MahApps.Metro.Controls.TextBoxHelper'   AutoWatermark' . (   UseFloatingWatermark( . )   	Watermark$) 服务IP��*   WatermarkAlignment$* Center=�$��0q�$��18(�$��	127.0.0.1���� -!   $��portbox��$	��100��$��5,0,0,0q�$	��Top=�$��Center=�' . ( . $) 端口��$* Center=�$��0q�$��18(�$
��8787���� $��日志��.���  �� $��30 ��� $��* �.+��� $ 
Horizontal=�.+��� $��Center=�$��一般日志��/  )MahApps.Metro.Controls.ToggleSwitchButton  + d� 	IsChecked+ �� $
 main��$ IsNormalLog�, �� Mode$, TwoWay=��� $��5q�$��Center=�$��警告日志��  + �� $
 main��$ IsWaringLog�$, TwoWay=��� $��5q�$��Center=�$��错误日志��  + �� $
 main��$ 
IsErrorLog�$, TwoWay=��� $��1��- �� 
IsReadOnly- . ��. . �� PanningMode$. VerticalOnly=�/ �� PanningRatio$/ 10Q�"0 �� VerticalScrollBarVisibility$0 Visible=����� 1 �� ImageSource$1 Resources\log.jpg��2 �� Opacity$	2 0.2Q�. �/� .T�J� -"   3 �Name$3 logBox��.*��� $��接口测试��.���  �� ��  �� $��30 ��� �� $��30 �.+��� $��2��$��接口测试���� -#   $��interfaceList��$��1������ .R��� $ 
Horizontal=�.+�	� $��Center=����� *Key++ �� $, TwoWay=�$ 
IsSelected�4 �� RelativeSource4 �� 5 �� AncestorType$5 ListBoxItemL��� $��Center=�$�� ���� $��1��$��1��.+��� ���� $ interfaceList��$" SelectedItem.Value.Paramters����� .R��  �� $��70 ��� $��* �.+��� $��Center=����� $ ParameterName��� $��1��$	��240��$��Center=����� $ Value�$, TwoWay=��� -$   )  #MahApps.Metro.Controls.ButtonHelper6   CornerRadius$6 5��$��执行接口���� $��接口返回的结果:���� -%   $��	resultBox��$	��200��- . 7 �� TextWrapping$
7 Wrap=��� $��配置��.���  �� $��60 ��� $	��150 ��� $��30 ��� .+��� .+��� $ 
Horizontal=�.+��� -&   $��positioninfo��$��5q�$��	无连接���� $��1q�$ 
Horizontal=�.+��� $��30����Z� ���� $��60��$ 
Horizontal=�.+��� $��Resources\load.png���� $��Center=�$��16(�$
��Bold"�$��导入���� $��30��$��1q���Z� ���� $��60��$ 
Horizontal=�.+��� $��Resources\load.png���� $��Center=�$��16(�$
��Bold"�$��导出���� $��2��$ 
Horizontal=�.+��� $��Center=�$��步长��*	  $MahApps.Metro.Controls.NumericUpDown	  -'   $��stepNum��$	��100��$��Center=�8 	  Value$8 10X��� $��3��$��10q�.+�� $��5q� �� $��* ��� $��60 �.+��� $��1��$ Vertical=�.+��� $��30��$��Center=����� $��Resources\add.png���� $��30��$��5q�$��Center=����� $��Resources\remove.png��*
  $MahApps.Metro.Controls.HamburgerMenu
  -(   $��	leftMenus��$	��570��$��40��
���   �$��1q����� 9 
  ItemTemplate9 �� .R��� $��5,3,3,3q�$ 
Horizontal=�.+��� $��40������ *Icon+: � ToolTip: �� $��5q�$��Center=�$��Center=���Z� ���� *
MenuName+�� $��5q�$��Center=����� *
MenuName+