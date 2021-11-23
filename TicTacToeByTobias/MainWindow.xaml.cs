using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToeByTobias
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        /// <summary>
        /// Holds the current results of cells active in game
        /// </summary>
        private MarkType[] mResults;

        /// <summary>
        /// True if it is Player 1's turn
        /// </summary>
        private bool mPlayer1Turn;

        /// <summary>
        /// True if game is over 
        /// </summary>
        private bool mGameEnded;
        
        #endregion

        #region Contstructor               
        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }
        #endregion

        //<summary> Starts a new game and clears all the values to the start. 
        private void NewGame()
        {   //Create a new blank array of Free cells
            mResults = new MarkType[9];
            for (int i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }
            //Make sure player 1 starts the game
            mPlayer1Turn = true;

            //interate every button on the grid and clear them...
            Container.Children.Cast<Button>().ToList().ForEach(button =>
           {
               button.Content = string.Empty;
               button.Background = Brushes.White;
           });

            //Reset game state to not finished...
            mGameEnded = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //If the game has ended and the user clicks on any grid cell, the game will reset.
            if(mGameEnded)
            {
                NewGame();
                return;
            }
            //Cast the sender to a button. 
            var button = (Button)sender;
            //Find the clicked button's position
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            //Calculate the position of the grid-cell in our mResults array
            var index = column + (row * 3);
            //Do nothing if the cell already has a value in it.
            if (mResults[index] != MarkType.Free)
                return;


            // This code was replaced with an if&ifelse statement below---
            //Set the cell value based on which players turn it is.
            //mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;
            //If it is Player-1's turn then mark cell with Cross, if it is Player-2's turn, mark with Nought (O);
            // button.Content = mPlayer1Turn ? 'X' : 'O';
            //toggle players turns using fancy "bit-operator" in expression.
            // mPlayer1Turn ^= true;

            if (mPlayer1Turn)
            {
                mResults[index] = MarkType.Cross;
                button.Content = 'X';
                mPlayer1Turn = false;
            }
            else if(!mPlayer1Turn)
            {
                mResults[index] = MarkType.Nought;
                button.Content = 'O';
                mPlayer1Turn = true;
            }
            
        }
    }
}
