using Jamesnet.Wpf.Controls;
using Prism.Mvvm;
using SmartPoker.Core.MultiLanguage;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;

namespace SmartPoker.Core
{
		public class AceWindow : Window, IAceViewable
		{
				public FrameworkElement View { get; init; }

				public AceWindow()
				{
						View = this;
						ViewModelLocationProvider.AutoWireViewModelChanged (this, AutoWireViewModelChanged);
				}
				private void AutoWireViewModelChanged(object view, object dataContext)
				{
						DataContext = dataContext;

						if (dataContext is IViewInitializable vm)
						{
								vm.OnViewWired (view as IViewable);
						}
						if (dataContext is IAceViewLoadable && view is FrameworkElement fe)
						{
								fe.Loaded += Fe_Loaded;
						}
				}
				private void Fe_Loaded(object sender, RoutedEventArgs e)
				{
						if (sender is FrameworkElement fe && fe.DataContext is IAceViewLoadable vm)
						{
								fe.Loaded -= Fe_Loaded;
								vm.OnLoaded (fe as IAceViewable);
						}
				}

				public void Language(string type)
				{
						// List all our resources 
						List<ResourceDictionary> dictionaryList = new List<ResourceDictionary> ();

						foreach (ResourceDictionary dictionary in Resources.MergedDictionaries)
						{
								dictionaryList.Add (dictionary);
						} // We want our specific culture

						string requestedCulture = $"{ResourceName.path}.{type}.xaml";
						resourceDictionary = dictionaryList.FirstOrDefault (d => d.Source.OriginalString == requestedCulture);
						if (resourceDictionary == null)
						{
								resourceDictionary = dictionaryList.FirstOrDefault (d => d.Source.OriginalString == ResourceName.basepath);
						}
						if (resourceDictionary != null)
						{
								Resources.MergedDictionaries.Remove (resourceDictionary);
								Resources.MergedDictionaries.Add (resourceDictionary);
						}
						//지역화 설정 
						Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture (type);
						Thread.CurrentThread.CurrentUICulture = new CultureInfo (type);
				}

				private static ResourceDictionary resourceDictionary;
				public static ResourceDictionary SharedDictionary => resourceDictionary;
		}
}
