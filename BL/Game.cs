using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BL.Character_Classes;
using BL.Enemy_Classes;
using BL.Character_Classes.Minions;
using BL.Enemy_Classes.Minions;
using System.Drawing;
using BL.Ally_Classes.Buildings;

namespace BL
{
    public class Game
    {
        public AllyEntity AllyHero;
        public List<Mine> Mines { get; set; }
        public List<EnemyEntity> EnemyMinions;
        public List<AllyEntity> AllyMinions { get; set; }
        public Label logLbl { get; set; }

        public Game()
        {
            Mines = new List<Mine>();
            EnemyMinions = new List<EnemyEntity>();
            AllyMinions = new List<AllyEntity>();
            logLbl = new Label();
        }

        public void CreateEnemyMinion()
        {
            EnemyEntity ee;
            Random rnd = new Random();
            int creep = rnd.Next(0, 3);
            int lane = rnd.Next(1, 4);
            ENTITY_MINION_CLASS_ENEMY et = (ENTITY_MINION_CLASS_ENEMY)creep;
            switch (et)
            {
                case ENTITY_MINION_CLASS_ENEMY.Goblin:
                    ee = new Goblin();
                    ee.Coords = CreateStartCoords(lane, ee);
                    ee.LaneMove = lane;
                    break;
                case ENTITY_MINION_CLASS_ENEMY.Golem:
                    ee = new Golem();
                    ee.Coords = CreateStartCoords(lane, ee);
                    ee.LaneMove = lane;
                    break;
                case ENTITY_MINION_CLASS_ENEMY.Basilisk:
                    ee = new Basilisk();
                    ee.Coords = CreateStartCoords(lane, ee);
                    ee.LaneMove = lane;
                    break;
                default:
                    ee = null;
                    break;
            }
            EnemyMinions.Add(ee);
        }

        public PointF CreateStartCoords(int Lane, EnemyEntity ee)
        {
            PointF startCoords;
            switch (Lane)
            {
                case 1:
                    startCoords = new PointF(10, 410);
                    break;
                case 2:
                    startCoords = new PointF(10, 435);
                    break;
                case 3:
                    startCoords = new PointF(10, 460);
                    break;
                default:
                    startCoords = new PointF();
                    break;
            }
            return startCoords;
        }

        public void MoveObjects()
        {
            #region EnemyMove
            foreach (var item in EnemyMinions.ToArray())
            {
                if (!FindAim(item) && item.MoveFight != Enemy_Classes.ACTION.Fight)
                    if (item.CheckPoints[0] == false)
                    {
                        switch (item.LaneMove)
                        {
                            case 1:
                                item.Coords.X += 79F;
                                item.Coords.Y += 34F;
                                if (item.Coords == new PointF(800, 750)) item.CheckPoints[0] = true;
                                break;
                            case 2:
                                item.Coords.X += 79F;
                                item.Coords.Y += 31.5F;
                                if (item.Coords == new PointF(800, 750)) item.CheckPoints[0] = true;
                                break;
                            case 3:
                                item.Coords.X += 79F;
                                item.Coords.Y += 29F;
                                if (item.Coords == new PointF(800, 750)) item.CheckPoints[0] = true;
                                break;
                        }
                    }
                    else if (item.CheckPoints[1] == false)
                    {
                        item.Coords.X -= 50F;
                        item.Coords.Y -= 65F;
                        if (item.Coords == new PointF(300, 100)) item.CheckPoints[1] = true;
                    }
                    else if (item.CheckPoints[2] == false)
                    {
                        item.Coords.X += 37.5F;
                        item.Coords.Y += 3.5F;
                        if (item.Coords == new PointF(675, 135)) item.CheckPoints[2] = true;
                    }
                    else if (item.CheckPoints[3] == false)
                    {
                        item.Coords.X += 22.5F;
                        item.Coords.Y += 16.5F;
                        if (item.Coords == new PointF(900, 300)) item.CheckPoints[3] = true;
                    }
            }
            #endregion

            #region Allymove
            foreach (var item in AllyMinions.ToArray())
            {
                if (!FindAim(item) && item.MoveFight != Character_Classes.ACTION.Fight)
                    if (item.CheckPoints[0] == false)
                    {
                        item.Coords.X -= 22.5F;
                        item.Coords.Y -= 16.5F;
                        if (item.Coords == new PointF(675, 135)) item.CheckPoints[0] = true;
                    }
                    else if (item.CheckPoints[1] == false)
                    {
                        item.Coords.X -= 37.5F;
                        item.Coords.Y -= 3.5F;
                        if (item.Coords == new PointF(300, 100)) item.CheckPoints[1] = true;
                    }
                    else
                    {
                        Random rnd = new Random();
                        item.Coords = new PointF(325 - rnd.Next(50), 125);
                    }
            }
            #endregion
            if (AllyMinions.Count == 0)
            {
                if (AllyHero.Health > 0 && !FindAim(ref AllyHero, true) && AllyHero.MoveFight != Character_Classes.ACTION.Fight)
                    if (AllyHero.CheckPoints[0] == false)
                    {
                        AllyHero.Coords.X -= 22.5F;
                        AllyHero.Coords.Y -= 16.5F;
                        if (AllyHero.Coords == new PointF(675, 135)) AllyHero.CheckPoints[0] = true;
                    }
                    else if (AllyHero.CheckPoints[1] == false)
                    {
                        AllyHero.Coords.X -= 37.5F;
                        AllyHero.Coords.Y -= 3.5F;
                        if (AllyHero.Coords == new PointF(300, 100)) AllyHero.CheckPoints[1] = true;
                    }
                    else
                    {
                        Random rnd = new Random();
                        AllyHero.Coords = new PointF(325 - rnd.Next(50), 125);
                    }
            }
            else
            {
                if (AllyHero.CheckPoints[1] = true && AllyMinions.Count > 0) { AllyHero.CheckPoints[0] = false; AllyHero.CheckPoints[1] = false; AllyHero.Coords = new PointF(900, 300); }
            }

        }

