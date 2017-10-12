using System.Windows.Forms;

namespace MeshCollision.Controlls
{
	public class CustomControl
	{
		public string Description;
		public Control Control;

		public CustomControl(string description, Control control) {
			Description = description;
			Control = control;
		}
	}
}