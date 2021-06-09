using System.Collections.Generic;

namespace CodeStructures.Design.Common.Reports.Interfaces
{
    public interface ICalcLog
    {
        string CalculatorID { get; set; }
        void AddEntry(ICalcLogEntry Entry);
        List<ICalcLogEntry> GetEntriesList();
        List<ICalcLogEntry> Entries { get; set; }
        ICalcLogEntry CreateNewEntry();
        //string Serealize();
    }
}
