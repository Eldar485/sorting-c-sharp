using System.Diagnostics;

/* double[] array = new double[100000];
Random rand = new Random();
for (int i = 0; i < 100000; i++)
{
    array[i] = rand.NextDouble();
}
*/
int[] array = new int[900000];
Random rand = new Random();
for (int i = 0; i < 900000; i++)
{
    array[i] = rand.Next(1, 900000);
}
Stopwatch stopwatch = new Stopwatch();

//////////////////////////////////////////////////////////Selection Sort//////////////////////////////////////////////////////////////
int[] SelectionSort(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        int min = i;
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[j] < array[min])
            {
                min = j;
            }
        }
        int temp = array[min];
        array[min] = array[i];
        array[i] = temp;
    }
    return array;
}

//////////////////////////////////////////////////////////Insertion Sort//////////////////////////////////////////////////////////////
int[] InsertionSort(int[] array)
{
    for (int i = 1; i < array.Length; i++)
    {
        int k = array[i];
        int j = i - 1;

        while (j >= 0 && array[j] > k)
        {
            array[j + 1] = array[j];
            array[j] = k;
            j--;
        }
    }
    return array;
}

//////////////////////////////////////////////////////////Merge Sort//////////////////////////////////////////////////////////////

//метод для слияния массивов
static void MergeSort(int[] array)
{
    if (array.Length == 1)
    {
        return;
    }
    // Разделение массива на две части 

    int mid = array.Length / 2;
    int[] left = new int[mid];
    int[] right = new int[array.Length - mid];

    // Присваивание элементов левой и правой частями
    for (int i = 0; i < mid; i++)
    {
        left[i] = array[i];
    }

    for (int i = mid; i < array.Length; i++)
    {
        right[i - mid] = array[i];
    }

    // Рекурсия, деление массива на части
    MergeSort(left);
    MergeSort(right);

    // Слияние в отсортированный подмассив
    Merge(array, left, right);
}

static void Merge(int[] targetArray, int[] array1, int[] array2)
{
    int array1MinIndex = 0;
    int array2MinIndex = 0;

    int targetArrayMinIndex = 0;

    while (array1MinIndex < array1.Length && array2MinIndex < array2.Length)
    {
        if (array1[array1MinIndex] <= array2[array2MinIndex])
        {
            targetArray[targetArrayMinIndex] = array1[array1MinIndex];
            array1MinIndex++;
        }
        else
        {
            targetArray[targetArrayMinIndex] = array2[array2MinIndex];
            array2MinIndex++;
        }
        targetArrayMinIndex++;
    }
    while (array1MinIndex < array1.Length)
    {
        targetArray[targetArrayMinIndex] = array1[array1MinIndex];
        array1MinIndex++;
        targetArrayMinIndex++;
    }
    while (array2MinIndex < array2.Length)
    {
        targetArray[targetArrayMinIndex] = array2[array2MinIndex];
        array2MinIndex++;
        targetArrayMinIndex++;
    }
}


//////////////////////////////////////////////////////////Heap Sort/////////////////////////////////////////////////////////////////

static void HeapSort(int[] array)
    {
        var length = array.Length;
        for (int i = length / 2 - 1; i >= 0; i--)
        {
            Heapify(array, length, i);
        }
        for (int i = length - 1; i >= 0; i--)
        {
            int temp = array[0];
            array[0] = array[i];
            array[i] = temp;
            Heapify(array, i, 0);
        }
    }

    //Rebuilds the heap
    static void Heapify(int[] array, int length, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        if (left < length && array[left] > array[largest])
        {
            largest = left;
        }
        if (right < length && array[right] > array[largest])
        {
            largest = right;
        }
        if (largest != i)
        {
            int swap = array[i];
            array[i] = array[largest];
            array[largest] = swap;
            Heapify(array, length, largest);
        }
    }

//////////////////////////////////////////////////////////Quick Sort/////////////////////////////////////////////////////////////////

int[] QuickSort(int[] array, int leftIndex, int rightIndex)
{
    var i = leftIndex;
    var j = rightIndex;
    var pivot = array[leftIndex];
    while (i <= j)
    {
        while (array[i] < pivot)
        {
            i++;
        }

        while (array[j] > pivot)
        {
            j--;
        }
        if (i <= j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
            i++;
            j--;
        }
    }

    if (leftIndex < j)
        QuickSort(array, leftIndex, j);
    if (i < rightIndex)
        QuickSort(array, i, rightIndex);
    return array;
}

//////////////////////////////////////////////////////////Bucket Sort/////////////////////////////////////////////////////////////////
static List<double> BucketSort(params double[] x)
{
    List<double> sortedArray = new List<double>();

    int numOfBuckets = 10;

    //Create buckets
    List<double>[] buckets = new List<double>[numOfBuckets];
    for (int i = 0; i < numOfBuckets; i++)
    {
        buckets[i] = new List<double>();
    }

    //Iterate through the passed array 
    //and add each integer to the appropriate bucket
    for (int i = 0; i < x.Length; i++)
    {
        double bucket = (x[i] / numOfBuckets);
        buckets[(int)bucket].Add(x[i]);
    }

    //Sort each bucket and add it to the result List
    for (int i = 0; i < numOfBuckets; i++)
    {
        List<double> temp = Sort(buckets[i]);
        sortedArray.AddRange(temp);
    }
    return sortedArray;
}

//Insertion Sort
static List<double> Sort(List<double> input)
{
    for (int i = 1; i < input.Count; i++)
    {
        double currentValue = input[i];
        int pointer = i - 1;

        while (pointer >= 0)
        {
            if (currentValue < input[pointer])
            {
                input[pointer + 1] = input[pointer];
                input[pointer] = currentValue;
            }
            else break;
        }
    }

    return input;
}

//////////////////////////////////////////////////////////Start Sort/////////////////////////////////////////////////////////////////
stopwatch.Start();
HeapSort(array);
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
