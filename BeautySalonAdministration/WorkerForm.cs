using BeautySalonAdministration.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeautySalonAdministration
{
    public partial class WorkerForm : Form
    {
        public Action? NeedToRerender;

        public WorkerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var list = textBox2.Text;

            CurAppData.Administration.AddWorkerType(new WorkerType(name, [.. list.Split("\n")]));
            UpdateList();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            CurAppData.Administration.RemoveWorkerType(comboBox1.Text);
            UpdateList();
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            UpdateList();
            comboBox1.SelectedItem = 0;
        }

        private void UpdateList()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(CurAppData.Administration.GetWorkerTypes().Cast<object>().ToArray());
            NeedToRerender?.Invoke();
            CurAppData.Save();
        }

        private void WorkerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
