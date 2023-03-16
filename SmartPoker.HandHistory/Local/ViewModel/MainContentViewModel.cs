using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Events;
using SmartPoker.Core;

namespace SmartPoker.HandHistory.Local.ViewModel
{
		[INotifyPropertyChanged]
		public partial class MainContentViewModel :AceViewModel
		{
				public MainContentViewModel(IEventAggregator eh) :base(eh) { }
		}
}
