using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_S2_L1
{
    internal class Menu
    {
        decimal total = 0;
        List<Product> menuProduct = new List<Product>()
        {
            new Product { NameProduct = "Coca Cola 150 ml", Price = 2.50m},
            new Product { NameProduct = "Insalata di pollo", Price = 5.20m},
            new Product { NameProduct = "Pizza Margherita", Price = 10.00m},
            new Product { NameProduct = "Pizza 4 formaggi", Price = 12.50m},
            new Product { NameProduct = "Pizza Patatine Fritte", Price = 3.50m },
            new Product { NameProduct = "Insalata di riso", Price = 8.00m},
            new Product { NameProduct = "Frutta di stagione", Price = 5.00m},
            new Product { NameProduct = "Pizza Fritta", Price = 5.00m},
            new Product { NameProduct = "Piadina vegetariana" , Price = 6.00m},
            new Product { NameProduct = "Panino Hamburger", Price = 7.90m}
        };
        List<Product> CartProduct = new List<Product> {};

        public void Allproduct()
        {
            Console.WriteLine("============== MENU ==============");
            int i = 0;
            foreach (Product product in menuProduct)
            {

                Console.WriteLine($"{i + 1}: {product.NameProduct} (€ {product.Price})");
                i++;
            }
            Console.WriteLine($"{i + 1}: Stampa conto finale e conferma");
            Choiceproduct();
            Console.WriteLine("============== MENU ==============");
        }

        public void Choiceproduct()
        {
            while (true)
            {
            Console.Write("Seleziona un opzione: ");
                int choice;
                bool isValidInput = int.TryParse(Console.ReadLine(), out choice);
                if (isValidInput && choice > 0 && choice <= menuProduct.Count)
                {
                    AddToCart(menuProduct[choice - 1]);
                }
                else if (isValidInput && choice == menuProduct.Count + 1)
                {

                    Bill();
                    break;
                }
                else
                {
                    Console.WriteLine("Scelta non valida. Riprova.");
                }
            }
         }

     public void AddToCart(Product product)
        {
            CartProduct.Add(product);
            Console.WriteLine($"{product.NameProduct} aggiunto alla lista");
        }
        public decimal TotalProductPrice() {
            
            foreach (Product product in CartProduct) { 
                total += product.Price; 
            }
            return total + 3.00m;
        }

        public void Bill()
        {
            int y = 0;
                Console.WriteLine("========================= SCONTRINO ======================================");
            foreach (Product product in CartProduct)
            {
                Console.WriteLine($"{y + 1}: {product.NameProduct} (€ {product.Price})");
                y++;
            }
            decimal finalTotal = TotalProductPrice();
            Console.WriteLine();
            Console.WriteLine($"Il totale finale è: € {finalTotal}");

        }

    }
}
