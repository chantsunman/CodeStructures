using System;

namespace CodeStructures.Design.Common.Exceptions
{
    public class ShapeTypeNotSupportedException : ApplicationException
    {

        public ShapeTypeNotSupportedException()
        {
            typeString = "";
        }

        public ShapeTypeNotSupportedException(string ActionType)
        {

            typeString = string.Format(" for {0} calculation", ActionType);
        }

        string typeString;

        public override string Message
        {
            get
            {
                return string.Format("Section type not supported{0}.", typeString);
            }
        }
    }

}
