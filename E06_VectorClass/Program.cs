﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E06_VectorClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector v0 = new Vector(1, 2, 3);
            Vector v1 = new Vector(3, 4, 0); //345 pythagorama
            Console.WriteLine($"v0: {v0}");
            Console.WriteLine($"v1: {v1}");

            Vector zero = new Vector();
            Console.WriteLine($"zero {zero}");

            Vector copyOfV1 = new Vector(v1);
            Console.WriteLine($"copy of v1: {copyOfV1}");

            Console.WriteLine($"v0 length: {v0.Length}, v1 length: {v1.Length}");

            v1.Reverse();
            Console.WriteLine($"v1: {v1}");

            v1.Scale(0.5);
            Console.WriteLine($"v1 length: {v1.Length}");

            v1.Unitize();
            Console.WriteLine($"v1 unitized length: {v1.Length}");
            Console.WriteLine($"v1 unitized: {v1}");
            if (v1.Unitize() == true) { Console.WriteLine("unitized"); } else { Console.WriteLine("unitize failure"); }
            
            zero.Unitize();
            Console.WriteLine($"zero unitized length: {zero.Length}");
            Console.WriteLine($"zero unitized: {zero}");
            if (zero.Unitize() == true) { Console.WriteLine("unitized"); } else { Console.WriteLine("unitize failure"); }


            Vector v2 = Vector.Addition(v0, v1);
            Console.WriteLine($"{v0} + {v1} = {v2}");

            Console.WriteLine($"dot product of ({v0}) and ({v1}) is: ({Vector.DotProduct(v0, v1)})");

            Vector vx = new Vector(Vector.XAxis);
            Vector vy = new Vector(Vector.YAxis);
            Vector vz = new Vector(Vector.ZAxis);
            Vector cross = Vector.CrossProduct(vx, vy);
            Console.WriteLine($"cross product of ({vx}) and ({vy}) is: ({cross})");

            Console.WriteLine($"VECTOR ADDITION ({v0}) + ({v1}): ({v0 + v1})");
            Console.WriteLine($"DOT PRODUCT ({v0}) x ({v1}): ({v0 * v1})");

            Vector v0x2 = v0 * 2;
            Console.WriteLine($"VECTOR MULTIPLICATION ({v0}) x 2: ({v0x2})");

            Console.WriteLine($"the X of vector v0 is: {v0[0]}");
            Console.WriteLine($"the Y of vector v0 is: {v0[1]}");
            Console.WriteLine($"the Z of vector v0 is: {v0[2]}");

            v0[0] = 9;
            Console.WriteLine($"change the X of v0 to 9: {v0}");


            Console.ReadKey();
        }
    }

    /// <summary>
    /// Represents a 3 dimensional vector
    /// </summary>
    public class Vector
    {
        //properties - belong to the intance of this class

        /// <summary>
        /// X coordinate
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Y coordinate
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Z coordinate
        /// </summary>
        public double Z { get; set; }
        /// <summary>
        /// Get length of vector
        /// </summary>
        public double Length { get => GetLength(); }

        //indexer
        /// <summary>
        /// Ge or set vector by index value 0,1,2 == X,Y,Z
        /// </summary>
        /// <param name="i">0,1,2 represents X,Y,Z</param>
        /// <returns></returns>
        public double this[int i]
        {
            get
            {
                if (i == 0) { return this.X; } 
                else if (i == 1) { return this.Y; }
                else if (i == 2) { return this.Z; }
                throw new Exception(); //in case of a condition not shown above
            }
            set
            {
                if (i == 0) { this.X = value; }
                else if (i == 1) { this.Y = value; }
                else if (i == 2) { this.Z = value; }
                else { throw new Exception(); }
            }
        }

        //static properties
        /// <summary>
        /// Create a new unit Vector in the X direction
        /// </summary>
        public static Vector XAxis { get => new Vector(1, 0, 0); }
        /// <summary>
        /// Create a new unit Vector in the Y direction
        /// </summary>
        public static Vector YAxis { get => new Vector(0, 1, 0); }
        /// <summary>
        /// Create a new unit Vector in the Z direction
        /// </summary>
        public static Vector ZAxis { get => new Vector(0, 0, 1); }

        //constructors
        /// <summary>
        /// Default Vector is 0,0,0
        /// </summary>
        public Vector()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }
        /// <summary>
        /// Create a new vector with X, Y, Z values
        /// </summary>
        /// <param name="x">X direction value</param>
        /// <param name="y">Y direction value</param>
        /// <param name="z">Z direction value</param>
        public Vector(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        /// <summary>
        /// Create a new Vector that is a copy of an existing Vector
        /// </summary>
        /// <param name="other">Vector that is being copied</param>
        public Vector(Vector other)
        {
            this.X = other.X;
            this.Y = other.Y;
            this.Z = other.Z;
        }

        //methods
        /// <summary>
        /// Calculate the length of a Vector
        /// </summary>
        /// <returns>Calculated length using pythagorean method SQRT(X^2+Y^2+Z^2)</returns>
        private double GetLength()
        {
            double sq1 = this.X * this.X + this.Y * this.Y + this.Z * this.Z;
            return Math.Sqrt(sq1);
        }
        /// <summary>
        /// Reverse a Vector (negative value of X,Y,Z)
        /// </summary>
        public void Reverse()
        {
            this.X = -this.X;
            this.Y = -this.Y;
            this.Z = -this.Z;
        }
        /// <summary>
        /// Scale a Vector's X,Y,Z by a factor
        /// </summary>
        /// <param name="factor">Multiplication factor to scale X,Y,Z</param>
        public void Scale(double factor)
        {
            this.X *= factor;
            this.Y *= factor;
            this.Z *= factor;
        }
        /// <summary>
        /// Unitize a Vector
        /// </summary>
        /// <returns>Divide a Vector by its length to unitize, returns unitized Vector</returns>
        public bool Unitize()
        {
            double length = this.GetLength();
            if (length <= 0) { return false; }
            this.X /= length;
            this.Y /= length;
            this.Z /= length;
            return true;
        }
        /// <summary>
        /// Add two vectors together, one is the base method and one is the parameter
        /// </summary>
        /// <param name="other">Name of second vector for addition function</param>
        public void Add(Vector other)
        {
            this.X += other.X;
            this.Y += other.Y;
            this.Z += other.Z;
        }

        //operator overloads
        /// <summary>
        /// Add two Vectors together by overloading the + symbol
        /// </summary>
        /// <param name="a">First of two Vectors to be added</param>
        /// <param name="b">Second of two Vectors to be added</param>
        /// <returns>New Vector - Value of both vectors added</returns>
        public static Vector operator +(Vector a, Vector b) => Vector.Addition(a, b);
        /// <summary>
        /// Multliply two Vectors by overloading the * symbol (Same as a DotProduct)
        /// </summary>
        /// <param name="a">First of two vectors to be multiplied</param>
        /// <param name="b">Second of two vectors to be multiplied</param>
        /// <returns>New Vector - Dot Product of the two multiplied Vectors</returns>
        public static double operator *(Vector a, Vector b) => Vector.DotProduct(a, b);
        /// <summary>
        /// Multiply a Vector and a number
        /// </summary>
        /// <param name="a">Vector to be multiplied</param>
        /// <param name="b">Number to multiply the vector</param>
        /// <returns>New Vector</returns>
        public static Vector operator *(Vector a, double b)
        {
            Vector v = new Vector(a);
            v.Scale(b);
            return v;
        }

        //static methods
        /// <summary>
        /// Add two vectors together
        /// </summary>
        /// <param name="a">First of two vectors for addition</param>
        /// <param name="b">Second of two vectors for addition</param>
        /// <returns>New Vector</returns>
        public static Vector Addition(Vector a, Vector b)
        {
            double newX = a.X + b.X;
            double newY = a.Y + b.Y;
            double newZ = a.Z + b.Z;
            Vector v = new Vector(newX, newY, newZ);
            return v;
        }
        /// <summary>
        /// Dot Product of two vectors
        /// </summary>
        /// <param name="a">First of two vectors to be multiplied</param>
        /// <param name="b">Second of two vectors to be multiplied</param>
        /// <returns>New Vector - Dot Product of two vectors</returns>
        public static double DotProduct(Vector a, Vector b) =>  a.X * b.X + a.Y * b.Y + a.Z * b.Z; 
        /// <summary>
        /// Cross Product of two vectors
        /// </summary>
        /// <param name="a">First of two vectors</param>
        /// <param name="b">Second of two vectors</param>
        /// <returns>New Vector - Cross Product of two vectors</returns>
        public static Vector CrossProduct(Vector a, Vector b)
        {
            double x = a.Y * b.Z - a.Z * b.Y;
            double y = a.Z * b.X - a.X * b.Z;
            double z = a.X * b.Y - a.Y * b.X;
            return new Vector(x, y, z);
        }

        //overrides
        /// <summary>
        /// Overrides ToString to serialize the vector into X,Y,Z values
        /// </summary>
        /// <returns>X,Y,Z values of the vector</returns>
        public override string ToString() => $"{this.X}, {this.Y}, {this.Z}";
    }
}
