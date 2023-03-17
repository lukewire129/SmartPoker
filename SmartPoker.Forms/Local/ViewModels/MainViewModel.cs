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

namespace SmartPoker.Forms.Local.ViewModels
{
		[INotifyPropertyChanged]
		public partial class MainViewModel : AceViewModel
		{
				[ObservableProperty]
				private List<ToolItem> _tools = new List<ToolItem> ();

				public MainViewModel(IEventAggregator eh,
												IRegionManager regionManager,
												IContainerExtension container)
						: base (eh,regionManager, container)
				{
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
						if (item.Type == ToolItemType.MAIN)
								MoveContent (ContentName.MainContent);
						else if (item.Type == ToolItemType.HANDHISTORY)
								MoveContent (ContentName.HandHistoryContent);
						else if (item.Type == ToolItemType.OPTION)
								MoveContent (ContentName.OptionContent);
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
