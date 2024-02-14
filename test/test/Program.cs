//class Program
//{
// static void Main(string[] args)
//{
/*1
 string first = "ab";
string second = "a" + "b";

Console.WriteLine(first == second);
Console.WriteLine((object)first == (object)second);*/
/*2
 Dictionary<Key, string> dictionary = new Dictionary<Key, string>();
Key firstKey = new Key(1);
dictionary.Add(firstKey, "First");
Key secondKey = new Key(2);
dictionary.Add(secondKey, "Second");

Console.WriteLine(dictionary[firstKey]);

public class Key
{
public int Marker { get; }

public Key(int marker) => Marker = marker;

public override int GetHashCode() => Marker / 10;

public override bool Equals(object? other) =>
other is Key ? other.GetHashCode() == GetHashCode() : base.Equals(other);
}*/
/*3
 Какое значение переменной `key` в результате выполнения кода?

string key = "a";

try
{
throw new ArgumentException();
}
catch (ArgumentException)
{
key += "b";
}
catch (Exception)
{
key += "c";
}
finally
{
key += "d";
}*/
/*4
 Какой результат выполнения кода?

try
{
using (Robot robot = new Robot())
{
robot.Dispose();
throw new InvalidOperationException();
}
}
catch (InvalidOperationException)
{
Console.WriteLine("Exception handled");
}

public class Robot : IDisposable
{
public Robot() => Console.WriteLine("Constructed");
public void Dispose() => Console.WriteLine("Disposed");
}*/
/*5
 Какой результат выполнения кода?

int first = 0;
object second = (object)first;
Increment(ref first);
Console.WriteLine(first == (int)second);

public static void Increment(ref int source)
{
source++;
}
*/
/*6
 Что будет выведено в консоль?

Ultrabot ultrabot = new Ultrabot();
Robot robot = new Robot();

public class Robot
{
static Robot() { Console.WriteLine("Static"); }
public Robot() { Console.WriteLine("Robot"); }
}

public class Ultrabot : Robot
{
public Ultrabot() : base() { Console.WriteLine("Ultrabot"); }
}*/
/*7
 Что будет выведено в консоль?

Fuzzbot bot = new Fuzzbot();		
Console.WriteLine(bot is Robot);
Console.WriteLine(bot is Fuzzbot);
Console.WriteLine(bot is Buzzbot);

public class Robot {}

public class Fuzzbot : Robot {}

public class Buzzbot : Robot {}*/
/*8
 Какой результат выполнения кода?

Human human = new Human();
Robot robot = new Robot(human);
robot.HumanOperator.Name = "Masha";
Console.WriteLine(robot.HumanOperator.Name);

public class Robot 
{
public readonly Human HumanOperator;
public Robot(Human humanOperator) => HumanOperator = humanOperator;
}

public class Human
{
public string Name;
}*/
/*9
 Что будет выведено в консоль?

Robot robot = new Robot();
robot.Print();
(robot as Robot).Print();
(robot as BaseRobot).Print();

public abstract class BaseRobot
{
public virtual void Print() => Console.WriteLine("BaseRobot");
}

public class Robot : BaseRobot
{
public override void Print() => Console.WriteLine("Robot");
}*/
/*10
 Что будет выведено в консоль?

Robot robot = new Robot();
robot.Print();
(robot as Robot).Print();		
(robot as BaseRobot).Print();

public abstract class BaseRobot
{
public void Print() => Console.WriteLine("BaseRobot");
}

public class Robot : BaseRobot
{
public new void Print() => Console.WriteLine("Robot");
}*/
/*11
 Какой результат выполнения кода?

Queue<string> queue = new Queue<string>();
queue.Enqueue("1");
queue.Enqueue("2");
queue.Dequeue();
queue.Enqueue("3");

foreach(string item in (IEnumerable<string>)queue)
{
Console.WriteLine(item);
}*/
/*12
 Что будет выведено в консоль?

Container container = new Container() { Value = 1 };
Container.Nullify(container);
Console.WriteLine(container.Value);

public struct Container
{
public int Value;
public static void Nullify(Container container) => container.Value = 0;
}*/
/*13
 Что будет выведено в консоль?

List<int> numbers = new List<int> { 1, 2, 3, 4 };
IEnumerable<int> squares = numbers
.Where(x => x % 2 == 0)
.Select(x => x * 2);

foreach(var square in squares)
{
Console.WriteLine(square);
}*/

