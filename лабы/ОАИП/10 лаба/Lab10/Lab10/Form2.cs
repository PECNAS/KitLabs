using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab10
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            dataGridView1.Dock = DockStyle.Fill;

            var columnType = new DataGridViewTextBoxColumn();
            columnType.HeaderText = "Сортировка";
            dataGridView1.Columns.Add(columnType);

            var columnCount = new DataGridViewTextBoxColumn();
            columnCount.HeaderText = "Кол-во";
            dataGridView1.Columns.Add(columnCount);

            var columnComparisons = new DataGridViewTextBoxColumn();
            columnComparisons.HeaderText = "Сравнений";
            dataGridView1.Columns.Add(columnComparisons);

            var columnPermutations = new DataGridViewTextBoxColumn();
            columnPermutations.HeaderText = "Перестановок";
            dataGridView1.Columns.Add(columnPermutations);

            var columnTime = new DataGridViewTextBoxColumn();
            columnTime.HeaderText = "Время";
            dataGridView1.Columns.Add(columnTime);

            AnalInfo[] simpleSorts =
            {
                new AnalInfo() { count = 100 },
                new AnalInfo() { count = 1000 },
                new AnalInfo() { count = 10000 }
            };
            foreach (var sort in simpleSorts)
            {
                Random random = new Random();
                int[] newArr = new int[sort.count];
                
                for (int i = 0; i < newArr.Length; i++)
                    newArr[i] = random.Next(0, 100);
                Context.array = newArr;
                new Context(new SimpleSort()).SortArr(sort,false);
                dataGridView1.Rows.Add("Метод выбора",sort.count,sort.comparisons,sort.permutations,sort.time);
            }
            AnalInfo[] simpleSorts1 =
            {
                new AnalInfo() { count = 100 },
                new AnalInfo() { count= 1000 },
                new AnalInfo() { count = 10000 }
            };
            foreach (var sort in simpleSorts1)
            {
                Random random = new Random();
                int[] newArr = new int[sort.count];

                for (int i = 0; i < newArr.Length; i++)
                    newArr[i] = random.Next(0, 100);
                Context.array = newArr;
                new Context(new ImprovedSort()).SortArr(sort,false);
                dataGridView1.Rows.Add("Метод поразрядной сортировки", sort.count, sort.comparisons, sort.permutations, sort.time);
            }
            FileOut.fileString = null;
        }
    }
}
