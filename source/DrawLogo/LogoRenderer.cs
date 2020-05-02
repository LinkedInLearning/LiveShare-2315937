using System;
using System.Collections.Generic;
using System.Text;

namespace DrawLogo {
	internal class LogoRenderer {

		private const int PADDING = 2;
		private string _paddedSpaces;
		private int _sideMargin;
		private const int LINE_HEIGHT = 4;
		private Random _ran = new Random();

		internal void DrawHeader(string titleText, int sideMargin = 4) {
			_paddedSpaces = new string(' ', sideMargin);
			_sideMargin = sideMargin;
			Console.Write(CreateTopLine());
			for (int counter = 0; counter < LINE_HEIGHT; counter++)
			{
				Console.Write(CreateMidLine());
			}

			DrawTitle(titleText);
			for (int counter = 0; counter < LINE_HEIGHT; counter++)
			{
				Console.Write(CreateMidLine());
			}
			Console.Write(CreateBottomLine());
		}

		private void DrawTitle(string titleText) {
			var dottedString = GetDottedString(_sideMargin);

			Console.Write(dottedString + "║");
			Console.ForegroundColor = ConsoleColor.Yellow;

			//center the title line
			//var halfWidth = (Console.WindowWidth) / 2;
			//var offset = halfWidth + (_sideMargin - titleText.Length) / 2;

			var remainingSpace = Console.WindowWidth - (_sideMargin * 2 + 2);
			var titlePad = (remainingSpace - (titleText.Length) )/2;
			string titlePadSpaces = new string(' ', titlePad);
			//var title = String.Format("{0," + offset + "}", titleText);
			//var formattedTitle = String.Format("{0," + titlePad + "}", titleText);


			Console.Write($"{titlePadSpaces}{titleText}{titlePadSpaces}");

			Console.ResetColor();

			//	var titleEnd = String.Format("{0," + (((Console.WindowWidth) / 2) - 5) + "}", "║" );
			var titleEnd = String.Format("{0," + ((titlePad + 5)) + "}", "║");
			Console.WriteLine(" ║" +  dottedString);
		}

		private string CreateTopLine() {
			var dottedString = GetDottedString(_sideMargin);
			var barText = new String('═', Console.WindowWidth - (_sideMargin * 2) - PADDING);
			var topLineText = String.Format(dottedString + "╔{0}╗" + dottedString, barText);

			return topLineText;
		}

		private String CreateMidLine() {
			var spaceText = new String(' ', Console.WindowWidth - (_sideMargin * 2) - PADDING);
			var dottedString = GetDottedString(_sideMargin);
			var midLineText = String.Format(dottedString + "║{0}║" + dottedString, spaceText);
			return midLineText;

		}

		private string CreateBottomLine() {
			var paddingString = GetDottedString(_sideMargin);
			var barText = new String('═', Console.WindowWidth - (_sideMargin * 2) - PADDING);

			var bottomLineText = String.Format(paddingString + "╚{0}╝" + paddingString, barText);

			return bottomLineText;
		}

		private int _switch;
		private string GetDottedString(int stringLength) {
			_switch += 1;
			string output = string.Empty;
			for (int i = 0; i < stringLength; i++)
			{
				if ((i + _switch) % 2 == 0)
				{
					output += " ";
				}
				else
				{
					output += "·";
				}

			}

			return output;
		}
	}
}

