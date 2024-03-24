namespace BeautySalonAdministration;

using BeautySalonAdministration.Logic.Extensions;

public partial class Form2 : Form
{
    public Form2()
    {
        InitializeComponent();
    }


    private void ShowTable()
    {
        var curMonth = MonthExtensions.Months[comboBox1.SelectedIndex];

        var arr = CurAppData.Manager.GetWorkers().Select(x => new DataGridViewRow()).ToArray();


        dataGridView1.ColumnCount = curMonth.DaysCount();
        dataGridView1.Columns.ForEach<DataGridViewColumn>((x, i) =>
            x.HeaderText = $"{i + 1}. {i.DayOfWeek(curMonth)}");
        dataGridView1.Columns.ForEach<DataGridViewColumn>((x, i) => x.Width = 50);
        dataGridView1.Rows.Clear();
        dataGridView1.Rows.AddRange(arr);
        dataGridView1.Rows.RemoveAt(0);

        dataGridView1.Rows.ForEach<DataGridViewRow>((x, i) =>
            x.HeaderCell.Value = CurAppData.Manager.GetWorker(i).WorkerType.ToString());

        dataGridView1.Rows.ForEach<DataGridViewRow>((x, workerIndex) => x.Cells.ForEach<DataGridViewCell>((x, i) =>
            x.Style.BackColor = !CurAppData.Manager.GetWorker(workerIndex).IsDayFull(i, curMonth)
                ? Color.White
                : Color.Red));

        dataGridView1.Rows.ForEach<DataGridViewRow>((x, workerIndex) => x.Cells.ForEach<DataGridViewCell>((x, i) =>
            x.Value = CurAppData.Manager.GetWorker(workerIndex).IsHoliday(i, curMonth)
                ? "В"
                : ""));

        dataGridView1.RowHeadersWidth = 150;
    }

    private void Form2_Load(object sender, EventArgs e)
    {
        label1.Text = CurAppData.Manager.Login;
        comboBox1.SelectedIndexChanged += (_, _) => ShowTable();
        comboBox1.SelectedIndex = 0;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        CurAppData.HolidaysForm.Show();

        CurAppData.HolidaysForm.OnNeedToRerender -= ShowTable;
        CurAppData.HolidaysForm.OnNeedToRerender -= CurAppData.Save;

        CurAppData.HolidaysForm.OnNeedToRerender += ShowTable;
        CurAppData.HolidaysForm.OnNeedToRerender += CurAppData.Save;
    }

    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            Hide();
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        CurAppData.WorkerForm.Show();

        CurAppData.WorkerForm.NeedToRerender -= ShowTable;
        CurAppData.WorkerForm.NeedToRerender += ShowTable;
    }

    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        var pos = (dataGridView1.SelectedCells[0].ColumnIndex, dataGridView1.SelectedCells[0].RowIndex);
        CurAppData.RealtimeData.Pos = pos;

        CurAppData.Form3.Show();

        CurAppData.Form3.NeedToRerender -= ShowTable;
        CurAppData.Form3.NeedToRerender += ShowTable;
    }
}