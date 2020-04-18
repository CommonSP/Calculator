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
    public partial class FirstGameType : Form
    {
        public Game Game;
        private List<string> _mechanicCards;
        private List<string> _electronCards;

        private string _cardsParth;
        private string[] _cardImages;

        private List<PictureBox> _mechanicImages = new List<PictureBox>();
        private List<PictureBox> _electronImages = new List<PictureBox>();


        private List<string> _currentCardsPool;

        

        public FirstGameType(Game game)
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

            _electronImages.Add(pictureBox_e1);
            _electronImages.Add(pictureBox_e2);
            _electronImages.Add(pictureBox_e3);
            _electronImages.Add(pictureBox_e4);
            _electronImages.Add(pictureBox_e5);
        }

        private void ClearTable()
        {
            string noneImage = _cardImages.First(image => image == _cardsParth + "\\none.png");
            for (int i = 0; i < 5; i++)
            {
                _electronImages[i].Image = new Bitmap(noneImage);
                _mechanicImages[i].Image = new Bitmap(noneImage);
            }
        }

        private void numericUpDown_coincidences_ValueChanged(object sender, EventArgs e)
        {
            Game.CoincidenceCount = Convert.ToInt32(numericUpDown_coincidences.Value);
        }

        private void numericUpDown_gameIterations_ValueChanged(object sender, EventArgs e)
        {
            Game.Interactions = Convert.ToInt32(numericUpDown_gameIterations.Value);
        }

        private void button_singleGame_Click(object sender, EventArgs e)
        {
            Game.GameStatistics = new GameStatistic();
            _currentCardsPool = Game.CardsPool;
            progressBar_gameProgres.Value = 0;

            _mechanicCards = new List<string>();
            _electronCards = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                _mechanicCards.Add(_currentCardsPool[Game.GetRandomValue(_currentCardsPool.Count - 1)]);
                _electronCards.Add(_currentCardsPool[Game.GetRandomValue(_currentCardsPool.Count - 1)]);

                _electronImages[i].Image = new Bitmap(_cardImages.First(image => image == _cardsParth + $"\\{_electronCards[i]}.png"));
                _mechanicImages[i].Image = new Bitmap(_cardImages.First(image => image == _cardsParth + $"\\{_mechanicCards[i]}.png"));
            }
            
            Game.GameStatistics.Statistics.Add(Game.GetGameStatistic(_mechanicCards, _electronCards));

            UpdateGameStatistic();
        }

        private void button_multiGame_Click(object sender, EventArgs e)
        {
            Game.GameStatistics = new GameStatistic();
            _currentCardsPool = Game.CardsPool;
            progressBar_gameProgres.Maximum = Game.Interactions;
            ClearTable();

            for (int j = 0; j < Game.Interactions; j++)
            {
                _mechanicCards = new List<string>();
                _electronCards = new List<string>();
                for (int i = 0; i < 5; i++)
                {

                    _mechanicCards.Add(_currentCardsPool[Game.GetRandomValue(_currentCardsPool.Count - 1)]);
                    _electronCards.Add(_currentCardsPool[Game.GetRandomValue(_currentCardsPool.Count - 1)]);
                }

                Game.GameStatistics.Statistics.Add(Game.GetGameStatistic(_mechanicCards, _electronCards));

                if (j % (Game.Interactions / 100) == 0)
                {
                    progressBar_gameProgres.Value = j;
                }
            }

            progressBar_gameProgres.Value = Game.Interactions;
            UpdateGameStatistic();
        }

        public void UpdateGameStatistic()
        {
            if (Game.GameStatistics.Statistics.Count == 0)
            {
                groupBox_statistic.Visible = false;
            }
            else
            {
                Game.GameStatistics.BuidData();
                label_totalGames.Text = Convert.ToString(Game.GameStatistics.GamesCount);
                label_wins.Text = Convert.ToString(Game.GameStatistics.WinsCount);
                label_winsp.Text = $"{(float)Game.GameStatistics.WinsCount * 100 / (float)Game.GameStatistics.GamesCount}%";
                label_loses.Text = Convert.ToString(Game.GameStatistics.LosesCount);
                label_losesp.Text = $"{(float)Game.GameStatistics.LosesCount * 100 / (float)Game.GameStatistics.GamesCount}%";
                label_jakpots.Text = Convert.ToString(Game.GameStatistics.Jaskpots);

                if (Game.GameStatistics.WinsCount > 0)
                {
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
                } else
                {
                    label_coincidences1.Text = "0";
                    label_coincidences1p.Text = "0";
                    label_coincidences2.Text =  "0";
                    label_coincidences2p.Text = "0";
                    label_coincidences3.Text =  "0";
                    label_coincidences3p.Text = "0";
                    label_coincidences4.Text =  "0";
                    label_coincidences4p.Text = "0";
                    label_coincidences5.Text =  "0";
                    label_coincidences5p.Text = "0";
                }



                groupBox_statistic.Visible = true;              
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Game.Save();
        }
    }
}
