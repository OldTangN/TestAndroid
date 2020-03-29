using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestAndroid
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Appearing += MainPage_Appearing;
        }
        //Plugin.SimpleAudioPlayer.ISimpleAudioPlayer player ;
        private void MainPage_Appearing(object sender, EventArgs e)
        {
            //player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            //player.Load("broken.wav");
            // this.DisplayAlert("提示", string.Format("{0}*{1} {2} {3}", App.WidthPixels, App.HeightPixels, App.Density, App.DPI), "取消");
            //return;
            InitLamp();
        }

        private List<ImageButton> lstImgBtn;

        private void InitLamp()
        {
            LampGrid.Children.Clear();
            lstImgBtn = new List<ImageButton>();
            double imgWidth = 200;
            double imgHeight = 200;
            double margin = 22;
            int rowCount = 0;
            int colCount = 0;
            colCount = (int)Math.Floor(App.WidthPixels / (imgHeight + margin));
            rowCount = (int)Math.Floor(App.HeightPixels / (imgWidth + margin));
            //this.DisplayAlert("提示", string.Format("{0}*{1}", rowCount, colCount), "取消");
            for (int col = 0; col < colCount; col++)
            {
                for (int row = 0; row < rowCount; row++)
                {

                    ImageButton imgbtn = new ImageButton();
                    imgbtn.Margin = new Thickness(col * (imgWidth + margin) / App.Density, row * (imgHeight + margin) / App.Density, 0, 0);
                    imgbtn.HorizontalOptions = LayoutOptions.Start;
                    imgbtn.VerticalOptions = LayoutOptions.Start;
                    imgbtn.WidthRequest = imgWidth / App.Density;
                    imgbtn.HeightRequest = imgHeight / App.Density;

                    imgbtn.CommandParameter = 1;
                    imgbtn.Source = "good.png";
                    imgbtn.Clicked += ImageButton_Clicked;
                    LampGrid.Children.Add(imgbtn);
                    lstImgBtn.Add(imgbtn);
                }
            }
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton imgbtn = sender as ImageButton;
            int flag = Convert.ToInt32(imgbtn.CommandParameter);
            //if (flag == 1)
            //{
            //    imgbtn.CommandParameter = 0;
            //    imgbtn.Source = "bad.png";
            //}
            //else
            //{
            //    imgbtn.CommandParameter = 1;
            //    imgbtn.Source = "good.png";
            //}
            //player.Stop();
            //player.Play();
            imgbtn.Source = "bad.png";
            lstImgBtn.Remove(imgbtn);
            if (lstImgBtn.Count == 0)
            {
                await this.DisplayAlert("提示", "唐唐好棒！", "确定");
                InitLamp();
            }
        }
    }
}
