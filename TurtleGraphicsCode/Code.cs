using System.Drawing;

namespace TurtleGraphicsCode
{

	public class Code
	{
		public Turtle ToExecute()
		{
			Turtle t = new Turtle(true);
			Text txt = new Text();
			ImagePrint prn = new ImagePrint();
			t = prn.Print(t,"ll");
			t.SetBrushSize(1);
			t.AnimatePath = false;
			t.TurtleSpeed = 50;
			t.SetColor("brown");
			t = txt.Write(t, "Želva", true, 1);
			t.Rotate(22.5);
			t.SetColor("Black");
			t = txt.Write(t, "píše!", false, 1);
			for (int i = 0; i < 14; i++)
			{
				t.Rotate(22.5);
				t = txt.Write(t, i + string.Empty, (i % 2) == 1, 1, new Font(SystemFonts.DefaultFont.FontFamily, 36, FontStyle.Underline));
			}
			
			return t;
		}
	}
}
