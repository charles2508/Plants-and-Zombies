using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Custom_Program
{
    public class IngameState : GameState
    {
        private Window _gameWindow;
        private Map _map;
        private PlayingCard _playingCard;
        private int _sunPoints;
        private Card _selectedCard;
        private List<SunFlower> _sunflowers;
        private List<Sun> _suns;
        private List<Zombie> _zombies;
        private List<Shooter> _shooters;
        private List<PotatoMine> _potatoMines;
        private List<Wallnut> _wallnuts;
        private List<Item> _items;
        private ZombieFactory _zombieFactory;
        private int _zombieKilled;
        private int _remainingZombies;
        private int _sunsAtBeggining;
        private bool _endGame;
        private Timer _timer;
        private List<Music> _musicList;
        private int _musicIndex;
        private Button _okayButton;
        public IngameState(Window window, List<Card> chosenCards) : base()
        {
            _gameWindow = window;
            _map = new Map();
            _playingCard = new PlayingCard(chosenCards);
            _sunflowers = new List<SunFlower>();
            _sunPoints = 0;
            _suns = new List<Sun>();
            _zombies = new List<Zombie>();
            _shooters = new List<Shooter>();
            _potatoMines = new List<PotatoMine>();
            _wallnuts = new List<Wallnut>();
            _items = new List<Item>();
            _zombieFactory = new ZombieFactory();
            _zombieFactory.RegisterZombie(ZombieType.Normal, typeof(NormalZombie)); //Register Zombie
            _zombieFactory.RegisterZombie(ZombieType.Conehead, typeof(ConeheadZombie));
            _zombieFactory.RegisterZombie(ZombieType.Buckethead, typeof(BucketheadZombie));
            _timer = SplashKit.CreateTimer("timer");
            _remainingZombies = 50;
            _sunsAtBeggining = 8;
            _endGame = false;
            _musicList = new List<Music>();
            _musicList.Add(SplashKit.LoadMusic("ChooseYourSeedsIngame", "ChooseYourSeedsIngame_19.mp3"));
            _musicList.Add(SplashKit.LoadMusic("Grasswalk", "Grasswalk_4.mp3"));
            _musicList.Add(SplashKit.LoadMusic("CrazyDaveIngame", "CrazyDaveIngame_18.mp3"));
            _musicList.Add(SplashKit.LoadMusic("CerebrawlIngame", "CerebrawlIngame_27.mp3"));
            _musicList.Add(SplashKit.LoadMusic("ZenGarden", "ZenGarden_7.mp3"));
            _musicList.Add(SplashKit.LoadMusic("UltimateBattleIngame", "UltimateBattleIngame_25.mp3"));
            _musicList.Add(SplashKit.LoadMusic("Winningmusic", "Winningmusic.mp3"));
            _musicList.Add(SplashKit.LoadMusic("DefeatingMusic", "DefeatingMusic.mp3"));
            SplashKit.StartTimer(_timer);
        }
        public void Next()
        {
            //No implementation
        }
        public void Previous()
        {
            GameContext.GetInstance(_gameWindow).State = new PickingItemState(_gameWindow);
        }

        public void Update()
        {
            SplashKit.ProcessEvents();
            _gameWindow.Clear(Color.White); 
            SplashKit.DrawAllSprites();
            if (!_endGame)
            {
                if (!SplashKit.MusicPlaying())
                {
                    SplashKit.PlayMusic(_musicList[_musicIndex], 1, 0.3f);
                    _musicIndex++;
                }
                if (_musicIndex == 5) _musicIndex = 0;
                _map.AddCentrePoint();
                _map.DrawSunPoint(_sunPoints);
                _map.DrawRemainingZombies(_remainingZombies);
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Point2D point = new Point2D();
                    point.X = SplashKit.MouseX();
                    point.Y = SplashKit.MouseY();
                    if (point.X >= 420 && point.Y >= 120)
                    {
                        if (_selectedCard != null)
                        {
                            PutItem(point);
                        }
                    }
                    else if (point.X >= 20 && point.X <= 85 && point.Y >= 50 && point.Y <= 680)
                    {
                        SelectCard(point);
                    }
                    else
                    {
                        _selectedCard = null;
                    }
                }
                CreateSun();
                CreateRandomSun();
                if (_remainingZombies > 0) CreateZombie();
                AdjustItemLayer();
                ShootZombies();
                CheckShooterLoad();
                CheckPeasCollideZombies();
                CheckItemsCollideZombies();
                CheckMinesCollideZombies();
                CheckRemoveSuns();
                CheckZombieState();
                CheckPotatoMineState();
                CheckDeath();
                _playingCard.DisplayCardsInGame();
                SplashKit.UpdateAllSprites();
                CheckEndGame();
            } else
            {
                if (!SplashKit.MusicPlaying()) SplashKit.PlayMusic(_musicList[_musicIndex], 1, 0.3f);
                _okayButton.CheckButtonState();
                _okayButton.Draw();
                if (_okayButton.OnClickingTime >= 15)
                {
                    FreeAllMusics();
                    FreeAllSprites();
                    Previous();
                }
            }
            _gameWindow.Refresh(60);
        }

        public void PutItem(Point2D point)
        {
            CentrePoint centrePoint = _map.FindNearestCentre(point);
            if (!centrePoint.Placed)
            {
                Item itm = null;
                if (_selectedCard.GetType().Equals(typeof(CardPeaShooter)))
                {
                    itm = new PeaShooter(centrePoint.Point.X, centrePoint.Point.Y);
                    _shooters.Add(itm as PeaShooter);
                }
                else if (_selectedCard.GetType().Equals(typeof(CardSunFlower)))
                {
                    itm = new SunFlower(centrePoint.Point.X, centrePoint.Point.Y);
                    _sunflowers.Add(itm as SunFlower);
                }
                else if (_selectedCard.GetType().Equals(typeof(CardIceShooter)))
                {
                    itm = new IcePeaShooter(centrePoint.Point.X, centrePoint.Point.Y);
                    _shooters.Add(itm as IcePeaShooter);
                }
                else if (_selectedCard.GetType().Equals(typeof(CardRepeater)))
                {
                    itm = new RepeaterShooter(centrePoint.Point.X, centrePoint.Point.Y);
                    _shooters.Add(itm as RepeaterShooter);
                }
                else if (_selectedCard.GetType().Equals(typeof(CardPotatoMine)))
                {
                    itm = new PotatoMine(centrePoint.Point.X, centrePoint.Point.Y);
                    _potatoMines.Add(itm as PotatoMine);
                }
                else if (_selectedCard.GetType().Equals(typeof(CardWallnut)))
                {
                    itm = new Wallnut(centrePoint.Point.X, centrePoint.Point.Y);
                    _wallnuts.Add(itm as Wallnut);
                }
                else if (_selectedCard.GetType().Equals(typeof(CardPuffShroom)))
                {
                    itm = new PuffShroom(centrePoint.Point.X, centrePoint.Point.Y);
                    _shooters.Add(itm as PuffShroom);
                }
                _items.Add(itm);
                _sunPoints -= _selectedCard.SunPointsRequired;
                itm.CentrePoint = centrePoint;
                centrePoint.Placed = true; //This indicates that the centrepoint has already been placed by an item
                _selectedCard = null;
            }
        }

        public void SelectCard(Point2D point)
        {
            foreach (Card card in _playingCard.PlayingCards)
            {
                if (SplashKit.SpritePointCollision(card.Sprite, point))
                {
                    if (_sunPoints >= card.SunPointsRequired) _selectedCard = card;
                }
            }
        }

        //Create Sun for sunflowers
        public void CreateSun()
        {
            foreach (SunFlower sunflower in _sunflowers)
            {
                if (sunflower.WaitingTime == sunflower.BloomingTime)
                {
                    _suns.Add(new Sun(sunflower));
                    sunflower.Reset();
                }
                sunflower.Count();
            }
        }
        //Create random sun
        public void CreateRandomSun()
        {
            if (SplashKit.TimerTicks(_timer) <= 15000 && _sunsAtBeggining >= 2)
            {
                if (SplashKit.Rnd(300) < 3)
                {
                    _suns.Add(new Sun(SplashKit.Rnd(445, 1200), SplashKit.Rnd(130, 700)));
                    _sunsAtBeggining--;
                }
            }
            else if (SplashKit.TimerTicks(_timer) <= 30000 && _sunsAtBeggining >=0)
            {
                if (SplashKit.Rnd(350) == 1)
                {
                    _suns.Add(new Sun(SplashKit.Rnd(445, 1200), SplashKit.Rnd(130, 700)));
                    _sunsAtBeggining--;
                }
            }
            else
            {
                if (SplashKit.Rnd(850) == 1)
                {
                    _suns.Add(new Sun(SplashKit.Rnd(445, 1200), SplashKit.Rnd(130, 700)));
                }
            }
        }

        //Create Zombie 
        public void CreateZombie()
        {
            Zombie zombie = _zombieFactory.CreateZombie(_remainingZombies, _timer);
            if (zombie != null)
            {
                _zombies.Add(zombie);
                _remainingZombies--;
            }
        }


        //Check whether the shooter has already loaded the Pea 
        public void CheckShooterLoad()
        {
            foreach (Shooter shooter in _shooters)
            {
                if (shooter.GetType().Equals(typeof(PuffShroom)))
                {
                    if (shooter.LoadingTime < 70)
                    {
                        shooter.IncreaseLoadingTime();
                    }
                    else
                    {
                        shooter.CanShoot = true;
                    }
                }
                else
                {
                    if (shooter.LoadingTime < 120)
                    {
                        shooter.IncreaseLoadingTime();
                    }
                    else
                    {
                        shooter.CanShoot = true;
                    }
                }
            }
        }

        //Check removing suns
        public void CheckRemoveSuns()
        {
            List<Sun> _removeSuns = new List<Sun>();
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                Point2D point = new Point2D();
                point.X = SplashKit.MouseX();
                point.Y = SplashKit.MouseY();
                foreach (Sun sun in _suns)
                {
                    if (sun.IsAt(point))
                    {
                        _removeSuns.Add(sun);
                        _sunPoints += 25;
                    }
                }
            }

            foreach (Sun sun in _suns)
            {
                if (sun.AppearTime >= 200)
                {
                    _removeSuns.Add(sun);
                }
                sun.Count();
            }

            foreach (Sun sun in _removeSuns)
            {
                _suns.Remove(sun);
                SplashKit.FreeSprite(sun.Sprite);
            }
        }

        //Check the state of zombies
        public void CheckZombieState()
        {
            foreach (Zombie zombie in _zombies)
            {
                zombie.IncreaseSwallowingTime(); //Always increase the swallowing time of the zombie
                zombie.AdjustVelocity(); //Check whether the velocity of zombie need to be adjusted
                zombie.AdjustLayer();   //Adjust the layer of zombies
                zombie.DecreaseSlowingTime();  //Decrease slowing time if it was hit by the ice shooter
            }
        }



        //Check the state of the potato mine
        public void CheckPotatoMineState()
        {
            foreach (PotatoMine pMine in _potatoMines)
            {
                pMine.AdjustingState();
            }
        }


        public void AdjustItemLayer()
        {
            AdjustWallnutsLayer();
            AdjustPuffShroomLayer();
        }

        public void AdjustPuffShroomLayer()
        {
            foreach (Shooter shooter in _shooters)
            {
                if (shooter.GetType().Equals(typeof(PuffShroom)))
                {
                    (shooter as PuffShroom).AdjustLayer();
                    (shooter as PuffShroom).SleepingTime++;
                }
            }
        }

        //Adjust layer of wallnut 
        public void AdjustWallnutsLayer()
        {
            foreach (Wallnut wallnut in _wallnuts)
            {
                wallnut.AdjustLayer();
            }
        }

        public void ShootZombies()
        {
            foreach (Zombie zombie in _zombies)
            {
                foreach (Shooter shooter in _shooters)
                {
                    if (shooter.Sprite.X > zombie.Sprite.X) continue;
                    if (shooter.CanShoot && shooter.Row == zombie.Row)
                    {
                        if (shooter.GetType().Equals(typeof(PuffShroom))) (shooter as PuffShroom).Shoot(zombie);
                        else shooter.Shoot();
                    }
                }
            }
        }

        //Check collision between zombie and pea
        public void CheckPeasCollideZombies()
        {
            foreach (Zombie zombie in _zombies)
            {
                foreach (Shooter shooter in _shooters)
                {
                    List<Pea> removePea = new List<Pea>();
                    if (zombie.Row == shooter.Row && shooter.ShootingPea.Count != 0)
                    {
                        foreach (Pea pea in shooter.ShootingPea)
                        {
                            if (SplashKit.SpriteCollision(pea.Sprite, zombie.Sprite))
                            {
                                if (!removePea.Contains(pea))
                                {
                                    removePea.Add(pea);
                                    zombie.BeAttacked(pea);
                                }
                            }
                        }    
                    }
                    foreach (Pea pea in shooter.ShootingPea)
                    {
                        if (pea.Sprite.X > SplashKit.ScreenWidth())
                        {
                            removePea.Add(pea);
                        }
                    }
                    foreach (Pea pea in removePea)
                    {
                        shooter.ShootingPea.Remove(pea);
                        SplashKit.FreeSprite(pea.Sprite);
                    }
                }
            }
        }

        public void CheckItemsCollideZombies()
        {
            foreach (Zombie zombie in _zombies)
            {
                zombie.Eating = false;
                foreach (Item itm in _items)
                {
                    if (itm.GetType().Equals(typeof(PotatoMine))) continue;
                    if (SplashKit.SpriteCollision(itm.Sprite, zombie.Sprite))
                    {
                        zombie.Eating = true;
                        if (zombie.SwallowingTime >= 36)
                        {
                            itm.BeAttacked(zombie);
                            zombie.SwallowingTime = 0;
                        }
                    }
                }
            }
        }

        public void CheckMinesCollideZombies()
        {
            foreach (PotatoMine pMine in _potatoMines)
            {
                if (pMine.InitialTime >= 900)
                {
                    foreach (Zombie zombie in _zombies)
                    {
                        if (pMine.Exploding && !zombie.DamagedByMine)
                        {
                            if (SplashKit.SpriteCollision(pMine.Sprite, zombie.Sprite))
                            {
                                zombie.Health -= pMine.Damage;
                                zombie.DamagedByMine = true;
                            }
                        }
                        else
                        {
                            if (SplashKit.SpriteCollision(pMine.Sprite, zombie.Sprite))
                            {
                                pMine.Exploding = true;
                            }
                        }
                    }
                }
            }
        }

        public void CheckDeath()
        {
            List<Zombie> _deathZombies = new List<Zombie>();
            List<Item> _deathItems = new List<Item>();
            foreach (Zombie zombie in _zombies)
            {
                if (zombie.Health <= 0)
                {
                    _deathZombies.Add(zombie);
                }
            }

            foreach (Item item in _items)
            {
                if (item.GetType().Equals(typeof(PotatoMine)))
                {
                    if ((item as PotatoMine).ExplodingTime >= 20) _deathItems.Add(item);
                }
                else
                {
                    if (item.Health <= 0)
                    {
                        _deathItems.Add(item);
                    }
                }
            }

            foreach (Zombie zombie in _deathZombies)
            {
                _zombies.Remove(zombie);
                _zombieKilled++;
                SplashKit.FreeSprite(zombie.Sprite);
            }

            foreach (Item item in _deathItems)
            {
                item.CentrePoint.Placed = false;
                if (item.GetType().BaseType.Equals(typeof(Shooter)))
                {
                    _shooters.Remove(item as Shooter);
                }
                else if (item.GetType().Equals(typeof(SunFlower)))
                {
                    _sunflowers.Remove(item as SunFlower);
                }
                else if (item.GetType().Equals(typeof(PotatoMine)))
                {
                    _potatoMines.Remove(item as PotatoMine);
                }
                else if (item.GetType().Equals(typeof(Wallnut)))
                {
                    _wallnuts.Remove(item as Wallnut);
                }
                _items.Remove(item);
                SplashKit.FreeSprite(item.Sprite);
            }
        }

        public void CheckEndGame()
        {
            if (_zombieKilled == 50) //testing case
            {
                _endGame = true;
                Victory victory = new Victory();
                if (_musicIndex != 6)
                {
                    SplashKit.StopMusic();
                    _musicIndex = 6;
                }
                if (!SplashKit.MusicPlaying()) SplashKit.PlayMusic(_musicList[6], 1, 0.3f);
                _okayButton = new OkayButton();
            }
            foreach (Zombie zombie in _zombies)
            {
                 if (zombie.Sprite.X < 280)
                 {
                    _endGame = true;
                     Defeat defeat = new Defeat();
                    if (_musicIndex != 7)
                    {
                        SplashKit.StopMusic();
                        _musicIndex = 7;
                    }
                    if (!SplashKit.MusicPlaying()) SplashKit.PlayMusic(_musicList[7], 1, 0.3f);
                    _okayButton = new OkayButton();
                }
            }
        }

        public bool Engame
        {
            get
            {
                return _endGame;
            }
        }

        public void FreeAllMusics()
        {
            SplashKit.FreeAllMusic();
            for (int i = 0; i < _musicList.Count; i++) _musicList.Remove(_musicList[i]);
        }
        public void FreeAllSprites()
        {
            SplashKit.FreeAllSprites();
            for (int i = 0; i < _items.Count; i++) _items.Remove(_items[i]);
            for (int i = 0; i < _sunflowers.Count; i++) _sunflowers.Remove(_sunflowers[i]);
            for (int i = 0; i < _suns.Count; i++) _suns.Remove(_suns[i]);
            for (int i = 0; i < _zombies.Count; i++) _zombies.Remove(_zombies[i]);
            for (int i = 0; i < _shooters.Count; i++) _shooters.Remove(_shooters[i]);
            for (int i = 0; i < _wallnuts.Count; i++) _wallnuts.Remove(_wallnuts[i]);
            for (int i = 0; i < _potatoMines.Count; i++) _potatoMines.Remove(_potatoMines[i]);
        }
    }
}
