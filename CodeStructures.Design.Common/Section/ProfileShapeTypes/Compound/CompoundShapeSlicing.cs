using CodeStructures.Design.Common.Entities;
using CodeStructures.Design.Common.Mathematics;
using CodeStructures.Design.Common.Section.Interfaces;
using System;
using System.Linq;

namespace CodeStructures.Design.Common.Section.ProfileShapeTypes.Compound
{
    public abstract partial class CompoundShape : ISliceableSection, ISection
    {
        /// <summary>
        /// Calculates slicing plane top offset 
        /// </summary>
        /// <param name="Atar">Target area</param>
        /// <returns>Offset of the slicing plane from the top</returns>
        public double GetSlicePlaneTopOffset(double Atar)
        {
            double SlicePlaneCoordinate = 0.0;
            double Sum_hi = 0;  //summation of height of previous rectangles
            double Sum_Ai = 0; //summation of areas of previous rectangles
            var sortedRectanglesX = RectanglesXAxis.OrderByDescending(r => r.InsertionPoint.Y).ToList();

            foreach (var r in sortedRectanglesX)
            {
                double bn = r.b;
                double hn = r.h;
                double hn_actual = r.h_a; //actual height used for fillet areas
                double yn = 0;

                double An = bn * hn;

                //distance from top of the rectangle to the slicing plane
                //this number is meaningful only for one rectangle
                double h_n_tilda = (Atar - Sum_Ai) / bn;
                double Y_n_tilda = 0;

                //check if this rectangle is the one where
                //slice plane is located
                if (h_n_tilda > 0 && h_n_tilda <= hn)
                {
                    //this condition is met only for one rectangle
                    Y_n_tilda = Sum_hi + h_n_tilda;
                    SlicePlaneCoordinate = Y_n_tilda;//slicing plane coordinate is measured from top
                }
                Sum_Ai += An;
                Sum_hi += hn_actual;
            }

            return SlicePlaneCoordinate;
        }


        /// <summary>
        /// Returns a top slice of section having specified area.
        /// </summary>
        /// <param name="Area"></param>
        /// <returns></returns>
        public IMoveableSection GetTopSliceOfArea(double Area)
        {
            return getSliceOfArea(Area, SliceType.Top);

        }

        /// <summary>
        /// Returns a top slice of section having specified area.
        /// </summary>
        /// <param name="Area"></param>
        /// <returns></returns>
        public IMoveableSection GetBottomSliceOfArea(double Area)
        {
            return getSliceOfArea(Area, SliceType.Bottom);
        }

        //variables used to store iteration data for finding a slice of a given area;
        double targetArea;
        IMoveableSection cutSection;

        /// <summary>
        /// Iterates the section until a top or bottom slice (as specified) 
        /// is of requested area.
        /// </summary>
        /// <param name="Area"></param>
        /// <param name="sliceType"></param>
        /// <returns></returns>
        private IMoveableSection getSliceOfArea(double Area, SliceType sliceType)
        {
            double Atar = 0; //target area
            double YOffsetTop = 0;
            if (Area > this.A)
            {
                throw new Exception("Section analysis failed. Area of section sub-part exceeds the total area of cross section.");
            }
            else
            {
                if (sliceType == SliceType.Top) // need to return the TOP portion of given area
                {
                    Atar = Area;
                }
                else // need to return the BOTTOM portion of given area
                {
                    Atar = this.A - Area;
                }
                YOffsetTop = GetSlicePlaneTopOffset(Atar);
            }
            double SlicePlaneYCoordinte;

            SlicePlaneYCoordinte = this.YMax - YOffsetTop;

            IMoveableSection s = getSliceAtCoordinate(SlicePlaneYCoordinte, sliceType);
            return s;
        }

        /// <summary>
        /// Calculates a section based on slicing criteria
        /// </summary>
        /// <param name="YCoordinate">Plane Y coordinate in local coordinate system</param>
        /// <param name="sliceType">Indicates whether top or bottom slice is returned</param>
        /// <returns></returns>
        private IMoveableSection getSliceAtCoordinate(double YCoordinate, SliceType sliceType)
        {


            ArbitraryCompoundShape newShape = new ArbitraryCompoundShape(null, null);
            if (sliceType == SliceType.Top)
            {
                var sortedRectanglesX = RectanglesXAxis.OrderByDescending(r => r.InsertionPoint.Y).ToList();
                foreach (var r in sortedRectanglesX)
                {
                    if (r.Ymax > YCoordinate && r.Ymin >= YCoordinate)
                    {
                        newShape.rectanglesXAxis.Add(r);
                    }
                    else if (r.Ymax >= YCoordinate && r.Ymin <= YCoordinate)
                    {
                        double thisRectHeight = r.Ymax - YCoordinate;
                        newShape.rectanglesXAxis.Add(new CompoundShapePart(r.b, thisRectHeight, new Point2D(0, r.Ymax - thisRectHeight / 2.0)));
                    }
                    else
                    {
                        //do nothing since this rectangle does not belong here
                    }

                }
            }
            else
            {
                var sortedRectanglesX = RectanglesXAxis.OrderBy(r => r.InsertionPoint.Y).ToList();
                foreach (var r in sortedRectanglesX)
                {
                    if (r.Ymax <= YCoordinate && r.Ymin < YCoordinate)
                    {
                        newShape.rectanglesXAxis.Add(r);
                    }
                    else if (r.Ymax > YCoordinate && r.Ymin <= YCoordinate)
                    {
                        double thisRectHeight = YCoordinate - r.Ymin;
                        newShape.rectanglesXAxis.Add(new CompoundShapePart(r.b, thisRectHeight, new Point2D(0, r.Ymin + thisRectHeight / 2.0)));
                    }
                    else
                    {
                        //do nothing since this rectangle does not belong here
                    }

                }
            }

            return newShape;


        }


        public IMoveableSection GetTopSliceSection(double PlaneOffset, SlicingPlaneOffsetType OffsetType)
        {
            double YPlane = GetYPlane(PlaneOffset, OffsetType);
            return getSliceAtCoordinate(YPlane, SliceType.Top);
        }

        public IMoveableSection GetBottomSliceSection(double PlaneOffset, SlicingPlaneOffsetType OffsetType)
        {
            double YPlane = GetYPlane(PlaneOffset, OffsetType);
            return getSliceAtCoordinate(YPlane, SliceType.Bottom);
        }

        private double GetYPlane(double PlaneOffset, SlicingPlaneOffsetType OffsetType)
        {
            double YPlane = 0;

            switch (OffsetType)
            {
                case SlicingPlaneOffsetType.Top:
                    YPlane = YMax - PlaneOffset;
                    break;
                case SlicingPlaneOffsetType.Centroid:
                    YPlane = this.Centroid.Y + PlaneOffset;
                    break;
                case SlicingPlaneOffsetType.Bottom:
                    YPlane = YMin + PlaneOffset;
                    break;
                default:
                    break;
            }

            return YPlane;
        }




    }

}
