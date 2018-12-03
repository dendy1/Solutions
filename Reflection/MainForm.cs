using System;
using System.Collections.Generic;
using System.Linq;
using ReflectionLibrary;
using System.Windows.Forms;
using System.Reflection;
using ReflectionUtils;

namespace Reflection
{
    public partial class MainForm : Form
    { 
        List<object> createdObjects;
        List<MethodInfo> methods;
        List<Type> classes;

        public MainForm()
        {
            InitializeComponent();
            createdObjects = new List<object>();
            methods = new List<MethodInfo>();
            classes = new List<Type>();
        }

        private void openBTN_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    classes = new List<Type>();
                    classes = Utils.GetClasses(ofd.FileName);
                    ClassesOutputListBox.Items.Clear();
                    foreach (Type t in classes)
                        ClassesOutputListBox.Items.Add(t.Name);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        private void methodBTN_Click(object sender, EventArgs e)
        {
            if (MethodsOutputListVox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите метод!");
                return;
            }
            if (objectListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала создайте объект!");
                return;
            }

            Type currentClass = classes[ClassesOutputListBox.SelectedIndex];
            MethodInfo currentMethod = methods[MethodsOutputListVox.SelectedIndex];


            MethodArgsForm methodArgsForm = new MethodArgsForm();
            methodArgsForm.MethodInfo = currentMethod;
            object methodResult = null;
            try
            {
                if (currentMethod.GetParameters().Count() == 0)
                {
                    methodResult = currentMethod.Invoke(objectListBox.SelectedItem, null);
                }
                else if (methodArgsForm.ShowDialog() == DialogResult.OK)
                {
                    object[] arguments = methodArgsForm.GetArguments;
                    methodResult = currentMethod.Invoke(objectListBox.SelectedItem, arguments);
                }

                if (methodResult != null)
                {
                    MessageBox.Show("Результат выполнения метода : " + methodResult.ToString(), "Результат");
                }

                RefreshInfo();
            }
            catch (TargetInvocationException ex)
            {
                if (ex.InnerException is NotImplementedException)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void createObjectBTN_Click(object sender, EventArgs e)
        {
            if (ClassesOutputListBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите класс!");
                return;
            }
            Type currentClass = classes[ClassesOutputListBox.SelectedIndex];
            ConstructorArgsForm constructorArgsForm = new ConstructorArgsForm();
            constructorArgsForm.ConstructorInfos = currentClass.GetConstructors().ToList();
            if (constructorArgsForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ConstructorInfo ci = constructorArgsForm.GetSelectedConstructorInfo;
                    object[] arguments = constructorArgsForm.GetArguments;
                    object obj = ci.Invoke(arguments);
                    createdObjects.Add(obj);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            objectListBox.Items.Clear();
            objectListBox.Items.AddRange(createdObjects.ToArray());
        }

        private void OutputListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type currentClass = classes[ClassesOutputListBox.SelectedIndex];
            MethodsOutputListVox.Items.Clear();
            if (ClassesOutputListBox.SelectedIndex != -1)
            {
                this.methods.Clear();
                this.methods.AddRange(classes[ClassesOutputListBox.SelectedIndex].GetMethods(
                    BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance
                    ));
                List<string> methods = new List<string>();
                foreach (MethodInfo mi in this.methods)
                {
                    methods.Add(mi.GetSignature());
                }
                MethodsOutputListVox.Items.AddRange(methods.ToArray());
            }
        }

        private void objectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (objectListBox.SelectedItem != null)
            {
                RefreshInfo();
            }
        }

        private void RefreshInfo()
        {
            object obj = objectListBox.SelectedItem;
            Type currentClass = obj.GetType();
            try
            {
                MethodInfo method = currentClass.GetMethod("GetInfo");
                object result = method.Invoke(obj, null);
                List<string> info = (List<string>)result;
                currentObjectInfo.Lines = info.ToArray();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}
