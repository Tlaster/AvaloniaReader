using System;
using System.IO;
using System.Reflection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaReader.Common;
using AvaloniaReader.UI.Hosting;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Realms;
using Splat;

namespace AvaloniaReader;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        EnsureWorkingDirectory();
        Ioc.Default.ConfigureServices(ConfigureServices());
        Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());
    }

    private void EnsureWorkingDirectory()
    {
        if (!Directory.Exists(Consts.DocumentDirectory))
        {
            Directory.CreateDirectory(Consts.DocumentDirectory);
        }
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddSingleton<Realm>(_ =>
            Realm.GetInstance(new RealmConfiguration(Path.Combine(Consts.DocumentDirectory, ".realm"))
                { ShouldDeleteIfMigrationNeeded = true }));
        return services.BuildServiceProvider();
    }


    public override void OnFrameworkInitializationCompleted()
    {
        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime classicDesktopStyleApplicationLifetime:
                classicDesktopStyleApplicationLifetime.MainWindow = new RootWindow();
                break;
            case ISingleViewApplicationLifetime singleViewApplicationLifetime:
                singleViewApplicationLifetime.MainView = new RootView();
                break;
        }

        base.OnFrameworkInitializationCompleted();
    }
}