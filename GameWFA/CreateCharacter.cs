using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWFA
{
    public partial class CreateCharacter : Form
    {
        public CreateCharacter()
        {
            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nameTxt.Text)) MessageBox.Show("Please enter the name");
            if (String.IsNullOrEmpty(classCmbB.SelectedItem.ToString())) MessageBox.Show("Please choose the class");
        }
    }
}
