using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using SmartPoker.Core;
using SmartPoker.Core.Events;
using SmartPoker.Core.View;
using SmartPoker.Core.ViewModel;
using SmartPoker.Forms.Local.Enums;
using SmartPoker.Forms.Local.Model;
using System.Collections.Generic;
using System.Windows.Documents;

namespace SmartPoker.Forms.Local.ViewModels
{
    [INotifyPropertyChanged]
		public partial class MainViewModel : AceViewModel
		{
				[ObservableProperty]
				private List<ToolItem> _tools = new List<ToolItem> ();
				private readonly IRegionManager _regionManager;
				private readonly IContainerExtension _container;

				public MainViewModel(IEventAggregator eh,
												IRegionManager regionManager,
												IContainerExtension container)
						: base (eh)
				{
						this._regionManager = regionManager;
						this._container = container;

						Tools = new List<ToolItem> ()
						{
								new ToolItem(ToolItemType.MAIN, "M"),
								new ToolItem(ToolItemType.HANDHISTORY, "기록"),
								new ToolItem(ToolItemType.OPTION, "설정"),
						};
				}

				private int aaa = 0;

				[RelayCommand]
				private void SelectedMenu(ToolItem o)
				{
						// 화면 전환용
						ScreenChange (o);

						// 언어 변경용
						// LanguageChange (o);
				}

				private void ScreenChange(ToolItem o)
				{
						ToolItem item = o;

						IRegion contentRegion = _regionManager.Regions["MainRegion"];
						IAceViewable currentContent = null;

						if (item.Type == ToolItemType.MAIN)
								currentContent = _container.Resolve<IAceViewable> (ContentName.MainContent);
						else if (item.Type == ToolItemType.HANDHISTORY)
								currentContent = _container.Resolve<IAceViewable> (ContentName.HandHistoryContent);
						else if (item.Type == ToolItemType.OPTION)
								currentContent = _container.Resolve<IAceViewable> (ContentName.OptionContent);

						if (!contentRegion.Views.Contains (currentContent))
						{
								contentRegion.Add (currentContent);
						}
						contentRegion.Activate (currentContent);
				}

				private void LanguageChange(ToolItem o)
				{
						ToolItem item = o;
						if (item.Type == ToolItemType.MAIN)
								this._eh.GetEvent<LanguageChangeEvent> ().Publish ("ko-KR");
						else if (item.Type == ToolItemType.HANDHISTORY)
								this._eh.GetEvent<LanguageChangeEvent> ().Publish ("ja-JP");
						else if (item.Type == ToolItemType.OPTION)
								this._eh.GetEvent<LanguageChangeEvent> ().Publish ("en-US");
				}
		}
}
