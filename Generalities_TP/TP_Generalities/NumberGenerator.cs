using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_Generalities
{
    class NumberGenerator : IRandomizable
    {
        public event EventHandler upperNumberIsNotANumber;

        public NumberGenerator()
        {
            upperNumberIsNotANumber += (sender, e) => { };
        }

        public string GetRandomNumber(string input)
        {
            double upperNumber = -1;
            if (!double.TryParse(input, out upperNumber))
            {
                NumberGeneratorEvenArgs args = new NumberGeneratorEvenArgs();
                args.Input = input;
                upperNumberIsNotANumber(this, args);
                return "Not a number";
            }
            return (new Random().NextDouble()*upperNumber).ToString();
        }
    }
}
