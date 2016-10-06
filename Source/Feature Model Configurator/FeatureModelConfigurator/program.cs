using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FeatureModelConfigurator
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new WindowsForm());
		}
	}
}