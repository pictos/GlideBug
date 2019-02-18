using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlideBug
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StackPage : ContentPage
    {
        bool isBusy;

        public StackPage()
        {
            InitializeComponent();

            indicator.IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            lbl.Text = $"Height: {bg.Height} Width: {bg.Width}";
            buglbl.Text = $"Height: {bugImage.Height} Width: {bugImage.Width}";
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            if (!isBusy)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    isBusy = true;
                    indicator.IsVisible = isBusy;
                    indicator.IsRunning = isBusy;
                    indicator.IsEnabled = isBusy;
                    await Task.Delay(2000);
                    isBusy = false;

                    indicator.IsVisible = isBusy;
                    indicator.IsRunning = isBusy;
                    indicator.IsEnabled = isBusy;

                    lbl.Text = $"Height: {bg.Height} Width: {bg.Width}";
                    buglbl.Text = $"Height: {bugImage.Height} Width: {bugImage.Width}";
                });
            }
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Click", $"Height: {bg.Height} - Widht: {bg.Width}", "Ok");
        }
    }
}