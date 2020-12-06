using System.Collections.Generic;

namespace BOMWeather.Model
{
    public interface IBomDataCollection
    {
        IReadOnlyCollection<IBomData> BomData { get; set; }
    }
}