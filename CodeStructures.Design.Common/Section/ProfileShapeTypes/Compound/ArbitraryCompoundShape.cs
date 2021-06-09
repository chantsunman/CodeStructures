using System.Collections.Generic;

namespace CodeStructures.Design.Common.Section.ProfileShapeTypes.Compound
{
    /// <summary>
    /// An implementation of compund shape when the profile type is not known.
    /// It is used for ISleceableShape implementation when a  slice of shape
    /// is generated and section properties for the slice are calculated.
    /// </summary>
    public class ArbitraryCompoundShape : CompoundShape
    {


        public ArbitraryCompoundShape(List<CompoundShapePart> rectanglesXAxis, List<CompoundShapePart> rectanglesYAxis)
        {

            if (rectanglesXAxis == null)
            {
                this.RectanglesXAxis = new List<CompoundShapePart>();
            }
            else
            {
                this.RectanglesXAxis = rectanglesXAxis;
            }

            if (rectanglesYAxis == null)
            {
                this.RectanglesYAxis = new List<CompoundShapePart>();
            }
            else
            {
                this.RectanglesYAxis = rectanglesYAxis;
            }

        }
        public override List<CompoundShapePart> GetCompoundRectangleXAxisList()
        {
            return RectanglesXAxis;
        }

        protected override void CalculateWarpingConstant()
        {
            _C_w = 0.0;
            torsionConstantCalculated = true;
        }

        public override List<CompoundShapePart> GetCompoundRectangleYAxisList()
        {
            return RectanglesYAxis;
        }
    }

}
