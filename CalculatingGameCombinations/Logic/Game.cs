using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MersenneTwister;
using static CalculatingGameCombinations.Logic.GameStatistic;

namespace CalculatingGameCombinations.Logic
{
    public enum GameType
    {
        First,
        Second,
        Thid
    }

    public class Game
    {
        public int MinCard = 2;
        public int MaxCard = 14;
        public bool WithJokers = false;

        public GameType GameType = GameType.First;
        public int CoincidenceCount = 1;
        public int Interactions = 1000;

        public GameStatistic GameStatistics = new GameStatistic();
        public MTRandom Randomaizer = new MTRandom();

        public List<string> CardsPool;

        public Game(int minCard, int maxCard, bool useJokers, GameType gameType)
        {
            MinCard = minCard;
            MaxCard = maxCard;
            WithJokers = useJokers;
            GameType = gameType;
            CreateCardsPool();
        }

        public void CreateCardsPool()
        {
            CardsPool = new List<string>();

            for (int i = MinCard; i <= MaxCard; i++)
            {
                CardsPool.Add($"B{i}");
                CardsPool.Add($"K{i}");
                CardsPool.Add($"P{i}");
                CardsPool.Add($"C{i}");
            }

            if (WithJokers)
            {
                CardsPool.Add("JB1");
                CardsPool.Add("JB2");
                CardsPool.Add("JR1");
                CardsPool.Add("JR2");
            }
        }


        public Statistic GetGameStatistic(List<string> mCards, List<string> eCards)
        {
            Statistic gameStatistic = new Statistic(mCards, eCards);

            eCards.ForEach(eCard =>
            {
                if (mCards.FirstOrDefault(mCard => mCard.Substring(1) == eCard.Substring(1)) != null)
                {
                    gameStatistic.CoincidencesCount++;
                }
            });

            if (gameStatistic.CoincidencesCount >= CoincidenceCount)
            {
                gameStatistic.IsWin = true;
                // Check on JaskPot
                if (CoincidenceCount == 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (mCards[i].Substring(1) != eCards[i].Substring(1))
                        {
                            return gameStatistic;
                        }
                    }

                    gameStatistic.Jaskpot = true;
                }
            }

            return gameStatistic;
        }

        public int GetRandomValue(int max)
        {
            return Convert.ToInt32(Randomaizer.genrand_intMax(Convert.ToUInt32(max)));
        }

        public void ClearCardPool()
        {
            this.CardsPool = new List<string>();
        }

        public void Save()
        {
            if (GameStatistics.Statistics.Count > 0)
            {
                DateTime currentDate = DateTime.Now;

                string date = $"{currentDate.Day}-{currentDate.Month}-{currentDate.Year}_{currentDate.Hour}-{currentDate.Minute}-{currentDate.Second}";
                string fileName = $"{date}_{GameType}_{Interactions}_{CoincidenceCount}";
                string newFilePath = $"Logs/{fileName}.txt";

                using (StreamWriter writer =
                    new StreamWriter(newFilePath, true))
                {
                    writer.WriteLine($"Date: {currentDate}");
                    writer.WriteLine($"GameType: {GameType}");
                    writer.WriteLine($"Iterations: {Interactions}");
                    writer.WriteLine($"Coincidence Count: {CoincidenceCount}");
                    writer.WriteLine("");
                    writer.WriteLine($"Wins: {Convert.ToString(GameStatistics.WinsCount)}");
                    writer.WriteLine($"Wins (%): {(float)GameStatistics.WinsCount * 100 / (float)GameStatistics.GamesCount}%");
                    writer.WriteLine($"Loses: {Convert.ToString(GameStatistics.LosesCount)}");
                    writer.WriteLine($"Loses (%): {(float)GameStatistics.LosesCount * 100 / (float)GameStatistics.GamesCount}%");
                    writer.WriteLine($"Jaskpots: {Convert.ToString(GameStatistics.Jaskpots)}");
                    writer.WriteLine("");
                    writer.WriteLine($"Coincidences [1]: {Convert.ToString(GameStatistics.CoincidencesCount[0])}");
                    writer.WriteLine($"Coincidences [1] (%): {(float)GameStatistics.CoincidencesCount[0] * 100 / (float)GameStatistics.TotalCoincidences}%");
                    writer.WriteLine($"Coincidences [2]: {Convert.ToString(GameStatistics.CoincidencesCount[1])}");
                    writer.WriteLine($"Coincidences [2] (%): {(float)GameStatistics.CoincidencesCount[1] * 100 / (float)GameStatistics.TotalCoincidences}%");
                    writer.WriteLine($"Coincidences [3]: {Convert.ToString(GameStatistics.CoincidencesCount[2])}");
                    writer.WriteLine($"Coincidences [3] (%): {(float)GameStatistics.CoincidencesCount[2] * 100 / (float)GameStatistics.TotalCoincidences}%");
                    writer.WriteLine($"Coincidences [4]: {Convert.ToString(GameStatistics.CoincidencesCount[3])}");
                    writer.WriteLine($"Coincidences [4] (%): {(float)GameStatistics.CoincidencesCount[3] * 100 / (float)GameStatistics.TotalCoincidences}%");
                    writer.WriteLine($"Coincidences [5]: {Convert.ToString(GameStatistics.CoincidencesCount[4])}");
                    writer.WriteLine($"Coincidences [5] (%): {(float)GameStatistics.CoincidencesCount[4] * 100 / (float)GameStatistics.TotalCoincidences}%");
                }
            }
            else
            {
                MessageBox.Show("No any statistics!");
            }
        }
    }

    public class GameStatistic
    {
        public struct Statistic
        {
            public List<string> MechanicCards;
            public List<string> ElectronCards;

            public int CoincidencesCount; 
            public bool IsWin;

            public bool Jaskpot;

            public Statistic(List<string> mechanic, List<string> electron)
            {
                MechanicCards = mechanic;
                ElectronCards = electron;
                CoincidencesCount = 0;
                IsWin = false;
                Jaskpot = false;
            }
        }

        public List<Statistic> Statistics;

        // Global Statistic
        public int GamesCount;
        public int WinsCount;
        public int LosesCount;
        public int Jaskpots;

        public int TotalCoincidences;

        // [0] - 1 coincidence
        // [1] - 2 coincidence
        public int[] CoincidencesCount = {0, 0, 0, 0, 0};

        public GameStatistic()
        {
            ClearStatistic();
        }

        public void ClearStatistic()
        {
            Statistics = new List<Statistic>();
            GamesCount = 0;
            WinsCount = 0;
            LosesCount = 0;
            Jaskpots = 0;
            TotalCoincidences = 0;

            for (int i = 0; i < CoincidencesCount.Length; i++)
            {
                CoincidencesCount[i] = 0;
            }
        }

        public void BuidData()
        {
            foreach (var statistic in Statistics)
            {
                GamesCount++;
                if (statistic.IsWin)
                {
                    WinsCount++;
                }
                else
                {
                    LosesCount++;
                }

                if (statistic.Jaskpot)
                {
                    Jaskpots++;
                }

                if (statistic.CoincidencesCount > 0)
                {
                    CoincidencesCount[statistic.CoincidencesCount - 1]++;
                }  
            }

            for (int i = 0; i < CoincidencesCount.Length; i++)
            {
                TotalCoincidences += CoincidencesCount[i];
            }
        }
    }
}
