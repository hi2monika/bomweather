using System.Collections.Generic;

namespace BOMWeather.Model
{
    public class BomDataCollection : IBomDataCollection
    {
        public IReadOnlyCollection<IBomData> BomData { get; set; }
    }
}