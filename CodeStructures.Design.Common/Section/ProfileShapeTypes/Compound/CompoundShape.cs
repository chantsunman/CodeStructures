using CodeStructures.Design.Common.Mathematics;
using CodeStructures.Design.Common.Section.Interfaces;
using System.Collections.Generic;

namespace CodeStructures.Design.Common.Section.ProfileShapeTypes.Compound
{
    /// <summary>
    /// Shape comprised of full-width rectangles,
    /// providing default implementation of ISliceableSection
    /// for calculation of location of PNA (Plastic Neutral Axis)
    /// and Plastic section Modulus Zx
    /// </summary>
    public abstract partial class CompoundShape : ISliceableSection, ISection //SectionBaseClass, 
    {
        bool basicPropertiesCalculated;


        /// <summary>
        /// Abstract method to get a list of rectangles for plastic section modulus analysis.
        /// These rectangles are used for plastic analysis with respect to X-axis.
        /// Correct definition of rectangles must be such that each rectangle 
        /// occupies FULL WIDTH of section.
        /// </summary>
        /// <returns>List of CompoundShapePart rectangles for this shape </returns>
        public abstract List<CompoundShapePart> GetCompoundRectangleXAxisList();

        private List<CompoundShapePart> rectanglesXAxis;

        public List<CompoundShapePart> RectanglesXAxis
        {
            get
            {
                if (rectanglesXAxis == null)
                {
                    rectanglesXAxis = GetCompoundRectangleXAxisList();
                }
                return rectanglesXAxis;
            }
            set { rectanglesXAxis = value; }
        }

        /// <summary>
        /// Abstract method to get a list of rectangles for plastic section modulus analysis.
        /// These rectangles are used for plastic analysis with respect to Y-axis.
        /// Correct definition of rectangles must be such that each rectangle 
        /// occupies FULL HEIGHT of section.
        /// </summary>
        /// <returns>List of CompoundShapePart rectangles for this shape </returns>
        public abstract List<CompoundShapePart> GetCompoundRectangleYAxisList();

        private List<CompoundShapePart> rectanglesYAxis;

        public List<CompoundShapePart> RectanglesYAxis
        {
            get
            {
                if (rectanglesYAxis == null)
                {
                    rectanglesYAxis = GetCompoundRectangleYAxisList();
                }
                return rectanglesYAxis;
            }
            set { rectanglesYAxis = value; }
        }

        private Point2D centroid;

        public Point2D Centroid
        {
            get
            {
                basicPropertiesCalculated = false;
                CalculateBasicProperties();

                return centroid;
            }
            set { centroid = value; }
        }

        private double centroidYAxisRect;

        public double CentroidYAxisRect
        {
            get
            {
                basicPropertiesCalculated = false;
                CalculateBasicProperties();

                return centroidYAxisRect;
            }
            set { centroidYAxisRect = value; }
        }
        public CompoundShape()
            : this(null)
        {

        }

        public CompoundShape(string Name)
        {
            basicPropertiesCalculated = false;
            momentsOfInertiaCalculated = false;
            areaCalculated = false;
            torsionConstantCalculated = false;
            warpingConstantCalculated = false;
            elasticPropertiesCalculated = false;
            plasticPropertiesCalculated = false;
            this.Name = Name;

            //if (AdjustCoordinateToCentroid == true)
            //{
            //    AdjustCoordinates();
            //}
        }




        Point2D plasticCentroid;
        public Point2D PlasticCentroidCoordinate
        {
            get
            {
                if (plasticPropertiesCalculated == false)
                {
                    CalculatePlasticProperties();
                }
                return plasticCentroid;
            }
        }

        public Point2D GetElasticCentroidCoordinate()
        {
            if (basicPropertiesCalculated == false)
            {
                CalculateBasicProperties();
            }
            return Centroid;
        }

        double _YMax;
        public double YMax
        {
            get
            {
                if (basicPropertiesCalculated == false)
                {
                    CalculateBasicProperties();
                }
                return _YMax;
            }
        }

        double _YMin;
        public double YMin
        {
            get
            {
                if (basicPropertiesCalculated == false)
                {
                    CalculateBasicProperties();
                }
                return _YMin;
            }
        }

        double _XMax;
        public double XMax
        {
            get
            {
                if (basicPropertiesCalculated == false)
                {
                    CalculateBasicProperties();
                }
                return _XMax;
            }
        }

        double _XMin;
        public double XMin
        {
            get
            {
                if (basicPropertiesCalculated == false)
                {
                    CalculateBasicProperties();
                }
                return _XMin;
            }
        }

        private void CalculateBasicProperties()
        {

            CalculateMinAndMaxCoordinates();
            CalculateCentroidForXAxisRectangles();
            CalculateCentroidForYAxisRectangles();
            basicPropertiesCalculated = true;
        }

        private void
            CalculateCentroidForXAxisRectangles()
        {

            double sumOfAreasX = 0;
            double sumOfAreasY = 0;
            double sumOfAreaTimesY = 0;
            double sumOfAreaTimesX = 0;

            foreach (var r in RectanglesXAxis)
            {

                double thisArea = r.b * r.h;
                sumOfAreasX += thisArea;
                sumOfAreaTimesY += thisArea * r.Centroid.Y;

            }
            double cY = sumOfAreaTimesY / sumOfAreasX;

            sumOfAreasY = 0;
            foreach (var r in RectanglesYAxis)
            {
                double thisArea = r.b * r.h;
                sumOfAreasY += thisArea;
                //we still use Y because the shape is symmetrical
                sumOfAreaTimesX += thisArea * r.Centroid.X;

            }
            double cX = sumOfAreaTimesX / sumOfAreasY;

            Centroid = new Point2D(cX, cY);

        }

        private void CalculateCentroidForYAxisRectangles()
        {

            double sumOfAreasX = 0;
            double sumOfAreas = 0;
            double sumOfAreaTimesY = 0;


            foreach (var r in RectanglesYAxis)
            {
                double thisArea = r.b * r.h;
                sumOfAreas += thisArea;
                //we still use Y because the shape is symmetrical
                sumOfAreaTimesY += thisArea * r.Centroid.Y;

            }
            double cY = sumOfAreaTimesY / sumOfAreas;

            CentroidYAxisRect = cY;

        }

        private void CalculateMinAndMaxCoordinates()
        {
            double MinXtemp = double.PositiveInfinity;
            double MaxXtemp = double.NegativeInfinity;
            double MinYtemp = double.PositiveInfinity;
            double MaxYtemp = double.NegativeInfinity;

            foreach (var r in RectanglesXAxis)
            {
                //this rectangle properties
                double thisMinX = r.Centroid.X - r.b / 2.0;
                double thisMaxX = r.Centroid.X + r.b / 2.0;
                double thisMinY = r.Centroid.Y - r.h / 2.0;
                double thisMaxY = r.Centroid.Y + r.h / 2.0;

                MinXtemp = thisMinX < MinXtemp ? thisMinX : MinXtemp;
                MaxXtemp = thisMaxX > MaxXtemp ? thisMaxX : MaxXtemp;
                MinYtemp = thisMinY < MinYtemp ? thisMinY : MinYtemp;
                MaxYtemp = thisMaxY > MaxYtemp ? thisMaxY : MaxYtemp;
            }
            this._XMin = MinXtemp;
            this._XMax = MaxXtemp;
            this._YMin = MinYtemp;
            this._YMax = MaxYtemp;
        }

        enum SliceType
        {
            Top,
            Bottom
        }



    }
}
