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
using BL.Character_Classes.Heroes;
using BL.Character_Classes;
using BL.Character_Classes.Minions;
using BL.Enemy_Classes;
using BL.Enemy_Classes.Heroes;
using BL.Enemy_Classes.Minions;
using BL.Workers;

namespace GameWFA
{
    public enum GAME_STATE { RUNNING, INACTIVE, GAME_OVER };

    public partial class MainForm : Form
    {
        private const int SIZE = 3;

        private Graphics g;
        private Bitmap bm;
        private CreateCharacter cc;
        private AllyEntity allyHero;
        private List<EnemyEntity> enemyMinions;
        private List<Worker> workers;
        private List<AllyEntity> allyMinions;
        private int wave { get; set; }


        public MainForm()
        {
            InitializeComponent();
            SetState(GAME_STATE.INACTIVE);
            enemyMinions = new List<EnemyEntity>();
            allyMinions = new List<AllyEntity>();
            workers = new List<Worker>();
            wave = 1;
            g = gamePnl.CreateGraphics();
            bm = new Bitmap(gamePnl.Width, gamePnl.Height, g);
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
                    case ENTITY_HERO_CLASS_ALLY.Griffin:
                        allyHero = cc._griffin;
                        allyHero.Coords = new PointF(500, 300);
                        break;
                    case ENTITY_HERO_CLASS_ALLY.Knight:
                        allyHero = cc._knight;
                        allyHero.Coords = new PointF(500, 300);
                        break;
                    case ENTITY_HERO_CLASS_ALLY.Crusader:
                        allyHero = cc._crusader;
                        allyHero.Coords = new PointF(500, 300);
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
            //GameAndWaveCheck();
            Thread.Sleep(300);

            MoveEnemyMinions();
            Draw();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            SetState(GAME_STATE.RUNNING);
            CreateStartWorkers();
            WaveCreation();
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
                allyHero.Name, allyHero.HeroClass, allyHero.Health, allyHero.Damage, allyHero.Armor, allyHero.Gold);
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
                if (item.CurrentGold >= item.LoadCapacity) { allyHero.Gold += item.CurrentGold; item.CurrentGold = 0; }
            }
        }
        private void WaveCreation()
        {
            enemyMinions.Clear();
            EnemyEntity ee;
            Random rnd = new Random();
            for (int i = 0; i < SIZE * wave; i++)
            {
                int creep = rnd.Next(0, 3);
                ENTITY_MINION_CLASS_ENEMY et = (ENTITY_MINION_CLASS_ENEMY)creep;
                switch (et)
                {
                    case ENTITY_MINION_CLASS_ENEMY.Goblin:
                        ee = new Goblin();
                        ee.Coords = new PointF(10, 100);
                        break;
                    case ENTITY_MINION_CLASS_ENEMY.Golem:
                        ee = new Golem();
                        ee.Coords = new PointF(10, 300);
                        break;
                    case ENTITY_MINION_CLASS_ENEMY.Spider:
                        ee = new Spider();
                        ee.Coords = new PointF(10, 500);
                        break;
                    default:
                        ee = null;
                        break;
                }
                enemyMinions.Add(ee);
                Draw();
            }
        }
        private void levelupBtn_Click(object sender, EventArgs e)
        {
            int cost = Convert.ToInt32(costLbl.Text.Substring(5));
            if (allyHero.Gold >= cost) { allyHero.LevelUp(cost); costLbl.Text = costLbl.Text.Remove(5); costLbl.Text += (cost * 2).ToString(); }
            else MessageBox.Show("You dont have enough gold to level up");
        }
        //private void GameAndWaveCheck()
        //{
        //    if (allyHero.Health <= 0)
        //    {
        //        SetState(GAME_STATE.GAME_OVER);
        //    }
        //    bool waveUp = false;
        //    for (int i = 0; i < SIZE * wave; i++)
        //    {
        //        if (enemyMinions[i].Health <= 0 && i + 1 == SIZE * wave)
        //        {
        //            waveUp = true;
        //        }
        //    }
        //    if (waveUp) wave++;
        //}
        private void Draw()
        {
            if (bm != null)
            {
                using (Graphics g0 = Graphics.FromImage(bm))
                {
                    ReDraw(g0);
                }
                g.DrawImage(bm, ClientRectangle);
            }
        }
        private void ReDraw(Graphics g)
        {
            g.Clear(DefaultBackColor);
            foreach (var item in enemyMinions)
            {
                g.FillRectangle(new SolidBrush(Color.Black), item.Coords.X, item.Coords.Y, 20, 20);
            }
            g.DrawLine(new Pen(Color.DarkGreen), new PointF(10, 100), new PointF(500, 500));
            g.DrawLine(new Pen(Color.DarkGreen), new PointF(10, 300), new PointF(500, 500));
            g.DrawLine(new Pen(Color.DarkGreen), new PointF(10, 500), new PointF(500, 500));
            g.FillRectangle(new SolidBrush(Color.Red), allyHero.Coords.X, allyHero.Coords.Y, 40, 40);
        }
        private void MoveEnemyMinions()
        {
            foreach (var item in enemyMinions)
            {
                switch (item.MinionClass)
                {
                    case ENTITY_MINION_CLASS_ENEMY.Goblin:
                        item.Coords.X += 98;
                        item.Coords.Y += 80;
                        break;
                    case ENTITY_MINION_CLASS_ENEMY.Spider:
                        item.Coords.X += 98;
                        item.Coords.Y += 0;
                        break;
                    case ENTITY_MINION_CLASS_ENEMY.Golem:
                        item.Coords.X += 98;
                        item.Coords.Y += 40;
                        break;
                }
            }
        }
        private void MoveAllyMinions()
        {
            foreach (var item in allyMinions)
            {
                switch (item.MinionClass)
                {
                    case ENTITY_MINION_CLASS_ALLY.Dwarf:
                        break;
                    case ENTITY_MINION_CLASS_ALLY.AirElemental:
                        break;
                    case ENTITY_MINION_CLASS_ALLY.Gargoyle:
                        break;
                }
            }
        }

        private void gamePnl_MouseMove(object sender, MouseEventArgs e)
        {
            coordsLbl.Text = String.Format("X: {0}; Y: {1}", e.X, e.Y);
        }
    }
}