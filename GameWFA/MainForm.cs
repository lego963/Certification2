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
using BL.Enemy_Classes;
using BL.Workers;

namespace GameWFA
{
    public enum GAME_STATE { RUNNING, INACTIVE, GAME_OVER };

    public partial class MainForm : Form
    {
        private CreateCharacter cc;
        private EntityHeroes player1;
        private List<EntityEnemies> enemies;
        private List<Worker> workers;

        public MainForm()
        {
            InitializeComponent();
            SetState(GAME_STATE.INACTIVE);
            enemies = new List<EntityEnemies>();
            workers = new List<Worker>();
        }
        private void createCharBtn_Click(object sender, EventArgs e)
        {
            cc = new CreateCharacter();
            cc.Show();
            loaddataBtn.Enabled = true;
        }

        private void loaddataBtn_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cc.eClass)
                {
                    case ENTITY_CLASS.Mage:
                        player1 = cc._mage;
                        break;
                    case ENTITY_CLASS.Knight:
                        player1 = cc._knight;
                        break;
                    case ENTITY_CLASS.Rogue:
                        player1 = cc._rogue;
                        break;
                    case ENTITY_CLASS.Unknown:
                        MessageBox.Show("Double Trouble");
                        break;
                }
                startBtn.Enabled = true;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You didn't create hero");
            }

        }

        private void gameTmr_Tick(object sender, EventArgs e)
        {
            UpdateCurrentStateLog();
            Mining();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            SetState(GAME_STATE.RUNNING);
        }
        private void SetState(GAME_STATE state)
        {
            switch (state)
            {
                case GAME_STATE.RUNNING:
                    CreateStartWorkers();
                    startBtn.Enabled = false;
                    levelupBtn.Enabled = true;
                    createCharBtn.Enabled = false;
                    loaddataBtn.Enabled = false;
                    gameTmr.Enabled = true;
                    break;
                case GAME_STATE.INACTIVE:
                    startBtn.Enabled = false;
                    levelupBtn.Enabled = false;
                    gameTmr.Enabled = false;
                    createCharBtn.Enabled = true;
                    loaddataBtn.Enabled = false;
                    break;
                case GAME_STATE.GAME_OVER:
                    startBtn.Enabled = false;
                    gameTmr.Enabled = false;
                    levelupBtn.Enabled = false;
                    createCharBtn.Enabled = true;
                    loaddataBtn.Enabled = false;
                    break;
            }
        }
        private void UpdateCurrentStateLog()
        {
            currentstatesLbl.Text = String.Format("Name: {0}\r\nClass: {1}\r\nHealth: {2}\r\nDamage: {3}\r\nArmorType: {4}\r\nGold: {5}",
                player1.Name, player1.Class, player1.Health, player1.Damage, player1.Armor, player1.Gold);
        }
        private void CreateStartWorkers()
        {
            for (int i = 0; i < 3; i++)
            {
                Worker ew = new Worker();
                workers.Add(ew);
            }
        }
        private void Mining()
        {
            foreach (var item in workers)
            {
                item.Mining();
                if (item.CurrentGold >= item.LoadCapacity) { player1.Gold += item.CurrentGold; item.CurrentGold = 0; }
            }
        }

    }
}
