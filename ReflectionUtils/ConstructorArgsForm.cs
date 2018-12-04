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
    public partial class ConstructorArgsForm : Form
    {
        public List<ConstructorInfo> ConstructorInfos { get; set; }
        public ConstructorArgsForm()
        {
            InitializeComponent();
        }

        private void OKBTN_Click(object sender, EventArgs e)
        {
            try
            {
                GetSelectedConstructorInfo.Invoke(GetArguments);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ConstructorInfo GetSelectedConstructorInfo
        {
            get
            {
                return ConstructorInfos[ConstructosListBox.SelectedIndex];
            }
        }

        public object[] GetArguments
        {
            get
            {
                ParameterInfo[] parameterInfos = GetSelectedConstructorInfo.GetParameters();
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

        private void ConstructorArgsForm_Load(object sender, EventArgs e)
        {
            if (ConstructorInfos != null)
            {
                foreach (ConstructorInfo ci in ConstructorInfos)
                    ConstructosListBox.Items.Add(ci.GetSignature());
                ConstructosListBox.SelectedIndex = 0;
            }
        }
    }
}
