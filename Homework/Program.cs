using static Homework.Nodes;

namespace Homework
{
    internal class Program
    {
        //פעולה המקבלת מצביע לחוליה 
        //מחזירה אמת אם החוליות מסודרות בסדר עולה
        //ושקר אחרת
        //אורך הקלט n: מספר החלויות
        //המקרה הגרוע: החוליות מסודרות בסדר עולה
        // פעמיםn הפעולה מתבצעת פעם אחת ובכל סיבוב הלולאה מתבצעות
        //מכאן שסיבוכיות הפעולה:o(n) 


        public static bool IsAscending(Node<int> lst)
        {
            while (lst.HasNext())
            {

                if (lst.GetValue() < lst.GetNext().GetValue())
                {
                    lst = lst.GetNext();
                }
                else
                    return false;
            }
            return true;
        }

        //אורך הקלט n: מספר החוליות 
        //המקרה הגרוע: החוליות מסודרות בסדר עולה
        //פעמים n הפעולה מבצעת פעם אחת  קריאות ובכל קריאה הלולאה מתבצעות
        //מכאן שסיבוכיות הפעולה: o(n)

        //כמו קודם רק מימוש רקורסיבי
        public static bool IsAscendingRecursive(Node<int> lst)
        {
            if (lst == null)
            {
                return true;
            }
            if (lst.HasNext() && lst.GetValue() > lst.GetNext().GetValue())
            {
                return false;
            }
            return IsAscendingRecursive(lst.GetNext());
        }

        //פעולה גנרית המחזירה אמת אם 
        //x 
        //קיים בשרשרת החוליות 
        //lst
        //ושקר אחחרת
        //שימו לב שבפעולה גנרית אין 
        //לא ניתן להשתמש ב
        //==
        //יש להתשמש בפעולה של
        //object
        //Equals

        //אורך הקלט n: מספר החוליות
        // לא קיים xהמקרה הגרוע: ה
        // פעמים n הפעולה מתבצעת פעם אחת ובכל סיבוב הלולאה מתבצעות
        //מכאן שסיבוכיות הפעולה: o(n)
        public static bool IsExists<T>(Node<T> lst, T x)
        {
            while (lst != null)
            {

                if (lst.GetValue().Equals(x))
                {
                    return true;
                }
                lst = lst.GetNext();
            }
            return false;
        }
        //אורך הקלט n:מספר החוליות
        // לא קיים xהמקרה הגרוע: ה
        // פעמים n הפעולה מתבצעת פעם אחת ובכל סיבוב הלולאה מתבצעות
        //מכאן שסיבוכיות הפעולה: o(n)

        public static bool IsExistsRecursive<T>(Node<T> lst, T x)
        {
            if (lst == null)
            {
                return false;

            }
            if (lst.GetValue().Equals(x))
            {
                return true;
            }
            return IsExistsRecursive(lst.GetNext(), x);


        }
        public static void Append<T>(Node<T> lst, Node<T> newn)
        {
            while (lst.HasNext())
            {
                lst = lst.GetNext();
            }
            lst.SetNext(newn);
        }
        public static void AddToMiddle(Node<int> lst, Node<int> newn)
        {
            while (lst.HasNext() && lst.GetNext().GetValue() < newn.GetValue())
            {
                lst = lst.GetNext();
            }
            newn.SetNext(lst.GetNext());
            lst.SetNext(newn);
        }
        public static Node<T> Deletevlue<T>(Node<T> lst, T value)
        {
            Node<T> head = lst;
            if (lst == null)
                return head;

            if (lst.GetValue().Equals(value))
            {
                head = lst.GetNext();
                lst.SetNext(null);
                return head;
            }
            Node<T> next = lst.GetNext();
            while (lst.HasNext() && !next.GetValue().Equals(value))
            {
                lst = next;
                next = lst.GetNext();
            }
            lst.SetNext(next.GetNext());
            next.SetNext(null);

            return head;
        }
        //page 76 question 2
        // סיבוכיות O(n)
        // אורך קלט n
        //  במקרה הגרוע יתבצעוn   פעולות  ולכן סהכ
        public static int RezefCount(Node<int> lst, int x)
        {
            int counter = 0;
            int a = 0;
            int b = 0;
            while (lst != null && lst.HasNext())
            {
                if (a == x && b != x)
                {
                    counter++;
                }
                a = b;
                b = lst.GetValue();
                lst = lst.GetNext();
            }
            if (b == x)
            {
                counter++;
            }
            return counter;
        }
        //page 76 question 4
        // סיבוכיות O(n)
        // אורך קלט n
        //  במקרה הגרוע יתבצעוn   פעולות  ולכן סהכ
        public static char CountEven(Node<int> lst)
        {
            int evenCounter = 0;
            int oddCounter = 0;
            while (lst != null)
            {
                if (lst.GetValue() % 2 == 0)
                {
                    evenCounter++;
                }
                else
                    oddCounter++;
                lst = lst.GetNext();
            }
            if (evenCounter > oddCounter)
            {
                return 'z';
            }
            else if (oddCounter > evenCounter)
            {
                return 'e';
            }
            else
                return 's';
        }


