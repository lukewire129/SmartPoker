using System.Windows;
using System.Windows.Controls;

namespace SmartPoker.Main.UI.Units
{
		public class CustomRadioButton : RadioButton
		{
				static CustomRadioButton()
				{
						DefaultStyleKeyProperty.OverrideMetadata (typeof (CustomRadioButton), new FrameworkPropertyMetadata (typeof (CustomRadioButton)));
				}
		}
}
