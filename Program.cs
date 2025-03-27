
    using CargoShip;

    public class Program
    {
        public static void Main(string[] args)
        {
            var ship1 = new Ship(50, 100, 1000);
            var ship2 = new Ship(50, 5, 10);

            
            Console.WriteLine("====================================================================");
            //stworzenie kontenerow
            Console.WriteLine("Wyswietlenie stworzenia kontenerow");

            
            var refrigeratedContainer1 = new RefrigeratedContainer(3, 1000, 5, 600, Product.Fish);
            var refrigeratedContainer2 = new RefrigeratedContainer(3, 300,5, 6, 1500, Product.Butter);

            var gasContainer1 = new GasContainer(3, 2000, 5, 2100);
            var gasContainer2 = new GasContainer(4, 1700, 1500, 2000);

            var liquidContainer1 = new LiquidContainer(3, 2000, 1000, 800, 2000, true);
            var liquidContainer2 = new LiquidContainer(3, 5, 600, 1500, false);

            Console.WriteLine(refrigeratedContainer1);
            Console.WriteLine(gasContainer1);
            Console.WriteLine(gasContainer2);
            Console.WriteLine(liquidContainer1);
            Console.WriteLine(liquidContainer2);

            
            Console.WriteLine("====================================================================");
            //zaladowanie kontenerow
            Console.WriteLine("Wyswietlenie zaladowania kontenerow");
            

            refrigeratedContainer1.LoadContainer(200);
            gasContainer1.LoadContainer(200);
            gasContainer2.LoadContainer(5);
            gasContainer1.LoadContainer(1000);
            liquidContainer2.LoadContainer(1000);


            Console.WriteLine(refrigeratedContainer1);
            Console.WriteLine(gasContainer1);
            Console.WriteLine(gasContainer2);
            Console.WriteLine(liquidContainer1);
            Console.WriteLine(liquidContainer2);
            
            
            Console.WriteLine("====================================================================");
            //zaladowanie kontenera na statek
            Console.WriteLine("Wyswietlenie zaladowania kontenera na statek");
            
            
            Console.WriteLine(ship1);
            Console.WriteLine(ship2);
            
            ship1.PutContainer(refrigeratedContainer1);
            ship1.PutContainer(refrigeratedContainer2);
            Console.WriteLine(ship1);
            
            
            Console.WriteLine("====================================================================");
            //zaladowanie kontenerow na statek
            Console.WriteLine("Wyswietlenie zaladowania kontenerow na statek");
            
            
            List<Container> containers = [gasContainer1, gasContainer2, liquidContainer1, liquidContainer2];
            ship2.PutContainers(containers);
            Console.WriteLine(ship2);
            
            
            Console.WriteLine("====================================================================");
            //usuniecie kontenera ze statku
            Console.WriteLine("Usuniecie kontenera ze statku");
            
            
            ship1.RemoveContainer(refrigeratedContainer1);
            Console.WriteLine(ship1);
            
            
            Console.WriteLine("====================================================================");
            //rozladowanie kontenera
            Console.WriteLine("Rozladowanie kontenera");
            
            
            Console.WriteLine(gasContainer2);
            gasContainer2.EmptyContainer();
            Console.WriteLine(gasContainer2);
            Console.WriteLine(ship2);
            
            
            Console.WriteLine("====================================================================");
            //Zastapienie kontenera o danym numerze seryjnym innym kontenerem
            Console.WriteLine("Zastapienie kontenera o danym numerze seryjnym innym kontenerem");
            
            
            var newGasContainer = new GasContainer(3, 2000, 5, 2100);

            Console.WriteLine(ship2);
            ship2.SwitchContainer(gasContainer1.SerialNumber, newGasContainer);
            Console.WriteLine(ship2);


            Console.WriteLine("====================================================================");
            //Przeniesienie kontenera miedzy statkami
            Console.WriteLine("Przeniesienie kontenera miedzy statkami");
            
            
            Console.WriteLine(ship1);
            Console.WriteLine(ship2);
            
            ship2.MoveContainerToAnotherShip(gasContainer2, ship1);
            Console.WriteLine(ship1);
            Console.WriteLine(ship2);
        }
    }