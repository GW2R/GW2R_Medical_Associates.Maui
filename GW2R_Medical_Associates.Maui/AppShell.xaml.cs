using GW2R_Medical_Associates.Maui.Views;

namespace GW2R_Medical_Associates.Maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(EMRDetailsPage), typeof(EMRDetailsPage));
	}
}
