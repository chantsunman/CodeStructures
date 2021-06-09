﻿using CodeStructures.Design.Common.Mathematics;
using System;

namespace CodeStructures.Design.Common.Section.ProfileShapeTypes.Compound
{
    /// <summary>
    /// Full width rectangular part from which CompoundShape section is built
    /// </summary>
    public class CompoundShapePart
    {
        /// <summary>
        /// Width
        /// </summary>

        private double _b;

        public double b
        {
            get
            {
                double width = GetWidth();
                return width;
            }
            set { _b = value; }
        }

        public virtual double GetWidth()
        {
            return _b;
        }


        /// <summary>
        /// Height
        /// </summary>

        private double _h;

        public double h
        {
            get
            {
                double height = GetHeight();
                return height;
            }
            set { _h = value; }
        }

        public virtual double GetHeight()
        {
            return _h;
        }

        /// <summary>
        /// Actual Height
        /// </summary>

        private double _h_a;

        public double h_a
        {
            get
            {
                double heightActual = GetActualHeight();
                return heightActual;
            }
        }

        protected virtual double GetActualHeight()
        {
            return _h;
        }


        private Point2D insertionPoint;

        /// <summary>
        /// Insertion point and centroid coinside for a rectangular shape but could be different for other types of shapes
        /// </summary>
        public Point2D InsertionPoint
        {
            get
            {
                return insertionPoint;
            }
            set { insertionPoint = value; }
        }

        private Point2D centroid;

        public Point2D Centroid
        {
            get
            {
                centroid = GetCentroid();
                return centroid;
            }
            set { centroid = value; }
        }


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="b">Width</param>
        /// <param name="h">Height</param>
        public CompoundShapePart(double b, double h, Point2D InsertionPoint)
        {
            this.b = b;
            this.h = h;
            this.InsertionPoint = InsertionPoint;
        }
        public CompoundShapePart()
        {

        }

        public virtual double GetArea()
        {
            return b * h;
        }
        public virtual double GetMomentOfInertia()
        {
            return b * Math.Pow(h, 3) / 12.0;
        }

        //public virtual double GetMomentOfInertiaY()
        //{
        //    return h * Math.Pow(b, 3) / 12.0;
        //}

        public virtual Point2D GetCentroid()
        {
            return insertionPoint;
        }


        public double Ymax
        {
            get { return GetYmax(); }
        }


        public double Ymin
        {
            get { return GetYmin(); }
        }

        protected virtual double GetYmax()
        {
            return this.InsertionPoint.Y + h / 2;
        }
        protected virtual double GetYmin()
        {
            return this.InsertionPoint.Y - h / 2;
        }
    }

}
