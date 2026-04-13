using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Study.LabWork1.Features.Task1
{
    public class RationalNumbers
    {
        private int Numerator;
        private int Denominator;


        // конструктор
        public RationalNumbers(int numerator, int denominator)
        {
            
            if (denominator == 0)
            {
                throw new DivideByZeroException("Знаменатель не может быть равен нулю");
            }

            // перевод минуса из знаменателя в числитель
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            int dividor = GetMultipleNumber(Math.Abs(numerator), denominator);
            numerator /= dividor;
            denominator /= dividor;


            Numerator = numerator;
            Denominator = denominator;
        }

        public int GetNumerator()
        {
            return Numerator;
        }
        public int GetDenominator()
        {
            return Denominator;
        }

        public static RationalNumbers operator +(RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static RationalNumbers operator +(RationalNumbers a)
        {
            return new RationalNumbers(+a.Numerator, a.Denominator);
        }

        public static RationalNumbers operator -(RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static RationalNumbers operator -(RationalNumbers a)
        {
            return new RationalNumbers(-a.Numerator, a.Denominator);
        }

        public static RationalNumbers operator *(RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static RationalNumbers operator /(RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static bool operator ==(RationalNumbers a, RationalNumbers b)
        {
            return (a.Numerator == b.Numerator) &&(a.Denominator == b.Denominator);
        }

        public static bool operator !=(RationalNumbers a , RationalNumbers b)
        {
            return !(a == b);
        }

        public static bool operator <(RationalNumbers a, RationalNumbers b)
        {
            return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
        }

        public static bool operator >(RationalNumbers a, RationalNumbers b)
        {
            return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
        }

        public static bool operator <=(RationalNumbers a, RationalNumbers b)
        {
            return a.Numerator * b.Denominator <= b.Numerator * a.Denominator;
        }

        public static bool operator >=(RationalNumbers a, RationalNumbers b)
        {
            return a.Numerator * b.Denominator >= b.Numerator * a.Denominator;
        }

        public override string ToString()
        {
            if (Denominator == 1)
                return Numerator.ToString();

            return $"{Numerator}/{Denominator}";
        }

        public int GetMultipleNumber (int n, int d)
        {
            while (d != 0)
            {
                int tmp = d;
                d = n % d;
                n = tmp;
            }
            return Math.Abs(n);
        }
    }
}
