using System;
using System.Drawing;
using System.Windows.Forms;
using BL.Character_Classes;
using BL.Enemy_Classes;
using System.Media;
using BL;

namespace GameWFA
{
    public enum GAME_STATE { RUNNING, INACTIVE, PAUSE, GAME_OVER };

    public partial class MainForm : Form
    {
        private Graphics g;
        private Bitmap bm;
        private CreateCharacter cc;
        public Game game;
        private int timer;

        public MainForm()
        {
            InitializeComponent();
            SetState(GAME_STATE.INACTIVE);
            game = new Game();
            g = gamePnl.CreateGraphics();
            bm = new Bitmap(gamePnl.Width, gamePnl.Height, g);
            timer = 0;
            cc = new CreateCharacter(this, game);
        }
        private void createCharBtn_Click(object sender, EventArgs e)
        {
            cc.Show();
            createCharBtn.Enabled = false;
            startBtn.Enabled = true;
        }

        private void gameTmr_Tick(object sender, EventArgs e)
        {
            if (!GameAndWaveCheck())
            {
                UpdateCurrentStateLog();
                game.Mining();
                timer++;
                if (timer % 15 == 0) game.CreateEnemyMinion();
                game.MoveObjects();
                logLbl.Text += game.logLbl.Text;
                game.logLbl.Text = string.Empty;
                Draw();
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            SetState(GAME_STATE.RUNNING);
            if (game.Mines.Capacity == 0)
            {
                game.CreateMinesWithWorkers();
                game.CreateAllyMinion();
            }
            logLbl.Text += "Game started\r\n";
        }

        private void SetState(GAME_STATE state)
        {
            switch (state)
            {
                case GAME_STATE.RUNNING:
                    startBtn.Enabled = false;
                    restartBtn.Enabled = false;
                    levelupBtn.Enabled = true;
                    createCharBtn.Enabled = false;
                    gameTmr.Enabled = true;
                    buyMinionBtn.Enabled = true;
                    pauseBtn.Enabled = true;
                    break;
                case GAME_STATE.INACTIVE:
                    restartBtn.Enabled = false;
                    startBtn.Enabled = false;
                    levelupBtn.Enabled = false;
                    gameTmr.Enabled = false;
                    createCharBtn.Enabled = true;
                    buyMinionBtn.Enabled = false;
                    pauseBtn.Enabled = false;
                    break;
                case GAME_STATE.GAME_OVER:
                    restartBtn.Enabled = true;
                    startBtn.Enabled = false;
                    gameTmr.Enabled = false;
                    levelupBtn.Enabled = false;
                    createCharBtn.Enabled = false;
                    levelupBtn.Enabled = false;
                    pauseBtn.Enabled = false;
                    buyMinionBtn.Enabled = false;
                    g.Clear(Color.White);
                    SoundPlayer loseAudio = new SoundPlayer(Properties.Resources.Lose);
                    loseAudio.Play();
                    g.DrawImage(Properties.Resources.GameOver, 175, -50);
                    gameTmr.Stop();
                    break;
                case GAME_STATE.PAUSE:
                    gameTmr.Stop();
                    restartBtn.Enabled = false;
                    buyMinionBtn.Enabled = false;
                    levelupBtn.Enabled = false;
                    createCharBtn.Enabled = false;
                    startBtn.Enabled = true;
                    pauseBtn.Enabled = false;
                    break;
            }
        }

        private void UpdateCurrentStateLog()
        {
            currentstatesLbl.Text = String.Format("Name: {0}\r\nClass: {1}\r\nHealth: {2}\r\nDamage: {3}\r\nArmorType: {4}\r\nGold: {5}\r\nYou have {6} minions",
                game.AllyHero.Name, game.AllyHero.HeroClass, game.AllyHero.Health, game.AllyHero.Damage, game.AllyHero.Armor, game.AllyHero.Gold, game.AllyMinions.Count);
        }

        private void levelupBtn_Click(object sender, EventArgs e)
        {
            int cost = Convert.ToInt32(costLbl.Text.Substring(15));
            if (game.AllyHero.Gold >= cost) { game.AllyHero.LevelUp(cost); costLbl.Text = costLbl.Text.Remove(15); costLbl.Text += (cost * 2).ToString(); }
            else logLbl.Text += "You don't hane enough money to level up your hero\r\n";
        }

        private bool GameAndWaveCheck()
        {
            if (game.AllyHero.Health <= 0 && game.EnemyMinions.Count >= 5 && game.Mines.Count == 0)
            {
                SetState(GAME_STATE.GAME_OVER);
                return true;
            }
            return false;
        }

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
            if (game.Mines.Count == 2)
            {
                g.DrawImage(Properties.Resources.BackGround1, 0, 0);
            }
            else if (game.Mines.Count == 1)
            {
                g.DrawImageUnscaled(Properties.Resources.BackGround2, 0, 0);
            }
            else if (game.Mines.Count == 0)
            {
                g.DrawImageUnscaled(Properties.Resources.BackGround3, 0, 0);
            }

            g.DrawLine(new Pen(Color.DarkGreen), new PointF(10, 410), new PointF(800, 750));
            g.DrawLine(new Pen(Color.DarkGreen), new PointF(10, 435), new PointF(800, 750));
            g.DrawLine(new Pen(Color.DarkGreen), new PointF(10, 460), new PointF(800, 750));
            g.DrawLine(new Pen(Color.DarkGreen), new PointF(800, 750), new PointF(300, 100));
            g.DrawLine(new Pen(Color.DarkGreen), new PointF(300, 100), new PointF(675, 135));
            g.DrawLine(new Pen(Color.DarkGreen), new PointF(675, 135), new PointF(900, 300));
            foreach (var item in game.EnemyMinions)
            {
                switch (item.MinionClass)
                {
                    case ENTITY_MINION_CLASS_ENEMY.Goblin:
                        g.DrawImage(Properties.Resources.Goblin, item.Coords.X, item.Coords.Y - 50);
                        break;
                    case ENTITY_MINION_CLASS_ENEMY.Basilisk:
                        g.DrawImage(Properties.Resources.Basilisk, item.Coords.X, item.Coords.Y - 50);
                        break;
                    case ENTITY_MINION_CLASS_ENEMY.Golem:
                        g.DrawImage(Properties.Resources.Stone_golem, item.Coords.X, item.Coords.Y - 50);
                        break;
                }
            }
            foreach (var item in game.AllyMinions)
            {
                switch (item.MinionClass)
                {
                    case ENTITY_MINION_CLASS_ALLY.Dwarf:
                        g.DrawImage(Properties.Resources.Dwarf, item.Coords);
                        break;
                    case ENTITY_MINION_CLASS_ALLY.AirElemental:
                        g.DrawImage(Properties.Resources.Air_Elemental, item.Coords);
                        break;
                    case ENTITY_MINION_CLASS_ALLY.Gargoyle:
                        g.DrawImage(Properties.Resources.Gargoyle, item.Coords);
                        break;
                }
            }
            if (game.AllyHero.Health > 0)
            {
                switch (game.AllyHero.HeroClass)
                {
                    case ENTITY_HERO_CLASS_ALLY.Griffin:
                        g.DrawImage(Properties.Resources.Royal_Griffin, game.AllyHero.Coords);
                        break;
                    case ENTITY_HERO_CLASS_ALLY.Knight:
                        g.DrawImage(Properties.Resources.Champion, game.AllyHero.Coords);
                        break;
                    case ENTITY_HERO_CLASS_ALLY.Crusader:
                        g.DrawImage(Properties.Resources.Crusader, game.AllyHero.Coords);
                        break;
                }
            }
        }

        private void gamePnl_MouseMove(object sender, MouseEventArgs e)
        {
            coordsLbl.Text = String.Format("X: {0}; Y: {1}", e.X, e.Y);
        }

        private void buyMinionBtn_Click(object sender, EventArgs e)
        {
            if (game.AllyHero.Gold < 150) logLbl.Text += "You don't have enough money\r\n";
            else { game.CreateAllyMinion(); game.AllyHero.Gold -= 150; logLbl.Text += "You have bought one minion\r\n"; }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            minionCostLbl.Text += 150.ToString();
            costLbl.Text += 300.ToString();
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            SetState(GAME_STATE.PAUSE);
        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            timer = 0;
            game = new Game();
            cc = new CreateCharacter(this, game);
            SetState(GAME_STATE.INACTIVE);
        }
    }
}