using System.Collections.Generic;

namespace CodeStructures.Design.Common.Interfaces
{
    public interface IStructuralMember
    {
        List<IMemberForce> Forces { get; set; }
        //ISection Section { get; set; }
    }
}
