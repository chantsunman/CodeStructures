using CodeStructures.Design.Common.Section.Interfaces;
using CodeStructures.Design.Common.Section.ProfileShapeTypes;

namespace CodeStructures.Design.Common.Section.SectionTypes.Predefined
{
    /// <summary>
    /// Predefined I-section is used for I-shapes having known properties 
    /// from catalog (such as AISC shapes)
    /// </summary>
    public class PredefinedSectionI : SectionPredefinedBase, ISectionI, ISliceableShapeProvider
    {
        GbCatalogShape s;
        public PredefinedSectionI(GbCatalogShape section)
            : base(section)
        {
            this._d = section.d;
            this._bf = section.bf;
            this._tf = section.tf;
            this._t_w = section.tw;
            this._k = section.kdes;
            s = section;
            OverrideCentroids();
        }

        private void OverrideCentroids()
        {
            _x_Bar = bf / 2;
            _y_Bar = d / 2;
            _x_pBar = bf / 2;
            _y_pBar = d / 2;
            ElasticCentroidCoordinate = new Mathematics.Point2D(x_Bar, y_Bar);
            PlasticCentroidCoordinate = new Mathematics.Point2D(x_pBar, y_pBar);

        }

        public ISliceableSection GetSliceableShape()
        {
            SectionIRolled secI = new SectionIRolled("", this.d, this.bf, this.t_f, this.t_w, this._k);
            return secI;
        }

        double _d;

        public double d
        {
            get { return _d; }
        }


        double _tf;

        public double t_f
        {
            get { return _tf; }
        }

        double _bf;

        public double bf
        {
            get { return _bf; }
        }
        double _t_w;

        public double t_w
        {
            get { return _t_w; }
        }
        double _k;

        public double k
        {
            get { return _k; }
        }



        public double h_web
        {
            get
            {

                //return _d - (tf + t_fBot) - 2 * k;
                return _d - (2 * k);
            }
        }


        public double h_o
        {
            get { return d - t_f; }
        }

        public double t_fBot
        {
            get { return t_f; }
        }

        public double b_fBot
        {
            get { return bf; }
        }

        public double b_fTop
        {
            get { return bf; }
        }


        public double t_fTop
        {
            get { return t_f; }
        }
    }

}
