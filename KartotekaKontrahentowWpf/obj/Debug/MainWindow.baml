   M S B A M L   `   `   `  ����I  ECustomersIndex, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CustomersIndex.UtilitiesCustomersIndex.Utilities  5   	   /clr-namespace:CustomersIndexCustomersIndex  5   	   E'clr-namespace:CustomersIndex.ViewModelsCustomersIndex.ViewModels  5   	   S.clr-namespace:CustomersIndex.TemplateSelectors CustomersIndex.TemplateSelectors  5   	       CustomersIndex.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <	utilities&clr-namespace:CustomersIndex.Utilities     5   	   .viewsclr-namespace:CustomersIndex     5   	   =	viewmodel'clr-namespace:CustomersIndex.ViewModels     5   	   Ltemplateselectors.clr-namespace:CustomersIndex.TemplateSelectors     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � DataContext 5	      3   -CustomersIndex.ViewModels.MainWindowViewModel  5
   
    � 	Resources 5         BusinessClientDataTemplate � ColumnDefinitions �� ElementName �� Path �� Mode   IndividualClientDataTemplateB   <CustomersIndex.TemplateSelectors.ClientsListTemplateSelector  ClientsListTemplateSelector  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder   BooleanToVisibilityConverter5   /CustomersIndex.Utilities.SelectedPanelConverter  SelectedPanelConverter=   7CustomersIndex.Utilities.TextInputToVisibilityConverter " TextInputToVisibilityConverter 	 EntryFieldStyle �� 
TargetType	 �� Property
 �� Value 
 BorderlessButtonStyle  buttonstripe1 �� 
TargetType � Cursor �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName��%�	  &	        &	 �    &	 �    &	 �    &	 �    &	 �    &	      &	     &	 &    &		 9    &	
 �    &	 J    �� 5   
   .R�5      � $��Stretch=�6    5      �� 5      $
��0.4* �6'   �� 5      $
��0.4* �6'   �� 5      $
��0.1* �6'   �� 5      $
��0.1* �6'   .+�5      �� $��Stretch=�5      ��5      �� *Name+5      �� 5      $��1��62   $��Stretch=�5      ��5      �� *City+5      �� 5      $��Edit client��6   $��5q�6/   $��2��6:   ��5      �� $ ClientsListView��$# DataContext.EditClientCommand�$ TwoWay=���5      �� �� 5      $��Delete client��6   $��5q�61   $��3��6<   ��5      �� $ ClientsListView��$% DataContext.DeleteClientCommand�$ TwoWay=���5      �� 5       5+      �� 5,   
   .R�5-      � $��Stretch=�6    5.      �� 5/      $
��0.4* �6'   �� 50      $
��0.4* �6'   �� 51      $
��0.1* �6'   �� 52      $
��0.1* �6'   .+�55      �� $��Stretch=�56      ��55      �� *Name+56      �� 57      $��1��62   $��Stretch=�58      ��57      �� *City+58      �� 59      $��Edit client��6   $��5q�6/   $��2��6:   ��5:      �� $ ClientsListView��$# DataContext.EditClientCommand�$ TwoWay=���5;      �� �� 5<      $��Delete client��6   $��5q�61   $��3��6<   ��5=      �� $ ClientsListView��$% DataContext.DeleteClientCommand�$ TwoWay=���5>      �� 5?      5J        5L   
   68   �� 5N   
   $ White��6;   �� 5O   
   $ LightSteelBlue��6;   �� 5P   
   $ Indigo��67   �� 5R   
   6'     5S   
   6+     5T   
   63   �� 5V   
   " �6(   .�5W      �� 	 � ��$
 Stretch=�64   �� 5X      	 � ��$
 Center=�62   �� 5Y      	 � ��$

 20,0q�6'   5Z      �� 5\   
   " ��6.   .�5]      �� 	 � ��$
 Stretch=�6;   �� 5^      	 � ��$
 Stretch=�69   5_      �� 5`   
   " 	�6   .�5a      �� 	 � ��
 5b      �� 5c      " 	�6&   .R�5d      �� $
 Hand��6*   ._�5f      �� $��30��6%   $��60��60   $ 3��6<   ���	#FFE2E2E2$��1q�6e   ._�5g   "   � .+�5h   &   � $��	RadioMark��6B   
��������� 5i   &   $��Center=�67   $��Center=�6T   5j   #   5k      5l       5o      P� 5p       �@d�	IsChecked$
 trueY�6;   . �5q   "   �� $ 	RadioMark��6)   	 � ��

 �����6V   5r      5t      5v      5w      5x      .��5z      �  5{   
   �� 5|      $
��0.1* �6   $��50��6,   $��25��6:   �� 5}      $
��9.9* �6   .+�5�   
   ��  �� Orientation$ Vertical=�6   
