﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace EECT.ElectricalCalculations
{
    public class PowerCalc : IPowerCalc
    {
        //public IPowerCalc PC { get; set; }

        //public PowerCalc(IPowerCalculations pwc)
        //{
        //    PC = pwc;
        //}

        public double Power(double current, double voltage, double phases)
        {
            return Math.Sqrt(phases) * current * voltage;
        }

        public double Current(double voltage, double power, double phases)
        {
            return power / (Math.Sqrt(phases) * voltage);
        }
        
        public double Voltage(double current, double power, double phases)
        {
            return power / (Math.Sqrt(phases) * current);
        }

        public double Ik(double voltage, Complex Z)
        {
            return voltage / (Math.Sqrt(3) * Z.Magnitude);
        }

        public double Zk3p(double voltage, double Ik, double Ek)
        {
            return voltage / (Ik * Math.Sqrt(3));
        }

        public double Xk3p(double voltage, double S, double Ex)
        {
            return Math.Pow(voltage,2) / (S / Ex);
        }

        public double Rk3p(double voltage, double S, double Er)
        {
            return (voltage * voltage) / (S / Er);
        }

        public double CosPhi(double Er, double Ek)
        {
            return Er / Ek;
        }

        public double Ex(double Ek)
        {
            return Math.Sqrt(Math.Pow(Ek, 2) - Math.Pow(0.01,2));
        }

        public Complex Z3p(double R3p, double X3p)
        {
            return new Complex(R3p, X3p);
        }

        public Complex Z2p(double R2p, double X2p)
        {
            return new Complex(R2p * 2, X2p * 2);
        }

        public Complex Z3Phase1polePE(double R, double X, double R0pen, double X0pen)
        {
            var CablePart = new Complex(R * 2, X * 2);
            var PENPart = new Complex(R0pen, X0pen);

            return CablePart + PENPart;
        }

        public Complex Z1Phase1PolePE(double RphasePEN, double XphasePEN)
        {
            return new Complex(3 * RphasePEN, 3 * XphasePEN);
        }

        public Complex SumImpedances(Complex[] Z)
        {
            Complex sum = 0;

            foreach (var Impedance in Z)
            {
                sum = sum + Impedance;
            }

            return sum;
        }

        public double SumSk(double[] Sk)
        {
            double sum = 0;

            foreach (var S in Sk)
            {
                sum = (1 / sum) + (1 / S);
            }

            return sum;
        }
    }
}