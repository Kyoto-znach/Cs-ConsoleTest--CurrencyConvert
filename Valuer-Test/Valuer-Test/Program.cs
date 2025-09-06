
using System.Runtime.CompilerServices;

namespace Valuer_game
{
    public class Value
    {
        public string name;
        public int acout;
        public int togold;
        public int id;

        public Value(string name, int acout, int togold, int id)
        {
            this.name = name;
            this.acout = acout;
            this.togold = togold;
            this.id = id;
        }
    }

    class GameValues
    {
        public static Value sil = new Value("Silver", 100, 100, 1);
        public static Value cop = new Value("Copper", 0, 1000, 2);
        public static Value eur = new Value("Euro", 0, 450, 3);
    }
    class GameLog
    {
        static Random rnd = new Random();

        static public int Grnr(int min, int max)
        {
            return rnd.Next(min, max + 1);
            
        }
        static private void showval(Value val)
        {
            Console.WriteLine($"{val.id}) name {val.name}, you have: {val.acout}, 1 gold = {val.togold} {val.name}");


        }
        static public void showvals()
        {
            Console.WriteLine("vals");
            showval(GameValues.sil);
            showval(GameValues.cop);
            showval(GameValues.eur);
        }

        static private Value GetValById(int id)
        {

            switch (id)
            {
                case 1: return GameValues.sil;
                case 2: return GameValues.cop;
                case 3: return GameValues.eur;
                default: return null;
            }
        }

        static private void changerval(int fid, int lid, int cout)
        {
            Value fval = GetValById(fid);
            Value lval = GetValById(lid);

            double gold = (double)cout / fval.togold;
          
            int converted = (int)(gold * lval.togold);

            fval.acout -= cout;
            lval.acout += converted;

            Console.WriteLine($"You change in {fval.name}, to {lval.name}, in cout {cout}");
        }

        static public void changeshop()
        {
            int step;
            Console.WriteLine("to step: ");
            step = Int32.Parse(Console.ReadLine());
            for (int e = 1; e <= step; e++)
            {
                for (int i = 1; i < 4; i++)
                {
                    Value sval = GetValById(i);

                    int chance = Grnr(1, 100);
                    int change;

                    if (chance <= 60)
                    {
                        change = Grnr(1, 5);
                    }
                    else
                    {
                        change = Grnr(10, 20);
                    }

                    bool up = (Grnr(0, 1) == 1);

                    if (up)
                    {
                        sval.togold += change;
                    }
                    else
                    {
                        if (sval.togold > change + 10)
                            sval.togold -= change;
                    }

                    Console.WriteLine($"{sval.name} изменился на {(up ? "+" : "-")}{change}, теперь {sval.togold}");
                }
            }
        }

        static public void actconvert()
        {
            while (true)
            {
                int fid;
                int lid;
                int cout;
                int res;
                Console.WriteLine("=== BEST CONVERTER ===");
                Console.WriteLine("Select from val change to:");
                showvals();
                fid = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Select to val change to:");
                showvals();
                lid = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Select cout val change to:");
                cout = Int32.Parse(Console.ReadLine());

                changerval(fid, lid, cout);
                break;


            }
        }
    }

    class GameCsl
    {
        static public void start()
        {
            while (true)
            {
                int act = 4;
                GameLog.showvals();

                Console.WriteLine("=== SELECR ACTTION ====");
                Console.WriteLine("1)    :convert");
                Console.WriteLine("2)    :change shop");
                Console.WriteLine("3)    :get value");
                Console.WriteLine("4)    :");

                act = Int32.Parse(Console.ReadLine());
                switch (act)
                {
                    case 1:
                        {
                            Console.WriteLine("Go convert");
                            GameLog.actconvert();
                            break;
                        }
                    case 2:
                        {
                            GameLog.changeshop();
                            Console.WriteLine("Changes");

                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("0");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("0");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("errpr");
                            break;
                        }
                }
            }

        }
        static public int Main()
        {
            Console.WriteLine(":0");
            Console.WriteLine("==== DREAM CONVERTER ====");
            start();

            return 0;
        }
    }
}