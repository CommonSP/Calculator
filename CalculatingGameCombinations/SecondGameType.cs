using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatingGameCombinations.Logic;

namespace CalculatingGameCombinations
{
    public partial class SecondGameType : Form
    {
        public Game Game;
        private List<string> _mechanicCards;
        private List<string> _electronCards;
        private int cardsRow = 1;

        private string _cardsParth;
        private string[] _cardImages;

        private List<PictureBox> _mechanicImages = new List<PictureBox>();
        private List<List<PictureBox>> _electronImagesList = new List<List<PictureBox>>();

        private List<PictureBox> _electronImages1 = new List<PictureBox>();
        private List<PictureBox> _electronImages2 = new List<PictureBox>();
        private List<PictureBox> _electronImages3 = new List<PictureBox>();
        private List<PictureBox> _electronImages4 = new List<PictureBox>();
        private List<PictureBox> _electronImages5 = new List<PictureBox>();


        private List<string> _currentCardsPool;

   
        public SecondGameType(Game game)
        {
            Game = game;
            Game.GameStatistics.ClearStatistic();
            InitializeComponent();
            _cardsParth = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Assets\Cards");
            _cardImages = Directory.GetFiles(_cardsParth, "*.png", SearchOption.AllDirectories);
            FillPictureBoxLists();
            numericUpDown_coincidences.Value = game.CoincidenceCount;
            numericUpDown_gameIterations.Value = game.Interactions;
        }

        private void FillPictureBoxLists()
        {
            _mechanicImages.Add(pictureBox_m1);
            _mechanicImages.Add(pictureBox_m2);
            _mechanicImages.Add(pictureBox_m3);
            _mechanicImages.Add(pictureBox_m4);
            _mechanicImages.Add(pictureBox_m5);

            _electronImages1.Add(pictureBox_e11);

            _electronImages2.Add(pictureBox_e21);
            _electronImages2.Add(pictureBox_e22);

            _electronImages3.Add(pictureBox_e31);
            _electronImages3.Add(pictureBox_e32);
            _electronImages3.Add(pictureBox_e33);

            _electronImages4.Add(pictureBox_e41);
            _electronImages4.Add(pictureBox_e42);
            _electronImages4.Add(picturebox_e43);
            _electronImages4.Add(pictureBox_e44);

            _electronImages5.Add(pictureBox_e51);
            _electronImages5.Add(pictureBox_e52);
            _electronImages5.Add(pictureBox_e53);
            _electronImages5.Add(pictureBox_e54);
            _electronImages5.Add(pictureBox_e55);

            _electronImagesList.Add(_electronImages1);
            _electronImagesList.Add(_electronImages2);
            _electronImagesList.Add(_electronImages3);
            _electronImagesList.Add(_electronImages4);
            _electronImagesList.Add(_electronImages5);
        }

        private void ClearTable()
        {
            string noneImage = _cardImages.First(image => image == _cardsParth + "\\none.png");

            foreach (var image in _mechanicImages)
            {
                image.Image = new Bitmap(noneImage);
            }

            foreach (var image in _electronImages1)
            {
                image.Image = new Bitmap(noneImage);
            }
            foreach (var image in _electronImages2)
            {
                image.Image = new Bitmap(noneImage);
            }
            foreach (var image in _electronImages3)
            {
                image.Image = new Bitmap(noneImage);
            }
            foreach (var image in _electronImages4)
            {
                image.Image = new Bitmap(noneImage);
            }
            foreach (var image in _electronImages5)
            {
                image.Image = new Bitmap(noneImage);
            }
        }

        private void createNewPool()
        {
            _currentCardsPool = new List<string>();
            Game.CardsPool.ForEach(card =>
            {
                _currentCardsPool.Add(card);
            });
        }

        private void button_singleGame_Click(object sender, EventArgs e)
        {
            Game.GameStatistics = new GameStatistic();
            createNewPool();
            ClearTable();
            progressBar_gameProgres.Value = 0;
            HideStatistic();

            _mechanicCards = new List<string>();
            _electronCards = new List<string>();

            // Fill Mechanic cards pool
            for (int i = 0; i < 5; i++)
            {
                _mechanicCards.Add(_currentCardsPool[Game.GetRandomValue(_currentCardsPool.Count - 1)]);
                _mechanicImages[i].Image = new Bitmap(_cardImages.First(image => image == _cardsParth + $"\\{_mechanicCards[i]}.png"));
            }

            for (int i = 0; i <= cardsRow - 1; i++)
            {
                int randomValue = Game.GetRandomValue(_currentCardsPool.Count - 1);
                _electronCards.Add(_currentCardsPool[randomValue]);

                _currentCardsPool.RemoveAt(randomValue);

                _electronImagesList[cardsRow - 1][i].Image = new Bitmap(_cardImages.First(image => image == _cardsParth + $"\\{_electronCards[i]}.png"));
            }
            
            Game.GameStatistics.Statistics.Add(Game.GetGameStatistic(_mechanicCards, _electronCards));

            ShowSingleGameStatistic();
        }

