namespace CodeStructures.Design.Common.Section.Interfaces
{
    public interface ISection : IMeasurableAreaSection
    {
        //void CalculateSectionProperties(); this will be added later todo:

        string Name { get; }
        double A { get; }
        double I_x { get; }
        double I_y { get; }
        double S_xTop { get; }
        double S_xBot { get; }
        double S_yLeft { get; }
        double S_yRight { get; }
        double Z_x { get; }
        double Z_y { get; }
        double r_x { get; }
        double r_y { get; }
        double x_Bar { get; }
        double y_Bar { get; }
        double x_pBar { get; }
        double y_pBar { get; }
        double C_w { get; }
        double J { get; }


        //ISection Clone();
    }

}
