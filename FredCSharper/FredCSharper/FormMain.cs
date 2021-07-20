using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FredCSharper
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Délégué
            Action<string> m = str => MessageBox.Show(str);
            Action<object> w = obj => Write(obj);
            w("This message is displayed using a delegate");

            // Concaténation plus rapide et optimale
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("This ");
            strBuilder.Append("is ");
            strBuilder.Append("more faster ");
            strBuilder.Append("than normal appending ");
            w(strBuilder);

            // Déclarations de tableau
                
                // Tableau 1D
                int[] intArray1 = new int[3];
                intArray1[0] = 17;
                intArray1[1] = 18;
                intArray1[2] = 19;
                w("intArray1 : " + intArray1);
                int[] intArray2 = { 158, 892, 783 };
                w("intArray2 : " + intArray2);
                int[] intArray3 = new int[3] { 100, 248, 389 };
                w("intArray3 : " + intArray3);
                int[] intArray4 = new int[] { 20, 22, 900 };
                w("intArray4 : " + intArray4);
                var indefinedArray = new[] { 1, 2, 3 };
                w("indefinedArray : " + indefinedArray);
                object[] objectArray1 = { 1, "hello", DateTime.Now };
                w("objectArray1 : " + objectArray1);
                var objectArray2 = new object[] { new TextBox(), 20.17, "okay" };
                w("objectArray2 : " + objectArray2);
                
                // Tableau 2D, 3D, ...etc
                int[,] int2dArray = new int[3, 3];
                int2dArray[0, 0] = 20;
                w("int2dArray : " + int2dArray);
                string[, ,] string3dArray = new string[4, 8, 2];
                string3dArray[1, 7, 1] = "A message";
                w("string3dArray : " + string3dArray);
                
                // Tableau de tableaux (Jagged array)
                int[][] jaggedArray = new int[5][];
                jaggedArray[0] = new int[3];
                jaggedArray[0][0] = 187;
                jaggedArray[0][1] = 47;
                jaggedArray[0][2] = 1000;
                jaggedArray[1] = intArray1;
                jaggedArray[2] = intArray2;
                jaggedArray[3] = intArray3;
                jaggedArray[4] = intArray4;
                w("jaggedArray : " + jaggedArray);
                w("jaggedArray[0] : " + jaggedArray[0]);
                w("jaggedArray[1] : " + jaggedArray[1]);
                w("jaggedArray[2] : " + jaggedArray[2]);
                w("jaggedArray[3] : " + jaggedArray[3]);
                w("jaggedArray[4] : " + jaggedArray[4]);

            // Manipulation des tableaux
            w("");
            string[] lettres = { "D", "C", "A", "B" };
            foreach (string l in lettres)
                w("lettre : " + l);
            string[] caractères = new string[4];
            lettres.CopyTo(caractères, 0);
            w("Copier lettres dans caractères");
            foreach (string c in caractères)
                w("caractère : " + c);
            w("Trier caractères");
            Array.Sort(caractères);
            foreach (string c in caractères)
                w("caractère : " + c);
        }

        private void Write(object message)
        {
            richTextBox1.Text += "♦ " + message.ToString() + Environment.NewLine;
            richTextBox1.Select(richTextBox1.TextLength, 0);
        }
    }
}
