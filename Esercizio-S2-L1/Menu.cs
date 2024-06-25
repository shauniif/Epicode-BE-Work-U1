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
            new Product { Id= 1,  NameProduct = "Coca Cola 150 ml", Price = 2.50m},
            new Product { Id= 2, NameProduct = "Insalata di pollo", Price = 5.20m},
            new Product { Id= 3, NameProduct = "Pizza Margherita", Price = 10.00m},
            new Product { Id= 4, NameProduct = "Pizza 4 formaggi", Price = 12.50m},
            new Product { Id= 5, NameProduct = "Pizza Patatine Fritte", Price = 3.50m },
            new Product { Id= 6, NameProduct = "Insalata di riso", Price = 8.00m},
            new Product { Id= 7, NameProduct = "Frutta di stagione", Price = 5.00m},
            new Product { Id= 8, NameProduct = "Pizza Fritta", Price = 5.00m},
            new Product { Id= 9, NameProduct = "Piadina vegetariana" , Price = 6.00m},
            new Product { Id= 10, NameProduct = "Panino Hamburger", Price = 7.90m}
        };
        List<Product> CartProduct = new List<Product> {};

        public void Allproduct()
        {
            Console.WriteLine("============== MENU ==============");
            foreach (Product product in menuProduct)
            {
                Console.WriteLine($"{product.Id}: {product.NameProduct} (€ {product.Price})");
            }
            Console.WriteLine($"11: Stampa conto finale e conferma");
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
            
                Console.WriteLine("========================= SCONTRINO ======================================");
            foreach (Product product in CartProduct)
            {
                Console.WriteLine($"{product.NameProduct} (€ {product.Price})");
            }
            decimal finalTotal = TotalProductPrice();
            Console.WriteLine();
            Console.WriteLine($"Il totale finale è: € {finalTotal}");

        }

    }
}
