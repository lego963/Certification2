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
    public enum GAME_STATE { RUNNING, INACTIVE, GAME_OVER };

    public partial class MainForm : Form
    {
        public Mage _mage;
        public Rogue _rogue;
        public Knight _knight;

        public MainForm()
        {
            InitializeComponent();
            SetState(GAME_STATE.INACTIVE);
        }
        public void Creation(CreateCharacter cc)
        {
            switch (cc.eClass)
            {
                case ENTITY_CLASS.Mage:
                    _mage = cc._mage;
                    break;
                case ENTITY_CLASS.Knight:
                    _knight = cc._knight;
                    break;
                case ENTITY_CLASS.Rogue:
                    _rogue = cc._rogue;
                    break;
                case ENTITY_CLASS.Unknown:
                    MessageBox.Show("Double Trouble");
                    break;
            }
            cc.Dispose();
            Enabled = true;
            startBtn.Enabled = true;
        }
        private void createCharBtn_Click(object sender, EventArgs e)
        {
            var cc = new CreateCharacter();
            Enabled = false;
            cc.Show();
        }
        private void SetState(GAME_STATE state)
        {
            switch (state)
            {
                case GAME_STATE.RUNNING:
                    startBtn.Enabled = false;
                    levelupBtn.Enabled = true;
                    createCharBtn.Enabled = false;
                    break;
                case GAME_STATE.INACTIVE:
                    startBtn.Enabled = false;
                    levelupBtn.Enabled = false;
                    createCharBtn.Enabled = true;
                    break;
                case GAME_STATE.GAME_OVER:
                    startBtn.Enabled = false;
                    levelupBtn.Enabled = false;
                    createCharBtn.Enabled = true;
                    break;
            }
        }
    }
}
