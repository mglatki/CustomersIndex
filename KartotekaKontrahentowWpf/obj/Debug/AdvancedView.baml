   M S B A M L   `   `   `  ����I  ECustomersIndex, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CustomersIndex.ViewModelsCustomersIndex.ViewModels  5      S.clr-namespace:CustomersIndex.TemplateSelectors CustomersIndex.TemplateSelectors  5      !    CustomersIndex.AdvancedView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =	viewmodel'clr-namespace:CustomersIndex.ViewModels     5      Ltemplateselectors.clr-namespace:CustomersIndex.TemplateSelectors     5        N� Title$  AdvancedView��5
       � DataContext 5      3   -CustomersIndex.ViewModels.MainWindowViewModel  5   
    � 	Resources 5         BusinessClientDataTemplate �� Orientation �� Path �� ModeB   <CustomersIndex.TemplateSelectors.ClientsListTemplateSelector  ClientsListTemplateSelector��%�  &	        &	 �    �� 5   
   .R�5      �� $ 
Horizontal=�6   
����ح�.+�5      �� $��5q�6   ��6'   �� *Name+�� 5      $��5q�6   ��6'   �� *City+�� 5      $��Edit client��6   $��5q�6/   ��5      �� $# DataContext.EditClientCommand�$ TwoWay=���5      �� �� 5      $��Delete client��6   $��5q�61   ��5      �� $% DataContext.DeleteClientCommand�$ TwoWay=���5      �� 5      5        5'   
   68   5(      .��5)      �  � ColumnDefinitions 5*   
   �� 5+      $
��0.1* �6   $��50��6,   $��25��6:   �� 5,      $
��9.9* �6   .+�5/   
   �� $ Vertical=�6   .+�50      �� $��+��6   ��6!   �� *OpenAddClientPanelCommand+$ TwoWay=��� 52      $��L��6   53      �� 55   
   $��0��6   $��1��6!   $��5q�61   $��Stretch=�56      $��Stretch=�60   #��[ 59      ��57      �� *ClientsList+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 58      �� *SelectedClient+$ TwoWay=�59      � 5;   
   $��1��6   $��Stretch=�6Z   $��Stretch=�6x   
������y�6   �� *EditionPanelVisibility+$ TwoWay=�	 � RowDefinitions	 5<      �� 5=      $��0.25* �6    �� 5>      $��0.25* �6    �� 5?      $��0.25* �6    �� 5@      $��0.25* �6    .+�5B      �� $ 
Horizontal=�6   .+�5C      �� $��0��6   $��0��6)   $��5q�69   $��Center=�5D      $��Center=�63   $��Client name��5E      �� 5F      $	��100��6   $��Center=�5G      $��Center=�61   ��5H      �� *
ClientName+$ TwoWay=�5I      �� 5K      $ 
Horizontal=�6   $��1��62   $��0��6?   .+�5L      �� $��0��6   $��0��6)   $��5q�69   $��Center=�5M      $��Center=�63   $��Client city��5N      �� 5O      $	��100��6   $��Center=�5P      $��Center=�6.   ��5Q      �� *
ClientCity+$ TwoWay=�5R      �� 5T      $ 
Horizontal=�6   $��2��5U      $��0��6"   $��Center=�5V      $��Center=�60   .+�5W      �� $��Business client��6   $��5q�63   �� 5X      $��Center=�6   $��Center=�66   
 d� 	IsChecked
 5Y      �� *IsBussinessClientChecked+$ TwoWay=�5Z      �� 5\      $��3��6   $��0��6"   $��Center=�5]      $��Center=�60   $
��Save��5^      ��5_      �� *SaveEditedClientCommand+$ TwoWay=�5`      5a      5b      