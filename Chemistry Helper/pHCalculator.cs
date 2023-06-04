namespace Chemistry_Helper;


public class pHCalculator : Chemistry
{
     static string request = "Hi";
    static bool IsAcid;
    static double H;
    static double OH;
    static double pOH;
    static double pH;
    
    public void getpH()
    {
        while (true)
        {
            Console.Clear();
            //handels molarity imput:

            Console.Write("Molarity: ");
            request = Console.ReadLine().ToLower();
            if (request == "exit") { break; }

            if (request != string.Empty && request != " ")
            {
                HandleMolarityImput();
                Console.Clear();
                continue;
            }

            Console.Clear();
            Console.Write("\npH: ");
            request = Console.ReadLine().ToLower();
            if (request == "exit") { break; }

            if (request != string.Empty && request != " ")
            {
                double PH;

                if (!Double.TryParse(request, out PH)) //checks the imput can be converted to double
                {
                    Console.WriteLine("Enter a valid number");
                    Console.ReadKey();
                    continue;
                }

                if (PH < 0 || PH > 14) {
                    Console.Write("\npH over accepted range ");
                    Console.ReadKey();
                    continue;
                }

                GetConcentration(PH);
                GetpH(H, true);
                Console.ReadLine();
                Console.Clear();
                continue;
            }

            Console.Clear();
            Console.Write("\npOH: ");
            request = Console.ReadLine().ToLower();
            if (request == "exit") { break; }

            if (request != string.Empty && request != " ")
            {
                double POH;

                if (!Double.TryParse(request, out POH)) //checks the imput can be converted to double
                {
                    Console.WriteLine("Enter a valid number");
                    Console.ReadKey();
                    continue;
                }

                if (POH < 0 || POH > 14)
                {
                    Console.Write("\npOH over accepted range ");
                    Console.ReadKey();
                    continue;
                }

                GetConcentration(14-POH);
                GetpH(H, true);
                Console.ReadLine();
                Console.Clear();
                continue;
            }

        }
    }
    static void HandleMolarityImput()
    {
        double Molarity;

        if (!Double.TryParse(request, out Molarity)) //checks the imput can be converted to double
        {
            Console.WriteLine("Enter a valid number");
            Console.ReadKey();
            return;
        }

        Console.Write("Is this an acid? : ");
        string s_DetermineAcid = Console.ReadLine();

        if (s_DetermineAcid.ToLower().Contains('y') || s_DetermineAcid.ToLower() == "yes") { IsAcid = true; }
        else if (s_DetermineAcid.ToLower().Contains('n') || s_DetermineAcid.ToLower() == "no") { IsAcid = false; }
        else
        {
            Console.WriteLine("IS THIS AN ACID OR NOT?!?");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        GetpH(Molarity, IsAcid);
        GetConcentration(pH);
        Console.ReadLine();
    }

    static void GetpH(double MolarConcentration, bool IsAcid)
    {
        double _OH = 1 / MolarConcentration;
        pOH = -Math.Log10(_OH * 0.00000000000001);
        pH = 14 - pOH;

        switch (IsAcid)
        {
            case true:
                Console.WriteLine($"pH: {Math.Round(pH,3)}\npOH: {Math.Round(pOH,3)}\n");
                break;

            case false:
                Console.WriteLine($"pH: {Math.Round(pOH,3)}\npOH: {Math.Round(pH,3)}\n");
                break;
        }
    }

    static void GetConcentration(double pH)
    {
        H =  Math.Pow(10, -pH);
        OH = Math.Pow(10, pH - 14);

        string formmatedH = H.ToString("E3");
        string formmatedOH = OH.ToString("E3");

        Console.WriteLine($"H+: {formmatedH}\nOH-: {formmatedOH}\n");
    }
}