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
 *  
 * 
    Usage Sample: 
                         
            AcronymValidator av = new AcronymValidator();

            List<String> productName1 = new List<String>();
            productName1.Add("GISi");
            productName1.Add("Robot");
            productName1.Add("Master");
            String acronym = "GRM"; 

            Console.WriteLine("Is valid?: " + acronym + " -->" + av.isValid(acronym, productName1));
********************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AcronymGenProj
{
    class AcronymValidator
    {
        //Constructor
        public AcronymValidator()
        { }

        /// <summary>AVC entry point will return "valid" or "invalid"</summary>
        /// <param name="acronym">Acronym</param>
        /// <param name="productName">ProductName as a String or List of String</param>
        /// <returns>"valid" if acronym is a valid representation of the productName, otherwise "invalid"</returns>
        public String isValid(String acronym, Object productName)
        {
            bool valid = false;
            if (productName.GetType() == typeof(String))
                valid = isValid(acronym, (String)productName);

            else if (productName.GetType() == typeof(List<String>))
            {
                valid = isValid(acronym, (List<String>)productName);
            }
            else
                return "The productName does not match a supported type.";

            if (valid)
                return "valid";
            else
                return "invalid";
        }


        /// <summary>Returns True or False if the Acronym is a valid representation of the Product Name.</summary>
        /// <param name="acronym">Acronym as a String</param>
        /// <param name="productName">Product Name as a String</param>
        /// <returns> "True" if acronym meets the requirements of the AVC, else "False"</returns>
        private bool isValid(String acronym, String productName)
        {
            List<String> result = productName.Split(' ').ToList();
            return (isValid(acronym, result));
        }

        /// <summary>Returns True or False if the Acronym is a valid representation of the Product Name.</summary>
        /// <param name="acronym">Acronym as a String</param>
        /// <param name="productName">Product Name as a List of Strings</param>
        /// <returns> "True" if acronym meets the requirements of the AVC, else "False"</returns>
        private bool isValid(String acronym, List<String> productName)
        {
            //convert acronym and productName to uppercase
            acronym = acronym.ToUpper();
            productName = productName.ConvertAll(d => d.ToUpper());

            // If acronym is same as product name, return Valid;
            if (String.Join("", productName.ToArray()).ToUpper().CompareTo(acronym) == 0)
                return true;

            // Requirement: you need at least one of the letters from each word, so if you have 3 words, 
            // the acronym is a minimum of 3 letters
            if (acronym.Length < productName.Count)
            {
                return false;
            }

            List<List<Char>> possib = new List<List<Char>>(); // A list of lists containing chars of the productName.

            //Iterate over the productName List of strings to create a new List that converts the strings to a list of chars.
            foreach (String word in productName)
            {
                List<Char> newList = new List<Char>();
                foreach (Char letter in word)
                {
                    newList.Add(letter);
                }
                possib.Add(newList);
            }
            //Create ArrayList of chars from the Acronym string.
            ArrayList acronymChars = new ArrayList();
            foreach (Char letter in acronym)
            {
                acronymChars.Add(letter);
            }

            // Initial entry point to check for validity.
            if (quick_recursive(productName.Count, possib, acronymChars, 0, 0, 0, -1))
                return true;
            else
                return false;
        }

        /// <summary>Reuse of quick_recursive algorithm converted to C# using .NET v4.0. (https://github.com/pauldzy/for_ian/blob/master/codetest.py) </summary>
        /// <param name="wc">Word Count</param>
        /// <param name="productNameAsList">List of a List of Characters.</param>
        /// <param name="testval">The acronym to test as an arrayList of characters.</param>
        /// <param name="depth">The index positon of the ProductNameAsList currently under test.</param>
        /// <param name="pos">The index position of the testval-List under test.</param>
        /// <param name="wpos">The index position of the character in the word under tested.</param>
        /// <param name="lastgood">The productNameAsList index depth at which there is a good match.</param>
        /// <returns> True if testVal is a valid acronym for the ProductNameAsList based on the depth, pos, wpos.</returns>
        private bool quick_recursive(Int32 wc, List<List<Char>> productNameAsList, ArrayList testval, Int32 depth, Int32 pos, Int32 wpos, Int32 lastgood)
        {
            bool boo = false;
            bool chk;

            if ((depth == 0) && (pos == 0))
            {
                for (Int32 i = wpos; i < productNameAsList[depth].Count; i++)
                {
                    if ((Char)testval[pos] == productNameAsList[depth][i])
                    {
                        pos += 1;
                        boo = true;
                        wpos = i + 1;
                        lastgood = depth;
                        break;
                    }
                }
                if (boo)
                {
                    if ((pos == testval.Count) && (wc == depth + 1))
                    {
                        return true;
                    }
                    else if (pos == testval.Count)
                    {
                        return false;
                    }

                    else
                    {
                        return quick_recursive(wc, productNameAsList, testval, depth, pos, wpos, lastgood);
                    }
                }
                else
                    return false;
            }
            else
            {
                if (depth + 1 > wc)
                {
                    return false;
                }

                for (Int32 i = wpos; i < productNameAsList[depth].Count; i++)
                {
                    if ((Char)testval[pos] == productNameAsList[depth][i])
                    {
                        pos += 1;
                        boo = true;
                        wpos = i + 1;

                        if (lastgood == depth || lastgood == depth - 1)
                        {
                            lastgood = depth;
                        }

                        else
                            return false;

                        break;
                    }
                }

                if (boo)
                {
                    if ((pos == testval.Count) && (wc == depth + 1))
                    {
                        return true;
                    }
                    else if (pos == testval.Count)
                    {
                        return false;
                    }

                    else
                    {
                        chk = quick_recursive(wc, productNameAsList, testval, depth, pos, wpos, lastgood);

                        if (chk == false)
                        {
                            chk = quick_recursive(wc, productNameAsList, testval, depth + 1, pos, 0, lastgood);
                        }

                        return chk;
                    }
                }
                else
                    return quick_recursive(wc, productNameAsList, testval, depth + 1, pos, 0, lastgood);

            }
        }
    }
}
