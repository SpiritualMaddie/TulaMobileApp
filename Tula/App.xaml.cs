﻿using Microsoft.Identity.Client;

namespace Tula
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
