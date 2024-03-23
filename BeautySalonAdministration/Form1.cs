namespace BeautySalonAdministration;

using BeautySalonAdministration.Logic;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        CurAppData.Administration = DataManager.GetAdministration();
        CurAppData.Form1 = this;
        CurAppData.Form2 = new Form2();
        CurAppData.HolidaysForm = new HolidaysForm();
        // CurAppData.Form3 = new Form3();

        CurAppData.Form2.Hide();
        CurAppData.HolidaysForm.Hide();
        // CurAppData.Form3.Hide();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var manager =
            CurAppData.Administration.Managers.Find(x => x.Login == textBox1.Text && x.Password == textBox2.Text);
        if (manager == null)
        {
            MessageBox.Show($"Не удалось найти менеджера с логином '{textBox1.Text}' и паролем '{textBox2.Text}'");
        }
        else
        {
            CurAppData.Manager = manager;

            CurAppData.Form1.Hide();
            CurAppData.Form2.Show();
        }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            Hide();
        }
    }
}