using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;

namespace TestAndroid.Droid
{
    [Activity(Label = "TestAndroid", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            App app = new App();
            DisplayMetrics dm = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetMetrics(dm);

            int _width = dm.WidthPixels;//分辨率宽度
            int _height = dm.HeightPixels;//分辨率高度
            float _density = dm.Density;////屏幕密度（像素比例0.75、1.0、1.5、2.0）
            DisplayMetricsDensity _densityDPI = dm.DensityDpi; //屏幕密度（每寸像素120、160、240、320）
            _width = WindowManager.DefaultDisplay.Width;
            _height = WindowManager.DefaultDisplay.Height;
            App.WidthPixels = _width;
            App.HeightPixels = _height;
            App.DPI = Convert.ToInt32(_densityDPI);
            App.Density = _density;
            LoadApplication(app);
        }
    }
}