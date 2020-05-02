using System;

namespace DrawLogo {
	class Program {
		private static LogoRenderer logo = new LogoRenderer();
		static void Main(string[] args) {

			Console.Title = "Draw-Logo";
			logo.DrawHeader(titleText: "123456789-123456789-123456789", sideMarginPercent: .10);
			logo.DrawHeader(titleText: "1234567891", sideMarginPercent: .20); // there is problem with this length string
		}
	}
}
