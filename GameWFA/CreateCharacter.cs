using System;
using System.Windows.Forms;
using BL.Character_Classes.Heroes;
using BL.Character_Classes;

namespace GameWFA
{
    public partial class CreateCharacter : Form
    {
        public ENTITY_HERO_CLASS_ALLY eClass { get; private set; }
        public Griffin _griffin { get; private set; }
        public Knight _knight { get; private set; }
        public Crusader _crusader { get; private set; }
        MainForm mf;

        public CreateCharacter(MainForm mf)
        {
            InitializeComponent();
            this.mf = mf;
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            string name = String.Empty;
            if (String.IsNullOrEmpty(nameTxt.Text)) MessageBox.Show("Please enter the name");
            else name = nameTxt.Text;
            switch (classCmbB.Text)
            {
                case "Griffin":
                    eClass = ENTITY_HERO_CLASS_ALLY.Griffin;
                    _griffin = new Griffin(name);
                    break;
                case "Knight":
                    eClass = ENTITY_HERO_CLASS_ALLY.Knight;
                    _knight = new Knight(name);
                    break;
                case "Crusader":
                    eClass = ENTITY_HERO_CLASS_ALLY.Crusader;
                    _crusader = new Crusader(name);
                    break;
                default:
                    eClass = ENTITY_HERO_CLASS_ALLY.Unknown;
                    MessageBox.Show("You must choose a class for your character");
                    break;
            }
            if (eClass != ENTITY_HERO_CLASS_ALLY.Unknown) { Close(); mf.Enabled = true; mf.Focus(); }
        }

        private void CreateCharacter_Load(object sender, EventArgs e)
        {
            mf.Enabled = false;
        }
    }
}
