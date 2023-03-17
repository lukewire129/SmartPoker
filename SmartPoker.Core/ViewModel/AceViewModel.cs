using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using SmartPoker.Core.Events;
using SmartPoker.Core.View;

namespace SmartPoker.Core.ViewModel
{
		public class AceViewModel : IAceViewLoadable
		{
				protected readonly IEventAggregator _eh;
				protected readonly IRegionManager _regionManager;
				protected readonly IContainerExtension _container;

				private IAceViewable _smartWindow;
				public void OnLoaded(IAceViewable smartWindow)
				{
						_smartWindow = smartWindow;
				}

				public AceViewModel(IEventAggregator eh,
												IRegionManager regionManager,
												IContainerExtension container)
				{
						this._eh = eh;
						this._regionManager = regionManager;
						this._container = container;
						this._eh.GetEvent<LanguageChangeEvent> ().Subscribe (LanguageChange);
				}


				protected void MoveContent(string ContentName)
				{
						IRegion contentRegion = _regionManager.Regions["MainRegion"];
						IAceViewable currentContent = _container.Resolve<IAceViewable> (ContentName);
						if (!contentRegion.Views.Contains (currentContent))
						{
								contentRegion.Add (currentContent);
						}
						contentRegion.Activate (currentContent);
				}

				protected void MoveContent(string regionsName, string ContentName)
				{
						IRegion contentRegion = _regionManager.Regions[regionsName];
						IAceViewable currentContent = null;
						if (!contentRegion.Views.Contains (currentContent))
						{
								contentRegion.Add (currentContent);
						}
						contentRegion.Activate (currentContent);
				}

				private void LanguageChange(string obj)
				{
						_smartWindow.Language (obj);
				}
		}
}
