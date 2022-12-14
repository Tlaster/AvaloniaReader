using System;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using FluentAvalonia.Styling;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Media;

namespace AvaloniaReader.UI.Controls;

class ModernWindow : CoreWindow
{
    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        var thm = AvaloniaLocator.Current.GetService<FluentAvaloniaTheme>();
        if (thm == null)
        {
            return;
        }
        thm.RequestedThemeChanged += OnRequestedThemeChanged;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // TODO: add Windows version to CoreWindow
            if (IsWindows11 && thm.RequestedTheme != FluentAvaloniaTheme.HighContrastModeString)
            {
                TransparencyBackgroundFallback = Brushes.Transparent;
                TransparencyLevelHint = WindowTransparencyLevel.Mica;

                TryEnableMicaEffect(thm);
            }
        }
        else
        {
            TransparencyLevelHint = WindowTransparencyLevel.AcrylicBlur;
            TransparencyBackgroundFallback = Brushes.Transparent;
        }

    }
    private void OnRequestedThemeChanged(FluentAvaloniaTheme sender, RequestedThemeChangedEventArgs args)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // TODO: add Windows version to CoreWindow
            if (IsWindows11 && args.NewTheme != FluentAvaloniaTheme.HighContrastModeString)
            {
                TryEnableMicaEffect(sender);
            }
            else if (args.NewTheme == FluentAvaloniaTheme.HighContrastModeString)
            {
                // Clear the local value here, and let the normal styles take over for HighContrast theme
                SetValue(BackgroundProperty, AvaloniaProperty.UnsetValue);
            }
        }
    }

    private void TryEnableMicaEffect(FluentAvaloniaTheme thm)
    {
        // The background colors for the Mica brush are still based around SolidBackgroundFillColorBase resource
        // BUT since we can't control the actual Mica brush color, we have to use the window background to create
        // the same effect. However, we can't use SolidBackgroundFillColorBase directly since its opaque, and if
        // we set the opacity the color become lighter than we want. So we take the normal color, darken it and 
        // apply the opacity until we get the roughly the correct color
        // NOTE that the effect still doesn't look right, but it suffices. Ideally we need access to the Mica
        // CompositionBrush to properly change the color but I don't know if we can do that or not
        if (thm.RequestedTheme == FluentAvaloniaTheme.DarkModeString)
        {
            var color = this.TryFindResource("SolidBackgroundFillColorBase", out var value) ? (Color2)(Color)(value ?? new Color2(32, 32, 32)) : new Color2(32, 32, 32);

            color = color.LightenPercent(-0.8f);

            Background = new ImmutableSolidColorBrush(color, 0.78);
        }
        else if (thm.RequestedTheme == FluentAvaloniaTheme.LightModeString)
        {
            // Similar effect here
            var color = this.TryFindResource("SolidBackgroundFillColorBase", out var value) ? (Color2)(Color)(value ?? new Color2(243, 243, 243)) : new Color2(243, 243, 243);

            color = color.LightenPercent(0.5f);

            Background = new ImmutableSolidColorBrush(color, 0.9);
        }
    }
    
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);            
        ExtendClientAreaChromeHints = 
            Avalonia.Platform.ExtendClientAreaChromeHints.PreferSystemChrome |                 
            Avalonia.Platform.ExtendClientAreaChromeHints.OSXThickTitleBar;
    }
}