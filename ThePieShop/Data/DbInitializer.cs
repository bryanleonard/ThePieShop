using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThePieShop.Models;

namespace ThePieShop.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Pies.Any())
            {
                context.AddRange
                (
                    new Pie
                    {
                        Name = "Apple Pie",
                        Price = 12.95M,
                        ShortDescription = "Our famous apple pies!",
                        LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                        Category = Categories["Fruit pies"],
                        ImageUrl = "/images/pies/applepie.jpg",
                        InStock = true,
                        IsPieOfTheWeek = true,
                        ImageThumbnailUrl = "/images/pies/apple.jpg",
                        AllergyInformation = ""
                    },
                    new Pie
                    {
                        Name = "Blueberry Cheese Cake",
                        Price = 18.95M,
                        ShortDescription = "You'll love it!",
                        LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                        Category = Categories["Cheese cakes"],
                        ImageUrl = "/images/pies/blueberry-cheesecake.jpg",
                        InStock = true,
                        IsPieOfTheWeek = false,
                        ImageThumbnailUrl = "/images/pies/blueberry-cheesecake.jpg",
                        AllergyInformation = ""
                    },
                    new Pie
                    {
                        Name = "Cheese Cake",
                        Price = 18.95M,
                        ShortDescription = "Plain cheese cake. Plain pleasure.",
                        LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                        Category = Categories["Cheese cakes"],
                        ImageUrl = "/images/pies/cheesecake.jpg",
                        InStock = true,
                        IsPieOfTheWeek = false,
                        ImageThumbnailUrl = "/images/pies/cheesecake.jpg",
                        AllergyInformation = ""
                    },
                    new Pie
                    {
                        Name = "Cherry Pie",
                        Price = 15.95M,
                        ShortDescription = "A summer classic!",
                        LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                        Category = Categories["Fruit pies"],
                        ImageUrl = "/images/pies/cherry.jpg",
                        InStock = true,
                        IsPieOfTheWeek = false,
                        ImageThumbnailUrl = "/images/pies/cherry.jpg",
                        AllergyInformation = ""
                    },
                    new Pie
                    {
                        Name = "Christmas Apple Pie",
                        Price = 13.95M,
                        ShortDescription = "Happy holidays with this pie!",
                        LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                        Category = Categories["Seasonal pies"],
                        ImageUrl = "/images/pies/xmas-apple.jpg",
                        InStock = true,
                        IsPieOfTheWeek = false,
                        ImageThumbnailUrl = "/images/pies/xmas-apple.jpg",
                        AllergyInformation = ""
                    },
                    new Pie
                    {
                        Name = "Cranberry Pie",
                        Price = 17.95M,
                        ShortDescription = "A Christmas favorite",
                        LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                        Category = Categories["Seasonal pies"],
                        ImageUrl = "/images/pies/cranberry.jpg",
                        InStock = true,
                        IsPieOfTheWeek = false,
                        ImageThumbnailUrl = "/images/pies/cranberry.jpg",
                        AllergyInformation = ""
                    },
                    new Pie
                    {
                        Name = "Peach Pie",
                        Price = 15.95M,
                        ShortDescription = "Sweet as peach",
                        LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                        Category = Categories["Fruit pies"],
                        ImageUrl = "/images/pies/peach.jpg",
                        InStock = false,
                        IsPieOfTheWeek = false,
                        ImageThumbnailUrl = "/images/pies/peach.jpg",
                        AllergyInformation = ""
                    },
                    new Pie
                    {
                        Name = "Pumpkin Pie",
                        Price = 12.95M,
                        ShortDescription = "Our Halloween favorite",
                        LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                        Category = Categories["Seasonal pies"],
                        ImageUrl = "/images/pies/pumpkin.jpg",
                        InStock = true,
                        IsPieOfTheWeek = false,
                        ImageThumbnailUrl = "/images/pies/pumpkin.jpg",
                        AllergyInformation = ""
                    },
                    new Pie
                    {
                        Name = "Rhubarb Pie",
                        Price = 15.95M,
                        ShortDescription = "My God, so sweet!",
                        LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                        Category = Categories["Fruit pies"],
                        ImageUrl = "/images/pies/rhubarb.jpg",
                        InStock = true,
                        IsPieOfTheWeek = true,
                        ImageThumbnailUrl = "/images/pies/rhubarb.jpg",
                        AllergyInformation = ""
                    },
                    new Pie
                    {
                        Name = "Strawberry Pie",
                        Price = 15.95M,
                        ShortDescription = "Our delicious strawberry pie!",
                        LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                        Category = Categories["Fruit pies"],
                        ImageUrl = "/images/pies/strawberry.jpg",
                        InStock = true,
                        IsPieOfTheWeek = false,
                        ImageThumbnailUrl = "/images/pies/strawberry.jpg",
                        AllergyInformation = ""
                    },
                    new Pie
                    {
                        Name = "Chicken Pie",
                        Price = 99.95M,
                        ShortDescription = "Our delicious chicken pie!",
                        LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                        Category = Categories["Joke pies"],
                        ImageUrl = "/images/pies/chicken.jpg",
                        InStock = true,
                        IsPieOfTheWeek = false,
                        ImageThumbnailUrl = "/images/pies/chicken.jpg",
                        AllergyInformation = ""
                    },
                    new Pie
                    {
                        Name = "Strawberry Cheese Cake",
                        Price = 18.95M,
                        ShortDescription = "You'll love it!",
                        LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                        Category = Categories["Cheese cakes"],
                        ImageUrl = "/images/pies/strawberry-cheesecake.jpg",
                        InStock = false,
                        IsPieOfTheWeek = false,
                        ImageThumbnailUrl = "/images/pies/strawberry-cheesecake.jpg",
                        AllergyInformation = ""
                    },
                    new Pie
                    {
                        Name = "Joke Pie",
                        Price = 28.95M,
                        ShortDescription = "What are you doing?",
                        LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                        Category = Categories["Joke pies"],
                        ImageUrl = "/images/pies/joke.jpg",
                        InStock = true,
                        IsPieOfTheWeek = true,
                        ImageThumbnailUrl = "/images/pies/joke.jpg",
                        AllergyInformation = ""
                    }
                );
            }

            context.SaveChanges();
        }



        private static Dictionary<string, Category> _categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Joke pies", Description="You\'re kidding me, right?" },
                        new Category { CategoryName = "Fruit pies", Description="All-fruity pies" },
                        new Category { CategoryName = "Cheese cakes", Description="Cheesy all the way" },
                        new Category { CategoryName = "Seasonal pies", Description="Get in the mood for a seasonal pie" },
                        new Category { CategoryName = "Party cakepies", Description = "When you wanna get funky and need something loosen up the crowd" }
                    };

                    _categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        _categories.Add(genre.CategoryName, genre);
                    }
                }

                return _categories;
            }
        }
    }
}
