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
        public static Player player1;

        public CreateCharacter()
        {
            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nameTxt.Text)) MessageBox.Show("Please enter the name");
            ENTITY_CLASS eClass;
            switch (classCmbB.Text)
            {
                case "Mage":
                    eClass = ENTITY_CLASS.Mage;
                    break;
                case "Knight":
                    eClass = ENTITY_CLASS.Knight;
                    break;
                case "Rogue":
                    eClass = ENTITY_CLASS.Rogue;
                    break;
                default:
                    MessageBox.Show("You must choose a class for your character");
                    eClass = ENTITY_CLASS.Unknown;
                    break;
            }
            player1 = new Player(nameTxt.Text, eClass);
            //MessageBox.Show(String.Format("U have created {2}/n Name {0}/n Damage {1} /n Health {3}", player1.Name, player1.Damage, player1.Class, player1.Health));
            Close();
        }
    }
}
