using Microsoft.Extensions.Logging;
using SponUI.ViewModel;

namespace SponUI;

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
				fonts.AddFont("Kanit-Black.ttf", "KanitBlack");
				fonts.AddFont("Kanit-BlackItalic.ttf", "KanitBlackItalic");
				fonts.AddFont("Kanit-Bold.ttf", "KanitBold");
				fonts.AddFont("Kanit-BoldItalic.ttf", "KanitBoldItalic");
				fonts.AddFont("Kanit-ExtraBold.ttf", "KanitExtraBold");
				fonts.AddFont("Kanit-ExtraBoldItalic.ttf", "KanitExtraBoldItalic");
				fonts.AddFont("Kanit-ExtraLight.ttf", "KanitExtraLight");
				fonts.AddFont("Kanit-ExtraLightItalic.ttf", "KanitExtraLightItalic");
				fonts.AddFont("Kanit-Italic.ttf", "Kanit-Italic");
				fonts.AddFont("Kanit-Light.ttf", "KanitLight");
				fonts.AddFont("Kanit-LightItalic.ttf", "KanitLightItalic");
				fonts.AddFont("Kanit-Medium.ttf", "KanitMedium");
				fonts.AddFont("Kanit-MediumItalic.ttf", "KanitMediumItalic");
				fonts.AddFont("Kanit-Regular.ttf", "KanitRegular");
				fonts.AddFont("Kanit-SemiBold.ttf", "KanitSemiBold");
				fonts.AddFont("Kanit-SemiBoldItalic.ttf", "KanitSemiBoldItalic");
				fonts.AddFont("Kanit-Thin.ttf", "KanitThin");
				fonts.AddFont("Kanit-ThinItalic.ttf", "KanitThinItalic");
                
            });

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

