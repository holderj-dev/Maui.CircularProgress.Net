# Circular Progress Bar for .NET MAUI

[![NuGet](https://img.shields.io/nuget/v/Maui.CircularProgress.Net.svg)](https://www.nuget.org/packages/Maui.CircularProgress.Net/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Maui.CircularProgress.Net.svg)](https://www.nuget.org/packages/Maui.CircularProgress.Net/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A beautiful, highly customizable circular progress bar control for .NET MAUI applications with multiple shape options, custom colors, and smooth rendering.

![Circular Progress Bar Demo](https://your-image-url.com/demo.png)

## ✨ Features

- 🎨 **Three Shape Options**: Circular (360°), Arch (180° semi-circle), and Flat (horizontal bar)
- 🎯 **Fully Customizable**: Colors, sizes, thickness, and edge styles
- 📊 **Custom Max Values**: Not limited to percentages - use any range (e.g., 250/500, 9700/15000)
- 💫 **Smooth Rendering**: Built with .NET MAUI Graphics for optimal performance
- 👁️ **Show/Hide Text**: Toggle progress display on/off
- 🔄 **Edge Styles**: Choose between rounded (LineCap.Round) or flat (LineCap.Butt) edges
- 📱 **Cross-Platform**: Works on iOS, Android, Windows, and macOS
- 🎭 **Multi-Layer Support**: Stack multiple progress bars for complex visualizations (donut charts)
- 🔗 **MVVM Ready**: Full data binding support for all properties
- 📖 **Well Documented**: Comprehensive XML documentation for IntelliSense

## 📦 Installation

### Package Manager Console
```powershell
Install-Package Maui.CircularProgress.Net
```

### .NET CLI
```bash
dotnet add package Maui.CircularProgress.Net
```

### Visual Studio
1. Right-click on your project → **Manage NuGet Packages**
2. Search for **"Maui.CircularProgress.Net"**
3. Click **Install**

## 🚀 Quick Start

### 1. Add Namespace to XAML

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:controls="clr-namespace:Maui.CircularProgress.Net.Controls;assembly=Maui.CircularProgress.Net"
             x:Class="YourApp.MainPage">
    
    <!-- Your content here -->
    
</ContentPage>
```

### 2. Use the Control

```xml
<controls:CircularProgressBar
    Progress="75"
    MaxProgress="100"
    ProgressColor="Green"
    ProgressLeftColor="LightGreen"
    Size="140"
    TextColor="DarkGreen"
    Thickness="10"
    ShowText="True"
    ProgressEdgeShape="Round"
    Shape="Circular" />
```

That's it! You now have a beautiful circular progress bar displaying "75/100".

## 📚 Properties Reference

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Progress` | int | 0 | Current progress value |
| `MaxProgress` | int | 100 | Maximum progress value |
| `Size` | int | 100 | Diameter of the circle (or width for flat bars) |
| `Thickness` | int | 10 | Thickness of the progress ring/bar |
| `ProgressColor` | Color | Blue | Color of the completed progress |
| `ProgressLeftColor` | Color | LightGray | Color of the remaining progress |
| `TextColor` | Color | Black | Color of the progress text |
| `ShowText` | bool | true | Show or hide the progress text |
| `ProgressEdgeShape` | LineCap | Butt | Edge style: `Butt` (flat) or `Round` (rounded) |
| `Shape` | ProgressBarShape | Circular | Shape: `Circular`, `Arch`, or `Flat` |

## 🎨 Shape Options

### Circular (360° Full Circle)
Perfect for general progress tracking, loading indicators, and percentage displays.

```xml
<controls:CircularProgressBar
    Progress="65"
    Shape="Circular"
    ProgressColor="#6B4EFF"
    ProgressLeftColor="#E0E7FF"
    Size="150"
    Thickness="12"
    ProgressEdgeShape="Round" />
```

### Arch (180° Semi-Circle)
Ideal for gauges, speedometers, and dashboard displays.

```xml
<controls:CircularProgressBar
    Progress="45"
    Shape="Arch"
    ProgressColor="#FB923C"
    ProgressLeftColor="#FED7AA"
    Size="150"
    Thickness="12"
    ProgressEdgeShape="Round" />
```

### Flat (Horizontal Bar)
Great for linear progress tracking, downloads, and uploads.

```xml
<controls:CircularProgressBar
    Progress="80"
    Shape="Flat"
    ProgressColor="#10B981"
    ProgressLeftColor="#D1FAE5"
    Size="200"
    Thickness="20" />
```

## 💡 Common Use Cases

### Basic Percentage Progress

```xml
<controls:CircularProgressBar
    Progress="75"
    ProgressColor="#3B82F6"
    ProgressLeftColor="#DBEAFE"
    Size="120"
    Thickness="10"
    ProgressEdgeShape="Round" />
```
**Displays:** 75/100

### Custom Range Progress

```xml
<controls:CircularProgressBar
    Progress="250"
    MaxProgress="500"
    ProgressColor="#8B5CF6"
    ProgressLeftColor="#EDE9FE"
    Size="140"
    Thickness="12" />
```
**Displays:** 250/500

### Progress Without Text

```xml
<controls:CircularProgressBar
    Progress="90"
    ShowText="False"
    ProgressColor="#EF4444"
    ProgressLeftColor="#FEE2E2"
    Size="100"
    Thickness="8" />
```

### Multi-Layer Donut Chart

Create beautiful data visualizations by overlaying multiple progress bars:

```xml
<Grid WidthRequest="200" HeightRequest="200">
    
    <!-- Outer Circle - Category 1 -->
    <controls:CircularProgressBar
        Progress="9700"
        MaxProgress="15000"
        ProgressColor="#6B4EFF"
        ProgressLeftColor="#EDD9FA"
        Size="200"
        Thickness="25"
        ShowText="False"
        ProgressEdgeShape="Round"
        HorizontalOptions="Center"
        VerticalOptions="Center" />
    
    <!-- Inner Circle - Category 2 -->
    <controls:CircularProgressBar
        Progress="5300"
        MaxProgress="15000"
        ProgressColor="#FB923C"
        ProgressLeftColor="#FCC99F"
        Size="150"
        Thickness="20"
        ShowText="False"
        ProgressEdgeShape="Round"
        HorizontalOptions="Center"
        VerticalOptions="Center" />
    
    <!-- Center Label -->
    <VerticalStackLayout VerticalOptions="Center" HorizontalOptions="Center">
        <Label Text="Total" FontSize="12" HorizontalTextAlignment="Center" />
        <Label Text="15000" FontSize="18" FontAttributes="Bold" HorizontalTextAlignment="Center" />
    </VerticalStackLayout>
    
</Grid>
```

## 🔗 Data Binding with MVVM

### ViewModel

```csharp
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class DashboardViewModel : INotifyPropertyChanged
{
    private int _currentProgress = 65;
    private int _maxProgress = 100;

    public int CurrentProgress
    {
        get => _currentProgress;
        set
        {
            _currentProgress = value;
            OnPropertyChanged();
        }
    }

    public int MaxProgress
    {
        get => _maxProgress;
        set
        {
            _maxProgress = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```

### XAML

```xml
<controls:CircularProgressBar
    Progress="{Binding CurrentProgress}"
    MaxProgress="{Binding MaxProgress}"
    ProgressColor="#10B981"
    ProgressLeftColor="#D1FAE5"
    Size="150"
    Thickness="12" />
```

## 🎨 Pre-built Color Themes

### Success Theme (Green)
```xml
<controls:CircularProgressBar
    Progress="85"
    ProgressColor="#10B981"
    ProgressLeftColor="#D1FAE5"
    TextColor="#065F46" />
```

### Warning Theme (Orange)
```xml
<controls:CircularProgressBar
    Progress="60"
    ProgressColor="#F59E0B"
    ProgressLeftColor="#FEF3C7"
    TextColor="#92400E" />
```

### Danger Theme (Red)
```xml
<controls:CircularProgressBar
    Progress="30"
    ProgressColor="#EF4444"
    ProgressLeftColor="#FEE2E2"
    TextColor="#991B1B" />
```

### Info Theme (Blue)
```xml
<controls:CircularProgressBar
    Progress="50"
    ProgressColor="#3B82F6"
    ProgressLeftColor="#DBEAFE"
    TextColor="#1E40AF" />
```

## 📱 Platform Support

| Platform | Minimum Version | Status |
|----------|----------------|--------|
| iOS | 15.0 | ✅ Supported |
| Android | 21 (5.0 Lollipop) | ✅ Supported |
| Windows | 10.0.17763.0 | ✅ Supported |
| macOS (Catalyst) | 15.0 | ✅ Supported |

## 🔧 Advanced Features

### Dynamic Progress Updates

```csharp
public async Task AnimateProgress()
{
    for (int i = 0; i <= 100; i += 5)
    {
        MyProgressBar.Progress = i;
        await Task.Delay(50); // 50ms delay
    }
}
```

### Conditional Color Changes

```csharp
public void UpdateProgressColor(int progress)
{
    if (progress < 30)
        MyProgressBar.ProgressColor = Colors.Red;
    else if (progress < 70)
        MyProgressBar.ProgressColor = Colors.Orange;
    else
        MyProgressBar.ProgressColor = Colors.Green;
}
```

## 📖 Documentation

- [Complete Usage Examples](https://github.com/yourusername/Maui.CircularProgress.Net/blob/main/USAGE_EXAMPLES.md)
- [API Reference](https://github.com/yourusername/Maui.CircularProgress.Net/wiki/API-Reference)
- [Change Log](https://github.com/yourusername/Maui.CircularProgress.Net/blob/main/CHANGELOG.md)

## 🐛 Troubleshooting

### Progress bar not visible
- Ensure the `Size` property is set (default is 100)
- Check that the parent container has enough space
- Verify colors aren't matching the background

### Text not displaying
- Check that `ShowText` is set to `true` (default)
- Verify `TextColor` contrasts with the background
- Ensure `Size` is large enough (minimum 80 recommended for text)

### Colors not applying
- Use proper color formats: `Colors.Blue` or `Color.FromArgb("#3B82F6")`
- Check for typos in color names

## 💻 System Requirements

- .NET 10.0 or later
- .NET MAUI workload installed
- Visual Studio 2022 17.8+ or Visual Studio Code with C# Dev Kit

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request


## 🙏 Acknowledgments

- Built with [.NET MAUI](https://dotnet.microsoft.com/apps/maui)
- Powered by .NET MAUI Graphics
- Inspired by modern UI/UX design principles
- Thanks to the .NET MAUI community for feedback and support

## ⭐ Show Your Support

If you find this library helpful, please consider:
- ⭐ Giving it a star on GitHub
- 📢 Sharing it with others
- 🐛 Reporting bugs or requesting features
- 🤝 Contributing to the project

## 📊 Stats

![GitHub stars](https://img.shields.io/github/stars/yourusername/Maui.CircularProgress.Net?style=social)
![GitHub forks](https://img.shields.io/github/forks/yourusername/Maui.CircularProgress.Net?style=social)
![GitHub issues](https://img.shields.io/github/issues/yourusername/Maui.CircularProgress.Net)
![GitHub pull requests](https://img.shields.io/github/issues-pr/yourusername/Maui.CircularProgress.Net)

---

**Made with ❤️ for the .NET MAUI community**

*Happy coding! 🚀*
