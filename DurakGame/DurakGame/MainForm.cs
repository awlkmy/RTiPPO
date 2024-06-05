using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DurakGame
{
    public partial class MainForm : Form
    {
        private Game game;
        private Button startGameButton;
        private Button cancelButton;
        private Button takeCardsButton;
        private Button throwCardsButton;
        private Button endTurnButton;
        private Label deckLabel;
        private PictureBox trumpCardPictureBox;
        private PictureBox deckPictureBox;
        private PictureBox discardPilePictureBox;
        private FlowLayoutPanel player1CardsPanel;
        private FlowLayoutPanel player2CardsPanel;
        private Panel tablePanel;

        public MainForm()
        {
            // Установка размера окна
            this.ClientSize = new Size(1920, 1080);
            InitializeComponent();
            InitializeStartUI();
        }

        private void InitializeStartUI()
        {
            // Очистка всех контролов
            this.Controls.Clear();

            // Кнопка "Начать игру"
            startGameButton = new Button
            {
                Text = "Начать игру",
                Location = new Point(this.ClientSize.Width / 2 - 50, this.ClientSize.Height / 2 - 25),
                Size = new Size(100, 50)
            };
            startGameButton.Click += StartGameButton_Click;
            this.Controls.Add(startGameButton);
        }

        private void InitializeGameUI()
        {
            // Очистка всех контролов
            this.Controls.Clear();

            int cardWidth = 100;
            int cardHeight = 150;

            // Панель для отображения карт первого игрока
            player1CardsPanel = new FlowLayoutPanel
            {
                Location = new Point(300, this.ClientSize.Height - cardHeight - 50),
                AutoSize = true
            };
            this.Controls.Add(player1CardsPanel);

            // Панель для отображения карт второго игрока
            player2CardsPanel = new FlowLayoutPanel
            {
                Location = new Point(300, 50),
                AutoSize = true
            };
            this.Controls.Add(player2CardsPanel);

            // Панель для отображения карт на столе
            tablePanel = new Panel
            {
                Location = new Point(300, (this.ClientSize.Height - cardHeight) / 2),
                Size = new Size(600, cardHeight)
            };
            this.Controls.Add(tablePanel);

            // Метка для отображения информации о колоде
            deckLabel = new Label
            {
                Text = "Колода:",
                Location = new Point(20, (this.ClientSize.Height / 2) + cardHeight / 2 + 10)
            };
            this.Controls.Add(deckLabel);

            // Картинка для отображения козырной карты
            trumpCardPictureBox = new PictureBox
            {
                Location = new Point(140, (this.ClientSize.Height / 2) - cardHeight / 2),
                Size = new Size(cardWidth, cardHeight),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(trumpCardPictureBox);

            // Картинка для отображения колоды карт
            deckPictureBox = new PictureBox
            {
                Location = new Point(20, (this.ClientSize.Height / 2) - cardHeight / 2),
                Size = new Size(cardWidth, cardHeight),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Properties.Resources.card_back
            };
            this.Controls.Add(deckPictureBox);

            // Картинка для отображения отбоя
            discardPilePictureBox = new PictureBox
            {
                Location = new Point(this.ClientSize.Width - 120, (this.ClientSize.Height / 2) - cardHeight / 2),
                Size = new Size(cardWidth, cardHeight),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Properties.Resources.card_back,
                Visible = false
            };
            this.Controls.Add(discardPilePictureBox);

            // Кнопка "Взять карты"
            takeCardsButton = new Button
            {
                Text = "Взять карты",
                Location = new Point(this.ClientSize.Width - 300, this.ClientSize.Height - 100),
                Size = new Size(100, 50)
            };
            takeCardsButton.Click += TakeCardsButton_Click;
            this.Controls.Add(takeCardsButton);

            // Кнопка "Подкинуть карты"
            throwCardsButton = new Button
            {
                Text = "Подкинуть карты",
                Location = new Point(this.ClientSize.Width - 200, this.ClientSize.Height - 100),
                Size = new Size(100, 50)
            };
            throwCardsButton.Click += ThrowCardsButton_Click;
            this.Controls.Add(throwCardsButton);

            // Кнопка "Закончить ход"
            endTurnButton = new Button
            {
                Text = "Закончить ход",
                Location = new Point(this.ClientSize.Width - 100, this.ClientSize.Height - 100),
                Size = new Size(100, 50)
            };
            endTurnButton.Click += EndTurnButton_Click;
            this.Controls.Add(endTurnButton);

            // Кнопка "Отмена"
            cancelButton = new Button
            {
                Text = "Отмена",
                Location = new Point(this.ClientSize.Width - 100, 10),
                Size = new Size(80, 30)
            };
            cancelButton.Click += CancelButton_Click;
            this.Controls.Add(cancelButton);
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            game = new Game(new List<string> { "Player 1", "Bot" });
            game.StartGame();
            InitializeGameUI();
            DetermineFirstPlayer();
            UpdateUI();
        }

        private void DetermineFirstPlayer()
        {
            // Логика определения первого игрока по наименьшему козырю
            Card player1LowestTrump = game.Players[0].GetLowestTrumpCard(game.TrumpCard.Suit);
            Card player2LowestTrump = game.Players[1].GetLowestTrumpCard(game.TrumpCard.Suit);

            if (player1LowestTrump == null && player2LowestTrump == null)
            {
                // Оба игрока не имеют козырей - случайный выбор
                game.CurrentPlayer = game.Players[new Random().Next(0, 2)];
            }
            else if (player1LowestTrump == null)
            {
                game.CurrentPlayer = game.Players[1];
            }
            else if (player2LowestTrump == null)
            {
                game.CurrentPlayer = game.Players[0];
            }
            else
            {
                game.CurrentPlayer = (player1LowestTrump.CompareTo(player2LowestTrump) < 0) ? game.Players[0] : game.Players[1];
            }

            game.LeadingPlayer = game.CurrentPlayer;

            MessageBox.Show($"{game.CurrentPlayer.Name} ходит первым!");
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            InitializeStartUI();
        }

        private void TakeCardsButton_Click(object sender, EventArgs e)
        {
            // Логика взятия карт со стола
            game.CurrentPlayer.TakeCards(game.Table);
            game.Table.Clear();
            game.EndRound();
            UpdateUI();
        }

        private void ThrowCardsButton_Click(object sender, EventArgs e)
        {
            // Логика подкидывания карт
            List<Card> selectedCards = GetSelectedCards(player1CardsPanel);
            if (selectedCards.Count > 0 && AreAllCardsSameRank(selectedCards) && CanThrowCards(selectedCards))
            {
                game.ThrowCards(selectedCards);
                UpdateUI();
            }
            else
            {
                MessageBox.Show("Выберите карты одинакового достоинства, которые есть на столе.");
            }
        }

        private void EndTurnButton_Click(object sender, EventArgs e)
        {
            if (game.Table.Count > 0)
            {
                if (game.CurrentPlayer.Name == "Player 1")
                {
                    game.CurrentPlayer = game.Players[1]; // Ход переходит боту
                    BotPlay();
                }
                else
                {
                    // Завершение хода (раунда)
                    game.MoveToDiscardPile();
                    game.EndRound();
                }
            }
            else
            {
                game.EndTurn();
                if (game.CurrentPlayer.Name == "Bot")
                {
                    BotPlay();
                }
            }
            UpdateUI();
        }

        private void BotPlay()
        {
            game.BotPlay();
            UpdateUI();

            if (game.CurrentPlayer.Name == "Player 1")
            {
                // Логика для игрока, чтобы он мог подкинуть карты
                MessageBox.Show("Ваш ход. Вы можете подкинуть карты.");
            }
        }

        private List<Card> GetSelectedCards(FlowLayoutPanel panel)
        {
            List<Card> selectedCards = new List<Card>();
            foreach (Control control in panel.Controls)
            {
                if (control is PictureBox pictureBox && pictureBox.BorderStyle == BorderStyle.Fixed3D)
                {
                    selectedCards.Add((Card)pictureBox.Tag);
                }
            }
            return selectedCards;
        }

        private bool AreAllCardsSameRank(List<Card> cards)
        {
            if (cards.Count == 0) return false;
            Rank rank = cards[0].Rank;
            return cards.All(card => card.Rank == rank);
        }

        private bool CanThrowCards(List<Card> selectedCards)
        {
            // Проверка, что все карты имеют достоинства, которые уже есть на столе
            var tableRanks = new HashSet<Rank>(game.Table.Select(card => card.Rank));
            return selectedCards.All(card => tableRanks.Contains(card.Rank));
        }

        private void CardPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox cardPictureBox = sender as PictureBox;
            if (cardPictureBox.BorderStyle == BorderStyle.None)
            {
                cardPictureBox.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                cardPictureBox.BorderStyle = BorderStyle.None;
            }
        }

        private void UpdateUI()
        {
            int cardWidth = 100;
            int cardHeight = 150;

            // Обновление информации о колоде и козырной карте
            int remainingCards = game.GetTotalCardsCount();
            deckLabel.Text = $"Колода: {remainingCards} карт";

            if (remainingCards > 1)
            {
                deckPictureBox.Visible = true;
                trumpCardPictureBox.Image = GetCardImage(game.TrumpCard);
                trumpCardPictureBox.Visible = true;
            }
            else if (remainingCards == 1)
            {
                deckPictureBox.Visible = false;
                trumpCardPictureBox.Image = GetCardImage(game.TrumpCard);
                trumpCardPictureBox.Size = new Size(cardWidth, cardHeight); // Установить размер козырной карты
                trumpCardPictureBox.Location = new Point(140, (this.ClientSize.Height / 2) - cardHeight / 2);
                trumpCardPictureBox.Visible = true;
            }
            else if (remainingCards == 0 && game.TrumpCard != null)
            {
                deckPictureBox.Visible = false;
                trumpCardPictureBox.Visible = false;
                deckLabel.Text = $"Колода: {game.TrumpCard.Suit.ToString()}";
            }
            else
            {
                deckPictureBox.Visible = false;
                trumpCardPictureBox.Visible = false;
            }

            // Очистка панелей с картами
            player1CardsPanel.Controls.Clear();
            player2CardsPanel.Controls.Clear();
            tablePanel.Controls.Clear();

            // Обновление карт первого игрока
            foreach (var card in game.Players[0].Hand)
            {
                var cardPictureBox = new PictureBox
                {
                    Image = GetCardImage(card),
                    Size = new Size(cardWidth, cardHeight),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = card
                };
                cardPictureBox.Click += CardPictureBox_Click;
                player1CardsPanel.Controls.Add(cardPictureBox);
            }

            // Обновление карт второго игрока
            bool showOpponentCards = game.GetWinner() != null;
            foreach (var card in game.Players[1].Hand)
            {
                var cardPictureBox = new PictureBox
                {
                    Image = showOpponentCards ? GetCardImage(card) : Properties.Resources.card_back,
                    Size = new Size(cardWidth, cardHeight),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = card
                };
                player2CardsPanel.Controls.Add(cardPictureBox);
            }

            // Обновление карт на столе
            for (int i = 0; i < game.Table.Count; i++)
            {
                var tableCardPictureBox = new PictureBox
                {
                    Image = GetCardImage(game.Table[i]),
                    Size = new Size(cardWidth, cardHeight),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = game.Table[i],
                    Location = new Point(i * (cardWidth + 10), 0) // Расположение карт на столе
                };
                tablePanel.Controls.Add(tableCardPictureBox);

                if (i + 1 < game.Table.Count)
                {
                    var tableCardDefenderPictureBox = new PictureBox
                    {
                        Image = GetCardImage(game.Table[i + 1]),
                        Size = new Size(cardWidth, cardHeight),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = game.Table[i + 1],
                        Location = new Point(i * (cardWidth + 10), 15) // Расположение карт защитника с наложением
                    };
                    tablePanel.Controls.Add(tableCardDefenderPictureBox);
                    i++;
                }
            }

            // Обновление отбоя
            if (game.DiscardPile.Count > 0)
            {
                discardPilePictureBox.Visible = true;
            }
            else
            {
                discardPilePictureBox.Visible = false;
            }

            // Проверка на победителя
            var winner = game.GetWinner();
            if (winner != null)
            {
                MessageBox.Show($"{winner.Name} выиграл!");

                // Обновление карт второго игрока для отображения лицевой стороны после победы
                player2CardsPanel.Controls.Clear();
                foreach (var card in game.Players[1].Hand)
                {
                    var cardPictureBox = new PictureBox
                    {
                        Image = GetCardImage(card),
                        Size = new Size(cardWidth, cardHeight),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = card
                    };
                    player2CardsPanel.Controls.Add(cardPictureBox);
                }
            }
        }

        private Image GetCardImage(Card card)
        {
            string resourceName = $"{card.Rank.ToString().ToLower()}_of_{card.Suit.ToString().ToLower()}";
            return (Image)Properties.Resources.ResourceManager.GetObject(resourceName);
        }
    }
}