//}

//}
/*public struct Container
{
    public int Value;
    public static void Nullify(Container container) => container.Value = 0;
}*/
using System.Linq;

namespace Program
{
    /*internal class Program
    {
        private const string TinkoffSort = "FFIKNOT";
        public static string[] CheckTinkoffSort(string[] inputStrings)
        {
            var outputResult = new string[inputStrings.Length];
            for (int i = 0; i < inputStrings.Length; i++)
            {
                inputStrings[i] = new(inputStrings[i].OrderBy(c => c).ToArray());
                outputResult[i] = inputStrings[i].Equals(TinkoffSort) ? "Yes"
                    : "No";
            }
            return outputResult;
        }
        static void Main(string[] args)
        {
            var stringCount = int.Parse(Console.ReadLine());
            if (stringCount > 100 || stringCount < 1) throw new ArgumentException("Invalid number of strings entered.");
            var inputStrings = new string[stringCount];
            for (int i = 0; i < stringCount; i++)
            {
                var currentString = Console.ReadLine();

                if (currentString.Length > 20) throw new ArgumentException("The length of the string is above the permissible limit.");
                inputStrings[i] = currentString;
            }
            var results = CheckTinkoffSort(inputStrings);
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }*/

    /*internal class Program
    {
        private const int MaxNumberOfGifts = 1000000;

        private const int MaxCreditAmount = 1000000000;

        private const int MaxGiftPriceValue = 1000000000;

        private static void Main(string[] args)
        {
            try
            {
                var giftsCountAndCredit = Console.ReadLine().Split(' ');

                var numberOfGifts = int.Parse(giftsCountAndCredit[0]);

                var creditAmount = int.Parse(giftsCountAndCredit[1]);

                ValidateNumberOfGifts(numberOfGifts);

                ValidateCreditAmount(creditAmount);

                var giftPricesInput = Console.ReadLine().Split(' ');

                ValidateGiftPrices(giftPricesInput);

                var giftPrices = new List<int>();

                for (var i = 0; i < numberOfGifts; i++)
                {
                    giftPrices.Add(int.Parse(giftPricesInput[i]));
                }

                Console.WriteLine(GetRemainigMoney(giftPrices, creditAmount));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static int GetRemainigMoney(List<int> giftsPrices, int credit)
        {
            var currentCredit = credit;

            foreach (var giftPrice in giftsPrices)
            {
                if (giftPrice <= credit)
                    credit -= giftPrice;
            }

            if (credit == 0)
            {
                currentCredit -= 1;
                return GetRemainigMoney(giftsPrices, currentCredit);
            }

            return credit;
        }

        private static void ValidateNumberOfGifts(int numberOfGifts)
        {
            if (numberOfGifts < 1 || numberOfGifts > MaxNumberOfGifts)
                throw new ArgumentException("Некорректное количество подарков");
        }

        private static void ValidateCreditAmount(int creditAmount)
        {
            if (creditAmount < 1 || creditAmount > MaxCreditAmount)
                throw new ArgumentException("Некорректный размер кредита");
        }

        private static void ValidateGiftPrices(string[] giftPricesInput)
        {
            foreach (var giftPriceStr in giftPricesInput)
            {
                var giftPrice = int.Parse(giftPriceStr);

                if (giftPrice < 1 || giftPrice > MaxGiftPriceValue)
                    throw new ArgumentException("Некорректная цена подарка");
            }
        }
    }
}*/

