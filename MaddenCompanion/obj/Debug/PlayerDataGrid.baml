   M S B A M L   `   `   `  ����J  FMaddenCompanion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MaddenCompanionMaddenCompanion  5      G(clr-namespace:MaddenCompanion.ConvertersMaddenCompanion.Converters  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      $    MaddenCompanion.PlayerDataGrid   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:MaddenCompanion     5      <convert(clr-namespace:MaddenCompanion.Converters     5      s oInfragisticsWPF4.DataPresenter.v16.1, Version=16.1.20161.2174, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb0igDP%http://infragistics.com/DataPresenter  5      m iInfragisticsWPF4.Editors.v16.1, Version=16.1.20161.2174, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb/	igEditorshttp://infragistics.com/Editors  5	      e aInfragisticsWPF4.v16.1, Version=16.1.20161.2174, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb/	igWindowshttp://infragistics.com/Windows  5
      0sys&clr-namespace:System;assembly=mscorlib  5        � 	Resources  5      %   MaddenCompanion.DevTraitCompare   DevTraitCompare,   &MaddenCompanion.NumColorScaleConverter  NumColorScaleConverter,   &MaddenCompanion.DevColorScaleConverter  DevColorScaleConverter%   MaddenCompanion.SalaryConverter  SalaryConverter%   MaddenCompanion.HeightConverter  HeightConverter8  2MaddenCompanion.Converters.RateToGradientConverter  RateToGradientConverter;  5Infragistics.Windows.DataPresenter.DataRecordCellArea �� 
TargetType �� Property �� Value?  9Infragistics.Windows.DataPresenter.GroupByRecordPresenter6	  0Infragistics.Windows.DataPresenter.FieldSettings  RatingFieldSettings 	  CellValuePresenterStyle;
  5Infragistics.Windows.DataPresenter.CellValuePresenter �� RelativeSource �� 	Converter  CenterNumberSettings 	  Width 	  LabelTextAlignment�  �Infragistics.Windows.Helpers.NullableConverter`1[[System.Windows.TextAlignment, PresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]  MoneyFieldSettings	 	  EditorStyle3  -Infragistics.Windows.Editors.XamNumericEditor1  +Infragistics.Windows.Editors.TextEditorBase 	 HeightFieldSettings4  .Infragistics.Windows.DataPresenter.FieldLength 
 RatingsWidth=  7Infragistics.Windows.DataPresenter.FieldLengthConverter  	MoneyMask  MoneyMaskMillions  MoneyMaskThousands��%�  &	        &	      &	 &     &	 9     &	 L     &	 _     '  r     '      &	 u    7  &	 *    &	 �    7  &		 >    7  &	
 �    &	 �    &	     &	 $      5   
   6      5   
   6'     5   
   6'     5   
   6      5   
   6      5   
   6*   �� 5   
   "  6   .�5      ��  �@ BackgroundAlternate �	#FF005DFF64   �� 5       �@ BorderAlternateBrush �	#B2ACACAC65   �� 5       �@ BackgroundHover 60   Z� �� 5       �@ BackgroundSelected �	#FF005DFF63   �� 5       �@ BackgroundActive �	#FF005DFF61   �� 5       �@ BorderSelectedBrush �	#FF005DFF64   5      �� 5    
   "  6   .�5!      ��  � ��$ 30��6'   �� 5"       � ��
 �  ��6+   5#      	  5%   
    5&      �� 5'      " 
 6   .�5(      ��  � �� 63   �� *Value+ �� *Self+8   �� 5)       � ��$ Center=�6C   5*      5,      	  5.   
   $ 60X�6:   $ Center 6E    5/      �� 50      " 
 6   .�51      ��  � ��$ Center=�6C   52      54      	  56   
   	 57      �� 58      "  6   .�59      �� # �@ ValueToDisplayTextConverter8   6D   5:      5<      	  5>   
   	 5?      �� 5@      "  6   .�5A      �� # �@ ValueToDisplayTextConverter8   6D   5B      5D       5F   
   60 64   ��5G   
   nnn,nnn,nnn,nnn��68   ��5H   
   	$nnn.nn M��6:   ��5I   
   nnn,nnn,nnn,nnn��6A   5J      .��5L      ]� .+�5M   
   4  .Infragistics.Windows.DataPresenter.XamDataGrid  -   5        
  Name$
 DataGrid��5M      $��Bottom=�6-   :  4Infragistics.Windows.DataPresenter.DataPresenterBase   SelectedDataItemsScope$ RecordsOnly=�6E      IsGroupByAreaExpanded .    ThemeJ  DInfragistics.Windows.Themes.Internal.DataPresenterThemeTypeConverter$ IGTheme 6�      FieldLayoutSettings 5O      <  6Infragistics.Windows.DataPresenter.FieldLayoutSettings  5P         AutoGenerateFields$ FalseY�5Q   -       AllowFieldGroupCollapsing$
 TrueY�5R   -   "   HeaderPrefixAreaDisplayMode$ FieldChooserButton=�5S   -      FilterUIType$ FilterRecord=�5T   -       HighlightAlternateRecords$
 TrueY�5U   -      AllowAddNew$ FalseY�5V   -      AllowDelete$ FalseY�5W   -      AllowRecordFixing$	 Top=�5X   -       GroupBySummaryDisplayMode$( "SummaryCellsAlwaysBelowDescription=�5Y   -      FieldSettings 5]      	  5^       	  AllowRecordFiltering�  �Infragistics.Windows.Helpers.NullableConverter`1[[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]$
 true 5_   -    	  	AllowEdit$ False 5`   -    	  
CellHeight$ 30Q�5a   -    	  CellClickAction$ SelectRecord=�5b   -   $ Center 5c   -    	  AllowSummaries$
 true 5d   -    	  SummaryUIType$ MultiSelect=�5e   -    	  SummaryDisplayArea�  �Infragistics.Windows.Helpers.NullableConverter`1[[Infragistics.Windows.DataPresenter.SummaryDisplayAreas, InfragisticsWPF4.DataPresenter.v16.1, Version=16.1.20161.2174, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb]]$ TopFixed 5f   -       FieldLayouts  5j      4  .Infragistics.Windows.DataPresenter.FieldLayout  5k      !   	IsDefault! . "   SummaryDefinitions" 5n      :  4Infragistics.Windows.DataPresenter.SummaryDefinition  5o      
#   Key$# PlayerBestOvr��61   $   SourceFieldName$$ PlayerBestOvr��6E   %   
CalculatorU  OInfragistics.Windows.DataPresenter.SummaryCalculator+SummaryCalculatorConverter$% Average 6e   &   StringFormat$& Ag: {0:0.00}��6z   '   DisplayArea$' TopFixed 6�     5p      $# PlayerBestOvr��61   $$ PlayerBestOvr��6E   $% Maximum 6e   $& Mx: {0:0.00}��6z   $' TopFixed 6�   (   	IsVisible( .  6�     5r      $$ 	FirstName��61   $% Count 6M   $& 	Ct: {0:0}��6`   $' InGroupByRecords 6{   ( .  6�     5t      $$ PlayerBestOvr��61   $% Average 6Q   $& Ag: {0:0.0}��6f   $' InGroupByRecords 6�     5u      $$ PlayerBestOvr��61   $% Maximum 6Q   $& 	Mx: {0:0}��6f   $' InGroupByRecords 6�   ( . 6�     5v      $$ PlayerBestOvr��61   $% Minimum 6Q   $& 	Mn: {0:0}��6f   $' InGroupByRecords 6�   ( . 6�     5x      $	$ Age��61   $% Maximum 6G   $& 	Mx: {0:0}��6\   $' InGroupByRecords 6w   ( . 6�     5y      $	$ Age��61   $% Minimum 6G   $& 	Mn: {0:0}��6\   $' InGroupByRecords 6w   ( . 6�     5{      $# CapHit��61   $$ CapHit��6>   $	% Sum 6W   $& Sm: {0:#,##0, K}��6h   $' TopFixed 6�     5|      $$ CapHit��61   $% Maximum 6J   $& Mx: {0:#,##0, K}��6_   $' InGroupByRecords 6�   ( . 6�     5}      $$ CapHit��61   $% Minimum 6J   $& Mn: {0:#,##0, K}��6_   $' InGroupByRecords 6�   ( . 6�     5      $$ CapReleaseNetSavings��61   $% Maximum 6X   $& Mx: {0:#,##0, K}��6m   $' InGroupByRecords 6�   ( . 6�     5�      $$ ContractYearsLeft��61   $% Maximum 6U   $& 	Mx: {0:0}��6j   $' InGroupByRecords 6�   ( . 6�     5�      $$ ContractYearsLeft��61   $% Minimum 6U   $& 	Mn: {0:0}��6j   $' InGroupByRecords 6�   ( . 6�   )   SortedFields) 5�      =  7Infragistics.Windows.DataPresenter.FieldSortDescription  5�      *   	Direction$* 
Descending=�64   +   	FieldName$+ PlayerBestOvr��6K   ,   RecordFilters, 5�      5  /Infragistics.Windows.DataPresenter.RecordFilter  5�      -   	FieldName$
- Name��6,   .   
Conditions.. 5�      7  1Infragistics.Windows.Controls.ComparisonCondition  /   Operator$/ Contains=�6<   0   Value$0  ��6P   5�      1   
FieldItems.1 5�      .  (Infragistics.Windows.DataPresenter.Field  2  ,Infragistics.Windows.DataPresenter.FieldItem2   Name$
2 Name��6!   3   Label$
3 Name��6-   4   Width$	4 150X�6:   5   FixedLocation$5 FixedToNearEdge=�6F   6   Column$6 1��6f     5�      $2 	FirstName��6!   $3 
First Name��62   $4 90X�6E   $5 FixedToNearEdge=�6P   $6 1��6p   7   
Visibility$7 	Collapsed=�6{     5�      $2 LastName��6!   $3 	Last Name��61   $4 90X�6C   $5 FixedToNearEdge=�6N   $6 2��6n   $7 	Collapsed=�6y     5�      $2 Position��6!   $	3 Pos��61   $4 60X�6=   $5 FixedToNearEdge=�6H   8   LabelTextAlignment$8 Center 6h   !9   HorizontalContentAlignment�  �Infragistics.Windows.Helpers.NullableConverter`1[[System.Windows.HorizontalAlignment, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]$9 Center 6�   $6 3��6�     5�      $2 Scheme��6!   $3 Scheme��6/   $4 80X�6>   $5 FixedToNearEdge=�6I   $6 4��6i   $7 	Collapsed=�6t     5�      $2 TeamName��6!   $
3 Team��61   $8 Center 6>   $9 Center 6Z   $4 80X�6~   $5 FixedToNearEdge=�6�   $6 5��6�     5�      $2 PassingStats��6!   $3 Passing Stats��65   $	4 100X�6K   $5 FixedToNearEdge=�6W   $6 1��6w     5�      $2 RushingStats��6!   $3 Rushing Stats��65   $	4 100X�6K   $5 FixedToNearEdge=�6W   $6 1��6w     5�      $2 ReceivingStats��6!   $3 Receiving Stats��67   $	4 100X�6O   $5 FixedToNearEdge=�6[   $6 1��6{     5�      $2 DefenseStats��6!   $3 Defense Stats��65   $	4 100X�6K   $5 FixedToNearEdge=�6W   $6 1��6w     5�      $2 PuntingStats��6!   $3 Punting Stats��65   $	4 100X�6K   $5 FixedToNearEdge=�6W   $6 1��6w     5�      $2 KickingStats��6!   $3 Kicking Stats��65   $	4 100X�6K   $5 FixedToNearEdge=�6W   $6 1��6w   3  -Infragistics.Windows.DataPresenter.FieldGroup  5�      $3 Player Info��6&   $6 5��6:   :   Children.: 5�        $	2 Age��6%   $	3 Age��60   $8 Center 6<   $9 Center 6X   #4 [
 6|   $6 0��6�     5�      $2 Weight��6%   $	3 WGT��63   $8 Center 6?   $9 Center 6[   #4 [
 6   $6 1��6�     5�      $2 Height��6%   $	3 HGT��63   $8 Center 6?   $9 Center 6[   #4 [
 6   $6 2��6�   ;   Settings#; [	 6�     5�      $2 BirthDay��6%   $3 	Birth Day��65   $7 	Collapsed=�6G   $6 3��6^     5�      $2 
BirthMonth��6%   $3 Birth Month��67   $7 	Collapsed=�6K   $6 4��6b     5�      $2 	BirthYear��6%   $3 
Birth Year��66   $7 	Collapsed=�6I   $6 5��6`     5�      $2 HomeTown��6%   $3 	Home Town��65   $7 	Collapsed=�6G   $6 6��6^     5�      $2 	HomeState��6%   $3 
Home State��66   $7 	Collapsed=�6I   $6 7��6`     5�      $2 YearsPro��6%   $3 Years��65   $7 	Collapsed=�6C   $8 Center 6Z   $9 Center 6v   $4 45X�6�   $6 8��6�   5�        5�      $3 Status��6&   $6 6��65   .: 5�        $2 	JerseyNum��6%   $3 
Jersey Num��66   $7 	Collapsed=�6I   $6 0��6`     5�      $2 IsActive��6%   $3 Active��65   $6 1��6D   $8 Center 6O   $9 Center 6k   #4 [
 6�   $7 	Collapsed=�6�     5�      $2 IsOnIR��6%   $3 IR��63   $6 2��6>   $7 	Collapsed=�6I     5�      $2 IsOnPracticeSquad��6%   $3 PS��6>   <   ToolTip$< Practice Squad��6I   $6 3��6b   $8 Center 5�   =   $9 Center 6Y   #4 [
 6}     5�      $2 IsFreeAgent��6%   $3 FA��68   $< 
Free Agent��6C   $7 	Collapsed=�6X   $6 4��6o   $8 Center 5�   =   $9 Center 6Y   #4 [
 6}     5�      $2 
InjuryType��6%   $3 Injury Type��67   $6 5��6K   $7 	Collapsed=�6V   $	4 120X�6m     5�      $2 InjuryLength��6%   $3 Inj Wks��69   $< Injury Length��6I   $6 6��6a   $8 Center 5�   =   $9 Center 6Y   #4 [
 6}   5   /Infragistics.Windows.DataPresenter.NumericField   5�      $2 LegacyScore��6,   $3 Legacy��6?   $6 7��6N   $7 	Collapsed=�6Y   8!  2Infragistics.Windows.DataPresenter.MaskedTextField= !  Mask#= [ 6p   $	4 100X�6�      5�      $2 ExperiencePoints��6,   $3 
