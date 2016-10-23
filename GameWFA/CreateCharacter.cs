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
    public partial class CreateCharacter : Form
    {
        public ENTITY_CLASS eClass { get; private set; }
        public Mage _mage { get; private set; }
        public Knight _knight { get; private set; }
        public Rogue _rogue { get; private set; }

        public CreateCharacter()
        {
            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            string name = String.Empty;
            if (String.IsNullOrEmpty(nameTxt.Text)) MessageBox.Show("Please enter the name");
            else name = nameTxt.Text;
            switch (classCmbB.Text)
            {
                case "Mage":
                    eClass = ENTITY_CLASS.Mage;
                    _mage = new Mage(name);
                    break;
                case "Knight":
                    eClass = ENTITY_CLASS.Knight;
                    _knight = new Knight(name);
                    break;
                case "Rogue":
                    eClass = ENTITY_CLASS.Rogue;
                    _rogue = new Rogue(name);
                    break;
                default:
                    eClass = ENTITY_CLASS.Unknown;
                    MessageBox.Show("You must choose a class for your character");
                    break;
            }

            Close();
        }
        private void CreateCharacter_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Hero was created");
            MainForm mf = new MainForm();
            mf.Creation(this);
        }
    }
}
