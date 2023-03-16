using SmartPoker.Forms.Local.Enums;

namespace SmartPoker.Forms.Local.Model
{
		public class ToolItem
		{
				public ToolItemType Type { get; set; }
				public string Name { get; set; }

				public ToolItem(ToolItemType type, string name)
				{
						Type = type;
						Name = name;
				}
		}
}
