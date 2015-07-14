namespace Common.Helpers.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Common.Helpers.DateTime;

    [TestClass]
    public class DateTimeTests
    {
        private const string HawaiianStandardTime = "Hawaiian Standard Time";
        private const string AtlanticStandardTime = "Atlantic Standard Time";
        private const string EasternStandardTime = "Eastern Standard Time";
        private const string CentralStandardTime = "Central Standard Time";
        private const string MountainStandardTime = "Mountain Standard Time";
        private const string PacificStandardTime = "Pacific Standard Time";

        [TestMethod]
        public void ToUtc()
        {
            var dateTime = new DateTime(2015, 7, 1, 13, 21, 0, DateTimeKind.Unspecified);

            var utcFromHawaiianTime = DateHelper.ToUtc(dateTime, HawaiianStandardTime);
            var utcFromAtlanticTime = DateHelper.ToUtc(dateTime, AtlanticStandardTime);
            var utcFromEasternTime = DateHelper.ToUtc(dateTime, EasternStandardTime);
            var utcFromCentralTime = DateHelper.ToUtc(dateTime, CentralStandardTime);
            var utcFromMountainTime = DateHelper.ToUtc(dateTime, MountainStandardTime);
            var utcFromPacificTime = DateHelper.ToUtc(dateTime, PacificStandardTime);

            var hawaiianTimeFromUtc = DateHelper.UtcToTimeZone(utcFromHawaiianTime, HawaiianStandardTime);
            var atlanticTimeFromUtc = DateHelper.UtcToTimeZone(utcFromAtlanticTime, AtlanticStandardTime);
            var easternTimeFromUtc = DateHelper.UtcToTimeZone(utcFromEasternTime, EasternStandardTime);
            var centralTimeFromUtc = DateHelper.UtcToTimeZone(utcFromCentralTime, CentralStandardTime);
            var mountainTimeFromUtc = DateHelper.UtcToTimeZone(utcFromMountainTime, MountainStandardTime);
            var pacificTimeFromUtc = DateHelper.UtcToTimeZone(utcFromPacificTime, PacificStandardTime);

            var hawaiianResult = DateTime.Compare(dateTime, hawaiianTimeFromUtc);
            var atlanticResult = DateTime.Compare(dateTime, atlanticTimeFromUtc);
            var easternResult = DateTime.Compare(dateTime, easternTimeFromUtc);
            var centralResult = DateTime.Compare(dateTime, centralTimeFromUtc);
            var mountainResult = DateTime.Compare(dateTime, mountainTimeFromUtc);
            var pacificResult = DateTime.Compare(dateTime, pacificTimeFromUtc);

            var expected = 0;

            Assert.AreEqual(expected, hawaiianResult);
            Assert.AreEqual(expected, atlanticResult);
            Assert.AreEqual(expected, easternResult);
            Assert.AreEqual(expected, centralResult);
            Assert.AreEqual(expected, mountainResult);
            Assert.AreEqual(expected, pacificResult);
        }
    }
}
