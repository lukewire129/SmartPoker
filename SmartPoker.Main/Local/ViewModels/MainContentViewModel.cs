using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Events;
using SmartPoker.Core.ViewModel;

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
