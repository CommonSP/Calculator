using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatingGameCombinations.Logic;

namespace CalculatingGameCombinations
{
    public partial class MainForm : Form
    {
        public int MinCard = 2;
        public int MaxCard = 14;
        public bool UseJokers = false;

        public List<string> CardsPool = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            label_minCardLabel.Text = GetCardTitle(MinCard);
            label_maxCardTitle.Text = GetCardTitle(MaxCard);
            UpdatePoolList();
        }


        public string GetCardTitle(int number)
        {
            switch (number)
            {
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
                case 10:
                    return "Ten";
                case 11:
                    return "Jack";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                case 14:
                    return "Ace";
                default:
                    return "Invalid card!";
            }
        }

        private void UpdatePoolList()
        {
            listBox_pool.Items.Clear();
            CardsPool.ForEach(card =>
            {
                listBox_pool.Items.Add(card);
            });

            label_cardCount.Text = $"Card count {CardsPool.Count}";
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

            if (UseJokers)
            {
                CardsPool.Add("JB1");
                CardsPool.Add("JB2");
                CardsPool.Add("JR1");
                CardsPool.Add("JR2");
            }
        }

        private void ClearCardPool()
        {
            CardsPool = new List<string>();
            label_cardCount.Text = $"Card count {CardsPool.Count}";
        }

        private void button_createPool_Click_1(object sender, EventArgs e)
        {
            CreateCardsPool();
            UpdatePoolList();
            label_cardCount.Text = $"Card count {CardsPool.Count}";
        }

        private void button_clearPool_Click_1(object sender, EventArgs e)
        {
            ClearCardPool();
            listBox_pool.Items.Clear();
            label_cardCount.Text = $"Card count {CardsPool.Count}";
        }

        private void numericUpDown_minCard_ValueChanged_1(object sender, EventArgs e)
        {
            MinCard = Convert.ToInt32(numericUpDown_minCard.Value);
            label_minCardLabel.Text = GetCardTitle(MinCard);
        }

        private void numericUpDown_maxCard_ValueChanged_1(object sender, EventArgs e)
        {
            MaxCard = Convert.ToInt32(numericUpDown_maxCard.Value);
            label_maxCardTitle.Text = GetCardTitle(MaxCard);
        }

        private void checkBox_useJokers_CheckedChanged_1(object sender, EventArgs e)
        {
            UseJokers = checkBox_useJokers.Checked;
        }

        private void button_firstGameType_Click_1(object sender, EventArgs e)
        {
            FirstGameType firstGameType = new FirstGameType(new Game(MinCard, MaxCard, UseJokers, GameType.First));
            firstGameType.Show();
        }

        private void button_secondGameType_Click(object sender, EventArgs e)
        {
            SecondGameType secondGameType = new SecondGameType(new Game(MinCard, MaxCard, UseJokers, GameType.Second));
            secondGameType.Show();
        }
    }
}
