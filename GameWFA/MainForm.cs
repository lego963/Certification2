using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.Character_Classes;

namespace GameWFA
{
    public partial class MainForm : Form
    {
        public Player player1 { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void createCharBtn_Click(object sender, EventArgs e)
        {
            var cc = new CreateCharacter();
            player1 = cc.player1;
            
            cc.Show();
        }
    }
}
