using System.Globalization;
using System.Xml.Linq;

namespace MedicalExaminationPreliminaryLists.Share
{
    public static class XElementHelper
    {
        public static string GetStringOrDefault(this XElement? element)
            => element?.Value ?? "";
        public static int GetIntOrDefault(this XElement? element)
            => element is not null ? int.Parse(element.Value) : 0;
        public static DateTime GetDateTimeOrDefault(this XElement? element)
            => element is not null ? DateTime.Parse(element.Value) : DateTime.MinValue;
        public static decimal GetDecimalOrDefault(this XElement? element)
            => element is not null ? decimal.Parse(element.Value, CultureInfo.InvariantCulture) : 0m;
        public static bool GetBoolOrDefualt(this XElement? element)
            => element is not null ? element.Value == "1" : false;
        public static string GetJoinsStringOrDefault(this IEnumerable<XElement>? elements)
            => elements is not null ? string.Join(';', elements.Select(x => x.Value)) : string.Empty;
    }
}
