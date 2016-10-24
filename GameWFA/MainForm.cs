using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private const int SIZE = 3;
        private CreateCharacter cc;
        private EntityHeroes player1;
        private List<EntityEnemies> enemies;
        private List<Worker> workers;
        private int wave { get; set; }
        private Graphics g;

        public MainForm()
        {
            InitializeComponent();
            SetState(GAME_STATE.INACTIVE);
            enemies = new List<EntityEnemies>();
            workers = new List<Worker>();
            wave = 1;
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
            Thread.Sleep(100);
            UpdateCurrentStateLog();
            Mining();
            GameAndWaveCheck();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            SetState(GAME_STATE.RUNNING);
            CreateStartWorkers();
            WaveCreation();
            g = gamePnl.CreateGraphics();
            g.DrawImage(Properties.Resources.b4e543d44f2f6fe7c3b16b3207c950d4, 20, 20, 40, 40);
        }
        private void SetState(GAME_STATE state)
        {
            switch (state)
            {
                case GAME_STATE.RUNNING:
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
                    costLbl.Text += 300.ToString();
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
            waveLbl.Text = waveLbl.Text.Remove(5);
            waveLbl.Text += wave.ToString();
        }
        private void CreateStartWorkers()
        {
            for (int i = 0; i < SIZE; i++)
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
        private void WaveCreation()
        {
            enemies.Clear();
            EntityEnemies ee;
            Random rnd = new Random();
            for (int i = 0; i < SIZE * wave; i++)
            {
                int creep = rnd.Next(0, 3);
                ENTITY_TYPE et = (ENTITY_TYPE)creep;
                switch (et)
                {
                    case ENTITY_TYPE.Goblin:
                        ee = new Goblin();
                        break;
                    case ENTITY_TYPE.Golem:
                        ee = new Golem();
                        break;
                    case ENTITY_TYPE.Spider:
                        ee = new Spider();
                        break;
                    default:
                        ee = new Goblin();
                        break;
                }
                enemies.Add(ee);
            }
        }
        private void levelupBtn_Click(object sender, EventArgs e)
        {
            int cost = Convert.ToInt32(costLbl.Text.Substring(5));
            if (player1.Gold >= cost) { player1.LevelUp(cost); costLbl.Text = costLbl.Text.Remove(5); costLbl.Text += (cost * 2).ToString(); }
            else MessageBox.Show("You dont have enough gold to level up");
        }
        private void GameAndWaveCheck()
        {
            if (player1.Health <= 0)
            {
                SetState(GAME_STATE.GAME_OVER);
            }
            bool waveUp = false;
            for (int i = 0; i < SIZE * wave; i++)
            {
                if (enemies[i].Health <= 0 && i + 1 == SIZE * wave)
                {
                    waveUp = true;
                }
            }
            if (waveUp) wave++;
        }
    }
}