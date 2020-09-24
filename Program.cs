using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{

    enum PlayerType
    {
        PlayerX,
        PlayerO,
        None,
        Nothing
    }

    static class PlayerTypeExt
    {
        public static string ToPureString(this PlayerType value)
        {
            switch (value)
            {
                case PlayerType.PlayerO:
                    return "O";
                case PlayerType.PlayerX:
                    return "X";
                case PlayerType.Nothing:
                    return "Ничья";
            }
            return "-";
        }
    }

    class XandO
    {
        PlayerType[,] grid;
        PlayerType move;

        public XandO()
        {
            grid = new PlayerType[3, 3];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = PlayerType.None;
                }
            }
            move = PlayerType.PlayerX;
        }
        public PlayerType GetCellInfo(int i, int j)
        {
            return grid[i, j];
        }
        public PlayerType WhoWins()
        {
            if ((grid[0, 0] == PlayerType.PlayerX) && (grid[0, 1] == PlayerType.PlayerX) && (grid[0, 2] == PlayerType.PlayerX))
            {
                return PlayerType.PlayerX;
            }
            else if ((grid[0, 0] == PlayerType.PlayerO) && (grid[0, 1] == PlayerType.PlayerO) && (grid[0, 2] == PlayerType.PlayerO))
            {
                return PlayerType.PlayerO;
            }
            if ((grid[1, 0] == PlayerType.PlayerX) && (grid[1, 1] == PlayerType.PlayerX) && (grid[1, 2] == PlayerType.PlayerX))
            {
                return PlayerType.PlayerX;
            }
            else if ((grid[1, 0] == PlayerType.PlayerO) && (grid[1, 1] == PlayerType.PlayerO) && (grid[1, 2] == PlayerType.PlayerO))
            {
                return PlayerType.PlayerO;
            }
            if ((grid[2, 0] == PlayerType.PlayerX) && (grid[2, 1] == PlayerType.PlayerX) && (grid[2, 2] == PlayerType.PlayerX))
            {
                return PlayerType.PlayerX;
            }
            else if ((grid[2, 0] == PlayerType.PlayerO) && (grid[2, 1] == PlayerType.PlayerO) && (grid[2, 2] == PlayerType.PlayerO))
            {
                return PlayerType.PlayerO;
            }


            if ((grid[0, 0] == PlayerType.PlayerX) && (grid[1, 0] == PlayerType.PlayerX) && (grid[2, 0] == PlayerType.PlayerX))
            {
                return PlayerType.PlayerX;
            }
            else if ((grid[0, 0] == PlayerType.PlayerO) && (grid[1, 0] == PlayerType.PlayerO) && (grid[2, 0] == PlayerType.PlayerO))
            {
                return PlayerType.PlayerO;
            }
            if ((grid[0, 1] == PlayerType.PlayerX) && (grid[1, 1] == PlayerType.PlayerX) && (grid[2, 1] == PlayerType.PlayerX))
            {
                return PlayerType.PlayerX;
            }
            else if ((grid[0, 1] == PlayerType.PlayerO) && (grid[1, 1] == PlayerType.PlayerO) && (grid[2, 1] == PlayerType.PlayerO))
            {
                return PlayerType.PlayerO;
            }
            if ((grid[0, 2] == PlayerType.PlayerX) && (grid[1, 2] == PlayerType.PlayerX) && (grid[2, 2] == PlayerType.PlayerX))
            {
                return PlayerType.PlayerX;
            }
            else if ((grid[0, 2] == PlayerType.PlayerO) && (grid[1, 2] == PlayerType.PlayerO) && (grid[2, 2] == PlayerType.PlayerO))
            {
                return PlayerType.PlayerO;
            }


            if ((grid[0, 0] == PlayerType.PlayerX) && (grid[1, 1] == PlayerType.PlayerX) && (grid[2, 2] == PlayerType.PlayerX))
            {
                return PlayerType.PlayerX;
            }
            else if ((grid[0, 0] == PlayerType.PlayerO) && (grid[1, 1] == PlayerType.PlayerO) && (grid[2, 2] == PlayerType.PlayerO))
            {
                return PlayerType.PlayerO;
            }
            if ((grid[0, 2] == PlayerType.PlayerX) && (grid[1, 1] == PlayerType.PlayerX) && (grid[2, 0] == PlayerType.PlayerX))
            {
                return PlayerType.PlayerX;
            }
            else if ((grid[0, 2] == PlayerType.PlayerO) && (grid[1, 1] == PlayerType.PlayerO) && (grid[2, 0] == PlayerType.PlayerO))
            {
                return PlayerType.PlayerO;
            }

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == PlayerType.None)
                    {
                        return PlayerType.None;
                    }
                }
            }

            return PlayerType.Nothing;
        }       


        public void MakeMove(int i, int j)
        {
            if (WhoWins() != PlayerType.None)
            {
                throw new Exception("Game already has finished");
            }


            grid[i, j] = move;


            if (move == PlayerType.PlayerX)
            {
                move = PlayerType.PlayerO;
            }
            else
            {
                move = PlayerType.PlayerX;
            }
        }

        public bool IsCellEmpty(int i, int j)
        {
            if (i==-1 && j==-1)
            {
                return false;
            }
            if (grid[i, j] == PlayerType.PlayerO || grid[i, j] == PlayerType.PlayerX)
            {
                Console.WriteLine("Клетка Занята");
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    class Program
    {
        static int ValueXY()
        {
            int xy = -1;
            while (xy < 0 || xy > 2)
            {
                try
                {
                    
                    xy = Convert.ToInt32(Console.ReadKey(true).KeyChar.ToString());
                    Console.WriteLine();
                    if (xy < 0 || xy > 2)
                    {
                        Console.WriteLine("Нельзя вводить цифры больше 2 или меньше 0!");
                    }
                }
                catch
                {
                    Console.WriteLine("Нельзя вводить буквы!");
                }
            }
            return xy;
        }
       
        
        static void Main(string[] args)
        {
            XandO Game = new XandO();

            void Repeat()
            {
                for (int a = 0; a < 3; a++)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        Console.Write("  " + Game.GetCellInfo(a, b).ToPureString());
                    }
                    Console.WriteLine("\n");
                }
            }
            Repeat();


            while (Game.WhoWins() == PlayerType.None)
            {
                var i = -1;
                var j = -1;
                while (!Game.IsCellEmpty(i, j))
                {
                    Console.WriteLine("ВВедите x и y");
                    Console.Write("x:");
                    i = ValueXY();
                    Console.Write("y:");
                    j = ValueXY();
                }
                Game.MakeMove(i, j);
                Repeat();
            }

            Console.WriteLine("Победа за :"+Game.WhoWins().ToPureString());


            Console.ReadKey();
        }
    }
}
