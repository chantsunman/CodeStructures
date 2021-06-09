namespace CodeStructures.Design.Common.Section.Interfaces
{
    public interface ISectionChannel : IDoubleFlangeMember
    {
        //double d { get; }
        double h_o { get; }
        double FlangeClearDistance { get; }
        //double t_f{ get; }
        double b_f { get; }
        //double t_w { get;  }
        double k { get; }
    }
}
