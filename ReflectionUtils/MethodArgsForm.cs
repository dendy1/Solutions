using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ReflectionUtils
{
    public partial class MethodArgsForm : Form
    {
        public object Object { get; set; }
        public MethodInfo MethodInfo { get; set; }
        public MethodArgsForm()
        {
            InitializeComponent();
        }

        private void OKBTN_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public object[] GetArguments
        {
            get
            {
                ParameterInfo[] parameterInfos = MethodInfo.GetParameters();
                object[] obj = InputTextBox.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                List<object> list = new List<object>();
                for (int i = 0; i < obj.Length; i++)
                {
                    var value = Convert.ChangeType(obj[i], parameterInfos[i].ParameterType);
                    list.Add(value);
                }
                return list.ToArray();
            }
               
        }

        private void MethodArgsForm_Load(object sender, EventArgs e)
        {
            if (MethodInfo != null)
            {
                MethodsListBox.Items.Add(MethodInfo.GetSignature());
                MethodsListBox.SelectedIndex = 0;
            }
        }
    }
}
