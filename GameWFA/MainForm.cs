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
            minionCostLbl.Text += "150";
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

            MoveObjects();
            Draw();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            SetState(GAME_STATE.RUNNING);
            CreateStartWorkers();
            WaveCreation();
            CreateStartAlly();
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
            foreach (var item in allyMinions)
            {
                g.FillRectangle(new SolidBrush(Color.Blue), item.Coords.X, item.Coords.Y, 20, 20);
            }
            g.DrawLine(new Pen(Color.DarkGreen), new PointF(10, 100), new PointF(500, 500));
            g.DrawLine(new Pen(Color.DarkGreen), new PointF(10, 300), new PointF(500, 500));
            g.DrawLine(new Pen(Color.DarkGreen), new PointF(10, 500), new PointF(500, 500));
            g.FillRectangle(new SolidBrush(Color.Red), allyHero.Coords.X, allyHero.Coords.Y, 40, 40);
        }
        private void MoveObjects()
        {
            foreach (var item in enemyMinions.ToArray())
            {
                FindAim(item);
                switch (item.MinionClass)
                {
                    case ENTITY_MINION_CLASS_ENEMY.Goblin:
                        item.Coords.X += 9.8F;
                        item.Coords.Y += 8.0F;
                        break;
                    case ENTITY_MINION_CLASS_ENEMY.Spider:
                        item.Coords.X += 9.8F;
                        item.Coords.Y += 0.0F;
                        break;
                    case ENTITY_MINION_CLASS_ENEMY.Golem:
                        item.Coords.X += 9.8F;
                        item.Coords.Y += 4.0F;
                        break;
                }
            }
            foreach (var item in allyMinions.ToArray())
            {
                FindAim(item);
                switch (item.MinionClass)
                {
                    case ENTITY_MINION_CLASS_ALLY.Dwarf:
                        if (item.Coords != new PointF(475, 450))
                        {
                            item.Coords.X += 35F;
                            item.Coords.Y += 0.0F;
                        }
                        break;
                    case ENTITY_MINION_CLASS_ALLY.AirElemental:
                        if (item.Coords != new PointF(475, 450))
                        {
                            item.Coords.X += 35F;
                            item.Coords.Y += 10.0F;
                        }
                        break;
                    case ENTITY_MINION_CLASS_ALLY.Gargoyle:
                        if (item.Coords != new PointF(475, 450))
                        {
                            item.Coords.X += 35F;
                            item.Coords.Y += 5.0F;
                        }
                        break; //475 450
                }
            }
        }
        private void CreateStartAlly()
        {
            AllyEntity ae;
            Random rnd = new Random();
            for (int i = 0; i < SIZE - 1; i++)
            {
                int creep = rnd.Next(0, 3);
                ENTITY_MINION_CLASS_ALLY et = (ENTITY_MINION_CLASS_ALLY)creep;
                switch (et)
                {
                    case ENTITY_MINION_CLASS_ALLY.AirElemental:
                        ae = new AirElemental();
                        ae.Coords = new PointF(300, 400);
                        break;
                    case ENTITY_MINION_CLASS_ALLY.Dwarf:
                        ae = new Dwarf();
                        ae.Coords = new PointF(300, 450);
                        break;
                    case ENTITY_MINION_CLASS_ALLY.Gargoyle:
                        ae = new Gargoyle();
                        ae.Coords = new PointF(300, 425);
                        break;
                    default:
                        ae = null;
                        break;
                }
                allyMinions.Add(ae);
            }
            Draw();
        }
        private void gamePnl_MouseMove(object sender, MouseEventArgs e)
        {
            coordsLbl.Text = String.Format("X: {0}; Y: {1}", e.X, e.Y);
        }
        private void FindAim(EnemyEntity enemy)
        {
            foreach (var item in allyMinions.ToArray())
            {
                double distance = Math.Sqrt(Math.Pow(enemy.Coords.X - item.Coords.X, 2) + Math.Pow(enemy.Coords.Y - item.Coords.Y, 2));
                if (distance < 50)
                {
                    do
                    {
                        item.Health -= enemy.Damage;
                        enemy.Health -= item.Damage;
                    } while (item.Health > 0 && enemy.Health > 0);
                    if (item.Health <= 0) allyMinions.Remove(item);
                    else enemyMinions.Remove(enemy);
                    break;
                }
            }
        }
        private void FindAim(AllyEntity ally)
        {
            foreach (var item in enemyMinions.ToArray())
            {
                double distance = Math.Sqrt(Math.Pow(ally.Coords.X - item.Coords.X, 2) + Math.Pow(ally.Coords.Y - item.Coords.Y, 2));
                if (distance < 50)
                {
                    do
                    {
                        item.Health -= ally.Damage;
                        ally.Health -= item.Damage;
                    } while (item.Health > 0 && ally.Health > 0);
                    if (item.Health <= 0) enemyMinions.Remove(item);
                    else allyMinions.Remove(ally);
                    break;
                }
            }
        }

        private void buyMinionBtn_Click(object sender, EventArgs e)
        {
            if (allyHero.Gold < 150) MessageBox.Show("Ti uporotiy chtoli suka ?");
            else
            {
                AllyEntity ae;
                Random rnd = new Random();
                int creep = rnd.Next(0, 3);
                ENTITY_MINION_CLASS_ALLY et = (ENTITY_MINION_CLASS_ALLY)creep;
                switch (et)
                {
                    case ENTITY_MINION_CLASS_ALLY.AirElemental:
                        ae = new AirElemental();
                        ae.Coords = new PointF(300, 400);
                        break;
                    case ENTITY_MINION_CLASS_ALLY.Dwarf:
                        ae = new Dwarf();
                        ae.Coords = new PointF(300, 450);
                        break;
                    case ENTITY_MINION_CLASS_ALLY.Gargoyle:
                        ae = new Gargoyle();
                        ae.Coords = new PointF(300, 425);
                        break;
                    default:
                        ae = null;
                        break;
                }
                allyMinions.Add(ae);
                Draw();
            }
        }
    }
}