namespace Chemistry_Helper;

public class AMUCalculator: Chemistry 
{
    
    public void getAMU()
    {
        float AMU = 0;
        
        Console.Write("Chemical: ");
        string Chemical = Console.ReadLine();
        
        for (int i = 0; i < Chemical.Length; i++)
        {
            string atom =Chemical[i].ToString();

            if (Char.IsLetter(Chemical[i + 1]) && Char.IsLower(Chemical[i + 1]))
            {
                atom += Chemical[i+1].ToString();
            }
            
            if (Char.IsNumber(Chemical[i + 1]))
            {
                int Multiply = (int)Chemical[i + 1];
                i++;
                
                if (Char.IsNumber(Chemical[i + 2]))
                {
                    Multiply *= 10;
                    Multiply += Chemical[i + 2];
                    i++;
                }
                
            }
            
            
        }
    }

}