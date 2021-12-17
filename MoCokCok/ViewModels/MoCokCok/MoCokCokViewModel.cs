using MoCokCok.Defines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoCokCok.ViewModels.MoCokCok
{
    public class MoCokCokViewModel : ViewModelBase
    {

        private bool _isMenuClick;
        public bool IsMenuClick
        {
            get => _isMenuClick;
            set => SetField(ref _isMenuClick, value);
        }

		public ICommand TestCommand => new RelayCommand(obj => Test());



        private void Test()
		{
            ;
		}
    }
}
