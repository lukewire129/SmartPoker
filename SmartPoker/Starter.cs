using SmartPoker.Settings;
using System;

namespace SmartPoker
{
		public class Starter
		{
				[STAThread]
				private static void Main(string[] args)
				{
						_ = new App ()
							.AddWireDataContext<WireDataContext> ()
							.AddInversionModule<ViewModules> ()
							.AddInversionModule<DirectModules> ()
							.Run ();
				}
		}
}
