using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static int getMax(int[] arr, int n){
            int mx = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > mx)
                    mx = arr[i];
            return mx;
        }

        public static void countSort(int[] arr, int n, int exp){
            int[] output = new int[n];
            int i;
            int[] count = new int[10];

            for (i = 0; i < 10; i++)
                count[i] = 0;

            for (i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (i = n - 1; i >= 0; i--){
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            for (i = 0; i < n; i++)
                arr[i] = output[i];
        }

        public static void radixsort(int[] arr, int n){

            int m = getMax(arr, n);

            for (int exp = 1; m / exp > 0; exp *= 10)
                countSort(arr, n, exp);
        }

        private void button1_Click(object sender, EventArgs e){
            var watch = System.Diagnostics.Stopwatch.StartNew();

            string ArrayString = textBox1.Text;
            string[] ArrayInt = ArrayString.Split(',');

            int[] ArrayInt2 = new int[ArrayInt.Length];

            for(int i = 0; i < ArrayInt.Length; i++){
                ArrayInt2[i] = Int32.Parse(ArrayInt[i]);
            }

            int n = ArrayInt2.Count();

            label2.Text = "Sorted numbers:";

            radixsort(ArrayInt2, n);

            string SortedRadix = string.Join(" ", ArrayInt2);

            label3.Text = SortedRadix;

            watch.Stop();

            label4.Text = "Execution Time:";

            label5.Text = watch.ElapsedMilliseconds.ToString() + " ms";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
