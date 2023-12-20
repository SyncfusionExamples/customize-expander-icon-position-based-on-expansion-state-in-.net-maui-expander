using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace ExpanderMaui
{
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
                    fonts.AddFont("ExpanderIcons.ttf", "ExpanderIcons");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.ConfigureSyncfusionCore();

            return builder.Build();
        }
    }
}
