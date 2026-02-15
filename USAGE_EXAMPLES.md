# Usage Examples - Maui.CircularProgress.Net

Complete examples of how to use the Circular Progress Bar control in your .NET MAUI application.

---

## 📦 Installation

```bash
dotnet add package Maui.CircularProgress.Net
```

---

## 🚀 Basic Setup

### Step 1: Add Namespace to XAML

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:controls="clr-namespace:Maui.CircularProgress.Net.Controls;assembly=Maui.CircularProgress.Net"
             x:Class="YourApp.MainPage">
    
    <!-- Your content here -->
    
</ContentPage>
```

### Step 2: Add Namespace to C# Code-Behind

```csharp
using Maui.CircularProgress.Net.Controls;
using Maui.CircularProgress.Net.Enums;
```

---

## 📊 Example 1: Basic Circular Progress Bar

### XAML
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

**Result:** Displays "75/100" in the center with a green circular progress bar.

---

## 📊 Example 2: Arch (Semi-Circle) Progress Bar

### XAML
```xml
<controls:CircularProgressBar
    Progress="60"
    MaxProgress="100"
    Shape="Arch"
    ProgressColor="#3B82F6"
    ProgressLeftColor="#DBEAFE"
    Size="150"
    TextColor="#1E40AF"
    Thickness="12"
    ProgressEdgeShape="Round" />
```

**Result:** Semi-circle progress bar starting from bottom-left to bottom-right.

---

## 📊 Example 3: Flat Horizontal Progress Bar

### XAML
```xml
<controls:CircularProgressBar
    Progress="45"
    MaxProgress="100"
    Shape="Flat"
    ProgressColor="#8B5CF6"
    ProgressLeftColor="#EDE9FE"
    Size="250"
    TextColor="#5B21B6"
    Thickness="20" />
```

**Result:** Horizontal progress bar with text displayed above it.

---

## 📊 Example 4: Progress Without Text

### XAML
```xml
<controls:CircularProgressBar
    Progress="85"
    MaxProgress="100"
    ShowText="False"
    ProgressColor="#EF4444"
    ProgressLeftColor="#FEE2E2"
    Size="120"
    Thickness="8"
    ProgressEdgeShape="Round" />
```

**Result:** Progress bar without any text display.

---

## 📊 Example 5: Custom Max Progress (Beyond 100)

### XAML
```xml
<controls:CircularProgressBar
    Progress="250"
    MaxProgress="500"
    ProgressColor="#F59E0B"
    ProgressLeftColor="#FEF3C7"
    Size="160"
    TextColor="#92400E"
    Thickness="12"
    ProgressEdgeShape="Round" />
```

**Result:** Displays "250/500" showing custom range progress.

---

## 📊 Example 6: Multi-Layer Donut Chart (Students Example)

### XAML
```xml
<Grid WidthRequest="200" HeightRequest="200">
    
    <!-- Outer Circle - Male Students (9,700 out of 15,000) -->
    <controls:CircularProgressBar
        Progress="9700"
        MaxProgress="15000"
        ProgressColor="#6B4EFF"
        ProgressLeftColor="#EDD9FA"
        Size="200"
        Thickness="25"
        ShowText="False"
        ProgressEdgeShape="Round"
        Shape="Circular"
        HorizontalOptions="Center"
        VerticalOptions="Center" />
    
    <!-- Inner Circle - Female Students (5,300 out of 15,000) -->
    <controls:CircularProgressBar
        Progress="5300"
        MaxProgress="15000"
        ProgressColor="#FB923C"
        ProgressLeftColor="#FCC99F"
        Size="150"
        Thickness="20"
        ShowText="False"
        ProgressEdgeShape="Round"
        Shape="Circular"
        HorizontalOptions="Center"
        VerticalOptions="Center" />
    
    <!-- Center Label -->
    <VerticalStackLayout VerticalOptions="Center" HorizontalOptions="Center">
        <Label Text="Total" 
               FontSize="12" 
               HorizontalTextAlignment="Center"
               TextColor="#6B7280" />
        <Label Text="15000" 
               FontSize="18" 
               FontAttributes="Bold" 
               HorizontalTextAlignment="Center"
               TextColor="#111827" />
    </VerticalStackLayout>
    
</Grid>

