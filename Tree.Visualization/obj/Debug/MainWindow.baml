   M S B A M L   `   `   `  ����M  ITree.Visualization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Tree.VisualizationTree.Visualization  5   	   #    Tree.Visualization.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Tree.Visualization     5   	   -   5          � Title$  
MainWindow��5   	   $	��800��6   $
��1200��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   �� 
���   �$��	0, 0, 0 2q�6%   ._�5      � 
����ح� � ColumnDefinitions 5      �� 5      $
��auto �6'   66   �� 5      $
��auto �6'   66   �� 5      $
��auto �6'   66   �� 5      $
��auto �6'   66   �� 5      $
��auto �6'   66   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��10q�66   .+�5      �� Number of Features:66   �� 5      -   5        $��DimensionBox��5   8   $	��100��6   $
��5, 0q�6*   .��6L   26O   5      �� 5      $ 
Horizontal=�6   $��1��66   $��10q�6F   .+�5      �� Activate Pruning:64   �� 5      -   5         ��Name$ PruneBox��5      $
��5, 0q�61   6A   5      �� 5      $��2��6   $��10q�6-   .+�5       �� -   5         ��Name$# RecalculateDecisionTreeButton��5    1   $��
0, 0, 0, 5q�6   $	��150��6x   .��6�   Create decision tree6�   �� 5!      -   5        $% RecalculateRegressionTreeButton��5!      $	��150��6t   .��6�   Create regression tree6�   5"      �� 5#      $��3��6   $��10q�6-   .+�5$      �� -   5        $ ImportButton��5$   1   $��
0, 0, 0, 5q�6   $	��150��6b   .��6n   Import tree6{   �� 5%      -   5        $ ExportButton��5%      $	��150��6N   .��6Z   Export tree6g   5&      5'      5(      �� 5)   
   -   5         ��Name$ 
TreeCanvas��5)      $��1��6   
�������.+�5*      � $��Center=�6    �� Left 60   �� *ActualWidth+ �� ElementName$ 
TreeCanvas��
	 �� Top	 5+      �� *ActualHeight+$ 
TreeCanvas��5,      5-      5.      5/      