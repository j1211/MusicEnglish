using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace MusicEnglish
{
	class Program
	{
		static void Main(string[] args)
		{
			DX.ChangeWindowMode(1);
			DX.SetBackgroundColor(255, 255, 255);
			DX.SetGraphMode(800, 600, 32);
			DX.DxLib_Init();
			DX.SetDrawScreen(DX.DX_SCREEN_BACK);

			Panel panel = new Panel(800, 600, 150);

			while (DX.ScreenFlip() == 0 && DX.ProcessMessage() == 0 && DX.ClearDrawScreen() == 0)
			{
				panel.Update();
				panel.Draw();
				panel.Action();
			}
			DX.DxLib_End();
		}
	}
}

