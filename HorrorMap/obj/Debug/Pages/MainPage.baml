   M S B A M L   `   `   `  ����D  @HorrorMap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HorrorMap.PagesHorrorMap.Pages  5          HorrorMap.Pages.MainPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:HorrorMap.Pages     5      -   5          N� Title$  MainPage��5	       � 	Resources 5       �� 
TargetType �� Property �� Value �� EndPoint �� 
StartPoint �� Opacity � Color	 � Offset��%!  '��       '�� T     '�� \    '�� �    �� 5   
   " ��6   .�5      ��  �@��CornerRadius$ 0��6-   5      �� 5   
   " ��6   .�5      ��  � ��$ 10��6&   �� 5       � ��$ 10��6'   �� 5       � ��
 ���� 6+   �� 5       � ��
 � � �6+   �� 5       �@��Padding$ 10q�6(   �� 5       � ��$ 10(�6)   5      �� 5   
   " ��6   .�5      ��  � ��
 � � �6+   �� 5       � ��$ 17(�6)   �� 5       � ��$ Century Schoolbook)�6+   5       �� 5#   
   " ��6   .�5$      ��  � �� 5%      �� 5&      $ 0.5,1&�6*   $ 0.5,0&�6;   $	 0.2Q�6N   .��5'      � $ 	#FF005100��6'   $	 0Q�69   � 5(      $ 	#FF005500��6'   $	 1Q�69   5)      5+      5,      5.      .��50      � .+�54   
   �� $��/Background/horror.jpg��6   $
��Fill=�60   � 55   
   
 � ColumnDefinitions
 56      �� 57      $	��950 �6#   �� 58      �� 59      .+�5<      �� $��1��6    �� Orientation$ 
Horizontal=�6)   $	��Top=�6B   $��0 10 0 0q�6Z   .+�5=      �� $��Поиск:��6   $��0q�6)   $��22(�6=   �� 5>      -   5         ��Name$ tbSearch��5>      $��30��6,   $	��400��68   $��Right=�6D   $��5q�6`   
��� � �
��� � � �� 
CaretBrush
 � � �.��6�   ��5?      �� 5@      $ 0.5,1&�6.    � MappingMode$ RelativeToBoundingBox=�6?   $ 0.5,0&�6c   $	 0.2Q�6v   .��5A      � $ 	#FF006800��6+   $	 0.544Q�6=   � 5B      $ Black��6+   $	 1Q�69   � 5C      $ Black��6+   $	 0.004Q�69   5D      .��5E   *   5F      5I      � 5K      $��0��6   .+�5M      �� -   5         ��Name$ ListMain��5M      
������ 
������ $��0 0 0 0q�6�    � Cursor$
 Hand��6�   ��5N      �� 5P      .R�5Q      � 
 5S   "   �� 5T   &   $��* �67   �� 5U   &   $��* �67   .+�5Y   "   � $��0��6'   $��0 0 0 0q�5Z   #   .+�5[   &   �� $	��300��6,   $	��400��5\   (   ��5]   (   �� *
ImageMovie+5_   '   5`   #   � 5b   "   $��1��6'   .+�5c   &   �� $	��Top=�61   $
��Left=�5d   1   $ Vertical=�5e   1   .+�5f   *   ��  �� ContentStringFormat$ 0��6I   $��30(�6a   $��	150 0 0 0q�6o   ��60   �� *Name+6o   �� 5g   *   $ Страна: {0}��6S   $��0,20,0,0q�6u   ��60   �� *CountryCreator+6u   �� 5h   *   $ Режиссер: {0}��6V   $��0,0,0,0q�6z   ��60   �� *Creators.Director+6z   �� 5i   *   $ Жанры: {0}��6K   $��0,0,0,0q�6l   ��60   �� *Genres+6l   �� 5j   *   $6 0Возрастное ограничение: {0}��6R   $��0,0,0,0q�6�   ��60   �� *AgeLimit.MPAA+6�   5k   '   5m   #   5o      5q      5s      5t      �� 5w      $��2��6   $��Right=�6)   .+�5x      �� -   5         ��Name$ 
ButtonExit��5x   *   $��
Выход��6   6>   �� 5y      -   5        $ 	ButtonAdd��5y   `   $!��Добавить фильм��6   $��15 200 15 15q�62   6`   �� 5z      -   5        $ 
ButtonEdit��5z   7   $+��%Редактировать фильм��6   6K   �� 5{      -   5        $ ButtonDelete��5{   P   $1��+Удалить фильм из списка��6   $��15 15 15 15q�6;   6f   5|      5�      5�      5�      