using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEnglish
{
	class Table
	{
		int lx, ly, rx, ry;
		public int rowCount { get; }
		public int colCount { get; }
		private List<Picture> pictures;
		private Mouse mouse;

		//コンストラクタ (Pictureの実体はまだ作っていない)
		public Table(int lx, int ly, int rx, int ry, int rowCount, int colCount, Mouse mouse)
		{
			this.lx = lx;
			this.ly = ly;
			this.rx = rx;
			this.ry = ry;
			this.rowCount = rowCount;
			this.colCount = colCount;
			pictures = new List<Picture>();
			for (int i = 0; i < rowCount * colCount; i++) { pictures.Add(new Picture()); }
			this.mouse = mouse;
		}

		//写真の登録
		public void SetPicture(int row, int col, int photoHandle, string mean)
		{
			int lx = this.lx + (this.rx - this.lx) * col / colCount;
			int rx = lx + (this.rx - this.lx) * 1 / colCount;
			int ly = this.ly + (this.ry - this.ly) * row / rowCount;
			int ry = ly + (this.ry - this.ly) * 1 / rowCount;
			pictures[row * colCount + col] = new Picture(lx, ly, rx, ry, photoHandle, mouse, mean);
		}

		//描画
		public void Draw()
		{
			for (int i = 0; i < pictures.Count; i++)
			{
				pictures[i].Draw();
			}
		}

		//クリックした写真の意味 (どれもクリックしていない場合は空文字を返す.)
		public string GetClickedMean()
		{
			for (int i = 0; i < pictures.Count; i++)
			{
				if (pictures[i].isClick())
				{
					return pictures[i].mean;
				}
			}
			return "";
		}
	}
}
