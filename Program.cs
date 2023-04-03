using static Assignment3.Program;

namespace Assignment3;

class Program
{
    public static void Main(string[] args)
    {
        MyStack<int> stk = new MyStack<int>();
        stk.Push(1);
        stk.Push(2);
        stk.Push(3);
        Console.WriteLine("Number of element in stk before pop is: " + stk.Count());
        stk.Pop();
        Console.WriteLine("Number of element in stack after pop is: " + stk.Count());


        MyList<int> ls = new MyList<int>();
        ls.Add(1);
        ls.Add(2);
        ls.Add(3);
        ls.Add(4);
        ls.Remove(3);
        Console.WriteLine("After remove the element at index 3, the list conatins 4 is: " + ls.Contains(4));
        Console.WriteLine("The list contains 2 is " + ls.Contains(2));
        ls.Clear();
        ls.InsrtAt(2,0);
        ls.InsrtAt(3, 1);
        ls.DeleteAt(1);
        Console.WriteLine("After all operations, the element of list at index 0 is " + ls.Find(0));

       
        GenericRepository<Entity> gr = new GenericRepository<Entity>();
        gr.Add(new Entity { Id = 1 });
        gr.Add(new Entity { Id = 2 });
        gr.Add(new Entity { Id = 3 });
        var e1 = gr.GetAll();
        foreach(var item in e1)
        {
            Console.WriteLine("Entity with id: {0}", item.Id);
        }

        var GetById = gr.GetById(1);
        Console.WriteLine("Using GetById to get Entity with id = " + GetById.Id);

        gr.Remove(GetById);

        gr.Save();
        var e2 = gr.GetAll();
        foreach (var item in e1)
        {
            Console.WriteLine("Entity with id: {0}", item.Id);
        }
        // Entity with id = 1 is removed







    }

    //Q1
    class MyStack<T>
    {
        Stack<T> stk = new Stack<T>();
        public int Count()
        {
            return stk.Count;
        }

        public T Pop()
        {
            if (stk.Count == 0)
            {
                Console.WriteLine("Cannot pop an empty stack");
            }
            return stk.Pop();
        }

        public void Push(T element)
        {
            stk.Push(element);
        }
    }

    //Q2
    class MyList<T>
    {
        List<T> list = new List<T>();
        public void Add(T element)
        {
            list.Add(element);
        }

        public T Remove(int index)
        {
            T removed = list[index];
            list.RemoveAt(index);
            return removed; 
        }

        public bool Contains(T element)
        {
            return list.Contains(element);
        }

        public void Clear()
        {
            list.Clear();
        }

        public void InsrtAt(T element, int index)
        {
            list.Insert(index, element);
        }

        public void DeleteAt(int index)
        {
            list.RemoveAt(index);
        }

        public T Find(int index)
        {
            return list[index];
        }

    }

    //Q3
    public interface IRepository<T>
    {
        public void Add(T item);

        public void Remove(T item);

        public void Save();

        public IEnumerable<T> GetAll();

        public T GetById(int d);

    }

    public class Entity
    {
        public int Id { get; set; }
    }




    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        List<T> ls = new List<T>();

        public void Add(T item)
        {
            ls.Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            return ls;
        }

        public T GetById(int Id)
        {
            return ls.FirstOrDefault(l => l.Id == Id);
        }

        public void Remove(T item)
        {
            ls.Remove(item);
        }

        public void Save()
        {
            
        }
    }
}