    /*3 internal class Program
    {
        private const int MaxNumberOfGifts = 1000000;

        private const int MaxCreditAmount = 1000000000;

        private const int MaxGiftPriceValue = 1000000000;

        private static void Main(string[] args)
        {
            try
            {
                var giftsCountAndCredit = Console.ReadLine().Split(' ');

                var numberOfGifts = int.Parse(giftsCountAndCredit[0]);

                var creditAmount = int.Parse(giftsCountAndCredit[1]);

                ValidateNumberOfGifts(numberOfGifts);

                ValidateCreditAmount(creditAmount);

                var giftPricesInput = Console.ReadLine().Split(' ');

                ValidateGiftPrices(giftPricesInput);

                var giftPrices = new List<int>();

                for (var i = 0; i < numberOfGifts; i++)
                {
                    giftPrices.Add(int.Parse(giftPricesInput[i]));
                }

                Console.WriteLine(GetRemainigMoney(giftPrices, creditAmount));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static int GetRemainigMoney(List<int> giftsPrices, int creditAmount)
        {
            foreach (var giftPrice in giftsPrices)
            {
                if (giftPrice <= creditAmount)
                    creditAmount -= giftPrice;
            }

            return creditAmount;
        }

        private static void ValidateNumberOfGifts(int numberOfGifts)
        {
            if (numberOfGifts < 1 || numberOfGifts > MaxNumberOfGifts)
                throw new ArgumentException("Некорректное количество подарков");
        }

        private static void ValidateCreditAmount(int creditAmount)
        {
            if (creditAmount < 1 || creditAmount > MaxCreditAmount)
                throw new ArgumentException("Некорректный размер кредита");
        }

        private static void ValidateGiftPrices(string[] giftPricesInput)
        {
            foreach (var giftPriceStr in giftPricesInput)
            {
                var giftPrice = int.Parse(giftPriceStr);

                if (giftPrice < 1 || giftPrice > MaxGiftPriceValue)
                    throw new ArgumentException("Некорректная цена подарка");
            }
        }
    }*/

    /*class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int q = int.Parse(input[1]);

            var array = new int[n];
            var arrayInput = Console.ReadLine().Split();
            var results = new List<int>();
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(arrayInput[i]);
            }

            for (int i = 0; i < q; i++)
            {
                var query = Console.ReadLine().Split();
                if (query[0] == "?")
                {
                    int l = int.Parse(query[1]) - 1;
                    int r = int.Parse(query[2]) - 1;
                    int k = int.Parse(query[3]);
                    int b = int.Parse(query[4]);

                    int result = GetQueryResult(array, l, r, k, b);
                    results.Add(result);
                }
                else if (query[0] == "+")
                {
                    int l = int.Parse(query[1]) - 1;
                    int r = int.Parse(query[2]) - 1;
                    int x = int.Parse(query[3]);

                    UpdateArray(array, l, r, x);
                }
            }
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        static int GetQueryResult(int[] array, int l, int r, int k, int b)
        {
            int maxMin = int.MinValue;
            for (int i = l; i <= r; i++)
            {
                int currentMin = Math.Min(array[i], k * (i + 1) + b);
                maxMin = Math.Max(maxMin, currentMin);
            }

            return maxMin;
        }

        static void UpdateArray(int[] array, int l, int r, int x)
        {
            for (int i = l; i <= r; i++)
            {
                array[i] += x;
            }
        }
    }*/

