using System.Windows;

namespace SmartPoker.Core.View
{
		public interface IAceViewable
    {
				FrameworkElement View { get; init; }
				object DataContext => View.DataContext;
				void Language(string type);
		}
}
