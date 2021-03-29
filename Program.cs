using System;

namespace SimpleBoxModel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define all variables
            int outInt = 0;
            double outDouble = 0;
            double totalMass = 0;
            double totalFlow = 0;
            double C_out = 0;
            string keyPress = "R";

            Console.WriteLine("Simple steady-state box model");
            while (keyPress != "Q")
            {
                // Reset values that could be overwritten during loop
                totalFlow = 0;  // Stores the total flow out from the system
                totalMass = 0;  // Stores the total mass of chemical in the system
                C_out = 0;      // Stores the outflow concentration

                // Ask user for number of inflow streams (concentration does not need to be > 0 for any stream, but we need the flowrate for the flow/water balance)
                Console.WriteLine("\r\n\r\nEnter number of input streams:");
                int.TryParse(Console.ReadLine(), out outInt);
                int nInputs = outInt;

                // Read in flow values
                Console.WriteLine("Enter the flow rate for input streams [L/s].");
                double[] Q_in = new double[nInputs];
                for (int i = 0; i < nInputs; i++)
                {
                    Console.WriteLine("Input stream " + (i+1).ToString() + "'s flow rate = ");
                    double.TryParse(Console.ReadLine(), out outDouble);
                    Q_in[i] = outDouble;
                }

                // Read in concentration values
                Console.WriteLine("Enter the concentration for input streams [mg/L].");
                double[] C_in = new double[nInputs];
                for (int i = 0; i < nInputs; i++)
                {
                    Console.WriteLine("Input stream " + (i+1).ToString() + "'s concentration = ");
                    double.TryParse(Console.ReadLine(), out outDouble);
                    C_in[i] = outDouble;
                }

                // Get the flow/water balance and mass balance for the system
                for (int i = 0; i < Q_in.Length; i++)
                {
                    totalFlow += Q_in[i];
                    totalMass += Q_in[i] * C_in[i];
                }

                // Calculate the steady state concentration in outflow
                C_out = totalMass / totalFlow;

                // Report the concentration and ask if user wants to quit or continue
                Console.WriteLine(String.Format("The steady-state concentration in effluent is: {0} mg/L", C_out));
                Console.WriteLine("Press \'R\' to restart or \'Q\' to quit");
                keyPress = Console.ReadKey().Key.ToString().ToUpper();
                if (keyPress == "Q") { Environment.Exit(0); }
            }
            Environment.Exit(0);
        }
    }
}
