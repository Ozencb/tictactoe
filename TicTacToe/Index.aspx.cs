using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicTacToe {
    public partial class Index : System.Web.UI.Page {
        private static List<HashSet<string>> winningCombination = new List<HashSet<string>>();

        private static string playerOneSymbol, playerTwoSymbol;
        private static int playerOneScore, playerTwoScore;

        private static bool playerTurn;

        private static bool isWin = false;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                initialConditions();

                playerOneScore = 0;
                playerTwoScore = 0;

                winningCombination.Add(new HashSet<string>(new string[] { "btn0", "btn1", "btn2" }));
                winningCombination.Add(new HashSet<string>(new string[] { "btn3", "btn4", "btn5" }));
                winningCombination.Add(new HashSet<string>(new string[] { "btn6", "btn7", "btn8" }));
                winningCombination.Add(new HashSet<string>(new string[] { "btn0", "btn3", "btn6" }));
                winningCombination.Add(new HashSet<string>(new string[] { "btn1", "btn4", "btn7" }));
                winningCombination.Add(new HashSet<string>(new string[] { "btn2", "btn5", "btn8" }));
                winningCombination.Add(new HashSet<string>(new string[] { "btn0", "btn4", "btn8" }));
                winningCombination.Add(new HashSet<string>(new string[] { "btn2", "btn4", "btn6" }));
            }
        }

        protected void markCell(object sender, EventArgs e) {
            (sender as Button).Text = !playerTurn ? playerOneSymbol : playerTwoSymbol;  
            (sender as Button).Enabled = false;

            checkWin(playerTurn);
            
            if (!isWin) {
                updateTurn();
            }
        }

        private void checkWin(bool turn) {
            HashSet<string> positions = getMarkedButtonPositions(turn == false ? playerOneSymbol : playerTwoSymbol);

            foreach (var combination in winningCombination) {
                if (combination.IsSubsetOf(positions)) {
                    isWin = true;
                }
            }

            if (isWin) {
                if (turn == false) {
                    gameMessage.Text = "Player 1 wins!";
                    playerOneScore++;
                    endGame();
                    return;
                }
                else {
                    gameMessage.Text = "Player 2 wins!";
                    playerTwoScore++;
                    endGame();
                    return;
                }
            }
            else {
                List<Button> tmpButtons = findButtons();
                int i = 0;
                foreach (var btn in tmpButtons) {
                    if (btn.Text.Equals("X") || btn.Text.Equals("O")) {
                        i++;
                    }
                }

                if (i == tmpButtons.Count){
                    gameMessage.Text = "Tie!";
                    endGame();
                }
            }
        }

        private void initialConditions() {
            isWin = false;

            playerTurn = false;
            gameMessage.Text = "Player 1";

            foreach (var btn in findButtons()) {
                btn.Enabled = true;
                btn.Text = "";
            }

            playerOneSymbol = randomBool() == false ? "O" : "X";
            playerTwoSymbol = playerOneSymbol == "O" ? "X" : "O";

            symbol1.Text = playerOneSymbol;
            symbol2.Text = playerTwoSymbol;
        }

        private HashSet<string> getMarkedButtonPositions(string symbol) {
            HashSet<string> tmpPositions = new HashSet<string>();

            foreach (var button in findButtons()) {
                if (button.Text.Equals(symbol)) {
                    tmpPositions.Add(button.ID);
                }
            }

            return tmpPositions;
        }

        protected void restartGame(object sender, EventArgs e) {
            initialConditions();
        }

        private void endGame() {
            isWin = true;

            score.Text = playerOneScore.ToString() + " - " + playerTwoScore.ToString();
            
            foreach (var btn in findButtons()) {
                btn.Enabled = false;
            }
        }

        private void updateTurn() {
            playerTurn = !playerTurn;

            gameMessage.Text = playerTurn == false ? "Player 1" : "Player 2";
        }

        private bool randomBool() {
            Random random = new Random();
            return random.Next(0, 2) == 0 ? false : true;
        }

        private List<Button> findButtons() {
            return board.Controls.OfType<Button>().ToList();
        }
    }
}