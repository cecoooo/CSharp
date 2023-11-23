using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //1
            //string input1 = File.ReadAllText("../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(context, input1));

            //2
            //string input2 = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(context, input2));

            //3
            //string input3 = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(context, input3));

            //4
            //string input4 = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(context, input4));

            //5
            //Console.WriteLine(GetProductsInRange(context));

            //6
            //Console.WriteLine(GetSoldProducts(context));

            //7
            //Console.WriteLine(GetCategoriesByProductsCount(context));

            //8
            Console.WriteLine(GetUsersWithProducts(context));
        }

        //1
        public static string ImportUsers(ProductShopContext context, string inputJson) 
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        //2
        public static string ImportProducts(ProductShopContext context, string inputJson) 
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //3
        public static string ImportCategories(ProductShopContext context, string inputJson) 
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson).Where(x => x.Name is not null).ToArray();
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        //4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson) 
        {
            var categories_products = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            context.CategoriesProducts.AddRange(categories_products);
            context.SaveChanges();

            return $"Successfully imported {categories_products.Length}";
        }

        //5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000 && x.Buyer.ProductsSold.Any(x => x.BuyerId != null))
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .OrderBy(x => x.price)
                .ToArray();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            return json;
        }

        //6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count >= 1)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                    .Where(x => x.BuyerId != null)
                    .Select(x => new
                    {
                        name = x.Name,
                        price = x.Price,
                        buyerFirstName = x.Buyer.FirstName,
                        buyerLastName = x.Buyer.LastName
                    })
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        //7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoriesProducts.Count,
                    averagePrice = $"{x.CategoriesProducts.Sum(x => x.Product.Price) / x.CategoriesProducts.Count:f2}",
                    totalRevenue = $"{x.CategoriesProducts.Sum(x => x.Product.Price):f2}"
                })
                .OrderByDescending(x => x.productsCount);

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        //8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersProducts = context.Users
                .Where(x => x.ProductsSold.Any(x => x.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = x.ProductsSold
                    .Where(x => x.BuyerId != null)
                    .Select(x => new
                    {
                        name = x.Name,
                        price = x.Price
                    })
                    .ToArray()
                })
                .OrderByDescending(x => x.soldProducts.Count())
                .ToArray();

            var obj = new
            {
                usersCount = usersProducts.Length,
                users = usersProducts
                .Select(x => new
                {
                    x.firstName,
                    x.lastName,
                    x.age,
                    soldProducts = new
                    {
                        count = x.soldProducts.Length,
                        products = x.soldProducts
                    }
                })
            };

            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}