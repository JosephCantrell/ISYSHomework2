using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISYSHomework2
{
    public partial class Cashier : Form
    {
        public Cashier()
        {
            //InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GraphicalFoodMenu.RadioButtonCheckedChanged();
        }

        private void btnExit_MouseUp(object sender, EventArgs e)
        {
            GraphicalFoodMenu.BtnExit_MouseUp();
        }

        private void btnClear_MouseUp(object sender, EventArgs e)
        {
            GraphicalFoodMenu.ClearAllSelections();
        }

        private void btnCalculate_MouseUp(object sender, EventArgs e)
        {
            GraphicalFoodMenu.Calculate();
        }
    }
}
