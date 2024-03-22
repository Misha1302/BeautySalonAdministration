namespace BeautySalonAdministration;

using BeautySalonAdministration.Logic;
using BeautySalonAdministration.Logic.Extensions;

public partial class Form2 : Form
{
    public Form2()
    {
        InitializeComponent();
    }


    private void ShowTable()
    {
        CurAppData.CurMonth = MonthExtensions.Months[comboBox1.SelectedIndex];

        var arr = CurAppData.Administration.WorkerTypes.Select(x => new DataGridViewRow()).ToArray();

        dataGridView1.ColumnCount = CurAppData.CurMonth.DaysCount();
        dataGridView1.Columns.ForEach<DataGridViewColumn>((x, i) =>
            x.HeaderText = $"{i + 1}. {i.DayOfWeek(CurAppData.CurMonth)}");
        dataGridView1.Columns.ForEach<DataGridViewColumn>((x, i) => x.Width = 50);
        dataGridView1.Rows.Clear();
        dataGridView1.Rows.AddRange(arr);
        dataGridView1.Rows.RemoveAt(0);

        dataGridView1.Rows.ForEach<DataGridViewRow>((x, i) =>
            x.HeaderCell.Value = CurAppData.Administration.WorkerTypes[i].ToString());

        dataGridView1.Rows.ForEach<DataGridViewRow>((row, _) =>
            row.Cells.ForEach<DataGridViewCell>((cell, i) => cell.Value = i.IsWorkableDay(CurAppData.CurMonth) ? "" : "В"));

        dataGridView1.Rows.ForEach<DataGridViewRow>((x, workerIndex) => x.Cells.ForEach<DataGridViewCell>((x, i) =>
            x.Style.BackColor = CurAppData.Manager.Workers[workerIndex].IsDayFull(i, CurAppData.CurMonth)
                ? Color.White
                : Color.Red));

        dataGridView1.RowHeadersWidth = 150;
    }

    private void Form2_Load(object sender, EventArgs e)
    {
        comboBox1.SelectedIndexChanged += (_, _) => ShowTable();
        comboBox1.SelectedIndex = 0;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        CurAppData.HolidaysForm.Show();

        CurAppData.HolidaysForm.OnNeedToRerender -= ShowTable;
        CurAppData.HolidaysForm.OnNeedToRerender -= Save;

        CurAppData.HolidaysForm.OnNeedToRerender += ShowTable;
        CurAppData.HolidaysForm.OnNeedToRerender += Save;
    }

    private static void Save()
    {
        DataManager.SetAdministration(CurAppData.Administration);
    }

    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            Hide();
        }
    }
}