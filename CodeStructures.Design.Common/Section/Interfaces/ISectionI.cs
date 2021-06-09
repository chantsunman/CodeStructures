namespace CodeStructures.Design.Common.Section.Interfaces
{
    public interface ISectionI : IDoubleFlangeMember
    {
        //double d { get; }
        double h_o { get; }
        double t_fBot { get; }

        double t_fTop { get; }
        //double tf { get;  }
        double b_fBot { get; }
        double b_fTop { get; }
        //double t_w { get;  }
        double h_web { get; }
        //double FilletDistance { get; }
    }
}
