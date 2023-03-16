using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SmartPoker.Core;

namespace SmartPoker.Settings
{
		internal class DirectModules : IModule
		{
				public void OnInitialized(IContainerProvider containerProvider)
				{
						IRegionManager region = containerProvider.Resolve<IRegionManager> ();
						region.RegisterViewWithRegion ("MainRegion", ContentName.MainContent);
				}

				public void RegisterTypes(IContainerRegistry containerRegistry)
				{
				}
		}
}
