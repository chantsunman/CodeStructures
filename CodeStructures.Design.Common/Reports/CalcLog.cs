using CodeStructures.Design.Common.Reports.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeStructures.Design.Common.Reports
{
    public class CalcLog : ICalcLog
    {
        private string calculatorID;

        public string CalculatorID
        {
            get { return calculatorID; }
            set { calculatorID = value; }
        }

        public CalcLog()
        {
            entries = new List<ICalcLogEntry>();
        }

        private List<ICalcLogEntry> entries;

        public List<ICalcLogEntry> GetEntriesList()
        {
            return entries;
        }

        public List<ICalcLogEntry> Entries
        {
            get { return entries; }
            set { entries = value; }
        }


        public ICalcLogEntry CreateNewEntry()
        {
            CalcLogEntry entry = new CalcLogEntry();
            return entry;
        }

        public void AddEntry(ICalcLogEntry Entry)
        {
            entries.Add(Entry);
        }

        public override string ToString()
        {
            return String.Empty; // JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        #region Serialization


        /// <summary>
        /// This constructor is required for the JSON deserializer to be able
        /// to identify concrete classes to use when deserializing the interface properties.
        /// </summary
        //[JsonConstructor]
        public CalcLog(List<CalcLogEntry> entries)
        {
            this.entries = entries.Cast<ICalcLogEntry>().ToList();
        }

        #endregion
    }

}
