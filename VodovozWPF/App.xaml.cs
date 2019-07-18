﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VodovozWPF.ViewModels;
using VodovozWPF.Views;

namespace VodovozWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {            
            base.OnStartup(e);

            MainWindowViewModel mainViewModel = new MainWindowViewModel();
            MainWindow mainWindowView = new MainWindow() { DataContext = mainViewModel };
            mainWindowView.Show();
        }
    }
}
