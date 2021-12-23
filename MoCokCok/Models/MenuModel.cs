using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MoCokCok.Models
{
	public class MenuModel
	{
		/// <summary>
		/// 식별자
		/// </summary>
		public int Idx { get; set; }

		/// <summary>
		/// Menu Name
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Menu Icon
		/// </summary>
		public ImageSource Icon { get; set; }

	}
}
