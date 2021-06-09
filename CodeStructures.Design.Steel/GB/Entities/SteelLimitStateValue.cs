namespace CodeStructures.Design.Steel.GB.Entities
{
    public class SteelLimitStateValue
    {
        public double Value { get; set; }
        public bool IsApplicable { get; set; }

        public SteelLimitStateValue()
        {


        }

        public SteelLimitStateValue(double Value, bool IsApplicable)
        {
            this.Value = Value;
            this.IsApplicable = IsApplicable;
        }

        public SteelLimitStateValue(double Value)
        {
            this.Value = Value;
            IsApplicable = true;
        }
    }

}