        public void CreateAllyMinion()
        {
            AllyEntity ae;
            Random rnd = new Random();
            int creep = rnd.Next(0, 3);
            ENTITY_MINION_CLASS_ALLY et = (ENTITY_MINION_CLASS_ALLY)creep;
            switch (et)
            {
                case ENTITY_MINION_CLASS_ALLY.AirElemental:
                    ae = new AirElemental();
                    break;
                case ENTITY_MINION_CLASS_ALLY.Dwarf:
                    ae = new Dwarf();
                    break;
                case ENTITY_MINION_CLASS_ALLY.Gargoyle:
                    ae = new Gargoyle();
                    break;
                default:
                    ae = null;
                    break;
            }
            ae.Coords = new PointF(900, 300);
            AllyMinions.Add(ae);
        }

        public bool FindAim(EnemyEntity enemy)
        {
            double distance;
            foreach (var item in AllyMinions.ToArray())
            {
                distance = Math.Sqrt(Math.Pow(enemy.Coords.X - item.Coords.X, 2) + Math.Pow(enemy.Coords.Y - item.Coords.Y, 2));
                if (distance <= 50)
                {
                    item.MoveFight = Character_Classes.ACTION.Fight;
                    enemy.MoveFight = Enemy_Classes.ACTION.Fight;
                    string s;
                    item.Health -= enemy.Hit(out s);
                    logLbl.Text += String.Format("{0} {1} {2}\r\n", enemy.MinionClass, s, item.MinionClass);
                    if (item.Health <= 0) { AllyMinions.Remove(item); enemy.MoveFight = Enemy_Classes.ACTION.Move; logLbl.Text += "ENEMY minion killed ALLY minion\r\n"; return false; }
                    enemy.Health -= item.Hit(out s);
                    logLbl.Text += String.Format("{0} {1} {2}\r\n", item.MinionClass, s, enemy.MinionClass);
                    if (enemy.Health <= 0) { EnemyMinions.Remove(enemy); item.MoveFight = Character_Classes.ACTION.Move; logLbl.Text += "ALLY minion killed ENEMY minion\r\n"; return false; }
                    return true;
                }
            }
            distance = Math.Sqrt(Math.Pow(enemy.Coords.X - AllyHero.Coords.X, 2) + Math.Pow(enemy.Coords.Y - AllyHero.Coords.Y, 2));
            if (distance <= 50 && AllyHero.Health > 0)
            {
                AllyHero.MoveFight = Character_Classes.ACTION.Fight;
                enemy.MoveFight = Enemy_Classes.ACTION.Fight;
                string s;
                AllyHero.Health -= enemy.Hit(out s);
                logLbl.Text += String.Format("{0} {1} {2}\r\n", enemy.MinionClass, s, AllyHero.HeroClass);
                if (AllyHero.Health <= 0) { enemy.MoveFight = Enemy_Classes.ACTION.Move; logLbl.Text += "ENEMY minion killed ALLY HERO\r\n"; return false; }
                enemy.Health -= AllyHero.Hit(out s);
                logLbl.Text += String.Format("{0} {1} {2}\r\n", AllyHero.HeroClass, s, enemy.MinionClass);
                if (enemy.Health <= 0) { EnemyMinions.Remove(enemy); AllyHero.MoveFight = Character_Classes.ACTION.Move; logLbl.Text += "ALLY minion killed ENEMY HERO\r\n"; return false; }
                return true;
            }

            foreach (var item in Mines.ToArray())
            {
                distance = Math.Sqrt(Math.Pow(enemy.Coords.X - item.Coords.X, 2) + Math.Pow(enemy.Coords.Y - item.Coords.Y, 2));
                if (distance <= 50)
                {
                    enemy.MoveFight = Enemy_Classes.ACTION.Fight;
                    string s;
                    item.Health -= enemy.Hit(out s);
                    logLbl.Text += String.Format("{0} {1} MINE\r\n", enemy.MinionClass, s);
                    if (item.Health <= 0) { Mines.Remove(item); enemy.MoveFight = Enemy_Classes.ACTION.Move; logLbl.Text += "ENEMY minion destroyed MINE\r\n"; return false; }
                    return true;
                }
            }
            enemy.MoveFight = Enemy_Classes.ACTION.Move;
            return false;
        }

