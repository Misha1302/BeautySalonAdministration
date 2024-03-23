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
        public WorkerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var list = textBox2.Text;

            CurAppData.Administration.WorkerTypes.Add(new Logic.WorkerType(name, [.. list.Split("\n")]));
            UpdateList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CurAppData.Administration.WorkerTypes.RemoveAll(x => x.Name == comboBox1.Text);
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
            comboBox1.Items.AddRange(CurAppData.Administration.WorkerTypes.Cast<object>().ToArray());
            CurAppData.Save();
        }
    }
}
