using System;
using System.Data.SqlClient;
using System.Xml.Schema;
using DataLayer.Items;
using ORM;
namespace ConsoleTry
{
    static class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Integrated Security=True;Initial Catalog=VIS");

            connection.Open();
            
            ItemRozhodci rozhodci = new ItemRozhodci()
            {
                Name = "Piprs",
                LastName = "NeniKokot",
                PersonalIn = "0000",
                Telephone = "asdasd",
                Password = "kokot"
            };

            // ReflectiveOrm<ItemTabulka> tabulka = new ReflectiveOrm<ItemTabulka>(connection);
            //
            // var r = tabulka.JoinedSelect();
            //
            // foreach (var a in r)
            // {
            //     Console.WriteLine(a);
            // }

            ReflectiveOrm<ItemHrac> hraci = new ReflectiveOrm<ItemHrac>(connection);
            var r = hraci.JoinedSelect();

            foreach (var a in r)
            {
                Console.WriteLine(a);
            }


            // ReflectiveORM<ItemRozhodci> ormRozhodci = new ReflectiveORM<ItemRozhodci>(connection);
            // // var r = ormRozhodci.Select();
            // // foreach (var rr in r)
            // // {
            // //     Console.WriteLine(rr);
            // // } 
            //
            // ormRozhodci.Where(x => x.Rid == 12).Delete();

            //  ReflectiveOrm<ItemHrac> hraci = new ReflectiveOrm<ItemHrac>(connection);
            //
            //  //var r = hraci.Where(x => x.Klub.Kid == 1).JoinedSelect();
            //
            // // var r = hraci.Where(x => x.Name == "Roman").Where(x => x.LastName == "Jurča").JoinedSelect();
            //  //var r = hraci.Where(x => x.Name == "Roman").JoinedSelect(); 
            //  
            //  ReflectiveOrm<ItemZapasy> zapasy = new ReflectiveOrm<ItemZapasy>(connection);
            //
            //  var r = zapasy.Where(x => x.Zid == 1).JoinedSelect();
            //
            //  int test = 0;
            //
            //  foreach (var a in r)
            //  {
            //      //Console.WriteLine(a);
            //       test = a.Klub2.Kid;
            //  }
            //
            //  Console.WriteLine(test);
            //
            //
            //  var h = hraci.Where(x => x.Klub.Kid == test).JoinedSelect();
            //
            //  foreach (var b in h)
            //  {
            //      Console.WriteLine(b);
            //  }

            // ReflectiveOrm<ItemHrac> hraci = new ReflectiveOrm<ItemHrac>(connection);
            //
            // var kokot = hraci.Where(x => x.Hid == 1).JoinedSelect();
            //
            //
            // foreach (var a in kokot)
            // {
            //     a.Name = "Funguju?";
            //     
            //     hraci.Where(x => x.Hid == 1).Update(a);
            //     
            // }
            //
            // foreach (var b in kokot)
            // {
            //     Console.WriteLine(b);
            // }

            // ReflectiveOrm<ItemZapasy> zapasy = new ReflectiveOrm<ItemZapasy>(connection);
            //
            // var kokot = zapasy.Where(x => x.Zid == 1).JoinedSelect();
            //
            // foreach (var a in kokot)
            // {
            //     a.DomaciSkore = 31;
            //     
            //     zapasy.Where(x => x.Zid == 1).Update(a);
            // }
            //
            // foreach (var b in kokot)
            // {
            //     Console.WriteLine(b);
            // }

            // ReflectiveOrm<ItemKlub> kluby = new ReflectiveOrm<ItemKlub>(connection);
            //
            // var kokot = kluby.Where(x => x.Kid == 1).JoinedSelect();
            //
            // foreach (var a in kokot)
            // {
            //     a.Name = "hcb karvina";
            //     kluby.Where(x=>x.Kid==1).Update(a);
            // }
            //
            // foreach (var b in kokot)
            // {
            //     Console.WriteLine(b);
            // }





        }
    }
}
