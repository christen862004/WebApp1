namespace WebApp1.Models
{
    //depenede
    //create intrefcae contract method
    interface ISort
    {
        void Sort(int[] arr);
    }
    //implement Interface
    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {
            //logic using Bubble sort ds
        }
    }

    class SelectionSort:ISort
    {
        public void Sort(int[] arr)
        {
            //logic using Bubble sort ds
        }
    }
    class ChrisSort : ISort
    {
        public void Sort(int[] arr)
        {
            //logic using Bubble sort ds
        }
    }
    //h=>l (based on abstarct or interface)
    class MyList //high level
    {
        int[] arr;
        ISort bSort; //low 
        //injection construct
        public MyList(ISort sort)//dont create ==>Ask carete list sort type (constructor - MEthod used it)
        {
            arr = new int[10];
            bSort = sort;//depencey
        }
        //injection mehod
        //injection property (not support in mvc core)
        public void SortArr(ISort sort)
        {
            bSort = sort;
            bSort.Sort(arr);
        }
    }




    public class Partent<T>
    {
        public T msg { get; set; }
    }
    //child close type
    public class Child : Partent<int>
    {
        object _viewData;//

        public object ViewData
        {
            get { return _viewData; }
            set { _viewData = value; }
        }
        //public property wrap the same filed
        public object ViewBag
        {
            get { return _viewData; }
            set { _viewData = value; }
        }
    }
    public class TestClass
    {

        public void Add(int x,int y)
        {
            Child c = new Child();
            
            //Child<int> c = new Child<int>();
            //Child<float> c2 = new Child<float>();
            //Partent<T> p1 = new Partent<T>();
            //no1
            int z = x + y;
        }

        public void DisplayCal()
        {

            dynamic x = 1;
            dynamic y = "hi";
            dynamic z = new Department();
            
            dynamic obj = z + y;//thwoe exception runtime

            MyList l1 = new MyList(new BubbleSort());
            MyList l2 = new MyList(new SelectionSort());
            MyList l3 = new MyList(new ChrisSort());


            int no1 = 10;
            int no2 = 20;
            Add(no1, no2);//send int no1
        }
    }
}
