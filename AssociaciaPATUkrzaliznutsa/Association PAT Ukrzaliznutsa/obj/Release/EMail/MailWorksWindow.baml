   M S B A M L   `   `   `  ���� X  TAssociation PAT Ukrzaliznutsa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Association_PAT_Ukrzaliznutsa.EMail#Association_PAT_Ukrzaliznutsa.EMail  9    3Association_PAT_Ukrzaliznutsa.EMail.MailWorksWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Clocal1clr-namespace:Association_PAT_Ukrzaliznutsa.EMail       � Title$  MailWorksWindow��$	��450��$	��800��.���  � ColumnDefinitions �� �� �� �� ��  � RowDefinitions �� �� �� �� �� �� .+��� -   $��mailfrom��$��0��$��0��$��20q�$��2��G� -   $��passfrom��$��2��$��0��$��20q��� -   $��mailto��$��0��$��1��$��20q�$��3���� -   $
��Send��$��4��$��10q�$��Отправить���� -   $
��Load��$��4��$��1��$��20q�$��Загрузить���� -   $��	btnAttach��$��4��$��2��$��20q�$+��%Прикрепить вложение���� -   $��server��$��3��$��0��$��20q��� -   $
��port��$��3��$��1��$��20q��� -	   $��checkbox��$��3��$��2��$��20q�$��SSL-соединение���� -
   $��subject��$��0��$��2��$��20q�$��2��&   System.Windows.Controls.DataGrid  -   $��datagrid��$��0��$��3��$��3��$��4���� $
��Left=�$��	89,-1,0,0q�$
��Wrap=�$'��!Электронная почта��$	��Top=�$��2��$	��155���� $
��Left=�$��56,2,0,0q�$
��Wrap=�$��Пароль��$	��Top=�$��66��$��2���� $
��Left=�$��47,2,0,0q�$
��Wrap=�$��Сервер почты��$	��Top=�$��91��$��3���� $
��Left=�$��58,0,0,0q�$
��Wrap=�$��Порт��$	��Top=�$��68��$��3��$��1���� $
��Left=�$��	141,4,0,0q�$
��Wrap=�$��Тема��$	��Top=�$��68��$��2��$��2���� $
��Left=�$��	125,3,0,0q�$
��Wrap=�$'��!Адресс получателя��$	��Top=�$	��119��$��1��$��2��