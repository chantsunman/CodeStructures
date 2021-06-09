using CodeStructures.Design.Common.Entities;
using CodeStructures.Design.Common.Reports.Interfaces;

namespace CodeStructures.Design.Steel.GB.Entities
{
    public abstract class SteelDesignElement : AnalyticalElement
    {
        //private SteelDesignFormat designFormat;

        //public SteelDesignFormat DesignFormat
        //{
        //    get { return designFormat; }
        //    set { designFormat = value; }
        //}

        public SteelDesignElement()
        {

        }
        public SteelDesignElement(ICalcLog CalcLog) : base(CalcLog)
        {

        }

    }

}
