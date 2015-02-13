using System;

namespace Kolikko3000
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			//ASCII supreme excellent!!!
			Console.OutputEncoding = System.Text.Encoding.GetEncoding (1252);

			//Startup specs
			int square = 48;
			bool test = true;
			while (test) {
				Console.WriteLine (" Clock: " + DateTime.Now);
				Console.Write ("Give the diameter of the clock:");
				try {
					square = int.Parse (Console.ReadLine ());
					if (square >= 5 && square <= 32000) {
						test = false;
					}
					else{Console.WriteLine ("Use value that is larger than 5");}
				} catch (Exception ex) {
					Console.Clear ();
					Console.WriteLine ("Please, use numbers only!");
				}
			}
			Console.Clear ();

			//Specs
			int x_scale = square;
			int y_scale = square/5*4;
			int distance = square/2-1;
			int xo = 0;
			int yo = 0;
			int x_point = 0;
			int y_point = 0;

			//Time
			int sec = 0;
			int min = 0;
			double hour = 0;

			//Clock spinner specs
			double spin = 1;
			int around = 0;


			char[,] matrix = new char[x_scale, y_scale];

			for (; ; ) {

				Console.WriteLine (" Clock v0.2 :" + DateTime.Now);
				Console.WriteLine (" Made by: Katu-Pekka Saarinen ");

				/////Matrix values/////
			
				int inum = 0;
					while (inum < 360) {

						//Clock back
					if (-0.8 <= spin && spin <= 0.9 && spin != 0) {
						if (spin >= 0) {
							xo = Convert.ToInt32 (Math.Round (x_scale / 2 - (distance / 8) + Math.Sin (inum / 57.3) * (distance * spin)));
						} else {
							xo = Convert.ToInt32 (Math.Round (x_scale / 2 + (distance / 8) + Math.Sin (inum / 57.3) * (distance * spin)));
						}
						yo = Convert.ToInt32 (Math.Round (y_scale / 2 + Math.Cos (inum / 57.3) * (distance * 0.75)));
						matrix [xo, yo] = (char)176;
					}

					//Clock time spots
					if (inum % 30 == 0) {
						xo = Convert.ToInt32(Math.Round(x_scale / 2 + Math.Sin (inum/57.3) * ((distance*spin)*0.9)));
						yo = Convert.ToInt32(Math.Round(y_scale / 2 + Math.Cos (inum/57.3) * (distance*0.9*0.75)));
						matrix[xo,yo] = (char)254;
					}
						inum += 1;
					}

				//Clock frames outer
				inum = 0;
				while (inum < 360) {
					xo = Convert.ToInt32(Math.Round(x_scale / 2 + Math.Sin (inum/57.3) * (distance*spin)));
					yo = Convert.ToInt32(Math.Round(y_scale / 2 + Math.Cos (inum/57.3) * (distance*0.75)));
					matrix[xo,yo] = (char)219;
					inum += 1;
				}

				//Hours
				inum = 0;
				while (inum < distance*0.5) {
					xo = Convert.ToInt32(Math.Round(x_scale / 2 + Math.Sin (hour/57.3) * (inum*spin)));
					yo = Convert.ToInt32(Math.Round(y_scale / 2 + Math.Cos (hour/57.3) * (inum*0.75)));
					matrix[xo,yo] = (char)178;
					inum += 1;
				}

				//Minutes
				inum = 0;
				while (inum < distance*0.75) {
					xo = Convert.ToInt32(Math.Round(x_scale / 2 + Math.Sin (min/57.3) * (inum*spin)));
					yo = Convert.ToInt32(Math.Round(y_scale / 2 + Math.Cos (min/57.3) * (inum*0.75)));
					matrix[xo,yo] = (char)177;
					inum += 1;
				}

				//Seconds
				inum = 0;
				while (inum < distance) {
					xo = Convert.ToInt32(Math.Round(x_scale / 2 + Math.Sin (sec/57.3) * (inum*spin)));
					yo = Convert.ToInt32(Math.Round(y_scale / 2 + Math.Cos (sec/57.3) * (inum*0.75)));
					matrix[xo,yo] = (char)176;
						inum += 1;
				}

				////Draw function////
				y_point = 0;
				while (y_point < y_scale) {
					x_point = 0;
					while (x_point < x_scale) {
								
						if (x_point == x_scale/2 && y_point == y_scale/2) {
							Console.Write ((char)206);
						}

						else {
							Console.Write ((char)matrix[x_point,y_point]);
							matrix[x_point,y_point] = (char)255;
						}
						x_point += 1;
					}
					Console.WriteLine ();
					y_point += 1;
				}
					
				//System.Threading.Thread.Sleep(1);
				sec = -360/60*DateTime.Now.Second-180;
				min = -360/60*DateTime.Now.Minute-180;
				hour = (-360/12*DateTime.Now.Hour)-(DateTime.Now.Minute/2)-180;


				//Spinner
				if (DateTime.Now.Second == 0 && around == 0) {
					around = 1;
				}

				if (around == 1) {
					if (spin > -0.9) {
						spin -= 0.05;
					} else {
						spin = -1;
						around = 2;
					}
				}

				if (around == 2) {
					if (spin < 0.9) {
						spin += 0.05;
					} else {
						spin = 1;
						around = 0;
					}
				}

				Console.SetCursorPosition(0,0);
			}

			Console.WriteLine ("Error: Loop is broken");
			Console.ReadLine();
		}

		private double RadianToDegree(double angle)
		{
			return angle * (180.0 / Math.PI);
		}
	}
}
