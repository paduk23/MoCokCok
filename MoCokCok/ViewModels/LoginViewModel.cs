using MoCokCok.Defines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MoCokCok.ViewModels
{
	public class LoginViewModel : ViewModelBase
	{
		#region Property

		#endregion

		#region ICommand

		public ICommand OnEventLoadedCommand => new RelayCommand(obj => Loaded());
		public ICommand OnClickLoginCommand => new RelayCommand(obj => Login());

		#endregion

		public LoginViewModel()
		{
			;
		}

		private void Loaded()
		{
			MessageBox.Show($"Loaded");
			;
		}
		
		private void Login()
		{
			MessageBox.Show($"Login");
			;
		}
	}
}
