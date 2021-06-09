using System.Collections.Generic;

namespace CodeStructures.Design.Common.Reports.Interfaces
{
    public interface ICalcLogEntry
    {
        void AddDependencyValue(string Key, string value);
        void AddDependencyValue(string Key, double value);
        Dictionary<string, string> GetDependencyValues();
        string DescriptionReference { get; set; }
        string FormulaID { get; set; }
        string Reference { get; set; }
        string VariableValue { get; set; }
        string ValueName { get; set; }
        Dictionary<string, string> DependencyValues { get; set; }
        List<List<string>> TableData { get; set; }
        string TemplateTableTitle { get; set; }
    }

}