Experience��6D   $6 8��6W   $7 	Collapsed=�6b   #= [ 6y   $4 70X�6�   5�        5�      $3 Draft��6&   >   IsCollapsed> . $7 	Collapsed=�6G   $6 7��6^   .: 5�        $2 College��6%   $3 College��64   $6 0��6D     5�      $2 	DraftPick��6%   $
3 Pick��66   $6 1��6C   $8 Center 6N   $9 Center 6j   #4 [
 6�     5�      $2 
DraftRound��6%   $3 Round��67   $6 2��6E   $8 Center 6P   $9 Center 6l   #4 [
 6�     5�      $2 
RookieYear��6%   $3 Rookie Year��67   $6 3��6K   $8 Center 6V   $9 Center 6r   $4 75X�6�   5�        5�      $3 Current Contract��6&   $6 8��6?   .: 5�         $2 ContractSalary��6,   $3 Salary��6B   $< Current Contract Salary��6Q   $7 Visible=�6s   #; [ 6�   $6 0��6�   $4 60X�6�      5�      $2 ContractBonus��6,   $3 Bonus��6A   $< Current Contract Bonus��6O   $7 Visible=�6p   #; [ 6�   $6 2��6�   $4 60X�6�     5�      $2 ContractLength��6%   $3 Length��6;   $< Current Contact Length��6J   $6 3��6k   $7 Visible=�6v   $9 Center 6�   $4 60X�6�      5�      $2 ContractYearSalary��6,   $3 Yearly��6F   $$< Current Contract Yearly Salary��6U   #; [ 6~   $6 4��6�   $4 60X�6�     5�      $2 ContractYearsLeft��6%   $3 Remain��6>   $&<  Current Contract Years Remaining��6M   $6 5��6x   $9 Center 6�   $4 60X�6�      5�      $2 CapHit��6,   $3 Cap Hit��6:   $< Current Cap Hit��6J   #; [ 6d   $6 6��6�   $4 60X�6�      5�      $2 CapReleasePenalty��6,   $3 Penalty��6E   $< Release Cap Penalty��6U   $7 Visible=�6s   #; [ 6�   $4 60X�6�   $6 7��6�      5�      $2 CapReleaseNetSavings��6,   $
3 Save��6H   $< Release Cap Savings��6U   #; [ 6s   $4 60X�6�   $6 8��6�   5�        5�      $3 Desired Contract��6&   > .  $7 Visible=�6S   $6 8��6h   .: 5�         $2 DesiredContractSalary��6,   $3 Salary��6I   $< Desired Contract Salary��6X   $7 	Collapsed=�6z   #; [ 6�   $6 0��6�   $4 65X�6�      5�      $2 DesiredContractYearSalary��6,   $3 Yearly��6M   $$< Desired Contract Yearly Salary��6\   #; [ 6�   $6 0��6�   $4 65X�6�     5�      $2 DesiredContractLength��6%   $3 Length��6B   $< Desired Contract Length��6Q   $6 2��6s   $8 Center 6~   $9 Center 6�   $4 65X�6�      5�      $2 DesiredContractYearBonus��6,   $3 Bonus��6L   $#< Desired Contract Yearly Bonus��6Z   $7 Visible=�6�   #; [ 6�   $6 3��6�   $4 65X�6�   5�        5�      $3 Basic Ratings��6&   $6 9��6<   .: 5�        $2 PlayerBestOvr��6%   $
3 BOVR��6:   $< Best Overall��6G   $6 0��6^   $8 Center 6i   #4 [
 6�   #; [ 6�     5�      $2 PlayerSchemeOvr��6%   $
