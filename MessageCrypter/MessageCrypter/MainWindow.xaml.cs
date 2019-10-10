using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MessageCrypter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MessageInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            charCount.Content = $"{messageInputBox.Text.Length} / 255";

            if (messageInputBox.Text.Length > 255) {

                charCount.Foreground = Brushes.Red;

            } else {

                charCount.Foreground = Brushes.Black;

            }

        }

        private void CryptButton_Click(object sender, RoutedEventArgs e) {

            if (messageInputBox.Text.Length <= 255) {

                messageOutputTextbox.Text = "";

                string textToCrypt = messageInputBox.Text;

                ArrayList letters = new ArrayList();
                ArrayList lettersAfter = new ArrayList();

                for (int i = 0; i < textToCrypt.Length; i++) {
                    letters.Add(Convert.ToChar(textToCrypt[i]));
                }

                if (staticRadioButton.IsChecked == true) {

                    for (int i = 0; i < letters.Count; i++) {

                        char l = Convert.ToChar(letters[i]);
                        int lInteger = Convert.ToInt32(l) + Convert.ToInt32(stepLabelValue.Content);
                        l = Convert.ToChar(lInteger);
                        lettersAfter.Add(l);

                    }
                } else if (rollingRadioButton.IsChecked == true) {

                    int newStep = Convert.ToInt32(stepLabelValue.Content);

                    for (int i = 0; i < letters.Count; i++) {

                        char l = Convert.ToChar(letters[i]);
                        int lInteger = Convert.ToInt32(l) + Convert.ToInt32(newStep);
                        l = Convert.ToChar(lInteger);
                        lettersAfter.Add(l);
                        newStep++;

                    }
                } else {
                    messageOutputTextbox.Text = "No crypt method selected";
                }

                for (int i = 0; i < lettersAfter.Count; i++) {
                    messageOutputTextbox.Text = messageOutputTextbox.Text + lettersAfter[i];
                }

            } else {

                messageOutputTextbox.Text = $"Error: Message to long message is {messageInputBox.Text.Length - 255} too long.";

            }

        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e) {

            if (messageInputBox.Text.Length <= 255) {

                messageOutputTextbox.Text = "";

                string textToCrypt = messageInputBox.Text;

                ArrayList letters = new ArrayList();
                ArrayList lettersAfter = new ArrayList();

                for (int i = 0; i < textToCrypt.Length; i++) {
                    letters.Add(Convert.ToChar(textToCrypt[i]));
                }

                if (staticRadioButton.IsChecked == true) {
                    for (int i = 0; i < letters.Count; i++) {

                        char l = Convert.ToChar(letters[i]);
                        int lInteger = Convert.ToInt32(l) - Convert.ToInt32(stepLabelValue.Content);
                        l = Convert.ToChar(lInteger);
                        lettersAfter.Add(l);

                    }
                } else if (rollingRadioButton.IsChecked == true) {

                    int newStep = Convert.ToInt32(stepLabelValue.Content);

                    for (int i = 0; i < letters.Count; i++) {

                        char l = Convert.ToChar(letters[i]);
                        int lInteger = Convert.ToInt32(l) - Convert.ToInt32(newStep);
                        l = Convert.ToChar(lInteger);
                        lettersAfter.Add(l);
                        newStep++;

                    }
                } else {

                    messageOutputTextbox.Text = "No crypt method selected";

                }

                for (int i = 0; i < lettersAfter.Count; i++) {
                    messageOutputTextbox.Text = messageOutputTextbox.Text + lettersAfter[i];
                }

            } else {

                messageOutputTextbox.Text = $"Error: Message to long message is {messageInputBox.Text.Length - 255} characters too long.";

            }

        }

        private void StepButton_Click(object sender, RoutedEventArgs e) {

            stepLabelValue.Content = stepTextbox.Text;

        }
    }
}
