using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RecursiveDrawings
{
    class Vector
    {
        private PointF _begin;
        private PointF _end;

        public Vector(PointF begin, PointF end)
        {
            _begin = begin;
            _end = end;
        }

        public PointF Begin
        {
            get
            {
                return _begin;
            }

            set
            {
                _begin = value;
            }
        }

        public PointF End
        {
            get
            {
                return _end;
            }

            set
            {
                _end = value;
            }
        }

        public float Length
        {
            get
            {
                return (float)Math.Sqrt(Math.Pow(_end.X - _begin.X, 2) + Math.Pow(_end.Y - _begin.Y, 2));
            }
        }

        public float Angle
        {
        get
            {
                float angle;
                if (_end.X == _begin.X)
                {
                    angle = Math.Sign(_end.Y - _begin.Y) * (float)Math.PI / 2;
                }
                else
                {
                    angle = (float)Math.Atan((_end.Y - _begin.Y) / (_end.X - _begin.X));
                    if (_begin.X > _end.X)
                    {
                        if (_begin.Y == _end.Y)
                        {
                            angle += (float)Math.PI;
                        }
                        else
                        {
                            angle += (float)Math.PI * Math.Sign(_end.Y - _begin.Y);
                        }
                    }
                }
                return angle;
            }
        }

        public float SinAngle
        {
        get
            {
                return (_end.Y - _begin.Y) / this.Length;
            }
        }

        public float CosAngle
        {
            get
            {
                return (_end.X - _begin.X) / this.Length;
            }
        }

        public void Reverse()
        {
            PointF buf = _end;
            _end = _begin;
            _begin = buf;
        }


    }
}
