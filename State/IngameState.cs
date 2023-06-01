using System.Collections.Generic;
using CustomProgram.Bullets;
using CustomProgram.Buttons;
using CustomProgram.Cards;
using CustomProgram.Factory;
using CustomProgram.Plants;
using CustomProgram.Zombies;
using SplashKitSDK;

namespace CustomProgram.State
{
    public class IngameState : GameState
    {
        private Window _gameWindow;
        private Map _map;
        private ChosenCards _chosenCard;
        private int _initialSun;
        private Card _selectedCard;
        private List<SunFlower> _sunflowers;
        private List<Sun> _suns;
        private List<Zombie> _zombies;
        private List<ShooterPlant> _shooterPlants;
        private List<PotatoMine> _potatoMines;
        private List<Wallnut> _wallnuts;
        private List<Plant> _plants;
        private ZombieFactoryCreator _zombieFactory;
        private int _zombieKilled;
        private int _zombieLeft;
        private bool _endGame;
        private Timer _timer;
        private List<Music> _musicList;
        private int _musicIndex;
        private Button _button;
        public IngameState(Window window, List<Card> chosenCards) : base()
        {
            _gameWindow = window;
            _map = new Map();
            _chosenCard = new ChosenCards(chosenCards);
            _sunflowers = new List<SunFlower>();
            _initialSun = 50;
            _suns = new List<Sun>();
            _zombies = new List<Zombie>();
            _plants = new List<Plant>();
            _shooterPlants = new List<ShooterPlant>();
            _potatoMines = new List<PotatoMine>();
            _wallnuts = new List<Wallnut>();
            _zombieFactory = new ZombieFactoryCreator();
            _timer = SplashKit.CreateTimer("timer");
            _zombieLeft = 100;
            _endGame = false;
            _musicIndex = 0;
            SplashKit.StartTimer(_timer);
            _musicList = new List<Music>();
            _musicList.Add(SplashKit.LoadMusic("UltimateBattleIngame", "UltimateBattleIngame_25.mp3"));
            _musicList.Add(SplashKit.LoadMusic("First", "First.mp3"));
            _musicList.Add(SplashKit.LoadMusic("Winningmusic", "Winningmusic.mp3"));
            _musicList.Add(SplashKit.LoadMusic("DefeatingMusic", "DefeatingMusic.mp3"));



        }
        public void NextState()
        {

        }
        public void PreviousState()
        {
            GameContext.GetGameInstance(_gameWindow).CurrentState = new ChooseSeedState(_gameWindow);   //return to chosen seed state
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
                    SplashKit.PlayMusic(_musicList[_musicIndex], 1, 0.5f);
                    _musicIndex++;
                }
                if (_musicIndex >= 1)
                {
                    _musicIndex = 0;
                }
                _map.GenerateCell();
                _map.DrawPlayerSun(_initialSun);
                _map.DrawRemainingZombies(_zombieLeft);
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Point2D point = new Point2D();
                    point.X = SplashKit.MouseX();
                    point.Y = SplashKit.MouseY();
                    if (point.X >= 400 && point.Y >= 100)
                    {
                        if (_selectedCard != null)
                        {
                            Planted(point);
                        }
                    }
                    else if (point.X >= 20 && point.Y <= 100)
                    {
                        SelectCard(point);
                    }
                    else
                    {
                        _selectedCard = null;
                    }
                }
                CreateSunFromSunflower();
                CreateRandomSunOnMap();
                if (_zombieLeft > 0)
                {
                    GenerateZombie();
                }
                ChangeWallnutsLayer();
                ShootZombies();
                RemoveSuns();
                ZombieStateInGame();
                PotatoMineStateInGame();
                ShooterPlantLoading();
                CheckPeasHitZombies();
                CheckMinesBlowZombies();
                ZombiesEatPlants();
                Death();
                _chosenCard.DrawCardsInGame();
                SplashKit.UpdateAllSprites();
                CheckEndGame();
            }
            else
            {
                if (!SplashKit.MusicPlaying()) SplashKit.PlayMusic(_musicList[_musicIndex], 1, 0.5f);
                _button.CheckButtonState();
                _button.Draw();
                if (_button.IsClickedTime >= 15)
                {
                    FreeAllMusics();
                    FreeAllSprites();
                    PreviousState();
                }
            }
            _gameWindow.Refresh(60);
        }
        public void FreeAllMusics()
        {
            SplashKit.FreeAllMusic();
            for (int i = 0; i < _musicList.Count; i++)
            {
                _musicList.Remove(_musicList[i]);
            }

        }
        public void FreeAllSprites()
        {
            SplashKit.FreeAllSprites();
            for (int i = 0; i < _plants.Count; i++) _plants.Remove(_plants[i]);
            for (int i = 0; i < _sunflowers.Count; i++) _sunflowers.Remove(_sunflowers[i]);
            for (int i = 0; i < _suns.Count; i++) _suns.Remove(_suns[i]);
            for (int i = 0; i < _zombies.Count; i++) _zombies.Remove(_zombies[i]);
            for (int i = 0; i < _wallnuts.Count; i++) _wallnuts.Remove(_wallnuts[i]);
            for (int i = 0; i < _potatoMines.Count; i++) _potatoMines.Remove(_potatoMines[i]);
            for (int i = 0; i < _shooterPlants.Count; i++) _shooterPlants.Remove(_shooterPlants[i]);
        }
        public void Planted(Point2D pt)     //let player plant plants on available cell
        {
            Cell cell = _map.LocateCellByMousePostion(pt);
            if (!cell.isPlaced)
            {
                Plant plant = null;
                if (_selectedCard.GetType().Equals(typeof(CardPeaShooter)))
                {
                    plant = new PeaShooter(cell.Point.X, cell.Point.Y);
                    _shooterPlants.Add(plant as PeaShooter);
                }
                else if (_selectedCard.GetType().Equals(typeof(CardSunFlower)))
                {
                    plant = new SunFlower(cell.Point.X, cell.Point.Y);
                    _sunflowers.Add(plant as SunFlower);
                }
                else if (_selectedCard.GetType().Equals(typeof(CardSnowpea)))
                {
                    plant = new IcePeaShooter(cell.Point.X, cell.Point.Y);
                    _shooterPlants.Add(plant as IcePeaShooter);
                }
                else if (_selectedCard.GetType().Equals(typeof(CardRepeater)))
                {
                    plant = new Repeater(cell.Point.X, cell.Point.Y);
                    _shooterPlants.Add(plant as Repeater);
                }
                else if (_selectedCard.GetType().Equals(typeof(CardPotatoMine)))
                {
                    plant = new PotatoMine(cell.Point.X, cell.Point.Y);
                    _potatoMines.Add(plant as PotatoMine);
                }
                else if (_selectedCard.GetType().Equals(typeof(CardWallnut)))
                {
                    plant = new Wallnut(cell.Point.X, cell.Point.Y);
                    _wallnuts.Add(plant as Wallnut);
                }
                else if (_selectedCard.GetType().Equals(typeof(CardSoldierPea)))
                {
                    plant = new SoldierPea(cell.Point.X, cell.Point.Y);
                    _shooterPlants.Add(plant as SoldierPea);
                }
                else if (_selectedCard.GetType().Equals(typeof(CardElectricPeashooter)))
                {
                    plant = new ElectricPeashooter(cell.Point.X, cell.Point.Y);
                    _shooterPlants.Add(plant as ElectricPeashooter);
                }

                _plants.Add(plant);
                _initialSun -= _selectedCard.SunCost;
                plant.Cell = cell;
                cell.isPlaced = true;
                _selectedCard = null;
            }
        }

        public void SelectCard(Point2D point)
        {
            foreach (Card card in _chosenCard.Chosencards)
            {
                if (SplashKit.SpritePointCollision(card.Sprite, point))
                {
                    if (_initialSun >= card.SunCost) _selectedCard = card;
                }
            }
        }
        public void CreateSunFromSunflower()  //sun generates from sunflower
        {
            foreach (SunFlower sunflower in _sunflowers)
            {
                if (sunflower.Cooldown == sunflower.SunGenTime)
                {
                    _suns.Add(new Sun(sunflower));
                    sunflower.ResetTick();
                }
                sunflower.TickSinceLastCreateSun();
            }
        }
        public void CreateRandomSunOnMap() //random sun generates on map
        {
            if (SplashKit.TimerTicks(_timer) <= 15000)
            {
                if (SplashKit.Rnd(400) < 5)
                {
                    _suns.Add(new Sun(SplashKit.Rnd(450, 1200), SplashKit.Rnd(130, 700)));

                }
            }
            else if (SplashKit.TimerTicks(_timer) <= 30000)
            {
                if (SplashKit.Rnd(600) < 5)
                {
                    _suns.Add(new Sun(SplashKit.Rnd(450, 1200), SplashKit.Rnd(130, 700)));

                }
            }
            else
            {
                if (SplashKit.Rnd(800) < 5)
                {
                    _suns.Add(new Sun(SplashKit.Rnd(450, 1200), SplashKit.Rnd(130, 700)));
                }
            }
        }
        public void GenerateZombie() //generate zombie 
        {
            Zombie zombie = _zombieFactory.CreateZombie(_timer);
            if (zombie != null)
            {
                _zombies.Add(zombie);
                _zombieLeft--;
            }
        }
        public void ShooterPlantLoading()  //check if shooter plants are ready to shoot
        {
            foreach (ShooterPlant shooter in _shooterPlants)
            {

                if (shooter.ReloadTime < 100)
                {
                    shooter.ReloadTimeTicks();
                }
                else
                {
                    shooter.IsReadyToShoot = true;
                }
            }

        }
        public void RemoveSuns()  //delete sun after amount of time
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
                        _initialSun += 25;
                    }
                }
            }

            foreach (Sun sun in _suns)
            {
                sun.TickSinceSpawns();
                if (sun.ExistTime >= 200)
                {
                    _removeSuns.Add(sun);
                }

            }

            foreach (Sun sun in _removeSuns)
            {
                _suns.Remove(sun);
                SplashKit.FreeSprite(sun.Sprite);
            }
        }
        public void ZombieStateInGame()  //check the state of zombie during the game
        {
            foreach (Zombie zombie in _zombies)
            {
                zombie.TickSinceFirstBite(); //ticks the counter since zombie first bite the plant.
                zombie.ChangeSpeed(); //check speed of zombie if it get stunned or slowed or normal
                zombie.ChangeLayer();   //change the layer when zombie eating or not
                zombie.DecreaseSlowingTime();  //decrease cooldown time if it was hit by the snowpea
                zombie.DecreaseStunningTime(); //decrease cooldown time if it was hit by the electricpea
            }
        }
        public void PotatoMineStateInGame()
        {
            foreach (PotatoMine potato in _potatoMines)
            {
                potato.ChangeState();
            }
        }
        public void ChangeWallnutsLayer()
        {
            foreach (Wallnut wallnut in _wallnuts)
            {
                wallnut.ChangeLayer();
            }
        }

        public void ShootZombies()
        {
            foreach (Zombie zombie in _zombies)
            {
                foreach (ShooterPlant plant in _shooterPlants)
                {
                    if (plant.Sprite.X > zombie.Sprite.X) continue;
                    if (plant.IsReadyToShoot && plant.Row == zombie.Row)
                    {
                        plant.Shoot();
                    }
                }
            }
        }

        public void CheckPeasHitZombies() //check when pea bullet hit zombie
        {
            foreach (Zombie zombie in _zombies)
            {
                foreach (ShooterPlant plant in _shooterPlants)
                {
                    List<Bullet> removeBullet = new List<Bullet>();
                    if (zombie.Row == plant.Row && plant.BulletPeas.Count != 0)
                    {
                        foreach (Bullet bullet in plant.BulletPeas)
                        {
                            if (SplashKit.SpriteCollision(bullet.Sprite, zombie.Sprite))
                            {
                                if (!removeBullet.Contains(bullet))
                                {
                                    removeBullet.Add(bullet);
                                    zombie.BeAttacked(bullet);
                                }
                            }
                        }
                    }
                    foreach (Bullet bullet in plant.BulletPeas)
                    {
                        if (bullet.Sprite.X > SplashKit.ScreenWidth())
                        {
                            removeBullet.Add(bullet);
                        }
                    }
                    foreach (Bullet bullet in removeBullet)
                    {
                        plant.BulletPeas.Remove(bullet);
                        SplashKit.FreeSprite(bullet.Sprite);
                    }
                }
            }
        }
        public void ZombiesEatPlants() //check when zombie attack plant
        {
            foreach (Zombie zombie in _zombies)
            {
                zombie.IsEating = false;
                foreach (Plant plant in _plants)
                {
                    if (SplashKit.SpriteCollision(plant.Sprite, zombie.Sprite))
                    {
                        zombie.IsEating = true;
                        if (zombie.ChewingTime >= 100)
                        {
                            plant.BeAttacked(zombie);
                            zombie.ChewingTime = 0;
                        }
                    }
                }
            }
        }

        public void CheckMinesBlowZombies() //check when zombie step on potato mine
        {
            foreach (PotatoMine potato in _potatoMines)
            {
                if (potato.PlantedTime >= 800)
                {
                    foreach (Zombie zombie in _zombies)
                    {
                        if (potato.IsExplode && !zombie.IsBlowedByMine)
                        {
                            if (SplashKit.SpriteCollision(potato.Sprite, zombie.Sprite))
                            {
                                zombie.Health -= potato.Damage;
                                zombie.IsBlowedByMine = true;
                            }
                        }
                        else
                        {
                            if (SplashKit.SpriteCollision(potato.Sprite, zombie.Sprite))
                            {
                                potato.IsExplode = true;
                            }
                        }
                    }
                }
            }
        }
        public void Death() //check all game object is alive or not
        {
            List<Zombie> _deathZombies = new List<Zombie>();
            List<Plant> _deathPlants = new List<Plant>();
            foreach (Zombie zombie in _zombies)
            {
                if (zombie.Health <= 0)
                {
                    _deathZombies.Add(zombie);
                }
            }
            foreach (Plant plant in _plants)
            {
                if (plant.GetType().Equals(typeof(PotatoMine)))
                {
                    if ((plant as PotatoMine).TimeSinceExploded >= 20 || (plant as PotatoMine).Health <= 0)
                    {
                        _deathPlants.Add(plant);
                    }
                }
                else
                {
                    if (plant.Health <= 0)
                    {
                        _deathPlants.Add(plant);
                    }
                }
            }

            foreach (Zombie zombie in _deathZombies)
            {
                _zombies.Remove(zombie);
                _zombieKilled++;
                SplashKit.FreeSprite(zombie.Sprite);
            }

            foreach (Plant plant in _deathPlants)
            {
                plant.Cell.isPlaced = false;
                if (plant.GetType().BaseType.Equals(typeof(ShooterPlant)))
                {
                    _shooterPlants.Remove(plant as ShooterPlant);
                }
                else if (plant.GetType().Equals(typeof(SunFlower)))
                {
                    _sunflowers.Remove(plant as SunFlower);
                }
                else if (plant.GetType().Equals(typeof(PotatoMine)))
                {
                    _potatoMines.Remove(plant as PotatoMine);
                }
                else if (plant.GetType().Equals(typeof(Wallnut)))
                {
                    _wallnuts.Remove(plant as Wallnut);
                }
                _plants.Remove(plant);
                SplashKit.FreeSprite(plant.Sprite);
            }
        }

        public void CheckEndGame() //check if player win or lose
        {
            if (_zombieKilled == 50)
            {
                _endGame = true;
                Taco taco = new Taco();
                if (_musicIndex != 2)
                {
                    SplashKit.StopMusic();
                    _musicIndex = 2;
                }
                if (!SplashKit.MusicPlaying()) SplashKit.PlayMusic(_musicList[2], 1, 0.3f);
                _button = new ButtonB();
            }
            foreach (Zombie zombie in _zombies)
            {
                if (zombie.Sprite.X < 280)
                {
                    _endGame = true;
                    Brain brain = new Brain();
                    if (_musicIndex != 3)
                    {
                        SplashKit.StopMusic();
                        _musicIndex = 3;
                    }
                    if (!SplashKit.MusicPlaying()) SplashKit.PlayMusic(_musicList[3], 1, 0.3f);
                    _button = new ButtonB();
                }
            }
        }

    }
}
