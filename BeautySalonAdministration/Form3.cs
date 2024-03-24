using BeautySalonAdministration.Logic.Extensions;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BeautySalonAdministration
{
    public partial class Form3 : Form
    {
        public Action? NeedToRerender;

        private static Logic.Day CurDay => CurAppData.Manager.GetWorker(CurAppData.RealtimeData.Pos.RowIndex).Calendar.Days[CurAppData.RealtimeData.Month.GetDayIndex(CurAppData.RealtimeData.Pos.ColumnIndex)];

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var records = CurDay.Records;

            for (int i = 0; i < records.Count; i++)
            {
                var cells = dataGridView1.Rows[i].Cells;

                var strings = ((string)cells[2].Value ?? "").Split(" ");

                bool parsed = int.TryParse((string)cells[4].Value ?? "", out var price);
                var record = records[i] with
                {
                    Time = ToTime((string)cells[0].Value ?? ""),
                    ServiceType = (string)cells[1].Value ?? "",
                    Name = strings.Length > 0 ? strings[0] : "",
                    Surname = strings.Length > 1 ? strings[1] : "",
                    Patronymic = strings.Length > 2 ? strings[2] : "",
                    PhoneNumber = (string)cells[3].Value ?? "",
                    Price = parsed ? price : -1
                };

                records[i] = record;
            }

            CurAppData.Save();
            NeedToRerender?.Invoke();
        }

        private static float ToTime(string value)
        {
            string[] strings = value.Split(":");
            return float.Parse(strings[0]) + float.Parse(strings[1]) / 60f;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
        }

        private void Form3_Activated(object sender, EventArgs e)
        {
            label1.Text = CurAppData.Manager.GetWorker(CurAppData.RealtimeData.Pos.RowIndex).WorkerType.Name;
            label2.Text = $"{CurAppData.RealtimeData.Pos.ColumnIndex + 1} {MonthExtensions.RuMonths[CurAppData.RealtimeData.Month]}";

            // добавить вид процедуры
            dataGridView1.AllowUserToAddRows = dataGridView1.AllowUserToDeleteRows = false;

            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("column name", "Время");
            dataGridView1.Columns[0].ReadOnly = true;

            dataGridView1.Columns.Add("column name", "Услуга");
            int serviceColumnIndex = dataGridView1.Columns.Count - 1;

            dataGridView1.Columns.Add("column name", "ФИО");
            dataGridView1.Columns.Add("column name", "Номер");
            dataGridView1.Columns.Add("column name", "Цена");


            dataGridView1.Rows.Clear();

            for (int i = 0; i < CurDay.Records.Count; i++)
            {
                Logic.Record item = CurDay.Records[i];
                dataGridView1.Rows.Add($"{item.Time - item.Time % 1f}:{(item.Time % 1f * 60f).ToString().PadRight(2, '0')}", $"{item.ServiceType}", $"{item.Surname} {item.Name} {item.Patronymic}", $"{item.PhoneNumber}", $"{item.Price}");

                AddServices(serviceColumnIndex, CurAppData.RealtimeData.Pos.RowIndex, item.ServiceType);
            }
        }

        private void AddServices(int serviceColumnIndex, int workerIndex, string defaultValue)
        {
            var cmbbox = new DataGridViewComboBoxCell();

            foreach (var item in CurAppData.Manager.GetWorker(workerIndex).WorkerType.List)
                cmbbox.Items.Add(item);

            cmbbox.Value = defaultValue;

            dataGridView1.Rows[^1].Cells[serviceColumnIndex] = cmbbox;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Next(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Next(-1);
        }

        private static void Next(int index)
        {
            CurAppData.RealtimeData.Pos.ColumnIndex = Math.Clamp(CurAppData.RealtimeData.Pos.ColumnIndex + index, 0, CurAppData.RealtimeData.Month.DaysCount() - 1);
            CurAppData.Form3.Hide();
            CurAppData.Form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form3Printer(this).Print();
        }
    }

    public class Form3Printer
    {
        private PrintDocument printDocument1 = new PrintDocument();
        Bitmap memoryImage;

        public Form3Printer(Form form)
        {
            printDocument1.PrintPage += printDocument1_PrintPage;
            Form = form;
        }

        public Form Form { get; }

        public void Print()
        {
            CaptureScreen();
            printDocument1.Print();
        }

        private void CaptureScreen()
        {
            Graphics myGraphics = Form.CreateGraphics();
            Size s = Form.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(Form.Location.X, Form.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
    }
}
