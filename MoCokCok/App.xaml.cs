using MoCokCok.ViewModels;
using MoCokCok.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MoCokCok
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        private const string mutexName = "MoCokCok_Project";
        private Mutex _mutex = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                _mutex = new Mutex(true, mutexName, out bool isNew);
                if (isNew)
                {
                    base.OnStartup(e);
                    var login = new LoginView();
                    login.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"MoCokCok는 이미 실행중입니다.", $"중복 실행", MessageBoxButton.OK, MessageBoxImage.Information);
                    Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace + "\n\n" + "Application Existing...", "Exception thrown");
                Current.Shutdown();
            }
        }

    }
}
