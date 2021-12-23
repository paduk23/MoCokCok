using MoCokCok.Defines;
using MoCokCok.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MoCokCok.ViewModels.MoCokCok
{
	public class MoCokCokViewModel : ViewModelBase
	{
		#region Property

		private bool _isMenuClick;
		public bool IsMenuClick
		{
			get => _isMenuClick;
			set => SetField(ref _isMenuClick, value);
		}


		private ObservableCollection<MenuModel> _menus;
		/// <summary>
		/// Navigation Items : Declaring / Initializing
		/// </summary>
		public ObservableCollection<MenuModel> Menus
		{
			get
			{
				if(_menus is null)
				{
					_menus = new ObservableCollection<MenuModel>
					{
						new MenuModel { Idx = 0, Title = $"Home",     Icon =  new BitmapImage(new Uri("/Assets/img_home.png", UriKind.Relative))},
						new MenuModel { Idx = 1, Title = $"Maps",     Icon =  new BitmapImage(new Uri("/Assets/img_map.png", UriKind.Relative))},
						new MenuModel { Idx = 2, Title = $"Settings", Icon =  new BitmapImage(new Uri("/Assets/img_setting.png", UriKind.Relative))},
					};
				}
				return _menus;
			}
		}

		#endregion




			#region Command

		public ICommand TestCommand => new RelayCommand(obj => Test());

		public ICommand OnEventPreviewClickCommand => new RelayCommand(obj => IsMenuClick = false);

		#endregion


		private void Test()
		{
			;
		}
	}
}
