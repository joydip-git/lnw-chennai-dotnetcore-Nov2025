using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    internal class Student
    {
        private int id;
        private string name;

        public Student()
        {
            
        }
        public Student(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        //public int Id 
        //{ 
        //    //public void setId(int id)
        //    set
        //    {
        //        //this.id = id;
        //        this.id = value;
        //    }
        //    //public int getId()
        //    get
        //    {
        //        return id;
        //    }
        //}
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public object this[int index]
        {
            get
            {
                if(index == 0)
                    return id;
                else if (index == 1)
                    return name;
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index == 0)
                    id = (int)value;
                else if (index == 1)
                    name = (string)value;
                else
                    throw new IndexOutOfRangeException();
            }
        }
        public object this[string propName]
        {
            get
            {
                if (propName == "id")
                    return id;
                else if (propName == "name")
                    return name;
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (propName == "id")
                    id = (int)value;
                else if (propName == "name")
                    name = (string)value;
                else
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
