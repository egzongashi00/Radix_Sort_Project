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

        public static int merreMaksimumin(int[] vektori, int n){
            int max = vektori[0];
            for (int i = 1; i < n; i++)
                if (vektori[i] > max)
                    max = vektori[i];
            return max;
        }

        public static void countSort(int[] vektori, int n, int exp){
            int[] output = new int[n];
            int i;
            int[] count = new int[10];

            for (i = 0; i < 10; i++)
                count[i] = 0;

            for (i = 0; i < n; i++)
                count[(vektori[i] / exp) % 10]++;

            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (i = n - 1; i >= 0; i--){
                output[count[(vektori[i] / exp) % 10] - 1] = vektori[i];
                count[(vektori[i] / exp) % 10]--;
            }

            for (i = 0; i < n; i++)
                vektori[i] = output[i];
        }

        public static void radixsort(int[] vektori, int n){

            int m = merreMaksimumin(vektori, n);

            for (int exp = 1; m / exp > 0; exp *= 10)
                countSort(vektori, n, exp);
        }

        private void button1_Click(object sender, EventArgs e){
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Start();

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