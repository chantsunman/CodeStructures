using CodeStructures.Design.Common.Mathematics;
using CodeStructures.Design.Common.Section.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeStructures.Design.CodeStructures.Design.Common.Section.ProfileShapeTypes.Compound
{
    /// <summary>
    /// This class is a generic implementation of IMoveableSection.
    /// It is used for output of section slice in the ISliceableSection implementation.
    /// The IMoveableSection member values must be provided to this class
    /// in the constructor.
    /// </summary>
    public class SectionSlice : IMoveableSection
    {
        public Point2D PlasticCentroidCoordinate { get; set; }


        public Point2D GetElasticCentroidCoordinate()
        {
            throw new NotImplementedException();
        }



        public double YMax
        {
            get { throw new NotImplementedException(); }
        }

        public double YMin
        {
            get { throw new NotImplementedException(); }
        }

        public double XMax
        {
            get { throw new NotImplementedException(); }
        }

        public double XMin
        {
            get { throw new NotImplementedException(); }
        }

        public double A
        {
            get { throw new NotImplementedException(); }
        }


        public double I_x
        {
            get { throw new NotImplementedException(); }
        }
    }

}
