using Prism.Events;
using SmartPoker.Core.Events;

namespace SmartPoker.Core
{
		public class AceViewModel : IAceViewLoadable
		{
				private IAceViewable _smartWindow;
				protected readonly IEventAggregator _eh;
				public void OnLoaded(IAceViewable smartWindow)
				{
						this._smartWindow = smartWindow;
				}

				public AceViewModel(IEventAggregator eh)
				{
						this._eh = eh;
						this._eh.GetEvent<LanguageChangeEvent> ().Subscribe (LanguageChange);
				}
				private void LanguageChange(string obj)
				{
						this._smartWindow.Language (obj);
				}
		}
}
