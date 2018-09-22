using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Views;
using System;
using Xamarin.Forms.Platform.Android;

namespace DevExpress.GridDemo.Android {
	[Activity(Theme="@style/DemoTheme", Label = "Grid Demo", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity {

        View layout;
        protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
            DevExpress.Mobile.Forms.Init();
			Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());


            //23부터는 카메라 권한을 별도로 작업해야 함.
            if ((int)Build.VERSION.SdkInt >= 23)
            {

                var permissions = new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };

                if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) != (int)Permission.Granted 
                    || ActivityCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) != (int)Permission.Granted)
                { 

                    RequestPermissions(permissions, 0);
                }
            }

            //void RequestCameraPermission(string permission)
            //{
            //    if (ActivityCompat.ShouldShowRequestPermissionRationale(this, permission))
            //    {
            //        Snackbar.Make(layout, "Camera permission is needed to show the camera preview.", Snackbar.LengthIndefinite).SetAction("OK", new Action<View>(delegate (View obj)
            //        {
            //            ActivityCompat.RequestPermissions(this, new String[] { permission }, 0);
            //        })).Show();
            //    }
            //    else
            //    {
            //        ActivityCompat.RequestPermissions(this, new String[] { permission }, 0);
            //    }
            //}
        }
	}
}