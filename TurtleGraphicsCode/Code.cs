namespace TurtleGraphicsCode
{

	public class Code
	{

		/// <summary>
		/// This is the place to put your turtle code
		/// </summary>
		public Turtle ToExecute()
		{
			Turtle t = new Turtle(true);
			Text txt = new Text();
			t.SetBrushSize(1);
			t.AnimatePath = false;
			t.TurtleSpeed = 25;
			t.SetColor("brown");
			t = txt.Write(t, "Želva", true, 1);
			t.Rotate(22.5);
			t.SetColor("Black");
			t = txt.Write(t, "píše!", false, 1);
			for (int i = 0; i < 14; i++)
			{
				t.Rotate(22.5);
				//t.CaptureScreenshot();
				t = txt.Write(t, i + string.Empty, (i % 2) == 1, 1);
			}
			
			
			/*t.BackgroundColor = "Black";
			t.Rotate(-90);

			for (int i = 0; i < 6; i++) {
				t.StoreTurtlePosition();

				for (int j = 0; j < 20; j++) {
					DrawSection(t, 100);
				}

				t.RestoreTurtlePosition();
				t.Rotate(60);
				t.CaptureScreenshot();
			}*/
			return t;
		}

		/*void DrawSection(Turtle t, int p) {
			t.Forward(10);
			t.StoreTurtlePosition();
			t.Rotate(-45);
			t.Forward(p);
			t.RestoreTurtlePosition();
			t.Rotate(45);
			t.Forward(p);
			t.RestoreTurtlePosition(true);
		}*/
	}
}













//Vytvořím si složku na disku Z: na mé projekty ve Visual Studiu
//Otevřu cmd/powershell v složce z řádku 11
//Zadám 'git clone https://github.com/Michal-MK/TurtleGraphics.git'
//Otevřu stažený solution ve visual studiu(.sln soubor)
//Najdu projekt 'TurteGraphicsCode'
//Najdu soubor Code.cs a otevřu ho
//Jsem zde!