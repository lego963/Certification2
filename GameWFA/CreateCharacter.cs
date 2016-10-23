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
        public Player player1
        {
            get
            {
                return _player1;
            }
        }
        private Mage _mage;
        private Knight _knight;
        private Rogue _rogue;
        private Player _player1;

        public CreateCharacter()
        {
            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {

            string name = String.Empty;
            if (String.IsNullOrEmpty(nameTxt.Text)) MessageBox.Show("Please enter the name");
            else name = nameTxt.Text;
            ENTITY_CLASS eClass;
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
                    MessageBox.Show("You must choose a class for your character");
                    eClass = ENTITY_CLASS.Unknown;
                    break;
            }

            _player1 = new Player(name, eClass);

            Close();
        }
    }
}
