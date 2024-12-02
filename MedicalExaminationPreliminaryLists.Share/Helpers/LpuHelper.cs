using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExaminationPreliminaryLists.Share.Helpers
{
    public class LpuHelper
    {
        public static string SetLpu(string ds)
        {
            Dictionary<string, Func<string, bool>> lpuDictionary = new Dictionary<string, Func<string, bool>>
            {
                { "43", ds => Between(ds, "E10", "E14") || ds.StartsWith("E14")},
                { "44", ds => Between(ds, "C00", "C97") || Between(ds[..3], "D00", "D09") || ds.StartsWith("C97") || ds.StartsWith("D09")},
                { "45", ds => ds.StartsWith("E78") || Between(ds, "I10", "I15") || ds.StartsWith("I15") || Between(ds, "I20", "I25") ||
                              ds.StartsWith("I25") || ds.StartsWith("I26") || ds.StartsWith("I27.0") || ds.StartsWith("I27.2") || ds.StartsWith("I27.8") ||
                              ds.StartsWith("I28") || Between(ds, "I33", "I42") || ds.StartsWith("I42") || Between(ds, "I44", "I49") || ds.StartsWith("I49") ||
                              ds.StartsWith("I50.0") || ds.StartsWith("I50.1") || ds.StartsWith("I50.9") || Between(ds, "I51.0", "I51.2") || ds.StartsWith("I51.4") ||
                              ds.StartsWith("I65.2") || ds.StartsWith("I67.8") || Between(ds, "I69.0", "I69.4") || ds.StartsWith("I71") || Between(ds, "Q20", "Q28") ||
                              ds.StartsWith("Q28") || Between(ds, "Z95.0", "Z95.5") || ds.StartsWith("Z95.8") || ds.StartsWith("Z95.9")},
                { "47", ds => ds.StartsWith("I") }
            };

            foreach (var lpu in lpuDictionary)
            {
                if (lpu.Value(ds))
                {
                    return lpu.Key;
                }
            }
            return "46";
        }

        static bool Between(string value, string start, string end)
        {
            return string.Compare(value, start, StringComparison.Ordinal) >= 0 && string.Compare(value, end, StringComparison.Ordinal) <= 0;
        }
    }
}
