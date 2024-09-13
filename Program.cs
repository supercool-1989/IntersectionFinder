/*
 Write a function that takes as parameters two unsorted arrays of integers and outputs an
array with the intersection of the two inputs.
arrays.
    a. Follow up: how to optimize this? (a: store largest in a tree and traverse for each
element in another array, or sort both arrays and iterate through them together)
    b. Follow up: what is the big O time for this? (a: O(n*log(n)) to sort and O(n) to find
each intersected element = O(n*log(n)))
 */


class Program
{
    enum sortType
    {
        defaultSort = 1,
        varient = 2
    }
    static int[] IntersectionFinder(int[] arr1, int[] arr2, sortType type)
    {
        //Store input's in hasset for faster search 0(1) + Loop thorugh smaller array
        var smallerArray = arr1.Length < arr2.Length ? arr1 : arr2;
        var largerArray = new HashSet<int>(arr1.Length >= arr2.Length ? arr1 : arr2);
        if (type == sortType.defaultSort)
        {            
            var output = new HashSet<int>();

            // Check if elements of arr2 exist in the arr1
            foreach (int num in smallerArray)
            {
                if (largerArray.Contains(num))
                {
                    output.Add(num);
                }
            }

            return output.ToArray();
        }
        else if (type == sortType.varient)
        {
            Array.Sort(smallerArray);
            Array.Sort(largerArray.ToArray());

            HashSet<int> output = new();
            int i = 0, j = 0;

            // Iterate through both arrays and find the common values
            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] < arr2[j])
                {
                    i++;
                }
                else if (arr1[i] > arr2[j])
                {
                    j++;
                }
                else
                {
                    output.Add(arr1[i]);
                    i++;
                    j++;
                }
            }

            return output.ToArray();
        }
        return [];
    }

    static void Main()
    {
        int[] arr1 = { 1, 4, 5, 6, 7, 8, 9 };
        int[] arr2 = { 9, 4, 9, 8, 4 };

        Console.WriteLine("=======Default==========");
        Console.WriteLine("Intersection: " + string.Join(", ", IntersectionFinder(arr1, arr2, sortType.defaultSort)));
        Console.WriteLine("Time comlexity is: O(n) for big array the small array loop 0(m)==> o(n+m)") ;
        Console.WriteLine("====================");

        Console.WriteLine("=======Optimized==========");
        Console.WriteLine("Intersection: " + string.Join(", ", IntersectionFinder(arr1, arr2, sortType.varient)));
        Console.WriteLine("Time comlexity is: sorting is costly O(nlogn) & O(mlogm) => 0(nlogn + mlogm)") ;
        Console.WriteLine("=================");

        Console.ReadKey();
    }
}
