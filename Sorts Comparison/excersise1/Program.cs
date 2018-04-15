using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excersise1
{
    class Program
    {
        static int mergesortcompared = 0;
        static int mergesortswapped = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter N:");
            int n = Convert.ToInt32(Console.ReadLine());
            Comparison(n);


        }
        static int[] InsertionSort(int [] a,out int s,out int c)                    //insertion sort method
        {
            int swapped = 0;
            int compared = 0;
            
            for (int i= 1; i<a.Length;i++)
            {
                compared++;
                int key = a[i];
                int k = i;
                while (k > 0 && a[k - 1] > key)
                {
                    swapped++;
                    compared++;
                    a[k] = a[k - 1];
                    k = k - 1;
                }

                a[k] = key;
            }
            s = swapped;
            c = compared;
            return a;

        }
        static int[] MergeSort(int[] a,int first,int last, out int s, out int c)            //merge sort method
        {

            if (last > first)
            {
                int middle = (first+last) / 2;
                MergeSort(a,first,middle,out Program.mergesortswapped,out Program.mergesortcompared);
                MergeSort(a,middle+1, last,out Program.mergesortswapped, out Program.mergesortcompared);
                Merge(a, first, middle, last);
            }
            s = Program.mergesortswapped;
            c = Program.mergesortcompared;
            return a;

        }

         static int[] Merge(int[] a, int first, int middle,int last)
        {
            int[] c = new int[last-first+1];    
            int i = first;
            int j = middle + 1;
            int k = 0;
            while (i<=middle && j<=last)
            {
                Program.mergesortcompared++;
                if (a[i]<=a[j])
                {
                    c[k] = a[i];
                    i++;
                }
                else
                {
                    c[k] = a[j];
                    j++;
                    Program.mergesortswapped ++;
                }
                k++;
            }
            if (i <= middle)
            {
                while (i <= middle)
                {
                    c[k] = a[i];
                    k++;
                    i++;
                }
            }
            if (j <= last)
            {
                while (j <= last)
                {
                    c[k] = a[j];
                    k++;
                    j++;  
                }
            }
            for (int t=0;t<c.Length;t++)
            {
                a[first+t]=c[t];
            }
            return a;
        }
        
        public static void Comparison(int n)
        {
            Random rndm = new Random();
            int[] array1 = new int[n];
            int[] array2 = new int[n];
            for (int i = 0; i < n; i++)
                array1[i] = rndm.Next(0, 100);         //fill the array with random numbers
            for (int j = 0; j < n; j++)             //copy array1 to array2
                array2[j] = array1[j];

                
            int MergeSwap;            //number of swaptions in merge sort
            int MergeCompare;                   //number of comparisons in merge sort
            int InsertionSwap;              //number of swaptions in insertion sort
            int InsertionCompare;               //number of comparisons in insertion sort

            int MergeComplexity = n * (Convert.ToInt32(Math.Log((double)n, 2)));  //calculate nLogn
            int InsertionComplexity = n * n;                                        //calculate n^2

            MergeSort(array1, 0, n-1,out MergeSwap,out MergeCompare); // call merge sort method

            Console.WriteLine("number of swaption in merge sort:{0}  number of comparisons in merge sort{1} .", MergeSwap, MergeCompare);
            Console.WriteLine("merge sort complexity is: {0} and number of merge sort comparisons is: {1}  .", MergeComplexity, MergeCompare);
            InsertionSort(array2,out InsertionSwap, out InsertionCompare); //call insertion sort method

            Console.WriteLine("number of swaption in insertion sort:{0}  number of comparisons in insertion sort{1} .", InsertionSwap, InsertionCompare);
            Console.WriteLine("insertion sort complexity is: {0} and number of insertion sort comparisons is: {1}  .", InsertionComplexity, InsertionCompare);

            if ((MergeSwap > InsertionSwap)|(MergeSwap == InsertionSwap & MergeCompare>InsertionCompare))
               Console.WriteLine("Insertion Sort is better here!");
            else if ((MergeSwap<InsertionSwap) | (MergeSwap == InsertionSwap & MergeCompare < InsertionCompare))
                Console.WriteLine("Merge Sort is better here!");
            Console.ReadKey();
        }

    }


}

