using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace MusicEnglish
{
	class Picture
	{
		private int lx, ly, rx, ry;
		private int image;
		private Mouse mouse;        //値取得のみする
		public string mean { get; }

		public Picture() { }
		public Picture(int lx, int ly, int rx, int ry, int photoHandle, Mouse mouse, string mean)
		{
			this.lx = lx;
			this.ly = ly;
			this.rx = rx;
			this.ry = ry;
			image = photoHandle;
			this.mouse = mouse;
			this.mean = mean;
		}

		public void Draw()
		{
			DX.DrawExtendGraph(lx, ly, rx, ry, image, DX.FALSE);
		}

		public bool isClick()
		{
			return mouse.isClick() && lx <= mouse.X && mouse.X <= rx && ly <= mouse.Y && mouse.Y <= ry;
		}
	}
}
