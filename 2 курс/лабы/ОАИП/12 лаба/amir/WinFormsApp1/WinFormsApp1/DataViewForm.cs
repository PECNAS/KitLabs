
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class DataViewForm : Form
    {
        public DataViewForm()
        {
            InitializeComponent();
            this.UpdateDataTable();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var win = new InsertForm();
            win.ShowDialog();
            UpdateDataTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selected = DataTable.SelectedRows;

            if (selected.Count == 0)
            {
                MessageBox.Show("Строка не выбрана!");
                return;
            }

            var result = MessageBox.Show("Уверены, что хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (var db = new MobileContext())
                {
                    int id = ((Notion)selected[0].DataBoundItem).Id;
                    db.Notions.Remove(
                        db.Notions.First(x => x.Id == id)
                        );
                    db.SaveChanges();
                }

                UpdateDataTable();
                MessageBox.Show("Удаление прошло успешно!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) this.Close();

        }

        private void DataTable_SelectionChanged(object sender, EventArgs e)
        {
            MessageBox.Show(DataTable.SelectedCells.Count.ToString());
        }

        private void UpdateDataTable()
        {
            using (var db = new MobileContext())
            {
                DataTable.DataSource = db.Notions.ToList();
            }
        }
    }
}
