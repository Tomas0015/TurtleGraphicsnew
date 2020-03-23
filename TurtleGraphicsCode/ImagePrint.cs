using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TurtleGraphicsCode
{
	class ImagePrint
	{
		public Turtle Print(Turtle printer, string input, int spacing = 1)
		{
			printer.ShowTurtle = false;
			int width = 64;
			int height = 64;
			Bitmap image = (Bitmap)Image.FromFile(input, true);
			for (int i = 0; i < image.Height; i++)
			{
				for (int j = 0; j < image.Width; j++)
				{
					Color clr = image.GetPixel(j, i);
					printer.SetColor(clr.R, clr.G, clr.B);
					printer.Forward(1);
				}
				printer.CaptureScreenshot();
				printer.PenUp();
				printer.Rotate(90,false);
				printer.Forward(spacing);
				printer.Rotate(90,false);
				printer.Forward(image.Width);
				printer.Rotate(-180,false);
				printer.PenDown();
			}
			printer.ShowTurtle = true;
			return printer;
		}
	}
}