3 SOVR��6<   $< Scheme Overall��6I   $6 1��6b   $8 Center 6m   #4 [
 6�   #; [ 6�     5�      $2 DevTrait��6%   $	3 DEV��65   $< Development��6A   $6 11��6W   $8 Center 6c   $9 Center 6   $4 80X�6�   ; 5�      	  5�   "   ? 	  SortComparer#? [  65    5�   &   �� 5�   *   " 
 60   .�5�   .   ��  � �� 6K   �� *Value+ �� *Self+# [ 5�   +   5�   #   5�        5�      $2 StrengthRating��6%   $	3 STR��6;   $< Strength��6G   $6 2��6Z   $8 Center 6e   #4 [
 6�   #; [ 6�     5�      $2 AgilityRating��6%   $	3 AGI��6:   $< Agility��6F   $6 3��6X   $8 Center 6c   #4 [
 6   #; [ 6�     5�      $2 SpeedRating��6%   $	3 SPD��68   $< Speed��6D   $6 4��6T   $8 Center 6_   #4 [
 6{   #; [ 6�     5�      $2 AccelRating��6%   $	3 ACC��68   $< Acceleration��6D   $6 5��6[   $8 Center 6f   #4 [
 6�   #; [ 6�     5�      $2 StaminaRating��6%   $	3 STA��6:   $< Stamina��6F   $6 6��6X   $8 Center 6c   #4 [
 6   #; [ 6�     5�      $2 AwarenessRating��6%   $	3 AWR��6<   $< 	Awareness��6H   $6 7��6\   $8 Center 6g   #4 [
 6�   #; [ 6�     5�      $2 
JumpRating��6%   $	3 JMP��67   $< Jumping��6C   $6 8��6U   $8 Center 6`   #4 [
 6|   #; [ 6�     5�      $2 InjuryRating��6%   $	3 INJ��69   $< Injury��6E   $6 9��6V   $8 Center 6a   #4 [
 6}   #; [ 6�     5�      $2 ToughRating��6%   $	3 TGH��68   $< 	Toughness��6D   $6 10��6X   $8 Center 6d   #4 [
 6�   #; [ 6�   5�        5�      $3 Passing Ratings��6&   $6 10��6>   > . .: 5�        $2 ThrowPowerRating��6%   $	3 THP��6=   $< Throw Power��6I   $6 0��6_   $8 Center 6j   #4 [
 6�   #; [ 6�     5�      $2 ThrowAccShortRating��6%   $	3 SAC��6@   $< Short Throw Accuracy��6L   $6 1��6l   $8 Center 6w   #; [ 6�   #4 [
 6�     5�      $2 ThrowAccMidRating��6%   $	3 MAC��6>   $< Medium Throw Accuracy��6J   $6 2��6k   $8 Center 6v   #; [ 6�   #4 [
 6�     5�      $2 ThrowAccDeepRating��6%   $	3 DAC��6?   $< Deep Throw Accuracy��6K   $6 3��6j   $8 Center 6u   #; [ 6�   #4 [
 6�     5�      $2 ThrowAccRating��6%   $	3 TAC��6;   $< Throw Accuracy Rating��6G   $6 4��6g   $7 	Collapsed=�6r   $8 Center 6�   #; [ 6�   #4 [
 6�     5�      $2 ThrowOnRunRating��6%   $	3 RUN��6=   $< Throw on the Run��6I   $6 5��6e   $8 Center 6p   #; [ 6�   #4 [
 6�     5�      $2 ThrowPlayActRating��6%   $	3 PAC��6?   $< Play Action��6K   $6 6��6b   $8 Center 6m   #; [ 6�   #4 [
 6�   5�        5     $3 Ball Carrier Ratings��6&   $6 11��6C   > . .: 5       $2 CarryRating��6%   $	3 CAR��68   $< Carrying��6D   $6 0��6W   $8 Center 6b   #; [ 6~   #4 [
 6�     5     $2 TruckRating��6%   $	3 TRK��68   $< Trucking��6D   $6 1��6W   $8 Center 6b   #; [ 6~   #4 [
 6�     5     $2 SpinMoveRating��6%   $	3 SPM��6;   $< 	Spin Move��6G   $6 2��6[   $8 Center 6f   #; [ 6�   #4 [
 6�     5     $2 StiffArmRating��6%   $	3 SFA��6;   $< 	Stiff Arm��6G   $6 3��6[   $8 Center 6f   #; [ 6�   #4 [
 6�     5     $2 JukeMoveRating��6%   $	3 JKM��6;   $< JukeMoveRating��6G   $6 4��6`   $8 Center 6k   #; [ 6�   #4 [
 6�     5     $2 ElusivenessRating��6%   $	3 ELU��6>   $< Elusiveness��6J   $6 5��6`   $8 Center 6k   #; [ 6�   #4 [
 6�     5	     $2 	BCVRating��6%   $	3 BCV��66   $< Ball Carrier Vision��6B   $6 6��6`   $8 Center 6k   #; [ 6�   #4 [
 6�   5
       5     $3 Receiving Ratings��6&   $6 12��6@   > . .: 5       $2 CatchRating��6%   $	3 CTH��68   $< Catching��6D   $6 0��6W   $8 Center 6b   #; [ 6~   #4 [
 6�     5     $2 CatInTrafficRating��6%   $	3 CIT��6?   $< Catch in Traffic��6K   $6 1��6f   $8 Center 6q   #; [ 6�   #4 [
 6�     5     $2 RouteRunRating��6%   $	3 RTE��6;   $< Route Running��6G   $6 2��6_   $8 Center 6j   #; [ 6�   #4 [
 6�     5     $2 SpecCatchRating��6%   $	3 SPC��6<   $< Spectacular Catch��6H   $6 3��6d   $8 Center 6o   #; [ 6�   #4 [
 6�     5     $2 ReleaseRating��6%   $	3 RLS��6:   $< Release��6F   $6 4��6X   $8 Center 6c   #; [ 6   #4 [
 6�   5       5     $3 Blocking Ratings��6&   $6 13��6?   > . .: 5       $2 PassBlockRating��6%   $	3 PBK��6<   $< 
Pass Block��6H   $6 0��6]   $8 Center 6h   #; [ 6�   #4 [
 6�     5     $2 RunBlockRating��6%   $	3 RBK��6;   $< 	Run Block��6G   $6 1��6[   $8 Center 6f   #; [ 6�   #4 [
 6�     5     $2 ImpactBlockRating��6%   $	3 IBL��6>   $< Impact Block��6J   $6 2��6a   $8 Center 6l   #; [ 6�   #4 [
 6�   5       5     $3 Defense Ratings��6&   $6 14��6>   > . .: 5       $2 TackleRating��6%   $	3 TAK��69   $< Tackle��6E   $6 0��6V   $8 Center 6a   #; [ 6}   #4 [
 6�     5     $2 HitPowerRating��6%   $	3 HIT��6;   $< Hit Power Rating��6G   $6 1��6b   $8 Center 6m   #; [ 6�   #4 [
 6�     5      $2 PowerMovesRating��6%   $	3 PMV��6=   $< Power Moves��6I   $6 2��6_   $8 Center 6j   #; [ 6�   #4 [
 6�     5!     $2 FinesseMovesRating��6%   $	3 FMV��6?   $< Finesse Moves��6K   $6 3��6c   $8 Center 6n   #; [ 6�   #4 [
 6�     5"     $2 BlockShedRating��6%   $	3 BSH��6<   $< Block Shedding��6H   $6 4��6a   $8 Center 6l   #; [ 6�   #4 [
 6�     5#     $2 PursuitRating��6%   $	3 PUR��6:   $< Pursuit��6F   $6 5��6X   $8 Center 6c   #; [ 6   #4 [
 6�     5$     $2 PlayRecRating��6%   $	3 PRC��6:   $< Play Recognition��6F   $6 6��6a   $8 Center 6l   #; [ 6�   #4 [
 6�     5%     $2 ManCoverRating��6%   $	3 MCV��6;   $< Man Coverage��6G   $6 7��6^   $8 Center 6i   #; [ 6�   #4 [
 6�     5&     $2 ZoneCoverRating��6%   $	3 ZCV��6<   $< Zone Coverage��6H   $6 8��6`   $8 Center 6k   #; [ 6�   #4 [
 6�     5'     $2 PressRating��6%   $	3 PRS��68   $< Press��6D   $6 9��6T   $8 Center 6_   #; [ 6{   #4 [
 6�   5(       5+     $3 Kicking Ratings��6&   $6 15��6>   > . .: 5,       $2 KickPowerRating��6%   $	3 KPW��6<   $< 
Kick Power��6H   $6 0��6]   $8 Center 6h   #; [ 6�   #4 [
 6�     5-     $2 KickAccRating��6%   $	3 KAC��6:   $< Kick Accuracy��6F   $6 1��6^   $8 Center 6i   #; [ 6�   #4 [
 6�     5.     $2 KickRetRating��6%   $	3 RET��6:   $< Kick Return��6F   $6 2��6\   $8 Center 6g   #; [ 6�   #4 [
 6�   5/       52     $3 Composite Ratings��6&   $6 16��6@   > . .: 53       $2 PhysicalGrade��6%   $
3 PHYS��6:   $< Physical Grade��6G   $6 0��6`   $8 Center 6k   #; [ 6�   #4 [
 6�     54     $2 PersonalityGrade��6%   $
3 PERS��6=   $< Personality Grade��6J   $6 1��6f   $8 Center 6q   #; [ 6�   #4 [
 6�     55     $2 IntangibleGrade��6%   $
3 TANG��6<   $< Intangible Grade��6I   $6 2��6d   $8 Center 6o   #; [ 6�   #4 [
 6�     56     $2 	SizeGrade��6%   $
3 SIZE��66   $< 
Size Grade��6C   $6 3��6X   $8 Center 6c   #; [ 6   #4 [
 6�     57     $2 DurabilityGrade��6%   $
3 DURA��6<   $< Durability Grade��6I   $6 4��6d   $8 Center 6o   #; [ 6�   #4 [
 6�     58     $2 ProductionGrade��6%   $
3 PROD��6<   $< Production Grade��6I   $6 5��6d   $8 Center 6o   #; [ 6�   #4 [
 6�     59     $2 ImportanceGrade��6%   $
3 PORT��6<   $< Importance Grade��6I   $6 6��6d   $8 Center 6o   #; [ 6�   #4 [
 6�     5:     $2 ConfidenceRating��6%   $
3 CONF��6=   $< Confidence Rating��6J   $6 7��6f   $8 Center 6q   #; [ 6�   #4 [
 6�   5;       5=     $3 Traits��6&   $6 17��65   $7 	Collapsed=�6A   5?       5A     $3 Other��6&   $6 18��64   $7 	Collapsed=�6@   5C     5F       5I     
@   Key$@ DefenseStats��6#   A   ParentFieldName$A DefenseStats��66   B   SettingsB 5K       5L     $ FalseY�63   $
 TrueY�6N   .1 5O       $2 WeekNum��6!   $
3 Week��60   $5 FixedToNearEdge=�6=   $6 1��6]   #; [ 6h     5P     $2 TotalTackles��6!   $3 Tackles��65   $6 2��6E   #; [ 6P     5Q     $2 Sacks��6!   $3 Sacks��6.   $6 3��6<   #; [ 6G     5R     $2 CatchesAllowed��6!   $3 Catches Allowed��67   $6 4��6O   #; [ 6Z     5S     $2 Deflections��6!   $3 Deflections��64   $6 5��6H   #; [ 6S     5T     $2 FumblesForc��6!   $3 Fumbles Forces��64   $6 6��6K   #; [ 6V     5U     $2 
FumblesRec��6!   $3 Fumbles Recovered��63   $6 7��6M   #; [ 6X     5V     $2 Interceptions��6!   $3 Interceptions��66   $6 8��6L   #; [ 6W     5X     $2 IntReturnYards��6!   $3 Int Return Yards��67   $6 9��6P   #; [ 6[   $7 	Collapsed=�6�     5Y     $2 Points��6!   $3 Points��6/   $6 10��6>   #; [ 6J   $7 	Collapsed=�6{     5Z     $2 Safeties��6!   $3 Safeties��61   $6 11��6B   #; [ 6N   $7 	Collapsed=�6     5[     $2 
Touchdowns��6!   $3 
Touchdowns��63   $6 12��6F   #; [ 6R   $7 	Collapsed=�6�   5\       5_     $@ KickingStats��6#   $A KickingStats��66   B 5a       5b     $
 TrueY�63   .1 5e       $2 WeekNum��6!   $
3 Week��60   $5 FixedToNearEdge=�6=   $6 1��6]   #; [ 6h   5h       5k     $@ RushingStats��6#   $A RushingStats��66   B 5m       5n     $
 TrueY�63   .1 5q       $2 WeekNum��6!   $
3 Week��60   $5 FixedToNearEdge=�6=   $6 1��6]   #; [ 6h   5s       5v     $@ PassingStats��6#   $A PassingStats��66   B 5x       5y     $
 TrueY�63   .1 5|       $2 WeekNum��6!   $
3 Week��60   $5 FixedToNearEdge=�6=   $6 1��6]   #; [ 6h   5~       5�     $@ PuntingStats��6#   $A PuntingStats��66   B 5�       5�     $
 TrueY�63   .1 5�       $2 WeekNum��6!   $
3 Week��60   $5 FixedToNearEdge=�6=   $6 1��6]   #; [ 6h   5�       5�     $@ ReceivingStats��6#   $A ReceivingStats��68   B 5�       5�     $
 TrueY�63   .1 5�       $2 WeekNum��6!   $
3 Week��60   $5 FixedToNearEdge=�6=   $6 1��6]   #; [ 6h   5�     5�     5�     5�     