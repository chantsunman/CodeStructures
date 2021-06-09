using CodeStructures.Design.Common.Interfaces;
using CodeStructures.Design.Common.Reports.Interfaces;
using CodeStructures.Design.Steel.GB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeStructures.Design.Steel.GB.Entities.Members
{
    public abstract class SteelMemberBase : SteelDesignElement, IStructuralMember, ISteelMember
    {
        public SteelMemberBase(ISteelSection Section, ICalcLog CalcLog)
            : base(CalcLog) //, ISteelMaterial Material)
        {
            //this.Material = Material;
            this.Section = Section;
        }
        public List<IMemberForce> Forces { get; set; }
        public ISteelSection Section { get; set; }
        //public ISteelMaterial Material { get; set; }


        public List<IMemberForce> GetForce(string LoadCaseName)
        {
            var f = Forces.Where(a => a.LoadCaseName == LoadCaseName).ToList();
            if (f == null)
            {
                throw new Exception("Member force for load combination not found");
            }

            return f;
        }


    }

}
