using System;
using System.Collections.Generic;
using System.Text;

namespace DrawLogo
{
	internal class LogoRenderer
	{

		private const int PADDING = 2;
		private string _paddedSpaces;
		private int _numCharsInSideMargin;
		private const int LINE_HEIGHT = 4;
		private Random _ran = new Random();

		internal void DrawHeader(string titleText, double sideMarginPercent = .10)
		{
			if (sideMarginPercent > .40)
			{
				sideMarginPercent = .40;
			}
			_numCharsInSideMargin = (int)(Console.WindowWidth * sideMarginPercent);
			_paddedSpaces = new string(' ', _numCharsInSideMargin);

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

		private void DrawTitle(string titleText)
		{
			var dottedString = GetDottedString(_numCharsInSideMargin);
			var remainingSpace = Console.WindowWidth - (_numCharsInSideMargin * 2 + 2);
			var titlePad = (remainingSpace - (titleText.Length)) / 2;

			Console.Write(dottedString + "║");
			Console.ForegroundColor = ConsoleColor.Yellow;




			string titlePadSpaces = new string(' ', titlePad);

			Console.Write($"{titlePadSpaces}{titleText}{titlePadSpaces}");

			Console.ResetColor();

			var titleEnd = String.Format("{0," + ((titlePad + 5)) + "}", "║");
			Console.WriteLine(" ║" + dottedString);
		}

		private string CreateTopLine()
		{
			var dottedString = GetDottedString(_numCharsInSideMargin);
			var barText = new String('═', Console.WindowWidth - (_numCharsInSideMargin * 2) - PADDING);
			var topLineText = String.Format(dottedString + "╔{0}╗" + dottedString, barText);

			return topLineText;
		}

		private String CreateMidLine()
		{
			var spaceText = new String(' ', Console.WindowWidth - (_numCharsInSideMargin * 2) - PADDING);
			var dottedString = GetDottedString(_numCharsInSideMargin);
			var midLineText = String.Format(dottedString + "║{0}║" + dottedString, spaceText);
			return midLineText;

		}

		private string CreateBottomLine()
		{
			var paddingString = GetDottedString(_numCharsInSideMargin);
			var barText = new String('═', Console.WindowWidth - (_numCharsInSideMargin * 2) - PADDING);

			var bottomLineText = String.Format(paddingString + "╚{0}╝" + paddingString, barText);

			return bottomLineText;
		}

		private int _switch;
		private string GetDottedString(int stringLength)
		{
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

