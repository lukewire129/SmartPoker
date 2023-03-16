using Prism.Ioc;
using Prism.Modularity;
using SmartPoker.Core;

namespace SmartPoker.Settings
{
		public class ViewModules : IModule
		{
				public void OnInitialized(IContainerProvider containerProvider)
				{
				}

				public void RegisterTypes(IContainerRegistry containerRegistry)
				{
						containerRegistry.RegisterSingleton<IAceViewable, Main.MainContent> (ContentName.MainContent);
						containerRegistry.RegisterSingleton<IAceViewable, HandHistory.MainContent> (ContentName.HandHistoryContent);
						containerRegistry.RegisterSingleton<IAceViewable, Option.MainContent> (ContentName.OptionContent);
				}
		}
}
