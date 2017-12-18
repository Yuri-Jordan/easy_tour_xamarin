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
