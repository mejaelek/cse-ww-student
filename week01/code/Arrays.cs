public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // Step 1: Create a new array of type double with size equal to 'length',
        //         because we need exactly 'length' multiples.
        // Step 2: Use a loop that runs from index 0 up to (but not including) length.
        //         At each index i, the multiple is number * (i + 1).
        //         For example, at i=0: number * 1 = first multiple,
        //                      at i=1: number * 2 = second multiple, etc.
        // Step 3: Store each computed multiple into the array at position i.
        // Step 4: After the loop is done, return the completed array.

        // Step 1: Create the array to hold the multiples
        double[] result = new double[length];

        // Step 2 & 3: Fill the array with multiples of 'number'
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        // Step 4: Return the completed array
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // Rotating right by 'amount' means the last 'amount' elements move to the front.
        // For example: {1,2,3,4,5,6,7,8,9} rotated right by 3 gives {7,8,9,1,2,3,4,5,6}
        //   - The last 3 elements {7,8,9} move to the front.
        //   - The first 6 elements {1,2,3,4,5,6} shift to the back.
        //
        // Step 1: Calculate the split point — where the "tail" section begins.
        //         splitIndex = data.Count - amount
        //         For the example above: splitIndex = 9 - 3 = 6
        //
        // Step 2: Extract the tail (last 'amount' elements) using GetRange(splitIndex, amount).
        //         This gives us the elements that need to move to the front.
        //
        // Step 3: Remove those tail elements from the end of the original list
        //         using RemoveRange(splitIndex, amount).
        //
        // Step 4: Insert the tail elements at the very beginning of the list (index 0)
        //         using InsertRange(0, tail).
        //         This places them at the front, completing the right rotation.

        // Step 1: Find the index where the tail starts
        int splitIndex = data.Count - amount;

        // Step 2: Copy the tail elements (the ones that will move to the front)
        List<int> tail = data.GetRange(splitIndex, amount);

        // Step 3: Remove those tail elements from the end of the list
        data.RemoveRange(splitIndex, amount);

        // Step 4: Insert the tail elements at the beginning of the list
        data.InsertRange(0, tail);
    }
}