using CodeStructures.Design.Common.Section.Interfaces;
using CodeStructures.Design.Common.Section.ProfileShapeTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeStructures.Design.Common.Section.SectionTypes.Predefined
{
    /// <summary>
    /// Predefined C-section is used for channel shapes having known properties 
    /// from catalog (such as AISC shapes)
    /// </summary>
    public class PredefinedSectionChannel : SectionPredefinedBase, ISectionChannel, ISliceableShapeProvider
    {
        GbCatalogShape s;
        public PredefinedSectionChannel(GbCatalogShape section)
            : base(section)
        {
            s = section;
            this._d = section.d;
            this._b_f = section.bf;
            this._t_f = section.tf;
            this._t_w = section.tw;
            this._k = section.kdes;
            OverrideCentroids();
        }

        private void OverrideCentroids()
        {
            _x_Bar = s.x_Bar;
            _y_Bar = d / 2;
            _x_pBar = s.x_pBar;
            _y_pBar = d / 2;

            ElasticCentroidCoordinate = new Mathematics.Point2D(x_Bar, y_Bar);
            PlasticCentroidCoordinate = new Mathematics.Point2D(x_pBar, y_pBar);
        }

        public ISliceableSection GetSliceableShape()
        {
            SectionChannelRolled secI = new SectionChannelRolled("", this.d, this.b_f, this.t_f, this.t_w, this.k);
            return secI;
        }

        double _d;

        public double d
        {
            get { return _d; }
        }
        double _h_o;

        public double h_o
        {
            get
            {
                _h_o = Get_h_o();
                return _h_o;
            }
        }

        private double Get_h_o()
        {
            return d - t_f;
        }
        double flangeClearDistance;

        public double FlangeClearDistance
        {
            get { return flangeClearDistance; }
        }
        double _t_f;

        public double t_f
        {
            get { return _t_f; }
        }
        double _b_f;

        public double b_f
        {
            get { return _b_f; }
        }
        double _t_w;

        public double t_w
        {
            get { return _t_w; }
            set { _t_w = value; }
        }
        double _k;

        public double k
        {
            get { return _k; }
            set { _k = value; }
        }


        //public override ISection Clone()
        //{
        //    throw new NotImplementedException();
        //}
    }

}
