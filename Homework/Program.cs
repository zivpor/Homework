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
        public static bool IsExists<T>(Node<T> lst, T x) where T : IEquatable<T>
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
            while(lst.HasNext() && lst.GetNext().GetValue()<newn.GetValue())
            {
                lst=lst.GetNext();
            }
            newn.SetNext(lst.GetNext());
            lst.SetNext(newn);
        }
        public static Node<T> Deletevlue<T>(Node<T> lst, T value)
        {
            Node<T> head = lst;
            if (lst == null)
                return head;

            if ( lst.GetValue().Equals(value))
            {
                head = lst.GetNext();
                lst.SetNext(null);
                return head;
            }
            Node<T> next= lst.GetNext();
            while(lst.HasNext()&&!next.GetValue().Equals(value))
            {
                lst = next;
                next=lst.GetNext();
            }
            lst.SetNext(next.GetNext());
            next.SetNext(null);

            return head;
        }

        public static int RezefCount(Node<int> lst, int x)
        {
            int counter = 0;
            while(lst!=null && lst.HasNext())
            {
                while(lst!=null&&lst.GetValue() == x)
                {
                    if(lst.HasNext()&&lst.GetNext().GetValue() != x)
                    {
                        counter++;
                    }
                    lst=lst.GetNext();
                }
                
                lst=lst.GetNext();
            }

            return counter;
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

                Node<int> lst1 = new Node<int>(4, new Node<int>(5, new Node<int>(6, new Node<int>(6, new Node<int>(3, new Node<int>(4, new Node<int>(4, new Node<int>(4, new Node<int>(22, new Node<int>(3))))))))));

                Console.WriteLine(RezefCount(lst1,4));

            }
        }
    }
}