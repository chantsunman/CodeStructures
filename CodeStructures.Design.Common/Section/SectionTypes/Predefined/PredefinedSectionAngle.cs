using CodeStructures.Design.Common.Entities;
using CodeStructures.Design.Common.Section.Interfaces;
using CodeStructures.Design.Common.Section.ProfileShapeTypes.Angle;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeStructures.Design.Common.Section.SectionTypes.Predefined
{
    /// <summary>
    /// Predefined L-section is used for single angles having known properties 
    /// from catalog (such as AISC shapes)
    /// </summary>
    public class PredefinedSectionAngle : SectionPredefinedBase, ISectionAngle, ISliceableShapeProvider
    {

        public PredefinedSectionAngle(GbCatalogShape section, AngleOrientation AngleOrientation, AngleRotation AngleRotation)
            : base(section)
        {
            //this._d = section.d;
            //this._b = section.b;
            Set_b_and_d(section.d, section.b, AngleOrientation);
            this._t = section.t;
            this.AngleOrientation = AngleOrientation;
            this.AngleRotation = AngleRotation;
            base._y_Bar = section.y;
            base._y_pBar = section.yp;

        }

        private void Set_b_and_d(double d, double b, AngleOrientation AngleOrientation)
        {
            double LongLeg = b >= d ? b : d;
            double ShortLeg = b < d ? b : d;

            if (AngleOrientation == AngleOrientation.LongLegVertical)
            {
                this._d = LongLeg;
                this._b = ShortLeg;
            }
            else
            {
                this._d = ShortLeg;
                this._b = LongLeg;
            }
        }



        public PredefinedSectionAngle(
                                    double Height,
                                    double Thickness,
                                    double Width,
                                    double MomentOfInertiaPrincipalMajor,
                                    double MomentOfInertiaPrincipalMinor,
                                    double SectionModulusPrincipalMajor,
                                    double SectionModulusPrincipalMinor,
                                    double RadiusOfGyrationPrincipalMajor,
                                    double RadiusOfGyrationPrincipalMinor, ISection section)
            : base(section)
        {
            this._d = Height;
            this._t = Thickness;
            this._b = Width;
            this._I_w = MomentOfInertiaPrincipalMajor;
            this._I_z = MomentOfInertiaPrincipalMinor;
            this._S_w = SectionModulusPrincipalMajor;
            this._S_z = SectionModulusPrincipalMinor;
            this._r_w = RadiusOfGyrationPrincipalMajor;
            this._r_z = RadiusOfGyrationPrincipalMinor;


        }



        double _d;

        public double d
        {
            get { return _d; }
            set { _d = value; }
        }
        double _t;

        public double t
        {
            get { return _t; }
        }
        double _b;

        public double b
        {
            get { return _b; }
        }

        double _I_w;

        public double I_w
        {
            get { return _I_w; }
        }
        double _I_z;

        public double I_z
        {
            get { return _I_z; }
        }

        double _S_w;

        public double S_w
        {
            get { return _S_w; }
        }
        double _S_z;

        public double S_z
        {
            get { return _S_z; }
        }

        double _r_w;

        public double r_w
        {
            get { return _r_w; }
        }
        double _r_z;

        public double r_z
        {
            get { return _r_z; }
        }


        public ISection GetWeakAxisClone()
        {
            PredefinedSectionAngle clone = new PredefinedSectionAngle(b, t, d,
              I_w,
              I_z,
              S_w,
              S_z,
              r_w,
              r_z,
              new SectionAngle("", this.b, d, t, AngleRotation.FlatLegBottom, AngleOrientation.ShortLegVertical)
                );
            clone._I_x = this.I_y;
            clone._I_y = this.I_x;
            clone._S_x_Top = this.S_yRight;
            clone._S_xBot = this.S_yLeft;
            clone._S_yLeft = this.S_xTop;
            clone._S_yRight = this.S_xBot;
            clone._Z_x = this.Z_y;
            clone._Z_y = this.Z_x;
            clone._r_x = this.r_y;
            clone._r_y = this.r_x;
            clone.elasticCentroidCoordinate.X = this.y_Bar;
            clone.elasticCentroidCoordinate.Y = this.x_Bar;
            clone.plasticCentroidCoordinate.X = this.y_pBar;
            clone.plasticCentroidCoordinate.Y = this.x_pBar;
            return clone;
        }

        //public override ISection Clone()
        //{
        //    throw new NotImplementedException();
        //}

        double _Angle_alpha;
        public double Angle_alpha
        {
            get
            {
                return _Angle_alpha;
            }

        }


        double _beta_w;
        public double beta_w
        {
            get
            {
                return _beta_w;
            }
        }

        private AngleOrientation angleOrientation;

        public AngleOrientation AngleOrientation
        {
            get { return angleOrientation; }
            set { angleOrientation = value; }
        }

        private AngleRotation angleRotation;

        public AngleRotation AngleRotation
        {
            get { return angleRotation; }
            set { angleRotation = value; }
        }

        public ISliceableSection GetSliceableShape()
        {
            SectionAngle L = new SectionAngle("", this.d, this.b, this.t, this.AngleRotation, this.AngleOrientation);
            return L;
        }
    }

}
