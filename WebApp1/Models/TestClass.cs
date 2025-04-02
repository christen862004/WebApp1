namespace WebApp1.Models
{

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




            int no1 = 10;
            int no2 = 20;
            Add(no1, no2);//send int no1
        }
    }
}
