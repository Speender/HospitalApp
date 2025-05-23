using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using HospitalApp.Models;
using HospitalApp.ViewModels; // ✅ Add this!
using System;


namespace HospitalApp.Views;

public partial class AppointmentsPageView : UserControl
{
    public AppointmentsPageView()
    {
        InitializeComponent();

        this.Loaded += (sender, args) =>
        {
            if (DataContext is AppointmentsPageViewModel vm)
            {
                vm.ParentWindow = TopLevel.GetTopLevel(this) as Window;
            }
        };
    }

    public AppointmentsPageView(ApiService apiService, SignalRService signalRService)
    {
        InitializeComponent();
        var viewModel = new AppointmentsPageViewModel(apiService, signalRService);
        this.DataContext = viewModel;
        this.Loaded += (sender, args) =>
        {
            if (DataContext is AppointmentsPageViewModel vm)
            {
                vm.ParentWindow = TopLevel.GetTopLevel(this) as Window;
                _ = vm.LoadDataAsync(); // Load data when the view is loaded
            }
        };
    }
}