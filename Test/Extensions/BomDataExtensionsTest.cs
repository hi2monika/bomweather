using System;
using System.Collections.Generic;
using System.Net;
using BOMWeather.Extensions;
using BOMWeather.Model;
using Moq;
using Xunit;
using FluentAssertions;

namespace BOMWeather.UnitTests.Extensions
{
    public class BomDataExtensionsTest
    {
        [Theory]
        [MemberData(nameof(GetTotalRainFallTestCases))]
        public void GetTotalRainFallTest(IReadOnlyCollection<IBomData> bomData,
            Action<string> assertion)
        {
            var result = bomData.GetTotalRainFall();
            assertion(result);
        }

        public static IEnumerable<object[]> GetTotalRainFallTestCases
        {
            get
            {
                var bomDataWithValidData = new List<BomData>
                {
                    new BomData()
                    {
                        RainFallAmount = "0.1",
                        Month = "07",
                        PeriodOverWhichRainfallWasMeasured = "1",
                        Day = "01",
                        Year = "2010"
                    },
                    new BomData()
                    {
                        RainFallAmount = "0.2",
                        Month = "08",
                        PeriodOverWhichRainfallWasMeasured = "1",
                        Day = "01",
                        Year = "2010"
                    }
                };

                Action<string> assertion = result =>
                {
                    result.Should().NotBeNullOrEmpty();
                    result.Should().Be("0.3");
                };

                yield return new object[]
                {
                    bomDataWithValidData,
                    assertion
                };

                var bomDataWithEmptyValue = new List<BomData>
                {
                    new BomData()
                    {
                        RainFallAmount = "",
                        Month = "07",
                        PeriodOverWhichRainfallWasMeasured = "1",
                        Day = "01",
                        Year = "2010"
                    },
                    new BomData()
                    {
                        RainFallAmount = "",
                        Month = "08",
                        PeriodOverWhichRainfallWasMeasured = "1",
                        Day = "01",
                        Year = "2010"
                    }
                };

                assertion = result =>
               {
                   result.Should().BeNullOrEmpty();
               };

                yield return new object[]
                {
                    bomDataWithEmptyValue,
                    assertion
                };

                var bomDataWithInvalidDataType = new List<BomData>
                {
                    new BomData()
                    {
                        RainFallAmount = "test",
                        Month = "07",
                        PeriodOverWhichRainfallWasMeasured = "1",
                        Day = "01",
                        Year = "2010"
                    },
                    new BomData()
                    {
                        RainFallAmount = "02",
                        Month = "08",
                        PeriodOverWhichRainfallWasMeasured = "1",
                        Day = "01",
                        Year = "2010"
                    }
                };

                assertion = result =>
                {
                    result.Should().NotBeNullOrEmpty();
                    result.Should().Be("2");
                };

                yield return new object[]
                {
                    bomDataWithInvalidDataType,
                    assertion
                };
            }
        }
    }
}