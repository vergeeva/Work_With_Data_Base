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
    public partial class Form3 : Form
    {
        int SelectValue;
        public Form3()
        {
            InitializeComponent();
        }
        public int SelectedValue
        {
            get { return SelectValue; }
            set { SelectValue = value; }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "transportDataSet.Route". При необходимости она может быть перемещена или удалена.
            this.routeTableAdapter.Fill(this.transportDataSet.Route);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "transportDataSet.StopInRoute". При необходимости она может быть перемещена или удалена.
            this.stopInRouteTableAdapter.Fill(this.transportDataSet.StopInRoute);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "transportDataSet.Stop". При необходимости она может быть перемещена или удалена.
            this.stopTableAdapter.Fill(this.transportDataSet.Stop);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Добавить
            Form4 f4 = new Form4();
            f4.ShowDialog();
            if (f4.Rc)
            {
                stopTableAdapter.Insert(f4.NameOfStop);
                this.stopTableAdapter.Fill(this.transportDataSet.Stop);
            } // if
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Изменить
            Int32 ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            String NameofStop = dataGridView1.CurrentRow.Cells[1].Value as String;

            Form4 f4 = new Form4
            {
                NameOfStop = NameofStop
            };

            f4.ShowDialog();
            if (f4.Rc)
            {
                stopTableAdapter.Update(f4.NameOfStop, ID, NameofStop);
                this.stopTableAdapter.Fill(this.transportDataSet.Stop);
            } // if
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Удалить остановку?", "Вопрос",
MessageBoxButtons.YesNo,
MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow dgvr = dataGridView1.CurrentRow;
                Int32 ID = Convert.ToInt32(dgvr.Cells[0].Value);
                String Name = dgvr.Cells[1].Value as String;
                stopTableAdapter.Delete(ID, Name);
                this.stopTableAdapter.Fill(this.transportDataSet.Stop);
            }
        }


        private void stopBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            // Определим текущую запись
            DataRowView drv = stopBindingSource.Current as DataRowView;
            // Определим значение поля Route_ID текущей записи
            int Stop_ID = 0;
            if (drv != null)
            {
                Stop_ID = Convert.ToInt32(drv.Row["Stop_ID"]);
            } // if
              // Выполним оператор select адаптера dataTable1TableAdapter с
              // параметром Route_ID и заполним dataTable1BindingSource
            dataTable2TableAdapter.Fill(transportDataSet1.DataTable2, Stop_ID);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Добавить для второго ГридВью

            // Определим текущую запись
            DataRowView drv = stopBindingSource.Current as DataRowView;
            // Определим значение поля Route_ID текущей записи
            int Stop_ID = Convert.ToInt32(drv.Row["Stop_ID"]);
            // Создадим форму Form5
            Form6 f6 = new Form6();
            // Вызовем форму Form5
            f6.ShowDialog();
            // Если нажали кнопку <OK>
            if (f6.Rc)
            {
                // Откроем подключение адаптера к базе данных
                dataTable2TableAdapter.Connection.Open();
                // Зададим параметры запроса
                dataTable2TableAdapter.Adapter.InsertCommand.Parameters["Stop_ID"].
                Value = Stop_ID;
                dataTable2TableAdapter.Adapter.InsertCommand.Parameters["StopNumb"].
                Value = f6.StopNumber;
                dataTable2TableAdapter.Adapter.InsertCommand.Parameters["Route_ID"].
                Value = f6.Route_ID;
                try
                {
                    // Выполним запрос insert
                    dataTable2TableAdapter.Adapter.InsertCommand.ExecuteNonQuery();
                    // Для обновления таблицы выполним запрос select и перезаполним
                    // dataTable1BindingSource
                    this.dataTable2TableAdapter.Fill(this.transportDataSet1.DataTable2,
                    Stop_ID);
                    // Подтвердим изменения в базе
                    dataTable2TableAdapter.Adapter.Update(this.transportDataSet1.DataTable2);
                    // Закроем подключение адаптера к базе данных
                }
                catch (Exception)
                {
                    throw;
                }

                dataTable2TableAdapter.Connection.Close();
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
            //// Удалить для второго ГридВью
            //DataRowView drv = dataTable2BindingSource.Current as DataRowView;
            //int Stop_ID = Convert.ToInt32(drv.Row["Stop_ID"]);
            //int StopNumb = Convert.ToInt32(drv.Row["StopNumb"]);
            //var result = MessageBox.Show("Удалить из маршрута?", "Вопрос",
            //MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    dataTable2TableAdapter.Connection.Open();
            //    dataTable2TableAdapter.Adapter.DeleteCommand.Parameters["Stop_ID"].
            //    Value = Stop_ID;
            //    dataTable2TableAdapter.Adapter.DeleteCommand.Parameters
            //    ["StopNumb"].Value = StopNumb;
            //    dataTable2TableAdapter.Adapter.DeleteCommand.ExecuteNonQuery();
            //    this.dataTable2TableAdapter.Fill(this.transportDataSet1.DataTable2,
            //    Stop_ID);
            //    dataTable2TableAdapter.Adapter.Update(this.transportDataSet1.DataTable2);
            //    dataTable2TableAdapter.Connection.Close();
            //}
        }
    }
}
