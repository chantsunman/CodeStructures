namespace CodeStructures.Design.Common.Reports.Interfaces
{
    public interface ILoggable
    {
        ICalcLog Log { get; set; }
        bool LogModeActive { get; set; }
        void AddToLog(ICalcLogEntry LogEntry);
    }
}
