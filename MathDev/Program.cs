using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MathDev
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("salida: ");
            Console.Out.WriteLine("Datos del programa ...\nCreamos dos vectores:");
            Vector2 a = new Vector2(2, 3);
            Console.WriteLine("Vector a: "+a.ToString());
            Vector2 b = new Vector2(4, 6);
            Console.WriteLine("Vector b: "+b.ToString());
            Vector2 x = new Vector2(-1, 0);
            Vector2 y = new Vector2(0, 1);
            Console.WriteLine("vector x ="+x.ToString()+", vector y ="+ y.ToString());
            Console.WriteLine("xx -- xx");
            double s = Vector2.Dot(a, x);
            double r = a.Length() * x.Length();
            Console.WriteLine(s.ToString() + " / "+ r.ToString());
            double ang = Math.Acos(s / r);
            Console.WriteLine("Angulo del coseno ="+ang.ToString()+" radianes");
            double angG = ang * 180 / Math.PI;
            Console.WriteLine("Angulo del coseno ="+angG.ToString()+" Grados.");
            Console.WriteLine("Angulo en grados del vector a - x: "+Vector2.AngG_V1r(a,x).ToString());
            Console.WriteLine("Angulo en grados del vector b - x: "+Vector2.AngG_V1r(b,x).ToString());

            Console.WriteLine("Angulo en grados del vector a - b: "+Vector2.AngG_V1r(a, b).ToString());
            Vector2 n = new Vector2(0, 0);
            Console.WriteLine("Vector nulo n = "+n.ToString());
            Console.WriteLine("Angulo en grados del vector a - n: "+Vector2.AngG_V1r(a,n).ToString());
            Vector2 na = new Vector2(1, 1);
            Console.WriteLine("Vector na = "+na.ToString());
            Console.WriteLine("Angulo en grados del vector a - na: "+Vector2.AngG_V1r(a, na).ToString());
            Console.WriteLine("Angulo en grados del vector na - x: "+Vector2.AngG_V1r(na, x).ToString());
            Console.WriteLine("XXXXXXXXXXXXX");
            Console.WriteLine("Angulo en grados del vector a - y: "+Vector2.AngG_V1r(a, y).ToString());
            
            // analisis de vectores.

            Console.WriteLine("Analisis vectorial de igualdad:  \n");
            a = new Vector2(6, -9);
            Console.WriteLine("vector A = "+a.ToString());
            b = new Vector2(2, 3);
            Console.WriteLine("vector B = "+b.ToString());
            //calculamos el vector suma.
            Vector2 rs = a+b;
            Console.WriteLine("suma vectorial R = A + B = "+rs.ToString());
            double alfa = Vector2.AngR_V1r(rs, a);
            double sigma = Vector2.AngR_V1r(b, a);
            double beta = Vector2.AngR_V1r(b, rs);
            string res= string.Format("{{Alfa={0}, Sigma={1}, Beta={2}}}", XmlConvert.ToString(Math.Round(alfa, 4)),
                XmlConvert.ToString(Math.Round(sigma, 4)), XmlConvert.ToString(Math.Round(beta, 4)));
            Console.WriteLine(res);
            //analizamos los senos.
            double senalfa = Math.Sin(alfa);
            double sensigma = Math.Sin(sigma);
            double senbeta = Math.Sin(beta);
            res = string.Format("{{sinAlfa={0}, sinSigma={1}, sinBeta={2}}}", XmlConvert.ToString(Math.Round(senalfa, 4)), 
                XmlConvert.ToString(Math.Round(sensigma, 4)), XmlConvert.ToString(Math.Round(senbeta, 4)));
            Console.Out.WriteLine(res);
            double rsR = rs.Length() / sensigma;
            double rsB = b.Length() / senalfa;
            double rsA = a.Length() / senbeta;
            res = string.Format("{{R={0}, A={1}, B={2}}}", XmlConvert.ToString(Math.Round(rsR, 4)), XmlConvert.ToString(Math.Round(rsA, 4)), XmlConvert.ToString(Math.Round(rsB, 4)));
            Console.WriteLine(res);
            //mediante la formula
            if (Vector2.SameDirection(b, a)) Console.WriteLine("tienen la misma direccion");
            else Console.WriteLine("tienen direcciones opuestas.");
            if (a == b) Console.WriteLine("los vectores a y b son iguales");
            else Console.WriteLine("los vectores a y b son distintos");
            //la misma cosa porque no cumple la primera condicion de los vectores
            //para con su dirección.
            if (a > b) Console.WriteLine("el vector a es mayor al vector b");
            else Console.WriteLine("el vector a es menor al vector b");
            if (a < b) Console.WriteLine("el vector a es menor al vector b");
            else Console.WriteLine("el vector a es mayor al vector b");
            Console.Read();
            
        }
    }
}
