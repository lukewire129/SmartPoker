using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Events;
using SmartPoker.Core;

namespace SmartPoker.Main.Local.ViewModels
{
		[INotifyPropertyChanged]
		public partial class MainContentViewModel : AceViewModel
		{
				public MainContentViewModel(IEventAggregator eh):
						base(eh)
				{

				}
		}
}
