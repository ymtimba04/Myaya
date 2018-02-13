using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Author Info
///-----------------------------------------------------------------
///   Namespace:      Day_16
///   Class:          PermutationPromenade
///   Description:    PermutationPromenade contains 3 dance move and run permutation methods. It basically compute the arrangement of letters after performing dance moves based on the input puzzle
///   Author:         Yandisa Mtimba                    Date: 13/02/2018
///   Email:          ymtimba04@gmail.com
///-----------------------------------------------------------------
#endregion

namespace Day_16
{
    /// <summary>
    /// PermutationPromenade contains 3 dance move and run permutation methods.
    /// </summary>
    class PermutationPromenade
    {
        // Original program
        private const string originalProgram = "abcdefghijklmnop";

        // Program result
        private string programResult = "";

        // Constructor method
        public PermutationPromenade()
        {
            // Initialize program result with original program data
            programResult = originalProgram;
        }

        #region Spin Dance Move

        /// <summary>Spin is a method in the PermutationPromenade class.
        /// <para>This will make X programs move from the end to the front, but maintain their order otherwise.</para>
        /// </summary>
        /// <param name="programData">Used to indicate the number of spins to be performed.</param>
        /// <returns>Returns void</returns>
        /// 
        protected void Spin(int programData)
        {
            // Get the size/length
            int size = programResult.Length;

            // Populate data for manipulation
            string data = programResult;

            for (int i = 1; i <= programData; i++)
            {
                // Get program result data minus last character
                string tempData = data.Substring(0, size - 1);

                // Get program result data's last character
                string lastCharacter = data.Substring(size - 1);

                // Do the spin
               data = lastCharacter + tempData;

                // Update master data i.e. ProgramResult
                programResult = data;
            }
        }
        #endregion

        #region Exchange Dance Move

        /// <summary>Exchange is a method in the PermutationPromenade class.
        /// <para>This will make the programs at positions A and B swap places.</para>
        /// </summary>
        /// <param name="programData">Used to indicate which places to swap.</param>
        /// <returns>Returns void</returns>
        /// 
        protected void Exchange(string programData)
        {
            // Get part of the program rule data 
            string[] dataRule = programData.Split('/');

            // Convert string into array of characters
            char[] programNumericIndex = programResult.ToCharArray(); 

            // Get temporary copy of character
            char temp = programNumericIndex[Convert.ToInt32(dataRule[0])];

            // Assign element
            programNumericIndex[Convert.ToInt32(dataRule[0])] = programNumericIndex[Convert.ToInt32(dataRule[1])];

            // Assign element
            programNumericIndex[Convert.ToInt32(dataRule[1])] = temp; 

            // Assign program result with new string data
            programResult = new string(programNumericIndex);

        }
        #endregion

        #region Partner Dance Move

        /// <summary>Partner is a method in the PermutationPromenade class.
        /// <para>This will makes the programs named A and B swap places.</para>
        /// </summary>
        /// <param name="programData">Used to indicate which program names to swap places.</param>
        /// <returns>Returns void</returns>
        ///
        protected void Partner(string programData)
        {
            // Get part of the program rule data 
            string[] dataRule = programData.Split('/');
            
            // Convert string into array of characters
            char[] programNumericIndex = programResult.ToCharArray();

            // Get the first swap character position from program result
            int firstSwapIndex = programResult.IndexOf(dataRule[0]);

            // Get the second swap character position from program result
            int secondSwapIndex = programResult.IndexOf(dataRule[1]);

            // Assign character on first swap position
            programNumericIndex[firstSwapIndex] = Convert.ToChar(dataRule[1]);

            // Assign character on second swap position
            programNumericIndex[secondSwapIndex] = Convert.ToChar(dataRule[0]);

            // Assign program result with new string data
            programResult = new string(programNumericIndex);
        }
        #endregion

        #region Run Permutation

        /// <summary>RunPermutation is a method in the PermutationPromenade class.
        /// <para>Run the puzzle using the input</para>
        /// </summary>
        /// <param name="inputPuzzle">Used to feed program with the puzzle for computation of dance moves.</param>
        /// <returns>Returns string programResult</returns>
        ///
        public string RunPermutation(string inputPuzzle)
        {
            // Convert input puzzle into array
            string[] masterPuzzle = inputPuzzle.Split(',');

            for (int i = 0; i < masterPuzzle.Length; i++)
            {
                // Get the type of rule
                string rule = masterPuzzle[i].Substring(0, 1);

                switch (rule)
                {
                    // Spin
                    case "s":
                        this.Spin(Convert.ToInt32(masterPuzzle[i].Substring(1)));
                        break;

                    // Exchange
                    case "x":
                        this.Exchange(masterPuzzle[i].Substring(1));
                        break;

                    // Partner
                    case "p":
                        this.Partner(masterPuzzle[i].Substring(1));
                        break;
                }
            }

            // Send back the program result
            return programResult;
        }
        #endregion

    }
}