<!-- Legend -->
<Grid ColumnDefinitions="*,*" ColumnSpacing="20" Margin="0,20,0,0">
    
    <HorizontalStackLayout Grid.Column="0" 
                           Spacing="8"
                           HorizontalOptions="Center">
        <BoxView Color="#6B4EFF"
                 WidthRequest="12"
                 HeightRequest="12"
                 CornerRadius="6"
                 VerticalOptions="Center"/>
        <Label Text="Male (9,700)"
               TextColor="#1F2937"
               FontSize="14"
               VerticalOptions="Center"/>
    </HorizontalStackLayout>
    
    <HorizontalStackLayout Grid.Column="1" 
                           Spacing="8"
                           HorizontalOptions="Center">
        <BoxView Color="#FB923C"
                 WidthRequest="12"
                 HeightRequest="12"
                 CornerRadius="6"
                 VerticalOptions="Center"/>
        <Label Text="Female (5,300)"
               TextColor="#1F2937"
               FontSize="14"
               VerticalOptions="Center"/>
    </HorizontalStackLayout>
</Grid>
```

**Result:** Overlapping circular progress bars creating a multi-layer donut chart.

---

## 📊 Example 7: Data Binding with ViewModel

### ViewModel (C#)
```csharp
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace YourApp.ViewModels
{
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

        // Method to update progress
        public async Task AnimateProgress()
        {
            for (int i = 0; i <= 100; i += 5)
            {
                CurrentProgress = i;
                await Task.Delay(50); // 50ms delay
            }
        }
    }
}
```

### XAML
```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:controls="clr-namespace:Maui.CircularProgress.Net.Controls;assembly=Maui.CircularProgress.Net"
             xmlns:viewmodels="clr-namespace:YourApp.ViewModels"
             x:Class="YourApp.DashboardPage">
    
    <ContentPage.BindingContext>
        <viewmodels:DashboardViewModel />
    </ContentPage.BindingContext>
    
    <VerticalStackLayout Padding="20" Spacing="20">
        
        <controls:CircularProgressBar
            Progress="{Binding CurrentProgress}"
            MaxProgress="{Binding MaxProgress}"
            ProgressColor="#10B981"
            ProgressLeftColor="#D1FAE5"
            Size="150"
            Thickness="12"
            ProgressEdgeShape="Round" />
        
        <Button Text="Animate Progress"
                Clicked="OnAnimateClicked" />
        
    </VerticalStackLayout>
    
</ContentPage>
```

### Code-Behind
```csharp
using YourApp.ViewModels;

namespace YourApp
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        private async void OnAnimateClicked(object sender, EventArgs e)
        {
            var viewModel = (DashboardViewModel)BindingContext;
            await viewModel.AnimateProgress();
        }
    }
}
```

---

## 📊 Example 8: Dynamic Color Changes Based on Progress

### C# Code-Behind
```csharp
using Maui.CircularProgress.Net.Controls;

namespace YourApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnProgressChanged(object sender, EventArgs e)
        {
            var slider = (Slider)sender;
            int progress = (int)slider.Value;
            
            MyProgressBar.Progress = progress;
            
            // Change color based on progress
            if (progress < 30)
            {
                MyProgressBar.ProgressColor = Colors.Red;
                MyProgressBar.TextColor = Colors.DarkRed;
            }
            else if (progress < 70)
            {
                MyProgressBar.ProgressColor = Colors.Orange;
                MyProgressBar.TextColor = Colors.DarkOrange;
            }
            else
            {
                MyProgressBar.ProgressColor = Colors.Green;
                MyProgressBar.TextColor = Colors.DarkGreen;
            }
        }
    }
}
```

### XAML
```xml
<VerticalStackLayout Padding="20" Spacing="20">
    
    <controls:CircularProgressBar
        x:Name="MyProgressBar"
        Progress="50"
        MaxProgress="100"
        Size="150"
        Thickness="12"
        ProgressEdgeShape="Round" />
    
    <Slider Minimum="0"
            Maximum="100"
            Value="50"
            ValueChanged="OnProgressChanged" />
    
