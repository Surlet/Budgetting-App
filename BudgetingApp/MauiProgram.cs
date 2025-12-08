using BudgetingApp.Services;
using BudgetingApp.ViewModels;
using BudgetingApp.Views;
using InputKit.Handlers;
using Microsoft.Extensions.Logging;

namespace BudgetingApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddInputKitHandlers();
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "budget.db3");
            builder.Services.AddSingleton<DatabaseService>(s => new DatabaseService(dbPath));

            builder.Services.AddTransient<FormViewModel>(); // Enregistrez le ViewModel
            builder.Services.AddTransient<TableViewModel>(); // Enregistrez le ViewModel
            builder.Services.AddTransient<SettingsViewModel>();

            builder.Services.AddTransient<TablePage>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<SettingsPage>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
