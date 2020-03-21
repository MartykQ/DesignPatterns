using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTree
{
    class Program
    {
        static void Main(string[] args)
        {

            Email e = new Email();
            Email e1 = new Email("Oferta zakupow", "Tesco", "Mariusz", 250, "Poznaj oferte");
            Email e2 = new Email("Wydarzenie", "TVN", "Mariusz", 220, "Zapraszamy na wydarzenie");
            Email e3 = new Email("Zaproszenie na otwarcie", "Żabka", "jd", 250, "Poznaj oferte");
            Email e4 = new Email("Oferta zakupow", "Tesco", "Mariusz", 250, "Poznaj oferte");

            Catalog wszystkie = new Catalog("Wszystkie");
            Catalog spam = new Catalog("Spam");
            Catalog oferty = new Catalog("Oferty");
            Catalog przypomnienia = new Catalog("Przypomnienia");

            spam.ChildList.Add(e);
            spam.ChildList.Add(e2);

            oferty.ChildList.Add(e);
            oferty.ChildList.Add(e1);
            oferty.ChildList.Add(e);

            przypomnienia.ChildList.Add(e);
            przypomnienia.ChildList.Add(e);
            przypomnienia.ChildList.Add(e);
            przypomnienia.ChildList.Add(e4);


            Catalog bardzoWaznePrzypomnienia = new Catalog("Bardzo wazne przypomnienia");
            bardzoWaznePrzypomnienia.ChildList.Add(e);
            przypomnienia.ChildList.Add(bardzoWaznePrzypomnienia);

            wszystkie.ChildList.Add(spam);
            wszystkie.ChildList.Add(oferty);
            wszystkie.ChildList.Add(przypomnienia);

            Console.WriteLine(wszystkie.DisplayStructure(""));

        }
    }
}
