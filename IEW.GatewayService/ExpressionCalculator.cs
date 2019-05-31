﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace IEW.GatewayService
{
    class ExpressionCalculator
    {
        public string calculate_expression { get; set; }
        public Double a { get; set; }
        public Double b { get; set; }
        public Double c { get; set; }
        public Double d { get; set; }
        public Double e { get; set; }
        public Double f { get; set; }
        public Double g { get; set; }
        public Double h { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Double Evaluate()
        {
            Double douResult = 0;

            //Expression exp = new Expression("Sin(0) + 3 * 5 + Pi");
            Expression exp = new Expression(this.calculate_expression);

            //custom functions
            exp.EvaluateFunction += delegate (string name, FunctionArgs args)
            {
                switch (name)
                {
                    case "avg":
                        args.Result = (int)args.Parameters[0].Evaluate() + (int)args.Parameters[1].Evaluate();
                        break;
                    default:
                        //Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
                        break;
                }
            };

            //custom parameters
            exp.EvaluateParameter += delegate (string name, ParameterArgs args)
            {
                switch (name)
                {
                    case "Pi":
                        args.Result = 3.14;
                        break;
                    case "A":
                        args.Result = this.a;
                        break;
                    case "B":
                        args.Result = this.b;
                        break;
                    case "C":
                        args.Result = this.c;
                        break;
                    case "D":
                        args.Result = this.d;
                        break;
                    case "E":
                        args.Result = this.e;
                        break;
                    case "F":
                        args.Result = this.f;
                        break;
                    case "G":
                        args.Result = this.g;
                        break;
                    case "H":
                        args.Result = this.h;
                        break;
                       
                    default:
                        //Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
                        break;
                }
            };

            try
            {
                Double.TryParse(exp.Evaluate().ToString(), out douResult);
            }
            catch (Exception ex)
            {
                douResult = -1;
            }

            return douResult;

        }
    }
}
