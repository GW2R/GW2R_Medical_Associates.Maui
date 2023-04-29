using GW2R_Medical_Associates.Maui.EMR_Management;
using GW2R_Medical_Associates.Maui.ViewModels;
using GW2R_Medical_Associates.Maui.Views;

namespace GW2R_Medical_Associates.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "emrs.db3");

		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<PatientsEMR>(s,dbPath));
		builder.Services.AddSingleton<PatientEMRViewModel>();
		builder.Services.AddTransient<EMRDetailsViewModel>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<EMRDetailsPage>();

		return builder.Build();
	}
}
