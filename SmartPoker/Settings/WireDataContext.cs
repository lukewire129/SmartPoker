using Jamesnet.Wpf.Global.Location;
using SmartPoker.Forms;
using SmartPoker.Forms.Local.ViewModels;
using SmartPoker.Main;
using SmartPoker.Main.Local.ViewModels;

namespace SmartPoker.Settings
{
		public class WireDataContext : ViewModelLocationScenario
		{
				protected override void Match(ViewModelLocatorCollection items)
				{
						items.Register<SmartPokerWindow, MainViewModel> ();
						items.Register<MainContent, MainContentViewModel> ();
				}
		}
}
