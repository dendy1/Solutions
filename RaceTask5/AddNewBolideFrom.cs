using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceTask5
{
    public partial class AddNewBolideFrom : Form
    {
        public AddNewBolideFrom()
        {
            InitializeComponent();
        }

        public string GetName
        {
            get { return (string)NameComboBox.SelectedItem; }
        }
        private void ОКButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
