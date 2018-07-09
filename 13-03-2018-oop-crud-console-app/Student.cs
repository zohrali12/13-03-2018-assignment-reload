using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_03_2018_oop_crud_console_app
{
    class Student
    {
        public static List<Student> db = new List<Student>();
        public static int Count=1;
        public int ID;
        public string Name;
        public string Surname;
        public int Age;
        public Student(string _name, string _surname, int _age)
        {
            Name = _name;
            Surname = _surname;
            Age = _age;
            db.Add(this);
            

        }

        public static void UserAuthentication()
        {
            Console.WriteLine("istifadeci adini daxil edin");
            string username = Console.ReadLine();
            Console.WriteLine("parolu daxil edin");
            string password = Console.ReadLine();
            if (username=="admin" && password=="admin" )
            {
                Instructions();
            }
            else if (username == "user" && password == "user")
            {
                InstructionUser();
            }
            else
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("XETA: Istifadeci adi ve ya parol yalnishdir");
                Console.WriteLine("-------------------------------------------");
            }
            UserAuthentication();
        }

        public static void Instructions()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1. Yeni telebe elave et");
            Console.WriteLine("2. Telebeleri gor");
            Console.WriteLine("3. Telebe melumatlarini deyis");
            Console.WriteLine("4. Telebeni sil");
            Console.WriteLine("5. Telebenin detalli melumati");
            Console.WriteLine("6. Proqramdan cix");
            Console.WriteLine("-----------------------------------");
            Console.Write("Istediyiniz emrin nomresini daxil edin: ");
            var emr = Console.ReadLine();
            int theNumber;
            if (int.TryParse(emr, out theNumber))
            {
                if (theNumber == 1)
                {
                    Create();
                }
                else if (theNumber == 2)
                {
                    Read();
                }
                else if (theNumber == 3)
                {
                    Update();
                }
                else if (theNumber == 4)
                {
                    Delete();
                }
                else if (theNumber == 5)
                {
                    Details();
                }
                else if (theNumber == 6)
                {
                    Exit();
                }
                else
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("XETA: Emr nomresi duzgun deyil");
                    Console.WriteLine("-----------------------------------");
                }


            }
            else
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("XETA: Zehmet olmasa reqem daxil edin");
                Console.WriteLine("-----------------------------------");
            }

           
            Instructions();


        }


        public static void InstructionUser()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1. Telebeleri gor"); 
            Console.WriteLine("2. Proqramdan cix");
            Console.WriteLine("-----------------------------------");
            Console.Write("Istediyiniz emrin nomresini daxil edin: ");
            Console.Write("Istediyiniz emrin nomresini daxil edin: ");
            var emr = Console.ReadLine();
            int theNumber;
            if (int.TryParse(emr, out theNumber))
            {
                if (theNumber == 1)
                {
                    ReadUser();
                }
                else if (theNumber == 2)
                {
                    Exit();
                }
                else
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("XETA: Emr nomresi duzgun deyil");
                    Console.WriteLine("-----------------------------------");
                }

            }
            else
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("XETA: Zehmet olmasa reqem daxil edin");
                Console.WriteLine("------------------------------------");
            }
            
            InstructionUser();



            
        }


        public static void Create()
        {
            
            Console.Write("Telebe adini daxil edin: ");
            var name = Console.ReadLine();
            Console.Write("Telebe soyadini daxil edin: ");
            var surname = Console.ReadLine();
            Console.Write("Telebe yasini daxil edin: ");
            returnToAge:
            var emr = Console.ReadLine();
            int age;
            if (int.TryParse(emr, out age))
            {
                Student telebe = new Student(name, surname, age);
                telebe.ID = Count;
                //db.Add(telebe);
                Count++;
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("{0} {1} {2} melumat bazasina elave olundu.", name, surname, age);
               
            }
            else
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("XETA: yas bolmesine reqem daxil edin");
                Console.WriteLine("------------------------------------");
                goto returnToAge;
            }

            
            Instructions();
            

        }
      
        public static void Read()
        {

            foreach (var item in Student.db)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Melumat bazasinda olanlar:");
                Console.WriteLine(item.ID + "-" + item.Name + "-" + item.Surname + "-" + item.Age);
            }


            Instructions();
        }

        public static void ReadUser()
        {
            foreach (var item in Student.db)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Melumat bazasinda olanlar:");
                Console.WriteLine(item.ID + "-" + item.Name + "-" + item.Surname + "-" + item.Age);
            }

            InstructionUser();
        }

        // Continue****************************************************************

        public static void Update()
        {
            Console.WriteLine("Deyiwmek istediyiniz Elementin  ID - sini Yazin");

            foreach (var item in Student.db)
            {
                Console.WriteLine(item.ID + "-" + item.Name + "-" + item.Surname + "-" + item.Age);
            }
           
            var chooseId = Convert.ToInt32(Console.ReadLine());

            foreach (var item in db)
            {
                if (item.ID == chooseId)
                {
                    Console.WriteLine("Yeni Adi Daxil Edin");
                    var ad = Console.ReadLine();
                    Console.WriteLine("Yeni soyadi Daxil Edin");
                    var soyad = Console.ReadLine();
                    Console.WriteLine("Yeni Yawi Daxil Edin");
                    var yaw = Convert.ToInt32(Console.ReadLine());

                    item.Name = ad;
                    item.Surname = soyad;
                    item.Age = yaw;

                    Read();

                }
            }
        }

        public static void Delete()
        {
            Console.WriteLine("Silmek istediyiniz telebenin id deyerini daxil edin : ");
            var _id=Convert.ToInt32(Console.ReadLine());
            foreach (var item in db)
            {
                if (item.ID == _id)
                {
                    db.Remove(item);
                    break;
                }
            }
            Instructions();
        }

        public static void Details()
        {
            Console.WriteLine("Detalli melumatini gormek istediyiniz telebenin id deyerini daxil edin : ");
            var _id = Convert.ToInt32(Console.ReadLine());

            foreach (var item in db)
            {
                if (item.ID == _id)
                {
                    Console.WriteLine(" Telebe adi : {0} ",item.Name);
                    Console.WriteLine(" Telebe soyadi : {0} ",item.Surname);
                    Console.WriteLine(" Telebe yasi : {0} ",item.Age);
                }
            }
            Instructions();
        }

        public static void Exit()
        {
            Console.WriteLine("Cixmaq ucun 6 yazin");
            Environment.Exit(6);
        }
    }
}
