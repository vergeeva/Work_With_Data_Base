using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
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

        private void button9_Click(object sender, EventArgs e)
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
            excelcells.Value2 = "Тип";
            // Запишем в ячейку B1
            excelcells = excelworksheet.get_Range("C1", "C1");
            excelcells.Value2 = "Номер";
            // Запишем в ячейку C1
            excelcells = excelworksheet.get_Range("D1", "D1");
            excelcells.Value2 = "Маршрут";

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



            excelcells = excelworksheet.get_Range("A1", "D" +
Convert.ToSingle(dataGridView1.RowCount + 1));
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

            // Размер 12
            excelcells.Font.Size = 12;
            // Выравнивание по центру
            excelcells.HorizontalAlignment = Excel.Constants.xlCenter; //-4108;

            // Выделим всю таблицу
            excelcells = excelworksheet.get_Range("A1", "D" + Convert.ToSingle(dataGridView1.RowCount + 1));
            // Подгоним ширины столбцов
            excelcells.Columns.AutoFit();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Второй способ Эксель

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

            excelcells = excelworksheet.get_Range("A1", "A1");
            excelcells.Value2 = "Номер";
            // Запишем в ячейку B1
            excelcells = excelworksheet.get_Range("B1", "B1");
            excelcells.Value2 = "Название";

            int i = 2;
            // Цикл по строкам таблицы, dr-текущая строка BindingSource
            foreach (DataRowView dr in dataTable1BindingSource)
            {
                // Из поля StopNumb получим номер остановки
                int StopNumb = Convert.ToInt32(dr.Row["StopNumb"]);
                // Из поля Name получим название остановки
                string StopName = dr.Row["Name"].ToString();
                // Запишем в i-ю строку Excel таблицы
                excelcells = excelworksheet.get_Range("A" + Convert.ToString(i), "A" +
               Convert.ToString(i));
                excelcells.Value2 = Convert.ToString(StopNumb);
                excelcells = excelworksheet.get_Range("B" + Convert.ToString(i), "B" +
               Convert.ToString(i));
                excelcells.Value2 = Convert.ToString(StopName);
                i++;
            }



            excelcells = excelworksheet.get_Range("A1", "B" + Convert.ToSingle(dataGridView2.RowCount));
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

            // Размер 12
            excelcells.Font.Size = 12;
            // Выравнивание по центру
            excelcells.HorizontalAlignment = Excel.Constants.xlCenter; //-4108;

            // Выделим всю таблицу
            excelcells = excelworksheet.get_Range("A1", "B" + Convert.ToSingle(dataGridView2.RowCount));
            // Подгоним ширины столбцов
            excelcells.Columns.AutoFit();
        }

        private void button11_Click(object sender, EventArgs e)
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
            WordRange.InsertAfter("Маршруты общественного транспорта\n");
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
            for (routeBindingSource.MoveFirst();i < routeBindingSource.Count;
 routeBindingSource.MoveNext())
            {
                // Получаем доступ к объекту текущая запись таблицы route
                DataRowView drv1 = routeBindingSource.Current as DataRowView;
                // Получаем значения полей Route_ID, Number, Type, Comment
                int Route_ID = Convert.ToInt32(drv1.Row["Route_ID"]);
                int Number = Convert.ToInt32(drv1.Row["Number"]);
                string Type = drv1.Row["Type"].ToString();
                string Comment = drv1.Row["Comment"].ToString();
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
                WordRange.InsertAfter(Convert.ToString(Route_ID) + ". " + Type + " " + Number + " " + Comment);
               
                j = 0;
                // Заполним набор данных DataTable1
                dataTable1TableAdapter.Fill(transportDataSet.DataTable1, Route_ID);
                // Цикл по записям таблицы DataTable1
                for (dataTable1BindingSource.MoveFirst();
                j < dataTable1BindingSource.Count;
                dataTable1BindingSource.MoveNext())
                {
                    // Получаем доступ к объекту текущая запись DataTable1
                    DataRowView drv2 = dataTable1BindingSource.Current as
                    DataRowView;
                    // Получаем значения полей StopNumb, Name
                    int StopNumb = Convert.ToInt32(drv2.Row["StopNumb"]);
                    string _Name = drv2.Row["Name"].ToString();
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
                    WordRange.InsertAfter("\t" + Convert.ToString(StopNumb) + ". " +
                    _Name);
                    j++;
                } // for
                i++;
            } // f
        }
    }
}
