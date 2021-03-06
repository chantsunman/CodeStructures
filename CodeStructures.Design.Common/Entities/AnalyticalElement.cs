using CodeStructures.Design.Common.Reports;
using CodeStructures.Design.Common.Reports.Interfaces;
using System;
using System.Collections.Generic;

namespace CodeStructures.Design.Common.Entities
{
    public class AnalyticalElement : ILoggable
    {
        public AnalyticalElement()
        {
            this.log = new CalcLog(new List<CalcLogEntry>());
            LogModeActive = true;
        }
        public AnalyticalElement(ICalcLog CalcLog)
        {
            if (CalcLog == null)
            {
                this.log = new CalcLog(new List<CalcLogEntry>());
                LogModeActive = true;
            }
            else
            {
                this.log = CalcLog;
                LogModeActive = true;
            }

        }
        private ICalcLog log;

        public ICalcLog Log
        {
            get { return log; }
            set { log = value; }
        }

        public bool LogModeActive { get; set; }


        public void AddToLog(ICalcLogEntry LogEntry)
        {
            if (LogModeActive == true)
            {
                log.AddEntry(LogEntry);
            }
        }

        public void AddGoverningCaseLogEntry(string ValueName, string Value)
        {

            #region GoverningValue
            ICalcLogEntry GoverningValueEntry = new CalcLogEntry();
            GoverningValueEntry.ValueName = "V";
            GoverningValueEntry.AddDependencyValue("N", ValueName);
            GoverningValueEntry.DescriptionReference = "/Templates/General/GoverningValue.docx";
            GoverningValueEntry.FormulaID = null; //reference to formula from code
            GoverningValueEntry.VariableValue = Value.ToString();
            #endregion
            log.AddEntry(GoverningValueEntry);
        }

        public void AddGoverningCaseMaxLogEntry(string ValueName, double ValMax, double ValMin, string GoverningEquation)
        {
            #region GoverningValueMax
            ICalcLogEntry GoverningValueEntryMax = new CalcLogEntry();
            GoverningValueEntryMax.ValueName = ValueName;
            GoverningValueEntryMax.AddDependencyValue("ValMax", Math.Round(ValMax, 3));
            GoverningValueEntryMax.AddDependencyValue("ValMin", Math.Round(ValMin, 3));
            GoverningValueEntryMax.AddDependencyValue("GoverningEquation", GoverningEquation);
            GoverningValueEntryMax.Reference = "Governing case";
            GoverningValueEntryMax.DescriptionReference = "/Templates/General/GoverningValueMax.docx";
            GoverningValueEntryMax.FormulaID = GoverningEquation; //reference to formula from code
            GoverningValueEntryMax.VariableValue = Math.Round(ValMax, 3).ToString();
            #endregion
            log.AddEntry(GoverningValueEntryMax);
        }

        public void AddGoverningCaseMinLogEntry(string ValueName, double ValMax, double ValMin, string GoverningEquation)
        {
            #region GoverningValueMin
            ICalcLogEntry GoverningValueEntryMin = new CalcLogEntry();
            GoverningValueEntryMin.ValueName = ValueName;
            GoverningValueEntryMin.AddDependencyValue("ValMax", Math.Round(ValMax, 3));
            GoverningValueEntryMin.AddDependencyValue("ValMin", Math.Round(ValMin, 3));
            GoverningValueEntryMin.AddDependencyValue("GoverningEquation", GoverningEquation);
            GoverningValueEntryMin.Reference = "Governing case";
            GoverningValueEntryMin.DescriptionReference = "/Templates/General/GoverningValueMin.docx";
            GoverningValueEntryMin.FormulaID = GoverningEquation; //reference to formula from code
            GoverningValueEntryMin.VariableValue = Math.Round(ValMin, 3).ToString();
            #endregion
            log.AddEntry(GoverningValueEntryMin);
        }
    }

}
