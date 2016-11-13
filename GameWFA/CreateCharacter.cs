using System;
using System.Windows.Forms;
using BL.Character_Classes.Heroes;
using BL;
using BL.Character_Classes;

namespace GameWFA
{
    public partial class CreateCharacter : Form
    {
        private MainForm mf { get; set; }
        public Game game { get; set; }

        public CreateCharacter(MainForm mf, Game game)
        {
            InitializeComponent();
            this.mf = mf;
            this.game = game;
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            string name = String.Empty;
            if (String.IsNullOrEmpty(nameTxt.Text)) MessageBox.Show("Please enter the name");
            else name = nameTxt.Text;
            switch (classCmbB.Text)
            {
                case "Griffin":
                    game.AllyHero = new Griffin(name);
                    game.AllyHero.Coords = new System.Drawing.PointF(900, 300);
                    break;
                case "Knight":
                    game.AllyHero = new Knight(name);
                    game.AllyHero.Coords = new System.Drawing.PointF(900, 300);
                    break;
                case "Crusader":
                    game.AllyHero = new Crusader(name);
                    game.AllyHero.Coords = new System.Drawing.PointF(900, 300);
                    break;
                default:
                    game.AllyHero = null;
                    break;
            }
            if (game.AllyHero != null) { Close(); mf.Enabled = true; mf.Focus(); mf.game = game; }
            else { MessageBox.Show("Choose the hero class"); }
        }

        private void CreateCharacter_Load(object sender, EventArgs e)
        {
            mf.Enabled = false;
        }
    }
}
