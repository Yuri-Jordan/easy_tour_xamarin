using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using EasyTourYuriHugo.BD;
using EasyTourYuriHugo.UWP.BD;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(BDFileHelper))]
namespace EasyTourYuriHugo.UWP.BD
{
    public class BDFileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
