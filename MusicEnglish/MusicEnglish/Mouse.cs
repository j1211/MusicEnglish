using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace MusicEnglish
{
	class Mouse
	{
		public int X { get; private set; }
		public int Y { get; private set; }
		private int bPush;
		private int Push;

		public Mouse()
		{
			Push = 0;
		}

		public void Update()
		{
			bPush = Push;
			Push = DX.GetMouseInput() & DX.MOUSE_INPUT_LEFT;
			int x, y;
			DX.GetMousePoint(out x, out y);
			X = x;
			Y = y;
		}

		public bool isPush()
		{
			return Push == 1;
		}

		public bool isClick()
		{
			return bPush == 0 && Push == 1;
		}
	}
}
