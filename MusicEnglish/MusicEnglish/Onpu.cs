using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace MusicEnglish
{
	class Onpu	//長方形の音符, 横長
	{
		//表示位置
		Judge judge;
		private double flowSpeedPerFrame;
		private int remFrame;

		//表示内容
		public string text { get; }
		private uint[] textColors;
		private int textFontHandle;
		private int charSizeX;		//1文字の間隔 (隙間含む)
		private int charSizeY;		//1文字の間隔 (隙間含む)

		//存在
		private bool isExist;

		//コンストラクタ
		public Onpu() { }
		public Onpu(Judge judge, double flowSpeedPerFrame, int remFrame, string text, uint[] textColors, int textFontHandle, int charSizeX, int charSizeY)
		{
			this.judge = judge;
			this.flowSpeedPerFrame = flowSpeedPerFrame;
			this.remFrame = remFrame;
			this.text = text;
			this.textColors = textColors;
			this.textFontHandle = textFontHandle;
			this.charSizeX = charSizeX;
			this.charSizeY = charSizeY;
			this.isExist = true;

			if (textColors == null) {
				this.textColors = new uint[text.Length];
				for (int i = 0; i < text.Length; i++) { this.textColors[i] = 0; }
			}
		}

		//表示
		public void Draw()
		{
			if (!isExist) { return; }
			DX.DrawBox(Lx, Ly, Rx, Ry, 0, DX.FALSE);
			for (int i = 0; i < text.Length; i++)
			{
				DX.DrawStringToHandle(Lx + charSizeX * i, Ly, text[i].ToString(), textColors[i], textFontHandle);
			}
		}
		
		//移動
		public void Move()
		{
			remFrame--;
		}

		//判定 (not exist, judgeComment)
		public string GetJudge()
		{
			if (!isExist) { return "not exist"; }
			return judge.GetJudge(remFrame);
		}

		//消す
		public void Erase()
		{
			isExist = false;
		}

		//位置
		public int Lx => (int)(judge.posX + remFrame * flowSpeedPerFrame);
		public int Rx => (int)(Lx + charSizeX * text.Length);
		private int Ly => (int)(judge.posY - charSizeY / 2);
		private int Ry => (int)(judge.posY + charSizeY / 2);
	}
}
