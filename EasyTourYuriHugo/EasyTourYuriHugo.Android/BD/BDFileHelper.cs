using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EasyTourYuriHugo.Droid.BD;
using EasyTourYuriHugo.BD;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(BDFileHelper))]
namespace EasyTourYuriHugo.Droid.BD
{
    public class BDFileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}