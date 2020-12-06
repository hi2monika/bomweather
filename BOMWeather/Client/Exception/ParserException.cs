using BOMWeather.Common;

namespace BOMWeather.Client.Exception
{
    public class ParserException : System.Exception
    {
        public ParserException(string data)
            : base(string.Format(Constants.ValidationMessage.ParserException, data))
        {
        }
    }
}