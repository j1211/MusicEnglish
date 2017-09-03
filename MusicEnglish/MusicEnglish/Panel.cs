using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace MusicEnglish
{
	class Panel
	{
		private int windowH;
		private int windowW;
		private int topH;
		private Judge judge;
		private Mouse mouse;
		private Table table;
		private List<Onpu> onpus;

		int badCount;
		int goodCount;
		int greatCount;
		int perfectCount;

		//コンストラクタ
		public Panel(int windowW, int windowH, int topH)
		{
			this.windowW = windowW;
			this.windowH = windowH;
			this.topH = topH;

			judge = new Judge(50, 0, topH, 3, 6, 12, 24, 0, 3);
			mouse = new Mouse();

			table = new Table(0, topH + 100, windowW, windowH, 1, 3, mouse);
			table.SetPicture(0, 0, DX.LoadGraph("apple.png"), "apple");
			table.SetPicture(0, 1, DX.LoadGraph("banana.png"), "banana");
			table.SetPicture(0, 2, DX.LoadGraph("orange.png"), "orange");

			onpus = new List<Onpu>();
			string[] fruits = { "apple", "banana", "orange" };
			int font = DX.CreateFontToHandle("メイリオ", 30, 3);
			for (int i = 0; i < 100; i++)
			{
				onpus.Add(new Onpu(judge, windowW / 240.0, i * 60 + 240, fruits[i % 3], null, font, 20, 35));
			}

			badCount = 0;
			goodCount = 0;
			greatCount = 0;
			perfectCount = 0;
		}

		//更新
		public void Update()
		{
			mouse.Update();
			for (int i = 0; i < onpus.Count; i++) { onpus[i].Move(); }
		}

		//描画
		public void Draw()
		{
			judge.Draw();
			for (int i = 0; i < onpus.Count; i++)
			{
				if (onpus[i].Lx > windowW || onpus[i].Rx < 0) { continue; }
				onpus[i].Draw();
			}
			DX.DrawLine(0, topH, windowW, topH, 0);
			DX.DrawString(500, topH + 10, "perfect: " + perfectCount.ToString(), 0);
			DX.DrawString(500, topH + 30, "great:   " + greatCount.ToString(), 0);
			DX.DrawString(500, topH + 50, "good:    " + goodCount.ToString(), 0);
			DX.DrawString(500, topH + 70, "bad:     " + badCount.ToString(), 0);
			DX.DrawLine(0, topH + 90, windowW, topH + 90, 0);
			table.Draw();
		}

		//処理
		public void Action()
		{
			string mean = table.GetClickedMean();
			int i;

			string result;
			for (i = 0; i < onpus.Count; i++)
			{
				result = onpus[i].GetJudge();
				if (result.Equals("not exist")) { continue; }
				if (result.Equals("too slow")) { onpus[i].Erase(); badCount++; continue; }
				break;
			}
			if (i == onpus.Count || mean.Equals("")) { return; }

			result = onpus[i].GetJudge();
			if (result.Equals("too fast")) { return; }

			List<string> res = result.Split(' ').ToList<string>();
			if (res[0].Equals("bad")) { badCount++; }
			if (res[0].Equals("good")) { goodCount++; }
			if (res[0].Equals("great")) { greatCount++; }
			if (res[0].Equals("perfect")) { perfectCount++; }
			onpus[i].Erase();
		 }
	}
}
