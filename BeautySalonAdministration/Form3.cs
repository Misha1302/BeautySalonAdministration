using BeautySalonAdministration.Logic.Extensions;
using System.Diagnostics;

namespace BeautySalonAdministration
{
    public partial class Form3 : Form
    {
        public Action? NeedToRerender;

        private static Logic.Day CurDay => CurAppData.Manager.Workers[CurAppData.RealtimeData.Pos.RowIndex].Calendar.Days[CurAppData.RealtimeData.Month.GetDayIndex(CurAppData.RealtimeData.Pos.ColumnIndex)];

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

                var strings = ((string)cells[1].Value ?? "").Split(" ");

                bool parsed = int.TryParse((string)cells[3].Value ?? "", out var price);
                var record = records[i] with
                {
                    Time = ToTime((string)cells[0].Value ?? ""),
                    Name = strings.Length > 0 ? strings[0] : "",
                    Surname = strings.Length > 1 ? strings[1] : "",
                    Patronymic = strings.Length > 2 ? strings[2] : "",
                    PhoneNumber = (string)cells[2].Value ?? "",
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
            dataGridView1.AllowUserToAddRows = dataGridView1.AllowUserToDeleteRows = false;

            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("column name", "Время");
            dataGridView1.Columns[0].ReadOnly = true;

            dataGridView1.Columns.Add("column name", "ФИО");
            dataGridView1.Columns.Add("column name", "Номер");
            dataGridView1.Columns.Add("column name", "Цена");


            dataGridView1.Rows.Clear();

            foreach (var item in CurDay.Records)
            {
                dataGridView1.Rows.Add($"{item.Time - item.Time % 1f}:{(item.Time % 1f * 60f).ToString().PadRight(2, '0')}", $"{item.Name} {item.Surname} {item.Patronymic}", $"{item.PhoneNumber}", $"{item.Price}");
            }
        }
    }
}
