using Prism.Events;
using SmartPoker.Core.Events;
using SmartPoker.Core.View;

namespace SmartPoker.Core.ViewModel
{
    public class AceViewModel : IAceViewLoadable
    {
        private IAceViewable _smartWindow;
        protected readonly IEventAggregator _eh;
        public void OnLoaded(IAceViewable smartWindow)
        {
            _smartWindow = smartWindow;
        }

        public AceViewModel(IEventAggregator eh)
        {
            _eh = eh;
            _eh.GetEvent<LanguageChangeEvent>().Subscribe(LanguageChange);
        }
        private void LanguageChange(string obj)
        {
            _smartWindow.Language(obj);
        }
    }
}