        //page 76 question 6
        //סיבוכיות O(n)
        // אורך קלט n
        //  במקרה הגרוע יתבצעוn   פעולות  ולכן סהכ
        public static Node<T> NoDouble<T>(Node<T> lst)
        {
            Node<T> newlst = new Node<T>(lst.GetValue());
            Node<T> head = newlst;
            Node<T> tail = newlst;
            while (lst != null )
            {
               
                if (!IsExists<T>(head, lst.GetValue()))
                {
                    tail.SetNext(new Node<T>(lst.GetValue()));
                    tail = tail.GetNext();
                }
                lst = lst.GetNext();
            }
            return head;
        }

        //page 76 question 8
        //סיבוכיות O(n)
        // אורך קלט n
        //  במקרה הגרוע יתבצעוn   פעולות  ולכן סהכ
        public static bool IsSorted(Node<int> lst)
        {
            while (lst.HasNext())
            {

                if (lst.GetValue() < lst.GetNext().GetValue())
                {
                    lst = lst.GetNext();
                }
                else
                    return false;
            }
            return true;
        }

        //page 76 question 10
        // סיבוכיות O(n)
        // אורך קלט n
        //  במקרה הגרוע יתבצעוn   פעולות  ולכן סהכ
        public static Node<int> Following(int beginner,int num)
        {
            Node<int> lst=new Node<int>(beginner);
            Node<int> head = lst;
           
            for(int i = beginner+1; i < beginner+num;i++)
            {
                lst.SetNext(new Node<int>(i));
                lst=lst.GetNext();
            }
            return head;
        }

        //page 76 question 12
        // סיבוכיות O(n)
        // אורך קלט n
        //  במקרה הגרוע יתבצעוn   פעולות  ולכן סהכ
        public static bool IsBalanced(Node<int> lst)
        {
            int sum = 0; 
            int countBigger=0;
            int countSmaller=0;
            while(lst!=null)
            {
                sum+=lst.GetValue();
                lst=lst.GetNext();
            }
            while(lst!=null)
            {
                if(lst.GetValue() < sum)
                {
                    countSmaller++;
                }
                else
                    countBigger++;
            }
            return countSmaller==countBigger;
        }


        //page 76 question 14
        // סיבוכיות O(n)
        // אורך קלט n
        //  במקרה הגרוע יתבצעוn   פעולות  ולכן סהכ
        public static int FindMax(Node<int> lst)
        {
            int max = int.MinValue;
            while (lst != null)
            {
                if (lst.GetValue() > max)
                {
                    max = lst.GetValue();
                    lst= lst.GetNext();
                }

            }
            return max;
        }

       

        public static void DeleteBiggest(Node<int> lst, int n)
        {
            int max = 0;
            for(int i=0;i<n;i++)
            {
                max=FindMax(lst);
                Deletevlue(lst, max);
                lst=lst.GetNext();
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            {
                //Node<int> lst1 = new Node<int>(4, new Node<int>(5, new Node<int>(6, new Node<int>(7))));//[4, next]=>[5, next]=>[6, next]=>[7, next]=>null
                //Console.WriteLine(IsAscending(lst1));//should print True
                //Console.WriteLine(IsAscendingRecursive(lst1));//should print True
                //Node<int> lst2 = new Node<int>(4, new Node<int>(5, new Node<int>(6, new Node<int>(2))));//[4, next]=>[5, next]=>[6, next]=>[2, next]=>null
                //Console.WriteLine(IsAscending(lst2));//should print False
                //Console.WriteLine(IsAscendingRecursive(lst2));//should print False
                //Node<int> lst3 = new Node<int>(4, new Node<int>(5, new Node<int>(4, new Node<int>(9))));//[4, next]=>[5, next]=>[4, next]=>[9, next]=>null
                //Console.WriteLine(IsAscending(lst3));//should print False
                //Console.WriteLine(IsAscendingRecursive(lst3));//should print False

                //Node<char> lst4 = new Node<char>('t', new Node<char>('A', new Node<char>('l', new Node<char>('s', new Node<char>('i')))));//['t', next]=>['a', next]=>['l', next]=>['s', next]=>['i', next]=>null
                //Console.WriteLine(IsExists(lst1, 5));//should print True
                //Console.WriteLine(IsExists(lst4, 'i'));//should print True
                //Console.WriteLine(IsExists(lst4, 'I'));//should print False
                //Console.WriteLine(IsExistsRecursive(lst1, 5));//should print True
                //Console.WriteLine(IsExistsRecursive(lst4, 'i'));//should print True
                //Console.WriteLine(IsExistsRecursive(lst4, 'I'));//should print False

                Node<int> lst1 = new Node<int>(4, new Node<int>(4, new Node<int>(8, new Node<int>(4, new Node<int>(4, new Node<int>(4, new Node<int>(4, new Node<int>(4, new Node<int>(4, new Node<int>(4))))))))));
                Node<int> lst2 = new Node<int>(1, new Node<int>(2, new Node<int>(3, new Node<int>(4, new Node<int>(5, new Node<int>(6))))));
                //Console.WriteLine(RezefCount(lst1, 4));
                //Console.WriteLine(CountEven(lst2));
                Console.WriteLine(NoDouble(lst1));
                Console.WriteLine(Following(5,4));

            }
        }
    }
}