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
        public int n;

        public XandO()
        {
            while (n<3)
            {
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n<3)
                    {
                        Console.WriteLine("Нельзя ввести поле меньше 3");
                    }
                }
                catch
                {
                    Console.WriteLine("Нельзя вводить буквы");
                }
            }
            grid = new PlayerType[n, n];
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
            
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                int value1 = 0;
                int value2 = 0;
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i,j]==PlayerType.PlayerX)
                    {
                        value1++;
                    }
                    else if (grid[i,j]==PlayerType.PlayerO)
                    {
                        value1--;
                    }
                    if (grid[j, i] == PlayerType.PlayerX)
                    {
                        value2++;
                    }
                    else if (grid[j, i] == PlayerType.PlayerO)
                    {
                        value2--;
                    }
                }
                if (n == value1||n==value2)
                {
                    return PlayerType.PlayerX;
                }
                else if (n == -value1||n==-value2)
                {
                    return PlayerType.PlayerO;
                }               
            }

            int valueDiagonal=0;

            for (int i = 0; i < n; i++)
            {
                if (grid[i,i]==PlayerType.PlayerX)
                {
                    valueDiagonal++;
                }
                else if (grid[i, i] == PlayerType.PlayerO)
                {
                    valueDiagonal--;
                }
            }
            if (n==valueDiagonal)
            {
                return PlayerType.PlayerX;
            }
            else if (n==-valueDiagonal)
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
        static int ValueXY(int N)
        {
            int xy = -1;
            while (xy < 0 || xy >= N )
            {
                try
                {
                    
                    xy = Convert.ToInt32(Console.ReadKey(true).KeyChar.ToString());
                    Console.WriteLine();
                    if (xy < 0 || xy > N)
                    {
                        Console.WriteLine("Нельзя вводить цифры больше поля или меньше 0!");
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
            Console.WriteLine("ВВедите размер поля");
            XandO Game = new XandO();

            void Repeat()
            {
                for (int a = 0; a < Game.n; a++)
                {
                    for (int b = 0; b < Game.n; b++)
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
                    i = ValueXY(Game.n);
                    Console.Write("y:");
                    j = ValueXY(Game.n);
                }
                Game.MakeMove(i, j);
                Repeat();
            }

            Console.WriteLine("Победа за :"+Game.WhoWins().ToPureString());


            Console.ReadKey();
        }
    }
}