</VerticalStackLayout>
```

---

## 📊 Example 9: Card Layout with Progress

### XAML
```xml
<Border Padding="20" 
        BackgroundColor="White"
        Stroke="LightGray"
        StrokeShape="RoundRectangle 15"
        Shadow="{StaticResource CardShadow}">
    
    <VerticalStackLayout Spacing="20">
        
        <Label Text="Download Progress" 
               FontSize="18" 
               FontAttributes="Bold"
               TextColor="#1F2937" />
        
        <controls:CircularProgressBar
            Progress="456"
            MaxProgress="1024"
            ProgressColor="#3B82F6"
            ProgressLeftColor="#DBEAFE"
            Size="140"
            TextColor="#1E40AF"
            Thickness="10"
            ProgressEdgeShape="Round" />
        
        <Label Text="456 MB of 1024 MB"
               HorizontalOptions="Center"
               TextColor="#6B7280"
               FontSize="14" />
        
        <Button Text="Pause"
                BackgroundColor="#3B82F6"
                TextColor="White" />
        
    </VerticalStackLayout>
    
</Border>
```

---

## 📊 Example 10: All Three Shapes Side by Side

### XAML
```xml
<Grid ColumnDefinitions="*,*,*" ColumnSpacing="20" Padding="20">
    
    <!-- Circular -->
    <VerticalStackLayout Grid.Column="0">
        <Label Text="Circular" 
               HorizontalOptions="Center"
               FontAttributes="Bold"
               Margin="0,0,0,10" />
        <controls:CircularProgressBar
            Progress="75"
            MaxProgress="100"
            Shape="Circular"
            ProgressColor="#10B981"
            ProgressLeftColor="#D1FAE5"
            Size="120"
            Thickness="10"
            ProgressEdgeShape="Round" />
    </VerticalStackLayout>
    
    <!-- Arch -->
    <VerticalStackLayout Grid.Column="1">
        <Label Text="Arch" 
               HorizontalOptions="Center"
               FontAttributes="Bold"
               Margin="0,0,0,10" />
        <controls:CircularProgressBar
            Progress="60"
            MaxProgress="100"
            Shape="Arch"
            ProgressColor="#F59E0B"
            ProgressLeftColor="#FEF3C7"
            Size="120"
            Thickness="10"
            ProgressEdgeShape="Round" />
    </VerticalStackLayout>
    
    <!-- Flat -->
    <VerticalStackLayout Grid.Column="2">
        <Label Text="Flat" 
               HorizontalOptions="Center"
               FontAttributes="Bold"
               Margin="0,0,0,10" />
        <controls:CircularProgressBar
            Progress="85"
            MaxProgress="100"
            Shape="Flat"
            ProgressColor="#8B5CF6"
            ProgressLeftColor="#EDE9FE"
            Size="200"
            Thickness="15" />
    </VerticalStackLayout>
    
</Grid>
```

---

## 🎨 Color Themes

### Success Theme
```xml
<controls:CircularProgressBar
    Progress="90"
    ProgressColor="#10B981"
    ProgressLeftColor="#D1FAE5"
    TextColor="#065F46" />
```

### Warning Theme
```xml
<controls:CircularProgressBar
    Progress="65"
    ProgressColor="#F59E0B"
    ProgressLeftColor="#FEF3C7"
    TextColor="#92400E" />
```

### Danger Theme
```xml
<controls:CircularProgressBar
    Progress="25"
    ProgressColor="#EF4444"
    ProgressLeftColor="#FEE2E2"
    TextColor="#991B1B" />
```

### Info Theme
```xml
<controls:CircularProgressBar
    Progress="50"
    ProgressColor="#3B82F6"
    ProgressLeftColor="#DBEAFE"
    TextColor="#1E40AF" />
```

---

## 📱 Responsive Sizing

### Small
```xml
<controls:CircularProgressBar Size="80" Thickness="6" />
```

### Medium (Default)
```xml
<controls:CircularProgressBar Size="140" Thickness="10" />
```

### Large
```xml
<controls:CircularProgressBar Size="200" Thickness="16" />
```

### Extra Large
```xml
<controls:CircularProgressBar Size="300" Thickness="24" />
```

---

## 🎯 Tips and Best Practices

1. **Size vs Thickness Ratio**: Keep thickness between 5-15% of size for best appearance
2. **Color Contrast**: Ensure good contrast between progress and background colors
3. **Text Visibility**: Use `ShowText="False"` for small progress bars (< 100px)
4. **Rounded Edges**: Use `ProgressEdgeShape="Round"` for modern look
5. **Overlay Charts**: Use different sizes (e.g., 200, 150, 100) for multi-layer effects
6. **Performance**: Avoid frequent progress updates (< 16ms) for smooth animations
7. **Accessibility**: Always provide alternative text descriptions for screen readers

---

Made with ❤️ using Maui.CircularProgress.Net
