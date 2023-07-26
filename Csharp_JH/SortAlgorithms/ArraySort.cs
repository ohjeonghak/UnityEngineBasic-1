using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    internal static class ArraySort
    {
        /// <summary>
        /// 거품 정렬
        /// 시간복잡도는 O(N^2) , 연산이 계속 되기때문에 느림
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(int[] arr)
        {
            int i, j;
            for (i = 0; i < arr.Length -1; i++)
            {
                for (j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }
        /// <summary>
        /// 선택 정렬
        /// 시간복잡도는 O(N^2)
        /// </summary>
        /// <param name="arr"></param>
        public static void SelecionSort(int[] arr)
        {
            int i, j, minIdx;
            for (i = 0; i < arr.Length; i++)
            {
                minIdx = i;
                for (j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIdx])
                        minIdx= j;
                }

                Swap(ref arr[i], ref arr[minIdx]);
            }
        }

        /// <summary>
        /// 삽입 정렬
        /// 시간복잡도는 O(N^2)
        /// stable
        /// Swap을 쓰지 않음
        /// </summary>
        /// <param name="arr"></param>
        public static void InsertionSort(int[] arr)
        {
            int i, j;
            int key;

            for (i = 0; i < arr.Length; i++)
            {
                key = arr[i];
                j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }


        //for 문에서 분할 됨
        public static void MergeSort(int[] arr)
        {
            int length = arr.Length;

            for (int mergeSize = 1; mergeSize < length; mergeSize *= 2)
            {
                for (int start = 0; start < length; start += 2 * mergeSize)
                {
                    int mid = Math.Min(start + mergeSize - 1, length -1);
                    int end = Math.Min(start + 2 * mergeSize - 1, length -1);

                    Merge(arr, start, mid, end);
                }
            }
        }

        //병합
        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int part1 = start;
            int part2 = mid + 1;
            int length1 = mid - start + 1;
            int length2 = end - mid;

            int[] copy1 = new int[length1];
            int[] copy2 = new int[length2];

            int i = 0;// Copy1 index
            int j = 0;// Copy2 index
            for (i = 0; i < length1; i++)
                 copy1[i] = arr[start + i];
            for (j = 0; j < length2; j++)
                copy2[j] = arr[mid + 1 + j];

            int index = start;
            i = 0;
            j = 0;

            while(i < length1 && j < length2)
            {
                if (copy1[i] <= copy2[j])
                    arr[index++] = copy1[i++];
                else
                    arr[index++] = copy2[j++];
            }

            while (i < length1)
                arr[index++] = copy1[i++];
            // part2는 남은건 그대로 고정되어 남기때문에 쓸 필요 없음
            //while (j < length2)
            //    arr[index++] = copy2[j++];
        }




        public static void RecursiveMergeSort(int[] arr)
        {
            RecursiveMergeSort(arr, 0, arr.Length - 1);
        }


        private static void RecursiveMergeSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int mid = end + (start - end) / 2 - 1; // == (start + end) / 2 - 1, Overflow 방지용(알고리즘 할때는 항상 Overflow 생각하기)
                RecursiveMergeSort(arr, start, mid);
                RecursiveMergeSort(arr, mid + 1, end);

                Merge(arr, start, mid, end);
            }
        }

        public static void QuickSort(int[] arr)
        {
            Stack<int> partitionstack = new Stack<int>();
            partitionstack.Push(0);
            partitionstack.Push(arr.Length - 1);

            while (partitionstack.Count > 0)
            {
                int end = partitionstack.Pop();
                int start = partitionstack.Pop();
                int partition = Partition(arr, start, end);
                
                //left side
                if (partition - 1 > start)
                {
                    partitionstack.Push(start);
                    partitionstack.Push(partition - 1);
                }

                //right side
                if (partition + 1 < end)
                {
                    partitionstack.Push(partition + 1);
                    partitionstack.Push(end);
                }
            }
        }
        

        
        public static void RecursiveQuickSort(int[] arr)
        {
            RecursiveQuickSort(arr, 0, arr.Length - 1);
        }


        public static void RecursiveQuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int partition = Partition(arr, start, end);
                RecursiveQuickSort(arr, start, partition - 1);
                RecursiveQuickSort(arr, partition + 1, end);
            }
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[(start + end) / 2];

            while (true)
            {
                while (arr[start] < pivot) start++;
                while (arr[end] > pivot) end--;

                if (start < end)
                {
                    Swap(ref arr[start], ref arr[end]);

                    if (arr[start] == pivot && arr[end] == pivot)
                        end--;
                }
                else
                {
                    return end;
                }
            }
        }


        public static void HeapSort(int[] arr)
        {
            //HeapifyTopDown(arr);
            HeapifyBottomUp(arr);

            InverseHeapify(arr);
        }

        // 위에서 아래로 구조 만들어가는 타입
        // O(NLogN)
        public static void HeapifyTopDown(int[] arr)
        {
            int end = 1;
            while (end < arr.Length)
            {
                SIFT_Up(arr, 0, end++);
            }
        }
        // 아래서 위로 구조를 만들어가는 타입
        // O(N) - 모든 단말노드에 대해서 수행할 필요가 없기 때문
        public static void HeapifyBottomUp(int[] arr)
        {
            int end = arr.Length -1;
            int current = end;

            while(current >= 0)
            {
                SIFT_Down(arr, end, current--);
            }

        }

        public static void InverseHeapify(int[] arr)
        {
            int end = arr.Length - 1;
            while (end > 0)
            {
                Swap(ref arr[0], ref arr[end]);
                end--;
                SIFT_Down(arr, end, 1);

            }
        }


        //자식이 부모를 탐색해서 스왑하면서 올라가는 형태의 알고리즘
        // O(NLogN)
        public static void SIFT_Up(int[] arr, int root, int current)
        {
            int parent = (current - 1) / 2;
            while (current > root)
            {
                if (arr[current] > arr[parent])
                {
                    Swap(ref arr[current], ref arr[parent]);
                    current = parent;
                    parent = (current - 1) / 2;
                }
                else
                {
                    return;
                }
            }
        }

        //부모가 자식을 탐색해서 스왑하면섯 내려가는 형태의 알고리즘
        public static void SIFT_Down(int[] arr, int end, int current)
        {
            int parent = (current - 1) / 2;
            while (current <= end)
            {
                //오른쪽이 더 크면 스왑 대상을 오른쪽으로 바꿈
                //자식노드를 구할떈 (*2 +1), 그 오른쪽은 (*2 +1 +1)
                if (current + 1 <= end &&
                    arr[current] < arr[current + 1])
                    current = current + 1;

                if (arr[current] > arr[parent])
                {
                    Swap(ref arr[current], ref arr[parent]);
                    parent = current;
                    current = parent * 2 + 1;
                }
                else
                {
                    return;
                }
            }
        }



        // ref : 인자를 변수의 참조로 받아야할떄 사용하는 키워드
        public static void Swap(ref int a, ref int b)
        {
            int tmp = b;
            b = a;
            a = tmp;
        }
    }
}
