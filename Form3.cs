using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace DataBase
{
    public partial class Form3 : Form
    {
        int SelectValue;

        private Excel.Application excelapp; // Программа Excel
        private Excel.Window excelWindow; // Окно программы Excel
        private Excel.Workbooks excelappworkbooks; // Рабочие книги
        private Excel.Workbook excelappworkbook; // Рабочая книга
        private Excel.Sheets excelsheets; // Рабочие листы
        private Excel.Worksheet excelworksheet; // Рабочий лист
        private Excel.Range excelcells; // Диапазон ячеек или ячейка

        private Word.Application WordApp; // Программа Word
        private Word.Documents WordDocuments; // Документы
        private Word.Document WordDocument; // Документ
        private Word.Paragraphs WordParagraphs; // Параграфы
        private Word.Paragraph WordParagraph; // Параграф
        private Word.Range WordRange; // Выделенный диапазон

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
                try
                {
                    stopTableAdapter.Delete(ID, Name);
                }
                catch
                {
                    MessageBox.Show("Нельзя удалить остановку, пока она имеет связи");
                }
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
                    MessageBox.Show("Чтобы поставить этим номером данную установку, сначала удалите текщую");
                }

                dataTable2TableAdapter.Connection.Close();
            } // if
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Изменить для второго
            DataRowView drv = dataTable2BindingSource.Current as DataRowView;
            String RType = Convert.ToString(drv.Row["Type"]);
            int Number = Convert.ToInt32(drv.Row["Number"]);
            int StopNumb = Convert.ToInt32(drv.Row["StopNumb"]);

            int Route_ID = Convert.ToInt32(drv.Row["Route_ID"]);
            int Stop_ID = Convert.ToInt32(drv.Row["Stop_ID"]);



            Form6 f6 = new Form6();
            f6.StopNumber = StopNumb;
            f6.comboBox1.Text = RType;
            f6.comboBox2.Text = Convert.ToString(Number);
            f6.ShowDialog();


            if (f6.Rc)
            {
                dataTable2TableAdapter.Connection.Open();
                dataTable2TableAdapter.Adapter.UpdateCommand.Parameters["Route_ID"]
                .Value = Route_ID;
                dataTable2TableAdapter.Adapter.UpdateCommand.Parameters
                ["StopNumb"].Value = f6.StopNumber;
                dataTable2TableAdapter.Adapter.UpdateCommand.Parameters
                ["Original_Route_ID"].Value = Route_ID;
                dataTable2TableAdapter.Adapter.UpdateCommand.Parameters
                ["Original_StopNumb"].Value = StopNumb;
                dataTable2TableAdapter.Adapter.UpdateCommand.Parameters["Stop_ID"].
                Value = Stop_ID;
                dataTable2TableAdapter.Adapter.UpdateCommand.ExecuteNonQuery();
                this.dataTable2TableAdapter.Fill(this.transportDataSet1.DataTable2,
                Route_ID);
                dataTable2TableAdapter.Adapter.Update(this.transportDataSet1.DataTable2);
                dataTable2TableAdapter.Connection.Close();
            }
            stopBindingSource_CurrentChanged(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Удалить для второго
            // Удалить для второго ГридВью
            DataRowView drv = dataTable2BindingSource.Current as DataRowView;
            int Route_ID = Convert.ToInt32(drv.Row["Route_ID"]);
            int StopNumb = Convert.ToInt32(drv.Row["StopNumb"]);
            var result = MessageBox.Show("Удалить остановку?", "Вопрос",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dataTable2TableAdapter.Connection.Open();
                dataTable2TableAdapter.Adapter.DeleteCommand.Parameters["Route_ID"].
                Value = Route_ID;
                dataTable2TableAdapter.Adapter.DeleteCommand.Parameters
                ["StopNumb"].Value = StopNumb;
                dataTable2TableAdapter.Adapter.DeleteCommand.ExecuteNonQuery();
                this.dataTable2TableAdapter.Fill(this.transportDataSet1.DataTable2,
                Route_ID);
                dataTable2TableAdapter.Adapter.Update(this.transportDataSet1.DataTable2);
                dataTable2TableAdapter.Connection.Close();
            }
            stopBindingSource_CurrentChanged(sender, e);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Передать в Excel
            // Запустим Excel
            excelapp = new Excel.Application();
            // Сделаем Excel видимым
            excelapp.Visible = true;
            // В книге, которую создадим позже, будет 3 листа
            excelapp.SheetsInNewWorkbook = 3;
            // Создадим книгу
            excelapp.Workbooks.Add(Type.Missing);
            // Получаем набор ссылок на объекты Workbook (на созданные книги)
            excelappworkbooks = excelapp.Workbooks;
            //Получаем ссылку на книгу 1 - нумерация от 1
            excelappworkbook = excelappworkbooks[1];
            // Получаем ссылку на рабочие листы книги
            excelsheets = excelappworkbook.Worksheets;
            //Получаем ссылку на лист 1
            excelworksheet = (Excel.Worksheet)excelsheets[1];
            // Сделаем первый лист активным
            excelworksheet.Activate();
            // Запишем в ячейку A1
            excelcells = excelworksheet.get_Range("B1", "B1");
            excelcells.Value2 = "Название остановки";


            string[] c = { "A", "B", "C", "D" };
            // Цикл по строкам таблицы
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                // Цикл по столбцам
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    // Вывод в ячейку i+2, j Excel-я содержимого соответствующей ячейки
                    // dataGridView1 
                    excelcells = excelworksheet.get_Range(c[j] + Convert.ToString(i + 2), c[j] +
                    Convert.ToString(i + 2));
                    excelcells.Value2 = dataGridView1.Rows[i].Cells[j].Value.ToString();
                } // for
            } // for

            // Размер 12
            //excelcells.Font.Size = 12;
            //// Выравнивание по центру
            //excelcells.HorizontalAlignment = Excel.Constants.xlCenter; //-4108;



            excelcells = excelworksheet.get_Range("A1", "B" + Convert.ToSingle(dataGridView1.RowCount + 1));
            Excel.XlBordersIndex bi = Excel.XlBordersIndex.xlInsideVertical;
            excelcells.Borders[bi].LineStyle = 1;
            bi = Excel.XlBordersIndex.xlInsideHorizontal;
            excelcells.Borders[bi].LineStyle = 1;
            bi = Excel.XlBordersIndex.xlEdgeLeft;
            excelcells.Borders[bi].LineStyle = 1;
            bi = Excel.XlBordersIndex.xlEdgeTop;
            excelcells.Borders[bi].LineStyle = 1;
            bi = Excel.XlBordersIndex.xlEdgeBottom;
            excelcells.Borders[bi].LineStyle = 1;
            bi = Excel.XlBordersIndex.xlEdgeRight;
            excelcells.Borders[bi].LineStyle = 1;

            excelcells.Font.Size = 12;
            // Выравнивание по центру
            excelcells.HorizontalAlignment = Excel.Constants.xlCenter; //-4108;
                                                                       // Выделим всю таблицу
            excelcells = excelworksheet.get_Range("A1", "B" + Convert.ToSingle(dataGridView1.RowCount + 1));
            // Подгоним ширины столбцов
            excelcells.Columns.AutoFit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Для текущей остановки
            //Передать в Excel
            // Запустим Excel
            excelapp = new Excel.Application();
            // Сделаем Excel видимым
            excelapp.Visible = true;
            // В книге, которую создадим позже, будет 3 листа
            excelapp.SheetsInNewWorkbook = 3;
            // Создадим книгу
            excelapp.Workbooks.Add(Type.Missing);
            // Получаем набор ссылок на объекты Workbook (на созданные книги)
            excelappworkbooks = excelapp.Workbooks;
            //Получаем ссылку на книгу 1 - нумерация от 1
            excelappworkbook = excelappworkbooks[1];
            // Получаем ссылку на рабочие листы книги
            excelsheets = excelappworkbook.Worksheets;
            //Получаем ссылку на лист 1
            excelworksheet = (Excel.Worksheet)excelsheets[1];
            // Сделаем первый лист активным
            excelworksheet.Activate();
            // Запишем в ячейку A1
            excelcells = excelworksheet.get_Range("A1", "A1");
            excelcells.Value2 = "Вид транспорта";
            // Запишем в ячейку B1
            excelcells = excelworksheet.get_Range("B1", "B1");
            excelcells.Value2 = "Номер маршрута";
            // Запишем в ячейку C1
            excelcells = excelworksheet.get_Range("C1", "C1");
            excelcells.Value2 = "Номер остановки";

            string[] c = { "A", "B", "C"};
            // Цикл по строкам таблицы
            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            {
                // Цикл по столбцам
                for (int j = 2; j < dataGridView2.ColumnCount; j++)
                {
                    excelcells = excelworksheet.get_Range(c[j-2] + Convert.ToString(i + 2), c[j-2] + Convert.ToString(i + 2));
                    excelcells.Value2 = dataGridView2.Rows[i].Cells[j].Value.ToString();
                } // for
            } // for

            excelcells = excelworksheet.get_Range("A1", "C" + Convert.ToSingle(dataGridView2.RowCount));
            Excel.XlBordersIndex bi = Excel.XlBordersIndex.xlInsideVertical;
            excelcells.Borders[bi].LineStyle = 1;
            bi = Excel.XlBordersIndex.xlInsideHorizontal;
            excelcells.Borders[bi].LineStyle = 1;
            bi = Excel.XlBordersIndex.xlEdgeLeft;
            excelcells.Borders[bi].LineStyle = 1;
            bi = Excel.XlBordersIndex.xlEdgeTop;
            excelcells.Borders[bi].LineStyle = 1;
            bi = Excel.XlBordersIndex.xlEdgeBottom;
            excelcells.Borders[bi].LineStyle = 1;
            bi = Excel.XlBordersIndex.xlEdgeRight;
            excelcells.Borders[bi].LineStyle = 1;

            excelcells.Font.Size = 12;
            // Выравнивание по центру
            excelcells.HorizontalAlignment = Excel.Constants.xlCenter; //-4108;
                                                                       // Выделим всю таблицу
            excelcells = excelworksheet.get_Range("A1", "C" + Convert.ToSingle(dataGridView1.RowCount));
            // Подгоним ширины столбцов
            excelcells.Columns.AutoFit();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            //Для закрепления полученных знаний, самостоятельно выведите в Word
            //список остановок и маршрутов, проходящих через остановку


            // Запускаем Word
            WordApp = new Word.Application();
            // Делаем Word видимым
            WordApp.Visible = true;

            WordDocuments = WordApp.Documents;
            // Добавляем документ
            WordDocument = WordDocuments.Add();

            // Получаем доступ к объекту все параграфы
            WordParagraphs = WordDocument.Content.Paragraphs;
            // Получаем доступ к объекту первый параграф
            WordParagraph = WordParagraphs[1];
            // Устанавливаем выравнивание по центру
            WordParagraph.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;
            // Получаем доступ к объекту выделенный участок
            WordRange = WordParagraph.Range;
            // Добавим текст в выделенный участок

            WordRange.InsertAfter("Остановки общественного транспорта\n");
            // Сделаем шрифт выделенного участка жирным
            WordRange.Font.Bold = 1;
            // Сделаем размер шрифта выделенного участка равным 16
            WordRange.Font.Size = 16;
            // Сбросим выделение участка
            WordRange.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
            // Сейчас выделенным участком будет пустой участок в конце текста
            WordRange = WordParagraph.Range;
            // Добавим текст, он будет выделенным участком.
            WordRange.InsertAfter("по состоянию на " +
             DateTime.Now.ToLongDateString() + "\n");
            // Сделаем шрифт выделенного участка нежирным
            WordRange.Font.Bold = 0;
            // Сделаем размер шрифта выделенного участка равным 14
            WordRange.Font.Size = 14;
            int i = 0, j = 0;
            // Цикл по записям таблицы route
            for (stopBindingSource.MoveFirst(); i < stopBindingSource.Count;
 stopBindingSource.MoveNext())
            {
                // Получаем доступ к объекту текущая запись таблицы stop
                DataRowView drv1 = stopBindingSource.Current as DataRowView;

                int Stop_ID = Convert.ToInt32(drv1.Row["Stop_ID"]);
                string Name = drv1.Row["Name"].ToString();
                // Добавим параграф
                WordParagraph = WordParagraphs.Add();
                // Устанавливаем выравнивание по левой границе
                WordParagraph.Alignment =
                Word.WdParagraphAlignment.wdAlignParagraphLeft;
                // Получим доступ к выделенному участку нового параграфа
                WordRange = WordParagraph.Range;
                // Установим шрифт выделенного участка нового параграфа
                WordRange.Font.Bold = 0;
                WordRange.Font.Size = 12;
                // Добавим текст в новый параграф
                WordRange.InsertAfter(Convert.ToString(Stop_ID) + ". " + Name);

                j = 0;
                // Заполним набор данных DataTable1
                dataTable2TableAdapter.Fill(transportDataSet1.DataTable2, Stop_ID);
                // Цикл по записям таблицы DataTable1
                for (dataTable2BindingSource.MoveFirst();
                j < dataTable2BindingSource.Count;
                dataTable2BindingSource.MoveNext())
                {
                    // Получаем доступ к объекту текущая запись DataTable1
                    DataRowView drv2 = dataTable2BindingSource.Current as
                    DataRowView;
                    // Получаем значения полей StopNumb, number
                    int StopNumb = Convert.ToInt32(drv2.Row["StopNumb"]);
                    int Numbr = Convert.ToInt32(drv2.Row["Number"]);
                    string RType = drv2.Row["Type"].ToString();
                    // Добавим параграф
                    WordParagraph = WordParagraphs.Add();
                    // Устанавливаем выравнивание по левой границе
                    WordParagraph.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    // Получим доступ к выделенному участку нового параграфа
                    WordRange = WordParagraph.Range;
                    // Установим шрифт выделенного участка нового параграфа
                    WordRange.Font.Bold = 0;
                    WordRange.Font.Size = 12;
                    // Добавим текст в новый параграф
                    WordRange.InsertAfter("\t"  + "— " + RType + " " + Convert.ToString(Numbr) + ". Номер остановки: " + Convert.ToString(StopNumb));
                    j++;
                } // for
                i++;
            } // f
        }
    }
}
