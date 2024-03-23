namespace BeautySalonAdministration;

using BeautySalonAdministration.Logic.Extensions;

public partial class HolidaysForm : Form
{
    public Action? OnNeedToRerender;

    public HolidaysForm()
    {
        InitializeComponent();
    }

    private void HolidaysForm_Load(object sender, EventArgs e)
    {
        comboBox1.SelectedIndexChanged += (_, _) =>
        {
            var items = Enumerable.Range(1, MonthExtensions.Months[comboBox1.SelectedIndex].DaysCount()).Cast<object>()
                .ToArray();
            comboBox2.Items.AddRange(items);
            comboBox3.Items.AddRange(items);

            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        };

        comboBox1.SelectedIndex = 0;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        SetHolidays(true);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        SetHolidays(false);
    }

    private void SetHolidays(bool active)
    {
        var start = int.Parse(comboBox2.Text);
        var end = int.Parse(comboBox3.Text);
        var month = MonthExtensions.Months[comboBox1.SelectedIndex];

        for (var i = start; i <= end; i++) 
            CurAppData.Administration.Holidays[month.GetDayIndex(i - 1)] = active;

        OnNeedToRerender?.Invoke();
    }

    private void HolidaysForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            Hide();
        }
    }
}