�������.+�5�      	�  	� 	GroupName$ groupA��6   $��+��6-   #��[ 5�   U    d� 	IsChecked 5�      �� *SelectedPanel+ �� 	Converter# [  �� ConverterParameter$ +����5�      �� *OpenAddClientPanelCommand+$ TwoWay=�6U   	� 5�      $ groupA��6   $��L��6-   #��[ 5�   K    5�      �� *SelectedPanel+# [ $ L����5�      �� *ShowListCommand+$ TwoWay=�6K   5�      �� 5�   
   -   5        $��ClientsListView��5�   <   $��0��6   $��1��6!   $��5q�61   $��Stretch=�5�      $��Stretch=�60   $��Stretch=�6N   #��[ 5�      ��5�      �� *ClientsList+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5�      � 5�   
   $��1��6   $��Stretch=�5�      $��Stretch=�6-   
�������y�5�      �� *EditionPanelVisibility+$ TwoWay=� � RowDefinitions 5�      �� 5�      $��0.20* �6    �� 5�      $��0.20* �6    �� 5�      $��0.20* �6    �� 5�      $��0.20* �6    �� 5�      $��0.20* �6     5�      �� 5�      $
��0.5* �6#   �� 5�      $
��0.5* �6#   .+�5�      � $��2��6   .+�5�      �  5�      �� 5�      $
��0.5* �6(   �� 5�      $
��0.5* �6(    5�      �� 5�      $��* �6+   �� 5�      $	��100��6+   $
��0.1* �6:   .+�5�      � $��2��6   #��[ 6,   #��[	 6c   $��Center=�6�   .+�5�      �� $	��5,2q�6$   $��Enter clients name��61   #��[ 6K   y�5�      �� $ txtClientsName��$ Text.IsEmpty�# [ �� 5�      -   5        $��txtClientsName��5�   "   
������ #��[ 6Q   ��6�   �� *
ClientName+$ TwoWay=�5�      �� 5�      $��Business client��6    $��5q�67   $��0��6B   $��1��6O   $��Center=�6_   $��Center=�6|   �� 5�      $��Center=�6   $��Center=�6:   $��1��6W   $��1��6d    5�      �� *IsBussinessClientChecked+$ TwoWay=�5�      5�      � 5�      $��1��6   $��0��6    #��[ 60   #��[	 6g   $��Center=�6�   .+�5�      �� $	��5,2q�6   $��Enter clients country��6)   #��[ 6F   y�5�      �� $ txtClientsCountry��$ Text.IsEmpty�# [ �� 5�      -   5        $��txtClientsCountry��5�      
������ #��[ 6L   ��6�   �� *ClientCountry+$ TwoWay=�5�      � 5�      $��1��6   $��1��6    #��[ 60   #��[	 6g   $��Center=�6�   .+�5�      �� $	��5,2q�6   $��Enter clients city��6)   #��[ 6C   y�5�      �� $ txtClientsCity��$ Text.IsEmpty�# [ �� 5�      -   5        $��txtClientsCity��5�      
������ #��[ 6I   ��6}   �� *
ClientCity+$ TwoWay=�5�      � 5�      $��2��6   $��0��6    #��[ 60   #��[	 6g   $��Center=�6�   .+�5�      �� $	��5,2q�6   $��Enter clients street��6)   #��[ 6E   y�5�      �� $ txtClientsStreet��$ Text.IsEmpty�# [ �� 5�      -   5        $��txtClientsStreet��5�      
������ #��[ 6K   ��6   �� *ClientStreet+$ TwoWay=�5�      � 5�      $��2��6   $��1��6    #��[ 60   #��[	 6g   $��Center=�6�   .+�5�      �� $	��5,2q�6   $!��Enter clients street number��6)   #��[ 6L   y�5�      �� $ txtClientsStreetNumber��$ Text.IsEmpty�# [ �� 5�      -   5        $��txtClientsStreetNumber��5�      
������ #��[ 6Q   ��6�   �� *ClientStreetNumber+$ TwoWay=�5�      � 5�      $��3��6   $��0��6    #��[ 60   #��[	 6g   $��Center=�6�   .+�5�      �� $	��5,2q�6   $��Enter phone number��6)   #��[ 6C   y�5�      �� $ txtClientsPhoneNumber��$ Text.IsEmpty�# [ �� 5�      -   5        $��txtClientsPhoneNumber��5�      
������ #��[ 6P   ��6�   �� *ClientsPhoneNumber+$ TwoWay=�5�      � 5�      $��3��6   $��1��6    #��[ 60   #��[	 6g   $��Center=�6�   .+�5�      �� $	��5,2q�6   $��Enter email��6)   #��[ 6<   y�5�      �� $ txtClientsEmail��$ Text.IsEmpty�# [ �� 5�      -   5        $��txtClientsEmail��5�      
������ #��[ 6J   ��6~   �� *ClientsEmailAdres+$ TwoWay=�5�      � 5�      $��4��6   $��1��6     5�      �� 5�      $��* �6'   �� 5�      $��* �6'   .+�5�      �� $��4��6   $��0��6&   $��Center=�5�      $��Center=�60   $
��Save��5�      ��5�      �� *SaveEditedClientCommand+$ TwoWay=��� 5�      $��4��6   $��1��6&   $��Center=�5�      $��Center=�60   $��Cancel��5�      ��5�      �� *CancelEditedClientCommand+$ TwoWay=�5�      5�      5�      5�      