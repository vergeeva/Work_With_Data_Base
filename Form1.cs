using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Form1 : Form
    {
        int SelectValue;
        public int SelectedValue
        {
            get { return SelectValue; }
            set { SelectValue = value; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "transportDataSet.Route". При необходимости она может быть перемещена или удалена.
            this.routeTableAdapter.Fill(this.transportDataSet.Route);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Добавить
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if (f2.Rc)
            {
                routeTableAdapter.Insert(f2.Type, f2.Number, f2.Comment);
                this.routeTableAdapter.Fill(this.transportDataSet.Route);
            } // if
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Изменить
            Int32 ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            String Type = dataGridView1.CurrentRow.Cells[1].Value as String;
            Int32 Number = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
            String Comment = dataGridView1.CurrentRow.Cells[3].Value as String;
            Form2 f2 = new Form2();
            f2.Type = Type;
            f2.Number = Number;
            f2.Comment = Comment;
            f2.ShowDialog();
            if (f2.Rc)
            {
                routeTableAdapter.Update(f2.Type, f2.Number, f2.Comment,
                ID, Type, Number, Comment);
                this.routeTableAdapter.Fill(this.transportDataSet.Route);
            } // if
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Удалить
            var result = MessageBox.Show("Удалить маршрут?", "Вопрос",
 MessageBoxButtons.YesNo,
 MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow dgvr = dataGridView1.CurrentRow;
                Int32 ID = Convert.ToInt32(dgvr.Cells[0].Value);
                String Type = dgvr.Cells[1].Value as String;
                Int32 Number = Convert.ToInt32(dgvr.Cells[2].Value);
                String Comment = dgvr.Cells[3].Value as String;
                routeTableAdapter.Delete(ID, Type, Number, Comment);
                this.routeTableAdapter.Fill(this.transportDataSet.Route);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void routeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            // Определим текущую запись
            DataRowView drv = routeBindingSource.Current as DataRowView;
            // Определим значение поля Route_ID текущей записи
            int Route_ID = 0;
            if (drv != null)
            {
                Route_ID = Convert.ToInt32(drv.Row["Route_ID"]);
            } // if
              // Выполним оператор select адаптера dataTable1TableAdapter с
              // параметром Route_ID и заполним dataTable1BindingSource
            dataTable1TableAdapter.Fill(transportDataSet.DataTable1, Route_ID);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Добавить для второго ГридВью

            // Определим текущую запись
            DataRowView drv = routeBindingSource.Current as DataRowView;
            // Определим значение поля Route_ID текущей записи
            int Route_ID = Convert.ToInt32(drv.Row["Route_ID"]);
            // Создадим форму Form5
            Form5 f5 = new Form5();
            // Вызовем форму Form5
            f5.ShowDialog();
            // Если нажали кнопку <OK>
            if (f5.Rc)
            {
                // Откроем подключение адаптера к базе данных
                dataTable1TableAdapter.Connection.Open();
                // Зададим параметры запроса
                dataTable1TableAdapter.Adapter.InsertCommand.Parameters["Route_ID"].
                Value = Route_ID;
                dataTable1TableAdapter.Adapter.InsertCommand.Parameters["StopNumb"].
                Value = f5.StopNumber;
                dataTable1TableAdapter.Adapter.InsertCommand.Parameters["Stop_ID"].
                Value = f5.Stop_ID;

                // Выполним запрос insert
                dataTable1TableAdapter.Adapter.InsertCommand.ExecuteNonQuery();
                // Для обновления таблицы выполним запрос select и перезаполним
                // dataTable1BindingSource
                this.dataTable1TableAdapter.Fill(this.transportDataSet.DataTable1,
                Route_ID);
                // Подтвердим изменения в базе
                dataTable1TableAdapter.Adapter.Update(this.transportDataSet.DataTable1);
                // Закроем подключение адаптера к базе данных
                dataTable1TableAdapter.Connection.Close();
            } // if
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Изменить для втоого ГридВью
            DataRowView drv = dataTable1BindingSource.Current as DataRowView;
            int Route_ID = Convert.ToInt32(drv.Row["Route_ID"]);
            int Stop_ID = Convert.ToInt32(drv.Row["Stop_ID"]);
            int StopNumb = Convert.ToInt32(drv.Row["StopNumb"]);
            Form5 f5 = new Form5();
            f5.StopNumber = StopNumb;
            f5.Stop_ID = Stop_ID;
            f5.ShowDialog();

            if (f5.Rc)
            {
                dataTable1TableAdapter.Connection.Open();
                dataTable1TableAdapter.Adapter.UpdateCommand.Parameters["Route_ID"]
                .Value = Route_ID;
                dataTable1TableAdapter.Adapter.UpdateCommand.Parameters
                ["StopNumb"].Value = f5.StopNumber;
                dataTable1TableAdapter.Adapter.UpdateCommand.Parameters
                ["Original_Route_ID"].Value = Route_ID;
                dataTable1TableAdapter.Adapter.UpdateCommand.Parameters
                ["Original_StopNumb"].Value = StopNumb;
                dataTable1TableAdapter.Adapter.UpdateCommand.Parameters["Stop_ID"].
                Value = f5.Stop_ID;
                dataTable1TableAdapter.Adapter.UpdateCommand.ExecuteNonQuery();
                this.dataTable1TableAdapter.Fill(this.transportDataSet.DataTable1,
                Route_ID);
                dataTable1TableAdapter.Adapter.Update(this.transportDataSet.DataTable1);
                dataTable1TableAdapter.Connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Удалить для второго ГридВью
            DataRowView drv = dataTable1BindingSource.Current as DataRowView;
            int Route_ID = Convert.ToInt32(drv.Row["Route_ID"]);
            int StopNumb = Convert.ToInt32(drv.Row["StopNumb"]);
            var result = MessageBox.Show("Удалить остановку?", "Вопрос",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dataTable1TableAdapter.Connection.Open();
                dataTable1TableAdapter.Adapter.DeleteCommand.Parameters["Route_ID"].
                Value = Route_ID;
                dataTable1TableAdapter.Adapter.DeleteCommand.Parameters
                ["StopNumb"].Value = StopNumb;
                dataTable1TableAdapter.Adapter.DeleteCommand.ExecuteNonQuery();
                this.dataTable1TableAdapter.Fill(this.transportDataSet.DataTable1,
                Route_ID);
                dataTable1TableAdapter.Adapter.Update(this.transportDataSet.DataTable1);
                dataTable1TableAdapter.Connection.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Close();
        }

    }
}
