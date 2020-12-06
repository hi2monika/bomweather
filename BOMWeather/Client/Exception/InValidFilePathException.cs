using BOMWeather.Common;

namespace BOMWeather.Client.Exception
{
    public class InValidFilePathException : System.Exception
    {
        public InValidFilePathException(string fileExtension)
            : base(string.Format(Constants.ValidationMessage.FileNotFound, fileExtension))
        {
        }
    }
}