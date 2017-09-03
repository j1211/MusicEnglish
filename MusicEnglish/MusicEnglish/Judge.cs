using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace MusicEnglish
{
	class Judge
	{
		//位置 (x軸方向に流れる♪を判定するバーです）
		public int posX { get; }
		private int posLy;
		private int posRy;
		public int posY => (posLy + posRy) / 2;

		//判定範囲 (時刻, フレーム数)
		private int perfect;
		private int great;
		private int good;
		private int bad;

		//色, 太さ
		uint color;
		int thickness;

		//コンストラクタ
		public Judge(int posX, int posLy, int posRy, int perfectFrame, int greatFrame, int goodFrame, int badFrame, uint color, int thickness)
		{
			this.posX = posX;
			this.posLy = posLy;
			this.posRy = posRy;
			this.perfect = perfectFrame;
			this.great = greatFrame;
			this.good = goodFrame;
			this.bad = badFrame;
			this.color = color;
			this.thickness = thickness;
		}

		//判定(too fast, bad fast, good fast, great fast, perfect, great slow, good slow, bad slow, too slow)
		public string GetJudge(int remFrame)
		{
			if (bad < remFrame) { return "too fast"; }
			if (good < remFrame) { return "bad fast"; }
			if (great < remFrame) { return "good fast"; }
			if (perfect < remFrame) { return "great fast"; }
			if (-perfect < remFrame) { return "perfect"; }
			if (-great < remFrame) { return "great slow"; }
			if (-good < remFrame) { return "good slow"; }
			if (-bad < remFrame) { return "bad slow"; }
			return "too slow";
		}

		//描画
		public void Draw()
		{
			DX.DrawLine(posX, posLy, posX, posRy, color, thickness);
		}
	}
}
