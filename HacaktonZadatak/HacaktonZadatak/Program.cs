using System;

using System.Collections.Generic;



public class Foo

{
    /* 

     * Complete the 'IsBuyerWinner' function below. 

     * 

     * The function is expected to return an Integer. 

     * The function accepts following parameters: 

     *  1. List (STRING_ARRAY) - codeList 

     *  2. List (STRING_ARRAY) - shoppingCart 

     */

    public static List<string>Skrati(List<string> codeList, List<int> indecesToRemove)
    {
        if(indecesToRemove != null)
        {
            for (int i = indecesToRemove.Count - 1; i >= 0; i--)
            {
                codeList.RemoveAt(indecesToRemove[i]);
            }
        }
        return codeList;
        
    }
   public static int NekaFja(List<string> shoppingCart, string codeListItem)
   {
        // funkcija koja vraca zadnji index koji potvrđuje grupu (List<string> shoppingCart ,List<string> sequence)
        List<string> group= codeListItem.Split().ToList();
        List<string> tempShoppingCart = new List<string>(shoppingCart);

        List<int> indices = new List<int>();
        for (int i = 0; i < group.Count; i++) 
        { 
            if (group[i] == "anything") 
                    indices.Add(i); 
        }

        int lastIndex=-1;
        int temp=group.Count;

        if(indices.Count != 0 )
            group= Skrati(group, indices);


        for (int i = 0; i <= tempShoppingCart.Count - group.Count; i++)
        {
           if (i > 0&&indices.Count!=0)
               tempShoppingCart.RemoveAt(0);
            
            tempShoppingCart = Skrati(tempShoppingCart, indices);


            if (tempShoppingCart.Skip(i).Take(group.Count).SequenceEqual(group))
            {
                lastIndex = i + temp - 1; 
                return lastIndex;
            }
           
         }
         
        
        return 0;
   
    }
    public static int IsBuyerWinner(List<string> codeList, List<string> shoppingCart)

    {
        foreach (var codeListItem in codeList)
        {
                 int lastIndex = NekaFja(shoppingCart, codeListItem);
                 if (lastIndex == 0)
                     return 0;
                 shoppingCart = shoppingCart.GetRange(lastIndex,shoppingCart.Count-lastIndex);
                 shoppingCart.RemoveAt(0);
        }
        return 1;
    }
}
public class Solution

{

    public static void Main(string[] args)

    {

        int codeListCount = Convert.ToInt32(Console.ReadLine().Trim());
        
        
        
        List<string> codeList = new List<string>();
        
        
        
        
        for (int i = 0; i < codeListCount; i++)
        
        {
        
            string codeListItem = Console.ReadLine();
        
            codeList.Add(codeListItem);
        
        }
        
        
        
        int shoppingCartCount = Convert.ToInt32(Console.ReadLine().Trim());
        
        
        
        List<string> shoppingCart = new List<string>();
        
        
        
        for (int i = 0; i < shoppingCartCount; i++)
        
        {
        
            string shoppingCartItem = Console.ReadLine();
        
            shoppingCart.Add(shoppingCartItem);
        
        }
        
        

        






        int foo = Foo.IsBuyerWinner(codeList, shoppingCart);



        Console.WriteLine(foo);

    }

}