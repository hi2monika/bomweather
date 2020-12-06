using BOMWeather.Common;

namespace BOMWeather.Client.Exception
{
    public class FileNotFoundException : System.IO.FileNotFoundException
    {
        public FileNotFoundException(string fileName)
            : base(string.Format(Constants.ValidationMessage.FileNotFound, fileName))
        {
        }
    }
}