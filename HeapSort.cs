using System;
using System.Collections.Generic;

namespace SortSpace
{
    public class Heap
    {
        public int[] HeapArray; // хранит неотрицательные числа-ключи

        public Heap() { HeapArray = null; }

        public void MakeHeap(int[] a, int size)
        {  
            HeapArray = new int[size];
            for (int i = 0; i < HeapArray.Length; i++)
                HeapArray[i] = -1;  
            for (int i = 0; i < size; i++)
                Add(a[i]);                   // fill heap array by incoming array
        }

        public int GetMax()
        {
            if (HeapArray[0] == -1)
                return -1; // if heap is empty
            else
            {
                int max_item = HeapArray[0];
                for (int i = HeapArray.Length - 1; i >= 0; i--) // passing the array from 2nd item
                {
                    if (HeapArray[i] >= 0)
                    {
                        HeapArray[0] = HeapArray[i];
                        HeapArray[i] = -1;
                        break;
                    }
                }
                sifting_down(0);
                return max_item;
            }
        }

        public bool Add(int key)
        {
            for (int i = 0; i < HeapArray.Length; i++)
            {
                if (HeapArray[i] < 0)
                {
                    HeapArray[i] = key;  // add new item "key" to the heap
                    sifting_up(i);       // rebuild the heap
                    return true;
                }
            }            
            return false; // если куча вся заполнена
        }

        static int two_to_the_degree(int D) 
        {  
           if (D == 0) 
              return 1;
           return (2 * two_to_the_degree(D-1));  
        }

        private void sifting_down(int i)
        { 
          int tmp = HeapArray[i];              // Copy
          while (i <= HeapArray.Length/ 2)     // the item is not a leaf
          {
              int child = 2*i+1;               // left child
              if (HeapArray[child] < HeapArray[child + 1]) // choose max child
                  child++;
              if (tmp >= HeapArray[child]) 
                 break;
              HeapArray[i] = HeapArray[child]; // change 
              i = child;                       // remember
          }
          HeapArray[i] = tmp; // At the end, we restore the sifted element to its original value.
        }

        private void sifting_up(int i)
        {
          int tmp = HeapArray[i];    
          while (i != 0)     // while have not reached the root
          {
              int parent = (i-1)/2;
              if (tmp < HeapArray[parent]) break;
              HeapArray[i] = HeapArray[parent]; 
              i = parent;
          }
          HeapArray[i] = tmp; 
        } 
    }

    public class HeapSort
    {
        public Heap HeapObject;
        public HeapSort(int[] arr)
        {
            HeapObject = new Heap();
            HeapObject.MakeHeap(arr, arr.Length);
        }
        public int GetNextMax()
        {
            return HeapObject.GetMax();
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        int test = 0;
    //        int[] arr = new int[] {0, 1, 2, 3, 4, -3, -2};
    //        HeapSort heap = new HeapSort(arr);
    //        for (int i = 0; i < arr.Length; i++) { Console.Write(heap.GetNextMax()); }
    //        Console.WriteLine();

    //        int[] arr_1 = new int[] { 0, 1, 2, 3, 4, -3, -2 , 5, 7};
    //        HeapSort heap_1 = new HeapSort(arr_1);
    //        for (int i = 0; i < arr_1.Length; i++) { Console.Write(heap_1.GetNextMax()); }
    //        Console.WriteLine();

    //        int[] arr_2 = new int[] { 0, 1, 2, 3, 4, 1, 2 };
    //        HeapSort heap_2 = new HeapSort(arr_2);
    //        for (int i = 0; i < arr_2.Length; i++) { Console.Write(heap_2.GetNextMax()); }
    //        Console.WriteLine();
    //     }
    //}
}