    /*internal class Program
    {
        private static void Main(string[] args)
        {
            int setsCount; try
            {
                setsCount = int.Parse(Console.ReadLine());
                ValidateSetsCount(setsCount);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message); return;
            }
            var results = new string[setsCount]; try
            {
                for (var i = 0; i < setsCount; i++)
                {
                    var developersCount = int.Parse(Console.ReadLine());
                    var socialLimits = new int[developersCount]; var socialLimitsStr = Console.ReadLine().Split(' ');
                    for (var j = 0; j < developersCount; j++)
                    {
                        socialLimits[j] = int.Parse(socialLimitsStr[j]);
                    }
                    ValidateSetData(developersCount, socialLimits); results[i] = GetCommunicationResult(socialLimits, developersCount);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Результат коммуникации групп"); foreach (var result in results)
                Console.WriteLine(result);
        }
        private static void ValidateSetData(int developersCount, int[] socialLimits)
        {
            if (developersCount < 1 || developersCount > 100000) throw new ArgumentException("Количество разработчиков имеет недопустимый размер");
            foreach (var limit in socialLimits)
            {
                if (limit < 1 || limit > 1000000000) throw new ArgumentException("Социальный предел имеет недопустимый размер");
            }
            if (developersCount != socialLimits.Length) throw new ArgumentException("Не равны");
        }
        private static void ValidateSetsCount(int setsCount)
        {
            if (setsCount < 1 || setsCount > 1000) throw new ArgumentException("Недопустимое количество наборов.");
        }
        private static string GetCommunicationResult(int[] socialLimits, int developersCount)
        {
            if (socialLimits.Length == 1) return "YES"; for (var j = 0; j < developersCount; j++)
            {
                for (var k = 0; k < developersCount; k++)
                {
                    if (j != k && socialLimits[j] != 0 && socialLimits[k] != 0)
                    {
                        socialLimits[j]--;
                        socialLimits[k]--;
                    }
                }
            }
            return socialLimits.All(r => r == 0) ? "YES" : "NO";
        }
    }*/

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);

            // Считываем имена компаний
            Dictionary<string, int> companyIndex = new Dictionary<string, int>();
            for (int i = 0; i < k; i++)
            {
                string companyName = Console.ReadLine();
                companyIndex[companyName] = i;
            }

            // Считываем описание вершин дерева
            int[][] tree = new int[n][];
            for (int i = 0; i < n; i++)
            {
                tree[i] = new int[3];

                string[] nodeInput = Console.ReadLine().Split(' ');
                tree[i][0] = int.Parse(nodeInput[0]);
                tree[i][1] = int.Parse(nodeInput[1]);
                tree[i][2] = companyIndex[nodeInput[2]];
            }

            // Решение задачи
            int minCost = Solve(tree, k);

            // Вывод результата
            if (minCost == -1)
            {
                Console.WriteLine("Выкупить акции всех компаний невозможно.");
            }
            else
            {
                Console.WriteLine(minCost);
            }
        }

        static int Solve(int[][] tree, int k)
        {
            List<int>[] adjacencyList = new List<int>[tree.Length];
            for (int i = 0; i < tree.Length; i++)
            {
                adjacencyList[i] = new List<int>();
            }

            for (int i = 0; i < tree.Length; i++)
            {
                if (tree[i][0] != 0)
                {
                    adjacencyList[i].Add(tree[i][0] - 1);
                    adjacencyList[tree[i][0] - 1].Add(i);
                }
            }

            int[] minCosts = new int[tree.Length];
            for (int i = 0; i < tree.Length; i++)
            {
                minCosts[i] = -1;
            }

            void dfs(int v, int parent, int[] costs)
            {
                if (costs[v] != -1)
                {
                    return;
                }

                bool containsAllCompanies = true;
                for (int i = 0; i < k; i++)
                {
                    if (tree[v][2] == i)
                    {
                        int cost = tree[v][1];
                        costs[v] = cost;
                    }
                    else
                    {
                        containsAllCompanies = false;
                    }
                }

                if (containsAllCompanies)
                {
                    int cost = tree[v][1];
                    costs[v] = cost;
                }

                foreach (int u in adjacencyList[v])
                {
                    if (u != parent)
                    {
                        dfs(u, v, costs);
                    }
                }
            }

            dfs(0, -1, minCosts);

            int minCost = minCosts[0];
            for (int i = 1; i < minCosts.Length; i++)
            {
                if (minCosts[i] != -1 && (minCost == -1 || minCosts[i] < minCost))
                {
                    minCost = minCosts[i];
                }
            }

            return minCost;
        }
    }
}