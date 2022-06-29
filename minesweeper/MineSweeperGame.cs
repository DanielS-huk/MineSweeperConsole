using System;
using System.Collections.Generic;
using System.Text;

namespace minesweeper
{
    class MineSweeperGame
    {
        private readonly int[,] gameBoard = new int[16, 16];
        private readonly bool[,] gameFogOfWar = new bool[16, 16];
        Graphics draw = new Graphics();
       // private Dictionary<string, bool> boardRevealStatus = new Dictionary<string, bool>();
        
        public void Run()
        {
            SetNewGameBoard();
            DisplayGameBoard();
            
            //player move input??



        }

        private void SetNewGameBoard()
        {
            Random rand = new Random();
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    gameFogOfWar[i, j] = false;
                    if (rand.Next(0, 3) == 0) 
                    { gameBoard[i, j] = 99; }
                    else 
                    { gameBoard[i, j] = 0; }
                }
            }
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] == 99)
                    {
                        //checking all mines to create the numerical clues on the playfield
                        
                        
                        if (i == 0 && j == 0) //top left corner
                        {
                            if (gameBoard[i+1, j] != 99)   { gameBoard[i+1, j] += 1;}
                            if (gameBoard[i, j+1] != 99)   { gameBoard[i, j+1] += 1;}
                            if (gameBoard[i+1, j+1] != 99) { gameBoard[i+1, j+1] += 1;}
                        } 
                        if (i == 0 && j == 15) //top right corner
                        {
                            if (gameBoard[i, j-1] != 99)   { gameBoard[i, j-1] += 1; }
                            if (gameBoard[i+1, j-1] != 99) { gameBoard[i+1, j-1] += 1; }
                            if (gameBoard[i+1, j] != 99)   { gameBoard[i+1, j] += 1; }
                        }
                        if (i == 15 && j == 0) //bottom left corner
                        {
                            if (gameBoard[i-1, j] != 99)   { gameBoard[i-1, j] += 1; }
                            if (gameBoard[i-1, j+1] != 99) { gameBoard[i-1, j+1] += 1; }
                            if (gameBoard[i, j+1] != 99)   { gameBoard[i, j+1] += 1; }
                        }
                        if (i == 15 && j == 15) //bottom right corner
                        {
                            if (gameBoard[i, j-1] != 99)   { gameBoard[i, j-1] += 1; }
                            if (gameBoard[i-1, j-1] != 99) { gameBoard[i-1, j-1] += 1; }
                            if (gameBoard[i-1, j] != 99)   { gameBoard[i-1, j] += 1; }
                        }
                        if (i == 0 && j > 0 && j < 15) //top row
                        {
                            if (gameBoard[i, j-1] != 99)   { gameBoard[i, j-1] += 1;}
                            if (gameBoard[i, j+1] != 99)   { gameBoard[i, j+1] += 1;}
                            if (gameBoard[i+1, j-1] != 99) { gameBoard[i+1, j-1] += 1;}
                            if (gameBoard[i+1, j] != 99)   { gameBoard[i+1, j] += 1;}
                            if (gameBoard[i+1, j+1] != 99) { gameBoard[i+1, j+1] += 1;}
                        }
                        if (i == 15 && j > 0 && j < 15) //Bottom row 
                        {
                            if (gameBoard[i, j-1] != 99)   { gameBoard[i, j-1] += 1; }
                            if (gameBoard[i-1, j-1] != 99) { gameBoard[i-1, j-1] += 1; }
                            if (gameBoard[i-1, j] != 99)   { gameBoard[i-1, j] += 1; }
                            if (gameBoard[i-1, j+1] != 99) { gameBoard[i-1, j+1] += 1; }
                            if (gameBoard[i, j+1] != 99)   { gameBoard[i, j+1] += 1; }
                        }
                        if (j == 0 && i > 0 && i < 15) //Left column 
                        {
                            if (gameBoard[i-1, j] != 99)   { gameBoard[i-1, j] += 1; }
                            if (gameBoard[i-1, j+1] != 99) { gameBoard[i-1, j+1] += 1; }
                            if (gameBoard[i, j+1] != 99)   { gameBoard[i, j+1] += 1; }
                            if (gameBoard[i+1, j+1] != 99) { gameBoard[i+1, j+1] += 1; }
                            if (gameBoard[i+1, j] != 99)   { gameBoard[i+1, j] += 1; }
                        }
                        if (j == 15 && i > 0 && i < 15) //Right Column 
                        {
                            if (gameBoard[i+1, j] != 99)   { gameBoard[i+1, j] += 1; }
                            if (gameBoard[i+1, j-1] != 99) { gameBoard[i+1, j-1] += 1; }
                            if (gameBoard[i, j-1] != 99)   { gameBoard[i, j-1] += 1; }
                            if (gameBoard[i-1, j-1] != 99) { gameBoard[i-1, j-1] += 1; }
                            if (gameBoard[i-1, j] != 99)   { gameBoard[i-1, j] += 1; }
                        }
                        if (j < 15 && j > 0 && i < 15 && i > 0) //MIDDLE AREA
                        {
                            if (gameBoard[i-1, j-1] != 99) { gameBoard[i-1, j-1] += 1; }
                            if (gameBoard[i-1, j] != 99)   { gameBoard[i-1, j] += 1; }
                            if (gameBoard[i-1, j+1] != 99) { gameBoard[i-1, j+1] += 1; }
                            if (gameBoard[i, j-1] != 99)   { gameBoard[i, j-1] += 1; }
                            if (gameBoard[i, j+1] != 99)   { gameBoard[i, j+1] += 1; }
                            if (gameBoard[i+1, j-1] != 99) { gameBoard[i+1, j-1] += 1; }
                            if (gameBoard[i+1, j] != 99)   { gameBoard[i+1, j] += 1; }
                            if (gameBoard[i+1, j+1] != 99) { gameBoard[i+1, j+1] += 1; }
                        }
                    }
                }
            }
        }
        //private void BuildCoordinateLookupDictionary()
        //{
        //    for (int i = 0; i < gameBoard.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < gameBoard.GetLength(1); j++)
        //        {
        //            boardRevealStatus.Add((i.ToString()) + " " + (j.ToString()), false);
        //        }
        //    }
        //}
        bool dumbThing = true;
        private void DisplayGameBoard()
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (dumbThing)
                    {
                        draw.WriteCyan("      1 ");
                        //Console.Write("1 ");
                        dumbThing = false;
                    }
                    if (gameFogOfWar[i, j])
                    {
                        if (i%2 == 0)
                        {
                            Console.Write("|");
                            draw.HiddenLight();
                        }
                        else
                        {
                            Console.Write("|");
                            draw.Hidden();
                        }
                    } 
                    else
                    {
                        if (gameBoard[i,j] == 99)
                        {
                            Console.Write("|");
                            draw.Mine();
                        } 
                        if (gameBoard[i,j] < 99)
                        {
                            Console.Write("|");
                            //draw safe and EMPTY
                            //draw.Safe();
                            Console.Write(gameBoard[i,j] + " ");
                        }
                    }
                    if (j == 15)
                    {
                        Console.Write("|");
                        Console.Write($"\n");
                        Console.Write("      ");
                        if (i + 2 < 10)
                        {
                            draw.WriteCyan((i+2).ToString()+" ");
                        }
                        else if (i+2 == 17)
                        {
                            draw.WriteCyan("  |1 |2 |3 |4 |5 |6 |7 |8 |9 |10|11|12|13|14|15|16|");
                        } else
                        {
                            draw.WriteCyan((i + 2).ToString());
                        }
                    }
                }
            }
        }
    }
}
