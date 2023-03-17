using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using SmartPoker.Core.ViewModel;

namespace SmartPoker.Main.Local.ViewModels
{
    [INotifyPropertyChanged]
		public partial class MainContentViewModel : AceViewModel
		{
				public MainContentViewModel(IEventAggregator eh,
												IRegionManager regionManager,
												IContainerExtension container)
						: base (eh, regionManager, container) 
				{

				}
		}
}
