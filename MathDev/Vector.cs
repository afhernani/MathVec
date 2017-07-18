using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;

namespace MathDev
{
    //implementation of a 2-D vector
    public struct Vector2
    {
        public static Vector2 Empty;
        public float X, Y;
        #region constructores
        /// <summary>
        /// constructor por defecto para la estructura
        /// del vector vacio, Empty
        /// </summary>
        static Vector2()
        {
            Empty = new Vector2();
            Empty.X = float.NaN;
            Empty.Y = float.NaN;
        }
        public Vector2(Vector2 v)
        {
            X = v.X;
            Y = v.Y;
        }
        public Vector2(float a)
        {
            X = a;
            Y = a;
        }

        public Vector2(float a, float b)
        {
            X = a;
            Y = b;
        }

        //public Vector2(PointF input)
        //{
        //    X = input.X;
        //    Y = input.Y;
        //}
        #endregion constructores
        /// <summary>
        /// true si es un vector vacion Empty
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return (float.IsNaN(X) && float.IsNaN(Y));
            }
        }
        /// <summary>
        /// Devuelve true si los vectores son distintos.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left == right);
        }
        /// <summary>
        /// Devuelve true si los dos vectores son iguales.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Vector2 left, Vector2 right)
        {
            if (SameDirection(left, right)) return sameLength(left, right);
            if (left.IsEmpty && right.IsEmpty) return true;
            return false;
        }
        /// <summary>
        /// siempre devuelve falso si los vectores no tienen
        /// la misma dirección y sentido.
        /// Si tienen la misma direccion, compara los modulos.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator < (Vector2 left, Vector2 right)
        {
            if(SameDirection(left, right)) return left.Length() < right.Length();
            if (left.IsEmpty && right.IsEmpty) return true;
            return false;
        }
        /// <summary>
        /// siempre devuelve falso si los vectores no tienen
        /// la misma dirección y sentido.
        /// Si tienen la misma direccion, compara los modulos.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Vector2 left, Vector2 right)
        {
            if (SameDirection(left, right)) return left.Length() > right.Length();
            if (left.IsEmpty && right.IsEmpty) return true;
            return false;
        }
        /// <summary>
        /// comprueba si es el mismo objeto
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector2) return (this == (Vector2)obj);
            return false;
        }
        /// <summary>
        /// Devuelve la cadena que representa el vector.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{{X={0}, Y={1}}}", XmlConvert.ToString(Math.Round(X, 8)), XmlConvert.ToString(Math.Round(Y, 8)));
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Devuelve el modulo o longitud del vector.
        /// </summary>
        /// <returns></returns>
        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }
        /// <summary>
        /// modulo o longitud del vector pasado por referencia
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static double Length(Vector2 v1)
        {
            return Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y);
        }
        /// <summary>
        /// devuelve el vector unitario con el mismo signo.
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static Vector2 Unidad(Vector2 v1)
        {
            int x1 = Math.Sign(v1.X);
            int y1 = Math.Sign(v1.Y);
            return new Vector2(x1, y1);
        }
        /// <summary>
        /// devuelve el vector unitario del vector pasado como referencia
        /// (no el vector unidad).
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
                       
        public static Vector2 Normalize(Vector2 v1)
        {
            double length = Vector2.Length(v1);
            if (length != 0)
            {
                return new Vector2((float)(v1.X / Vector2.Length(v1)), (float)(v1.Y / Vector2.Length(v1)));
            }
            else
            {
                return new Vector2((float)(v1.X / 1), (float)(v1.Y / 1));
            }
        }
        /// <summary>
        /// calcula el vector unitario
        /// (no el vector unidad)
        /// </summary>
        public void Normalize()
        {
            this.X = (float)(this.X / Vector2.Length(this));
            this.Y = (float)(this.Y / Vector2.Length(this));
        }
        /// <summary>
        /// funcion suma.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector2 Add(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }
        /// <summary>
        /// función diferencia.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector2 Subtract(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }
        /// <summary>
        /// calcula es producto vectorial.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float Dot(Vector2 v1, Vector2 v2)
        {
            return (v1.X * v2.X + v1.Y * v2.Y);
        }
        #region nuevo

        /// <summary>
        /// Devuelve el Angulo en radianes entre dos vectores, 
        /// si no existe devuelve un valor vacio NaN.
        /// comprobacion double.isNaN(Devuelto).
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static double AngR_V1r(Vector2 v1, Vector2 r)
        {
            double v1pr = Vector2.Dot(v1, r);
            double v1r = Vector2.Length(v1) * Vector2.Length(r);
            if(v1r != 0) return Math.Acos(v1pr / v1r);
            return double.NaN;
        }

        /// <summary>
        /// Devuelve el Angulo en Grados entre dos vectores, 
        /// si no existe devuelve un valor vacio NaN.
        /// comprobacion double.isNaN(Devuelto).
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static float AngG_V1r(Vector2 v1, Vector2 r)
        {
            double res = AngR_V1r(v1, r);
            if (double.IsNaN(res)) return float.NaN;
            return (float)(res * 180 / Math.PI);
        }
        /// <summary>
        /// Devuelve true si los dos vectores tienen el mismo modulo.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool sameLength(Vector2 A, Vector2 B)
        {
            return (A.Length() == B.Length());
        }
        /// <summary>
        /// Devuelve true si los dos vectores tienen la misma direccion
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool SameDirection(Vector2 A, Vector2 B)
        {
            return AngR_V1r(A, B) == 0;
        }

        #endregion nuevo


        /// <summary>
        /// Comprueba si los dos parametros del vector tienen el mismo signo.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool Sign(Vector2 v1, Vector2 v2)
        {
            if (Math.Sign(v1.X) == Math.Sign(v2.X))
            {
                if (Math.Sign(v1.Y) == Math.Sign(v2.Y)) return true;
            }
            return false;
        }
        /// <summary>
        /// función multiplicacion
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector2 Multiply(Vector2 v1, float v2)
        {
            return new Vector2(v1.X * v2, v1.Y * v2);
        }
        /// <summary>
        /// operador sobrecargado suma vector escalar entero
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vector2 operator +(Vector2 v1, int a)
        {
            return new Vector2(v1.X + a, v1.Y + a);
        }
        public static Vector2 operator -(Vector2 v1, Vector2 a)
        {
            return new Vector2(v1.X - a.X, v1.Y - a.Y);
        }
        public static Vector2 operator +(Vector2 v1, Vector2 a)
        {
            return new Vector2(v1.X + a.X, v1.Y + a.Y);
        }
        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X * v2.X, v1.Y * v2.Y);
        }
        public static Vector2 operator *(Vector2 v1, int a)
        {
            return new Vector2(v1.X * a, v1.Y * a);
        }

        public static Vector2 operator *(Vector2 v1, float a)
        {
            return new Vector2(v1.X * a, v1.Y * a);
        }
        public static Vector2 operator /(Vector2 v1, int a)
        {
            if (a != 0)
            {
                return new Vector2(v1.X / a, v1.Y / a);
            }
            else
                return v1;
        }

        public static Vector2 operator /(Vector2 v1, float a)
        {
            if (a != 0)
                return new Vector2(v1.X / a, v1.Y / a);
            else
                return v1;
        }

        public static Vector2 operator /(Vector2 v1, double a)
        {
            if (a != 0)
                return new Vector2((float)(v1.X / a), (float)(v1.Y / a));
            else
                return v1;
        }

        internal static Vector2 Truncate(Vector2 vec, float max_value)
        {
            if (vec.Length() > max_value)
            {
                return Vector2.Multiply(Vector2.Normalize(vec), max_value);
            }
            return vec;
        }
    }
}
