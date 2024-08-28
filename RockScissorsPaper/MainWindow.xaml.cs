using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RockScissorsPaper
{
    public partial class MainWindow : Window
    {
        private static readonly string RockImagePath = @"C:\Users\aliengin.sivas\source\repos\RockScissorsPaper\RockScissorsPaper\Images\tas.png";
        private static readonly string PaperImagePath = @"C:\Users\aliengin.sivas\source\repos\RockScissorsPaper\RockScissorsPaper\Images\kagit.png";
        private static readonly string ScissorsImagePath = @"C:\Users\aliengin.sivas\source\repos\RockScissorsPaper\RockScissorsPaper\Images\makas.png";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnChoiceMade(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string playerChoice = button.Name;
                string playerImagePath = string.Empty;

                switch (playerChoice)
                {
                    case "rockButton":
                        playerImagePath = RockImagePath;
                        break;
                    case "paperButton":
                        playerImagePath = PaperImagePath;
                        break;
                    case "scissorsButton":
                        playerImagePath = ScissorsImagePath;
                        break;
                }

                
                playerChoiceImage.Source = new BitmapImage(new Uri(playerImagePath));

               
                string computerChoice = GetComputerChoice();
                string computerImagePath = GetImagePathForChoice(computerChoice);

            
                computerChoiceImage.Source = new BitmapImage(new Uri(computerImagePath));

              
                string result = DetermineWinner(playerChoice, computerChoice);
                resultTextBlock.Text = result;
            }
        }

        private string GetComputerChoice()
        {
            var choices = new[] { "rockButton", "paperButton", "scissorsButton" };
            Random random = new Random();
            int index = random.Next(choices.Length);
            return choices[index];
        }

        private string GetImagePathForChoice(string choice)
        {
            switch (choice)
            {
                case "rockButton":
                    return RockImagePath;
                case "paperButton":
                    return PaperImagePath;
                case "scissorsButton":
                    return ScissorsImagePath;
                default:
                    throw new ArgumentException("Invalid choice", nameof(choice));
            }
        }

        private string DetermineWinner(string playerChoice, string computerChoice)
        {
            if (playerChoice == computerChoice)
            {
                return "Beraberlik!";
            }

            switch (playerChoice)
            {
                case "rockButton":
                    return computerChoice == "scissorsButton" ? "Kazandınız!" : "Kaybettiniz!";
                case "paperButton":
                    return computerChoice == "rockButton" ? "Kazandınız!" : "Kaybettiniz!";
                case "scissorsButton":
                    return computerChoice == "paperButton" ? "Kazandınız!" : "Kaybettiniz!";
                default:
                    return "Geçersiz seçim!";
            }
        }
    }
}
