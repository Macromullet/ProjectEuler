using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EulerAnswers;

namespace ProjectEuler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private bool _PreJit = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            List<TypeDropdownItem> matchingTypes = new List<TypeDropdownItem>();
            var answerType = typeof(IAnswer);
            var eulerAssembly = answerType.Assembly;
            foreach (var type in eulerAssembly.GetTypes())
            {
                if (type == answerType)
                {
                    continue;
                }
                if (answerType.IsAssignableFrom(type))
                {
                    if (_PreJit)
                    {
                        IAnswer answer = (IAnswer)Activator.CreateInstance(type);
                        answer.Answer();
                    }
                    TypeDropdownItem typeDropdownItem = new TypeDropdownItem(type);
                    matchingTypes.Add(typeDropdownItem);
                }
            }
            matchingTypes.Sort(new Comparison<TypeDropdownItem>((item1, item2) => item1.Order.CompareTo(item2.Order)));
            this.cboTypes.DisplayMember = "Name";
            this.cboTypes.ValueMember = "Type";
            this.cboTypes.DataSource = matchingTypes;
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            var selectedType = cboTypes.SelectedValue as Type;
            if (selectedType == null)
            {
                MessageBox.Show("Please select a type!");
            }

            IAnswer answer = (IAnswer)Activator.CreateInstance(selectedType);
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            this.txtResult.Text = answer.Answer();
            sw.Stop();
            this.lblElapsed.Text = string.Format("Elapsed (ms) {0}", sw.ElapsedMilliseconds);
        }
    }
}
