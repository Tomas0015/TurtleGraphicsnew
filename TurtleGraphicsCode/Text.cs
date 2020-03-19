using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TurtleGraphicsCode
{
	public class Text
	{
		public Turtle Write(Turtle writer, String input, bool inv)
		{
			char[] chars = input.ToCharArray();
			string[] lines = new string[CharToImage('A').Height];
			for (int ctr = 0; ctr < chars.Length; ctr++)
			{


				Bitmap image = CharToImage(chars[ctr]);

				for (int h = 0; h < image.Height; h++)
				{
					string line = string.Empty;
					for (int w = 0; w < image.Width; w++)
					{
						Color color = image.GetPixel(w, h);
						if ((color.A != 0) == inv)
						{
							line += '1';
						}
						else
						{
							line += '0';
						}
					}
					lines[h] += line;
				}
			}
			foreach (string line in lines)
			{
				int totalProceed = 0;
				int temp = 0;
				string lineCopy = line;
				while (line.Length != totalProceed)
				{
					writer = penSet(lineCopy[0], writer);
					temp = LastIndexBeforeChange(lineCopy);
					lineCopy = lineCopy.Substring(temp);
					writer.Forward(temp);
					totalProceed += temp;
					Console.WriteLine(totalProceed + "/" + line.Length);
				}
				writer = TurleReturn(writer, line.Length);
			}
			return writer;
		}
		static Turtle penSet(char state,Turtle t)
		{
			if (state == '0')
			{
				t.PenUp();
			}
			else
			{
				t.PenDown();
			}
			return t;
		}
		static int LastIndexBeforeChange(string inp)
		{
			if (inp == string.Empty)
			{
				return -1;
			}
			char firstChar = inp[0];
			bool loop = true;
			int trueIndex = 0;
			inp += '!';
			while (loop)
			{
				if (inp[trueIndex] == firstChar)
				{
					trueIndex++;
				}
				else
				{
					loop = false;
				}
			}
			return trueIndex;
		}
		static Turtle TurleReturn(Turtle t, int lenght)
		{
			t.Rotate(90,false);
			t.Forward(1);
			t.Rotate(90,false);
			t.Forward(lenght);
			t.Rotate(-180,false);
			return t;
		}
		static Bitmap CharToImage(char inputChar)
		{
			Bitmap image = new Bitmap(64, 64);
			RectangleF rectf = new RectangleF(0, 0, 64, 64);
			using (Graphics g = Graphics.FromImage(image))
			{
				g.SmoothingMode = SmoothingMode.AntiAlias;
				g.InterpolationMode = InterpolationMode.HighQualityBicubic;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Center;
				sf.LineAlignment = StringAlignment.Center;
				g.DrawString(inputChar.ToString(), new Font(SystemFonts.DefaultFont.FontFamily, 36, FontStyle.Regular), Brushes.Black, rectf, sf);
			}

			return image;
		}
	}
}
