using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlideBug
{
    public partial class ScrollPage : ContentPage
    {
        public bool isBusy = false;
        public ScrollPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            indicator.IsEnabled = false;
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

                    buglbl.Text = $"Height: {bugImage.Height} Width: {bugImage.Width}";

                    lbl.Text = $"Height: {bg.Height} Width: {bg.Width}";
                });
            }
        }
    }
}