using CodeStructures.Design.Common.Reports.Interfaces;
using System.Collections.Generic;

namespace CodeStructures.Design.Common.Reports
{
    public class CalcLogEntry : ICalcLogEntry
    {

        private string valueName;

        public string ValueName
        {
            get { return valueName; }
            set { valueName = value; }
        }


        private string variableValue;

        public string VariableValue
        {
            get { return variableValue; }
            set { variableValue = value; }
        }


        private string reference;

        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }


        private string formulaID;

        public string FormulaID
        {
            get { return formulaID; }
            set { formulaID = value; }
        }

        private Dictionary<string, string> dependencyValues;

        public Dictionary<string, string> DependencyValues
        {
            get
            {
                return dependencyValues;
            }
            set
            {
                dependencyValues = value;
            }
        }

        private string descriptionReference;

        public string DescriptionReference
        {
            get { return descriptionReference; }
            set { descriptionReference = value; }
        }


        private List<List<string>> tableData;

        public List<List<string>> TableData
        {
            get { return tableData; }
            set { tableData = value; }
        }


        private string templateTableTitle;

        public string TemplateTableTitle
        {
            get { return templateTableTitle; }
            set { templateTableTitle = value; }
        }


        public CalcLogEntry()
        {
            dependencyValues = new Dictionary<string, string>();
        }

        public void AddDependencyValue(string Key, string value)
        {
            DependencyValues.Add(Key, value);
        }

        public void AddDependencyValue(string Key, double value)
        {
            DependencyValues.Add(Key, value.ToString());
        }

        public Dictionary<string, string> GetDependencyValues()
        {
            return dependencyValues;
        }
    }

}
