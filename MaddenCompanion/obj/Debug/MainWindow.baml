   M S B A M L   `   `   `  ����J  FMaddenCompanion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MaddenCompanionMaddenCompanion  5   	   G(clr-namespace:MaddenCompanion.ConvertersMaddenCompanion.Converters  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	        MaddenCompanion.TestWindow   5   	   | xInfragisticsWPF4.Controls.Menus.XamMenu.v16.1, Version=16.1.20161.2174, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cbe aInfragisticsWPF4.v16.1, Version=16.1.20161.2174, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb/ig$http://schemas.infragistics.com/xaml   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:MaddenCompanion     5   	   <convert(clr-namespace:MaddenCompanion.Converters     5   	   s oInfragisticsWPF4.DataPresenter.v16.1, Version=16.1.20161.2174, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb0igDP%http://infragistics.com/DataPresenter  5   	   q	 mInfragisticsWPF4.DockManager.v16.1, Version=16.1.20161.2174, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb0igDock#http://infragistics.com/DockManager 	 5	   	   m
 iInfragisticsWPF4.Editors.v16.1, Version=16.1.20161.2174, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb/	igEditorshttp://infragistics.com/Editors 
 5
   	   0sys&clr-namespace:System;assembly=mscorlib 
 5   	   -   5          � Title$  
TestWindow��5   	   $	��500��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65    � WindowState$ 	Maximized=�6Z    � 	Resources 5         teamInfoViewSource  playerTradesViewSource  actionsViewSource  positionStatusesViewSource%   MaddenCompanion.DevTraitCompare  DevTraitCompare,   &MaddenCompanion.NumColorScaleConverter  NumColorScaleConverter,   &MaddenCompanion.DevColorScaleConverter  DevColorScaleConverter%   MaddenCompanion.SalaryConverter  SalaryConverter8  2MaddenCompanion.Converters.RateToGradientConverter  RateToGradientConverter;  5Infragistics.Windows.DataPresenter.DataRecordCellArea �� 
TargetType �� Property �� Value?  9Infragistics.Windows.DataPresenter.GroupByRecordPresenter6  0Infragistics.Windows.DataPresenter.FieldSettings 	 RatingFieldSettings   CellValuePresenterStyle;	  5Infragistics.Windows.DataPresenter.CellValuePresenter �� RelativeSource	 �� 	Converter 
 CenterNumberSettings
   Width   LabelTextAlignment�
  �Infragistics.Windows.Helpers.NullableConverter`1[[System.Windows.TextAlignment, PresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]  MoneyFieldSettings   EditorStyle3 
 -Infragistics.Windows.Editors.XamNumericEditor1 
 +Infragistics.Windows.Editors.TextEditorBase4  .Infragistics.Windows.DataPresenter.FieldLength  RatingsWidth=  7Infragistics.Windows.DataPresenter.FieldLengthConverter  	MoneyMask  MoneyMaskMillions  MoneyMaskThousands��%�  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     '  �     '  @    &		 �    7  &	
 c    &	 �    7  &	 w    &	 �    &	 �    &	 �    �� 5   
   67   �� 5   
   6;   �� 5   
   66   �� 5   
   6?     5   
   6      5   
   6'     5   
   6'     5   
   6      5   
   6*   �� 5   
   "  6   .�5      ��  �@ BackgroundAlternate �	#FF005DFF64   �� 5       �@ BorderAlternateBrush �	#B2ACACAC65   �� 5       �@ BackgroundHover 60   Z� �� 5       �@ BackgroundSelected �	#FF005DFF63   �� 5        �@ BackgroundActive �	#FF005DFF61   �� 5!       �@ BorderSelectedBrush �	#FF005DFF64   5"      �� 5$   
   "  6   .�5%      ��  � ��$ 30��6'   �� 5&       � ��
 �  ��6+   5'        5)   
    5*      �� 5+      " 	 6   .�5,      ��  � �� 63   �� *Value+ �� *Self+8	   �� 5-       � ��$ Center=�6C   5.      50        52   
   $
 60X�6:   $ Center
 6E    53      �� 54      " 	 6   .�55      ��  � ��$ Center=�6C   56      58        5:       5;      �� 5<      "  6   .�5=      �� # �@ ValueToDisplayTextConverter8   6D   5>      5@       5B   
   60 64   ��5C   
   nnn,nnn,nnn,nnn��68   ��5D   
   $nnn.n M��69   ��5E   
   nnn,nnn,nnn,nnn��6A   5G      .��5I      ]� .+�5J   
   )  #Infragistics.Controls.Menus.XamMenu  $	��Top=�6   $��25��6*   .@�5K      -  'Infragistics.Controls.Menus.XamMenuItem  -   5          Name$ menData��5K      D  >Infragistics.Controls.Menus.Primitives.XamHeaderedItemsControl   Header$
 Data��6.   .@�5L        -   5        $ menDownloadData��5L   !   $ Download Data��6:   6Q     5M      -   5        $ menLoadData��5M   !   $ 	Load Data��66   6I   5N        5O      -   5        $ 
menAddGrid��5O      $ Add Player Grid��61   6J     5P      -   5        $ menPositionStatuses��5P      $ Generate Position Status��6:   6\   5Q      5 	 /Infragistics.Windows.DockManager.XamDockManager  5R   
   -   5          Name$ dockManager��5R   7   $��Right=�6    #   AllowMaximizeFloatingWindows . #   AllowMinimizeFloatingWindows . 
�������   Panes 5S      0 	 *Infragistics.Windows.DockManager.SplitPane  5T         InitialLocation$ 
DockedLeft=�6#   5U      .��5W      : 	 4Infragistics.Windows.DockManager.DocumentContentHost     Panes. 5X        -   5          Name$ panMain��5X   #      Panes. 5Y      3 	 -Infragistics.Windows.DockManager.TabGroupPane  -	   5          Name$ 
grpTabPane��5Y   *   
������� � UseLayoutRounding .  5
     5     5     5     5     5     