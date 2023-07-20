using System;
using System.Collections.Generic;
using System.Linq;
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

        // ref : 인자를 변수의 참조로 받아야할떄 사용하는 키워드
        public static void Swap(ref int a, ref int b)
        {
            int tmp = b;
            b = a;
            a = tmp;
        }
    }
}
