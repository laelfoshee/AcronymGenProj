/********************************************************************************************
 *  Acronym Validty Checker (AVC).
 * 
 * Copyright 2015 Lael Foshee (laelfoshee@gmail.com)
 * This file is part of AcronymGenProj.
 * AcronymGenProj is free software: you can redistribute it and/or modify it under the terms 
 * of the GNU General Public License as published by the Free Software Foundation, either version
 * 3 of the License, or (at your option) any later version.
 *
 * AcronymGenProj is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
 * See the GNU General Public License for more details.
 *
 *    You should have received a copy of the GNU General Public License along with Foobar. 
 *    If not, see http://www.gnu.org/licenses/.

 *  Requirements of AVC AcronymGenProj:
 *  1) Every word in the product name is represented by at least one letter in the acronym 
 *  (i.e., you need at least one of the letters from each word, so if you have 3 words, 
 *  the acronym is a minimum of 3 letters). 
 *  2) The characters of the acronym must appear in-order in the product name (i.e., you can
 *  remove letters from the product name to create the acronym, but you can’t add/rearrange
 *  the characters)
 *  @author: Lael Foshee
 *  @ref quick_recursive() algorithm reused: https://github.com/pauldzy/for_ian/blob/master/codetest.py 
********************************************************************************************/
using System;
using System.Collections.Generic;

namespace AcronymGenProj
{
    class Program
    {
        static void Main(String[] args)
        {

            AcronymValidator av = new AcronymValidator();

            List<String> productName1 = new List<String>();
            productName1.Add("GISi");
            productName1.Add("Robot");
            productName1.Add("Master");

            String acronym = "GISRM";

            Console.WriteLine("Is valid?: " + acronym + " -->" + av.isValid(acronym, productName1));
            

            String product = "GISi Zombie Tracker 3000";
            Console.WriteLine(product);
            String productName;

            String tester = "GIZTK3";
            Console.WriteLine("   " + tester + ": " + av.isValid(acronym = tester, productName = product));

            tester = "GZT3";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester, productName = product
            ));

            tester = "GISEE0";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "GZT3k";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "GZT";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "GZTK";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "BLAH";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            Console.WriteLine(
            product = "Google Search Engine");
            Console.WriteLine(product);


            tester = "GOOSE";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "GEANIE";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "OOSN";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "LEACHE";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "OOGLEE";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "GOOSEEE";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "GGSEE";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "GGSE";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "SGE";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "GEANIEOOSN";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "OGGLEE";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "GGG";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "GGSEA";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));


            product = "Apple Apple Apple";
            Console.WriteLine(product);

            tester = "AAA";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "APAP";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));

            tester = "APPLE";
            Console.WriteLine("   " + tester + ": " + av.isValid(
                acronym = tester
               , productName = product
            ));
            
            Console.WriteLine("Press Enter to End");
            Console.ReadLine();

        }

    }
}