        private void button_multiGame_Click(object sender, EventArgs e)
        {
            Game.GameStatistics = new GameStatistic();
            progressBar_gameProgres.Maximum = Game.Interactions;
            ClearTable();
            HideStatistic();

            for (int j = 0; j < Game.Interactions; j++)
            {
                _mechanicCards = new List<string>();
                _electronCards = new List<string>();

                createNewPool();

                // Fill Mechanic cards pool
                for (int i = 0; i < 5; i++)
                {
                    _mechanicCards.Add(_currentCardsPool[Game.GetRandomValue(_currentCardsPool.Count - 1)]);
                }

                for (int i = 0; i <= cardsRow - 1; i++)
                {
                    int randomValue = Game.GetRandomValue(_currentCardsPool.Count - 1);
                    _electronCards.Add(_currentCardsPool[randomValue]);

                    _currentCardsPool.RemoveAt(randomValue);
                }

                Game.GameStatistics.Statistics.Add(Game.GetGameStatistic(_mechanicCards, _electronCards));

                if (j % (Game.Interactions / 100) == 0)
                {
                    progressBar_gameProgres.Value = j;
                }
            }

            progressBar_gameProgres.Value = Game.Interactions;
            ShowMultiGameStatistic();
        }

        #region Statistic

        public void ShowSingleGameStatistic()
        {
            if (Game.GameStatistics.Statistics.Count == 1)
            {
                Game.GameStatistics.BuidData();
                if (Game.GameStatistics.WinsCount > 0)
                {
                    label_result.Text = "You win!";
                    label_result.ForeColor = Color.Green;
                    System.Media.SystemSounds.Asterisk.Play();

                } else
                {
                    label_result.Text = "You lose!";
                    label_result.ForeColor = Color.Red;
                    System.Media.SystemSounds.Exclamation.Play();
                }


                label_coincidence.Text = "0 coincidences";

                for (int i = 0; i < 5; i++)
                {
                    if (Game.GameStatistics.CoincidencesCount[i] > 0)
                    {
                        label_coincidence.Text = $"{i + 1} coincidences";
                        break;
                    }
                }

                groupBox_multigameStatistic.Visible = false;
                groupBox_singleGameStatistic.Visible = true;
            }
        }

        public void ShowMultiGameStatistic()
        {
            if (Game.GameStatistics.Statistics.Count > 0)
            {
                Game.GameStatistics.BuidData();
                label_totalGames.Text = Convert.ToString(Game.GameStatistics.GamesCount);
                label_wins.Text = Convert.ToString(Game.GameStatistics.WinsCount);
                label_winsp.Text = $"{(float)Game.GameStatistics.WinsCount * 100 / (float)Game.GameStatistics.GamesCount}%";
                label_loses.Text = Convert.ToString(Game.GameStatistics.LosesCount);
                label_losesp.Text = $"{(float)Game.GameStatistics.LosesCount * 100 / (float)Game.GameStatistics.GamesCount}%";
                label_jakpots.Text = Convert.ToString(Game.GameStatistics.Jaskpots);

                label_coincidences1.Text = Convert.ToString(Game.GameStatistics.CoincidencesCount[0]);
                label_coincidences1p.Text = $"{(float)Game.GameStatistics.CoincidencesCount[0] * 100 / (float)Game.GameStatistics.TotalCoincidences}%";
                label_coincidences2.Text = Convert.ToString(Game.GameStatistics.CoincidencesCount[1]);
                label_coincidences2p.Text = $"{(float)Game.GameStatistics.CoincidencesCount[1] * 100 / (float)Game.GameStatistics.TotalCoincidences}%";
                label_coincidences3.Text = Convert.ToString(Game.GameStatistics.CoincidencesCount[2]);
                label_coincidences3p.Text = $"{(float)Game.GameStatistics.CoincidencesCount[2] * 100 / (float)Game.GameStatistics.TotalCoincidences}%";
                label_coincidences4.Text = Convert.ToString(Game.GameStatistics.CoincidencesCount[3]);
                label_coincidences4p.Text = $"{(float)Game.GameStatistics.CoincidencesCount[3] * 100 / (float)Game.GameStatistics.TotalCoincidences}%";
                label_coincidences5.Text = Convert.ToString(Game.GameStatistics.CoincidencesCount[4]);
                label_coincidences5p.Text = $"{(float)Game.GameStatistics.CoincidencesCount[4] * 100 / (float)Game.GameStatistics.TotalCoincidences}%";

                groupBox_multigameStatistic.Visible = true;
                groupBox_singleGameStatistic.Visible = false;
            }
        }

        public void HideStatistic()
        {
            groupBox_singleGameStatistic.Visible = false;
            groupBox_multigameStatistic.Visible = false;
        }

        #endregion

        #region ValueChanged

        private void numericUpDown_cards_ValueChanged(object sender, EventArgs e)
        {
            cardsRow = Convert.ToInt32(numericUpDown_cards.Value);
        }

        private void numericUpDown_coincidences_ValueChanged(object sender, EventArgs e)
        {
            Game.CoincidenceCount = Convert.ToInt32(numericUpDown_coincidences.Value);
        }

        private void numericUpDown_gameIterations_ValueChanged(object sender, EventArgs e)
        {
            Game.Interactions = Convert.ToInt32(numericUpDown_gameIterations.Value);
        }

        #endregion

        private void button_save_Click(object sender, EventArgs e)
        {
            Game.Save();
        }
    }
}
