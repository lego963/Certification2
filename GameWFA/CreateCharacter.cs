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
        public ENTITY_HERO_CLASS eClass { get; private set; }
        public Griffin _mage { get; private set; }
        public Knight _knight { get; private set; }
        public Crusader _rogue { get; private set; }

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
                    eClass = ENTITY_HERO_CLASS.Griffin;
                    _mage = new Griffin(name);
                    break;
                case "Knight":
                    eClass = ENTITY_HERO_CLASS.Knight;
                    _knight = new Knight(name);
                    break;
                case "Rogue":
                    eClass = ENTITY_HERO_CLASS.Crusader;
                    _rogue = new Crusader(name);
                    break;
                default:
                    eClass = ENTITY_HERO_CLASS.Unknown;
                    MessageBox.Show("You must choose a class for your character");
                    break;
            }
            Close();
        }
    }
}
