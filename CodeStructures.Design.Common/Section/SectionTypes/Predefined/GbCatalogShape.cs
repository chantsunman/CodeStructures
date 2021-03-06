using CodeStructures.Design.Common.Properties;
using CodeStructures.Design.Common.Reports.Interfaces;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CodeStructures.Design.Common.Section.SectionTypes.Predefined
{
    /// <summary>
    /// This class is used to retrieve the GB shape properies
    /// from GB section database.
    /// </summary>
    public class GbCatalogShape : SectionBase
    {
        public GbCatalogShape(string ShapeName, ICalcLog CalcLog)
            : base(ShapeName)
        {

            if (ShapeName != null)
            {
                bool shapeFound = ReadShapePropertiesInCatalog(ShapeName);
                if (shapeFound == false)
                {
                    throw new Exception("Shape name not found in AISC shape database.");
                }
            }

        }


        private bool ReadShapePropertiesInCatalog(string ShapeName)
        {
            bool ShapeFound = false;
            using (StringReader reader = new StringReader(Resources.GBShapeDatabaseImperial))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] Vals = line.Split(',');
                    if (Vals.Count() == 64)
                    {
                        string thisShapeId = Vals[0];
                        if (thisShapeId == ShapeName)
                        {

                            ShapeId = thisShapeId;
                            string ShapeTypeStr = "ShapeType_" + Vals[1];
                            Type = (GbShapeType)Enum.Parse(typeof(GbShapeType), ShapeTypeStr);
                            W = double.Parse(Vals[2], CultureInfo.InvariantCulture);
                            A = double.Parse(Vals[3], CultureInfo.InvariantCulture);
                            d = double.Parse(Vals[4], CultureInfo.InvariantCulture);
                            Ht = double.Parse(Vals[5], CultureInfo.InvariantCulture);
                            h = double.Parse(Vals[6], CultureInfo.InvariantCulture);
                            OD = double.Parse(Vals[7], CultureInfo.InvariantCulture);
                            bf = double.Parse(Vals[8], CultureInfo.InvariantCulture);
                            B = double.Parse(Vals[9], CultureInfo.InvariantCulture);
                            b = double.Parse(Vals[10], CultureInfo.InvariantCulture);
                            ID = double.Parse(Vals[11], CultureInfo.InvariantCulture);
                            tw = double.Parse(Vals[12], CultureInfo.InvariantCulture);
                            tf = double.Parse(Vals[13], CultureInfo.InvariantCulture);
                            t = double.Parse(Vals[14], CultureInfo.InvariantCulture);
                            tnom = double.Parse(Vals[15], CultureInfo.InvariantCulture);
                            tdes = double.Parse(Vals[16], CultureInfo.InvariantCulture);
                            kdes = double.Parse(Vals[17], CultureInfo.InvariantCulture);
                            x = double.Parse(Vals[18], CultureInfo.InvariantCulture);
                            y = double.Parse(Vals[19], CultureInfo.InvariantCulture);
                            eo = double.Parse(Vals[20], CultureInfo.InvariantCulture);
                            xp = double.Parse(Vals[21], CultureInfo.InvariantCulture);
                            yp = double.Parse(Vals[22], CultureInfo.InvariantCulture);
                            Ix = double.Parse(Vals[23], CultureInfo.InvariantCulture);
                            Zx = double.Parse(Vals[24], CultureInfo.InvariantCulture);
                            Sx = double.Parse(Vals[25], CultureInfo.InvariantCulture);
                            rx = double.Parse(Vals[26], CultureInfo.InvariantCulture);
                            Iy = double.Parse(Vals[27], CultureInfo.InvariantCulture);
                            Zy = double.Parse(Vals[28], CultureInfo.InvariantCulture);
                            Sy = double.Parse(Vals[29], CultureInfo.InvariantCulture);
                            ry = double.Parse(Vals[30], CultureInfo.InvariantCulture);
                            Iz = double.Parse(Vals[31], CultureInfo.InvariantCulture);
                            rz = double.Parse(Vals[32], CultureInfo.InvariantCulture);
                            Sz = double.Parse(Vals[33], CultureInfo.InvariantCulture);
                            J = double.Parse(Vals[34], CultureInfo.InvariantCulture);
                            Cw = double.Parse(Vals[35], CultureInfo.InvariantCulture);
                            C = double.Parse(Vals[36], CultureInfo.InvariantCulture);
                            Wno = double.Parse(Vals[37], CultureInfo.InvariantCulture);
                            Sw1 = double.Parse(Vals[38], CultureInfo.InvariantCulture);
                            Sw2 = double.Parse(Vals[39], CultureInfo.InvariantCulture);
                            Sw3 = double.Parse(Vals[40], CultureInfo.InvariantCulture);
                            Qf = double.Parse(Vals[41], CultureInfo.InvariantCulture);
                            Qw = double.Parse(Vals[42], CultureInfo.InvariantCulture);
                            ro = double.Parse(Vals[43], CultureInfo.InvariantCulture);
                            if (ShapeName.StartsWith("HSS"))
                            {
                                H = Ht;
                            }
                            else
                            {
                                H = double.Parse(Vals[44], CultureInfo.InvariantCulture);
                            }
                            tanAlpha = double.Parse(Vals[45], CultureInfo.InvariantCulture);
                            Qs = double.Parse(Vals[46], CultureInfo.InvariantCulture);
                            Iw = double.Parse(Vals[47], CultureInfo.InvariantCulture);
                            zA = double.Parse(Vals[48], CultureInfo.InvariantCulture);
                            zB = double.Parse(Vals[49], CultureInfo.InvariantCulture);
                            zC = double.Parse(Vals[50], CultureInfo.InvariantCulture);
                            wA = double.Parse(Vals[51], CultureInfo.InvariantCulture);
                            wB = double.Parse(Vals[52], CultureInfo.InvariantCulture);
                            wC = double.Parse(Vals[53], CultureInfo.InvariantCulture);
                            SwA = double.Parse(Vals[54], CultureInfo.InvariantCulture);
                            SwB = double.Parse(Vals[55], CultureInfo.InvariantCulture);
                            SwC = double.Parse(Vals[56], CultureInfo.InvariantCulture);
                            SzA = double.Parse(Vals[57], CultureInfo.InvariantCulture);
                            SzB = double.Parse(Vals[58], CultureInfo.InvariantCulture);
                            SzC = double.Parse(Vals[59], CultureInfo.InvariantCulture);
                            rts = double.Parse(Vals[60], CultureInfo.InvariantCulture);
                            ho = double.Parse(Vals[61], CultureInfo.InvariantCulture);
                            PA = double.Parse(Vals[62], CultureInfo.InvariantCulture);
                            PB = double.Parse(Vals[63], CultureInfo.InvariantCulture);

                            CreateISectionElement(Type);

                            ShapeFound = true;


                        }
                    }
                }

            }
            return ShapeFound;
        }


        private void CreateISectionElement(GbShapeType Type)
        {
            //SectionGenericShape sec = new SectionGenericShape(ShapeId, null); //todo null for vertices needs to be revisited

            base._A = A;
            base._I_x = Ix;
            base._I_y = Iy;
            base._S_x_Top = GetSxTop(Type);
            base._S_xBot = GetSxBot(Type);
            base._S_yLeft = GetSyLeft(Type);
            base._S_yRight = GetSyRight(Type);
            base._Z_x = Zx;
            base._Z_y = Zy;
            base._r_x = rx;
            base._r_y = ry;
            base.elasticCentroidCoordinate.X = x;
            base.elasticCentroidCoordinate.Y = y;
            base.plasticCentroidCoordinate.X = xp;
            base.plasticCentroidCoordinate.Y = yp;
            base._C_w = Cw;
            base._J = J;

        }

        private double GetSyRight(GbShapeType Type)
        {
            double SyRight = Sy;
            if (Type == GbShapeType.ShapeType_L)
            {
                SyRight = Iy / (d - x);
            }
            return SyRight;
        }

        private double GetSyLeft(GbShapeType Type)
        {
            double SyRight = Sy;
            if (Type == GbShapeType.ShapeType_L)
            {
                SyRight = Iy / x;
            }
            return SyRight;
        }

        private double GetSxTop(GbShapeType Type)
        {
            double SxTop = Sx;
            switch (Type)
            {
                case GbShapeType.ShapeType_2L:
                    SxTop = Ix / y;
                    break;
                case GbShapeType.ShapeType_C:
                    break;
                case GbShapeType.ShapeType_HP:
                    break;
                case GbShapeType.ShapeType_HSS:
                    break;
                case GbShapeType.ShapeType_L:
                    SxTop = Ix / (d - y);
                    break;
                case GbShapeType.ShapeType_M:
                    break;
                case GbShapeType.ShapeType_MC:
                    break;
                case GbShapeType.ShapeType_MT:
                    SxTop = Ix / (d - y);
                    break;
                case GbShapeType.ShapeType_PIPE:
                    break;
                case GbShapeType.ShapeType_S:
                    break;
                case GbShapeType.ShapeType_ST:
                    SxTop = Ix / (d - y);
                    break;
                case GbShapeType.ShapeType_W:
                    break;
                case GbShapeType.ShapeType_WT:
                    SxTop = Ix / (d - y);
                    break;
                default:
                    break;
            }
            return SxTop;
        }


        private double GetSxBot(GbShapeType Type)
        {
            double SxBot = Sx;
            switch (Type)
            {
                case GbShapeType.ShapeType_2L:
                    if (ShapeId.Contains("SLBB"))
                    {
                        SxBot = Ix / (d - y);
                    }
                    else if (ShapeId.Contains("LLBB"))
                    {
                        SxBot = Ix / (b - y);
                    }
                    else
                    {
                        SxBot = Ix / (d - y);
                    }

                    break;
                case GbShapeType.ShapeType_C:
                    break;
                case GbShapeType.ShapeType_HP:
                    break;
                case GbShapeType.ShapeType_HSS:
                    break;
                case GbShapeType.ShapeType_L:
                    SxBot = Ix / (y);
                    break;
                case GbShapeType.ShapeType_M:
                    break;
                case GbShapeType.ShapeType_MC:
                    break;
                case GbShapeType.ShapeType_MT:
                    SxBot = Ix / (d - y);
                    break;
                case GbShapeType.ShapeType_PIPE:
                    break;
                case GbShapeType.ShapeType_S:
                    break;
                case GbShapeType.ShapeType_ST:
                    SxBot = Ix / (d - y);
                    break;
                case GbShapeType.ShapeType_W:
                    break;
                case GbShapeType.ShapeType_WT:
                    SxBot = Ix / (d - y);
                    break;
                default:
                    break;
            }
            return SxBot;
        }


        public string ShapeId { get; set; }
        public GbShapeType Type { get; set; }
        public double W { get; set; }
        public double A { get; set; }
        public double d { get; set; }
        public double Ht { get; set; }
        public double h { get; set; }
        public double OD { get; set; }
        public double bf { get; set; }
        public double B { get; set; }
        public double b { get; set; }
        public double ID { get; set; }
        public double tw { get; set; }
        public double tf { get; set; }
        public double t { get; set; }
        public double tnom { get; set; }
        public double tdes { get; set; }
        public double kdes { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double eo { get; set; }
        public double xp { get; set; }
        public double yp { get; set; }
        public double Ix { get; set; }
        public double Zx { get; set; }
        public double Sx { get; set; }
        public double rx { get; set; }
        public double Iy { get; set; }
        public double Zy { get; set; }
        public double Sy { get; set; }
        public double ry { get; set; }
        public double Iz { get; set; }
        public double rz { get; set; }
        public double Sz { get; set; }
        public double J { get; set; }
        public double Cw { get; set; }
        public double C { get; set; }
        public double Wno { get; set; }
        public double Sw1 { get; set; }
        public double Sw2 { get; set; }
        public double Sw3 { get; set; }
        public double Qf { get; set; }
        public double Qw { get; set; }
        public double ro { get; set; }
        public double H { get; set; }
        public double tanAlpha { get; set; }
        public double Qs { get; set; }
        public double Iw { get; set; }
        public double zA { get; set; }
        public double zB { get; set; }
        public double zC { get; set; }
        public double wA { get; set; }
        public double wB { get; set; }
        public double wC { get; set; }
        public double SwA { get; set; }
        public double SwB { get; set; }
        public double SwC { get; set; }
        public double SzA { get; set; }
        public double SzB { get; set; }
        public double SzC { get; set; }
        public double rts { get; set; }
        public double ho { get; set; }
        public double PA { get; set; }
        public double PB { get; set; }

        bool detailingParametersAvailable;
        private double _T;

        public double T
        {
            get
            {
                if (detailingParametersAvailable == false)
                {
                    ReadDetailingParameters();
                }
                return _T;
            }
            set { _T = value; }
        }

        private double _k_det;

        public double k_det
        {
            get
            {
                if (detailingParametersAvailable == false)
                {
                    ReadDetailingParameters();
                }
                return _k_det;
            }
            set { _k_det = value; }
        }

        private double _WG;

        public double WG
        {
            get
            {
                if (detailingParametersAvailable == false)
                {
                    ReadDetailingParameters();
                }
                return _WG;
            }
            set { _WG = value; }
        }

        private void ReadDetailingParameters()
        {
            using (StringReader reader = new StringReader(Resources.GBShapeDatabaseDetailingImperial))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] Vals = line.Split(',');
                    if (Vals.Count() == 4)
                    {
                        string thisShapeId = Vals[0];
                        double WG_ = double.Parse(Vals[1], CultureInfo.InvariantCulture);
                        double T_ = double.Parse(Vals[2], CultureInfo.InvariantCulture);
                        double k_det_ = double.Parse(Vals[3], CultureInfo.InvariantCulture);

                        if (thisShapeId == base.Name)
                        {

                            WG = WG_;
                            T = T_;
                            k_det = k_det_;
                        }
                    }
                }
            }
            detailingParametersAvailable = true;
        }
    }

}
