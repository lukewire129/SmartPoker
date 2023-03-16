using Jamesnet.Wpf.Controls;
using SmartPoker.Forms;
using System.Windows;

namespace SmartPoker
{
		public class App: JamesApplication
		{
				protected override Window CreateShell()
				{
						return new SmartPokerWindow ();
				}
		}
}
