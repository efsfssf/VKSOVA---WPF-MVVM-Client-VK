   M S B A M L   `   `   `  ????B  >TestWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TestWPF.ViewsTestWPF.Views  5          TestWPF.Views.MakeUsers   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:TestWPF.Views     5      .??5	      ?   ? RowDefinitions  5
   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   .+?5   
   ?? $/??)Добавить пользователя??5      $??0??5       
  Header#??[  5      ? 5   
   $??1??6   $??	 0 25 0 0q?6     5      ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    .+?5      ?? $??0??6   $??Имя??6%   ?? 5      $??1??5      $??0 10 0 0q?5       ??5      ?? *Name+ ?? UpdateSourceTrigger$ PropertyChanged=?5       5!      ? 5#   
   $??2??6   $??	 0 25 0 0q?6     5$      ?? 5%      $
??auto ?6    ?? 5&      $
??auto ?6     ? ColumnDefinitions 5(      ?? 5)      $
??auto ?6#   ?? 5*      $
??auto ?6#   .+?5-      ?? $??0??6   $??0??6%   $??Дата рождения??65   (  "System.Windows.Controls.DatePicker  5.      $??1??5/      $??0??50      $??	0 10 10 0q?52      $	??500??53         SelectedDate 51      ?? *
Birthday+$ PropertyChanged=?53      ?? 55      $??0??6   $??1??6%   $??
Город??65   $??5 0 0 0q?6B   ?? 56      $??1??57      $??1??58      $??
0,10,-30,0q?5:      $
??auto??6%   ??59      ?? *Sity+$ PropertyChanged=?5:   %   5;      ?? 5<   
    ?? Orientation$ 
Horizontal=?6   $??3??6.   $??	 0 25 0 0q?6;   .+?5=      ?? $??Submit??6   ??6&   ?? *SubmitCommand+?? 5>      $??Cancel??6   $??5 0 0 0q?6&   ??67   ?? *CancelCommand+?? 5?      $
??Make??6   $??5 0 0 0q?6$   ??65   ?? *MakeUsersCommand+5@      5A      5B      