        public bool FindAim(AllyEntity ally)
        {
            foreach (var item in EnemyMinions.ToArray())
            {
                double distance = Math.Sqrt(Math.Pow(ally.Coords.X - item.Coords.X, 2) + Math.Pow(ally.Coords.Y - item.Coords.Y, 2));
                if (distance <= 50)
                {
                    item.MoveFight = Enemy_Classes.ACTION.Fight;
                    ally.MoveFight = Character_Classes.ACTION.Fight;
                    string s;
                    item.Health -= ally.Hit(out s);
                    logLbl.Text += String.Format("{0} {1} {2}\r\n", ally.MinionClass, s, item.MinionClass);
                    if (item.Health <= 0) { EnemyMinions.Remove(item); ally.MoveFight = Character_Classes.ACTION.Move; logLbl.Text += "ALLY minion killed ENEMY minion\r\n"; return false; }
                    ally.Health -= item.Hit(out s);
                    logLbl.Text += String.Format("{0} {1} {2}\r\n", item.MinionClass, s, ally.MinionClass);
                    if (ally.Health <= 0) { AllyMinions.Remove(ally); item.MoveFight = Enemy_Classes.ACTION.Move; logLbl.Text += "ENEMY minion killed ALLY minion\r\n"; return false; }
                    return true;
                }
            }
            ally.MoveFight = Character_Classes.ACTION.Move;
            return false;
        }

        public bool FindAim(ref AllyEntity hero, bool flag)
        {
            foreach (var item in EnemyMinions.ToArray())
            {
                double distance = Math.Sqrt(Math.Pow(hero.Coords.X - item.Coords.X, 2) + Math.Pow(hero.Coords.Y - item.Coords.Y, 2));
                if (distance <= 50)
                {
                    item.MoveFight = Enemy_Classes.ACTION.Fight;
                    hero.MoveFight = Character_Classes.ACTION.Fight;
                    string s;
                    item.Health -= hero.Hit(out s);
                    logLbl.Text += String.Format("{0} {1} {2}\r\n", hero.HeroClass, s, item.MinionClass);
                    if (item.Health <= 0) { EnemyMinions.Remove(item); hero.MoveFight = Character_Classes.ACTION.Move; logLbl.Text += "ALLY HERO killed ENEMY minion\r\n"; return false; }
                    hero.Health -= item.Hit(out s);
                    logLbl.Text += String.Format("{0} {1} {2}\r\n", item.MinionClass, s, hero.HeroClass);
                    if (hero.Health <= 0) { item.MoveFight = Enemy_Classes.ACTION.Move; logLbl.Text += "ENEMY minion killed ALLY HERO\r\n"; return false; }
                    return true;
                }
            }
            hero.MoveFight = Character_Classes.ACTION.Move;
            return false;
        }

        public void Mining()
        {
            foreach (var item in Mines)
            {
                item.Mining();
                AllyHero.Gold += item.MinedGold;
                item.MinedGold = 0;
            }

        }

        public void CreateMinesWithWorkers()
        {
            for (int i = 0; i < 2; i++)
            {
                if (i == 0) Mines.Add(new Mine(new PointF(675, 115)));
                else Mines.Add(new Mine(new PointF(350, 80)));
            }
            foreach (var item in Mines)
            {
                for (int i = 0; i < 3; i++)
                {
                    item.CreateWorker();
                }
            }
        }
    }
}
