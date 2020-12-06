using BOMWeather.Common;

namespace BOMWeather.Client.Exception
{
    public class IncorrectFileExtensionException : System.Exception
    {
        public IncorrectFileExtensionException(string fileExtension)
            : base(string.Format(Constants.ValidationMessage.FileNotFound, fileExtension))
        {
        }
    }
}