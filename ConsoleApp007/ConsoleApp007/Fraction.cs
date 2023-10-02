using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp007
{
    internal class Fraction
    {
        private int _numerator;
        private int _denominator;

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public int Numerator { get => _numerator; set => _numerator = value; }
        public int Denominator
        {
            get => _denominator; set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator CANNOT be zero.");
                }
                _denominator = value;
            }
        }
        public int LCD(int number, int numner2)
        {
            int divided;
            int remainder = 1;
            int temp;
            int tam = 0;
            if (number > numner2)
            {
                divided = number;
                temp = numner2;
            }
            else
            {
                divided = numner2;
                temp = number;
            }
            tam = divided / temp;
            remainder = divided - (temp * tam);
            while (remainder > 0)
            {
                tam = temp / remainder;
                int save = remainder;
                remainder = temp - (remainder * tam);
                temp = save;
            }
            return temp;
        }
        public Fraction FractionSimplifier()
        {
            int suret = Numerator;
            int mexrec = Denominator;
            Fraction frac = new(1, 1);
            if (suret == mexrec) return frac;
            else if (suret % mexrec == 0 || mexrec == 1)
            {
                suret /= mexrec;
                frac.Numerator = suret;
                frac.Denominator = mexrec;
                Console.WriteLine(suret);
                return frac;
            }
            else if (mexrec % suret == 0)
            {
                mexrec /= suret;
                suret /= suret;
                frac.Numerator = suret;
                frac.Denominator = mexrec;
                return frac;
            }
            else
            {
                int temp = LCD(suret, mexrec);

                if (temp == 1)
                {
                    frac.Denominator = suret;
                    frac.Denominator = mexrec;
                    return frac;
                }
                else
                {
                    suret /= temp;
                    mexrec /= temp;
                    frac.Numerator = suret;
                    frac.Denominator = mexrec;
                    return frac;
                }

            }

        }
        public static Fraction operator +(Fraction frac_1, Fraction frac_2)
        {
            int suret_1 = frac_1.Numerator;
            int mexrec_1 = frac_1.Denominator;
            int suret_2 = frac_2.Numerator;
            int mexrec_2 = frac_2.Denominator;
            if (mexrec_1 == mexrec_2)
            {
                mexrec_1 = mexrec_2;
            }
            else if (mexrec_1 % mexrec_2 == 0)
            {
                int temp = mexrec_1 / mexrec_2;
                mexrec_2 *= temp;
                suret_2 *= temp;
            }
            else if (mexrec_2 % mexrec_1 == 0)
            {
                int temp = mexrec_2 / mexrec_1;
                mexrec_1 *= temp;
                suret_1 *= temp;
            }
            else
            {
                int temp = mexrec_2;
                suret_1 *= mexrec_2;
                suret_2 *= mexrec_1;
                mexrec_2 *= mexrec_1;
                mexrec_1 *= temp;
            }
            frac_1.Numerator = suret_1;
            frac_1.Denominator = mexrec_1;
            frac_2.Numerator = suret_2;
            frac_2.Denominator = mexrec_2;
            Fraction frac = new((suret_1 + suret_2), (mexrec_1));
            if (frac.Numerator % frac.Denominator==0)
                frac = frac.FractionSimplifier();
            return frac;
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            int suret_1 = fraction1.Numerator;
            int mexrec_1 = fraction1.Denominator;
            int suret_2 = fraction2.Numerator;
            int mexrec_2 = fraction2.Denominator;
            if (mexrec_1 % mexrec_2 == 0)
            {
                int temp = mexrec_1 / mexrec_2;
                mexrec_2 *= temp;
                suret_2 *= temp;
            }
            else if (mexrec_2 % mexrec_1 == 0)
            {
                int temp = mexrec_2 / mexrec_1;
                mexrec_1 *= temp;
                suret_1 *= temp;
            }
            else
            {
                int temp = mexrec_2;
                suret_1 *= mexrec_2;
                suret_2 *= mexrec_1;
                mexrec_2 *= mexrec_1;
                mexrec_1 *= temp;
            }
            fraction1.Numerator = suret_1;
            fraction1.Denominator = mexrec_1;
            fraction2.Numerator = suret_2;
            fraction2.Denominator = mexrec_2;
            Fraction result = new((suret_1 - suret_2), (mexrec_1));
            if (result.Numerator % result.Denominator == 0)
                result = result.FractionSimplifier();
            return result;

        }

        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            int suret_1 = fraction1.Numerator;
            int mexrec_1 = fraction1.Denominator;
            int suret_2 = fraction2.Numerator;
            int mexrec_2 = fraction2.Denominator;
            if (suret_1 % mexrec_2 == 0)
            {
                suret_1 /= mexrec_2;
                mexrec_2 /= mexrec_2;
            }
            else if (mexrec_2 % suret_1 == 0)
            {
                mexrec_2 /= suret_1;
                suret_1 /= suret_1;
            }
            if (suret_2 % mexrec_1 == 0)
            {
                suret_2 /= mexrec_1;
                mexrec_1 /= mexrec_1;
            }
            else if (mexrec_1 % suret_2 == 0)
            {
                mexrec_1 /= suret_2;
                suret_2 /= suret_2;
            }
            fraction1.Numerator = suret_1;
            fraction1.Denominator = mexrec_1;
            fraction2.Numerator = suret_2;
            fraction2.Denominator = mexrec_2;
            Fraction result = new((suret_1 * suret_2), (mexrec_1 * mexrec_2));
            if (result.Numerator % result.Denominator == 0)
                result = result.FractionSimplifier();
            return result;
        }

        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            int suret_1 = fraction1.Numerator;
            int mexrec_1 = fraction1.Denominator;
            int suret_2 = fraction2.Numerator;
            int mexrec_2 = fraction2.Denominator;
            if (suret_1 % suret_2 == 0)
            {
                suret_1 /= suret_2;
                suret_2 /= suret_2;
            }
            else if (suret_2 % suret_1 == 0)
            {
                suret_2 /= suret_1;
                suret_1 /= suret_1;
            }
            if (mexrec_2 % mexrec_1 == 0)
            {
                mexrec_2 /= mexrec_1;
                mexrec_1 /= mexrec_1;
            }
            else if (mexrec_1 % mexrec_2 == 0)
            {
                mexrec_1 /= mexrec_2;
                mexrec_2 /= mexrec_2;
            }
            fraction1.Numerator = suret_1;
            fraction1.Denominator = mexrec_1;
            fraction2.Numerator = suret_2;
            fraction2.Denominator = mexrec_2;
            Fraction result = new((suret_1 * mexrec_2), (suret_2 * mexrec_1));
            if (result.Numerator % result.Denominator == 0)
                result = result.FractionSimplifier();
            return result;
        }


        public override string ToString() => $"{Numerator} / {_denominator}";
    }
}
