using GW2R_Medical_Associates.Maui.EMR_Management;

namespace GW2R_Medical_Associates.Maui;

public partial class App : Application
{
		public static PatientsEMR PatientsEMR { get; private set; }
	public App(PatientsEMR patientsEMR)
	{ 
		InitializeComponent();

		MainPage = new AppShell();
		PatientsEMR = patientsEMR;
	}
}
