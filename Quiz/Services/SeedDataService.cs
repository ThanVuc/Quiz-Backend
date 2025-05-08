using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz.Data;

namespace Quiz.Services
{
    public class SeedDataService
    {
        private readonly AppDbContext _context;
        public SeedDataService(AppDbContext context)
        {
            _context = context;
        }
        public async Task SeedQuizData()
        {
            if (!_context.Quizzes.Any())
            {
                var quizData = new List<Quiz.Models.Quiz>
                {
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the capital of France?",
                        FeedBack = "The capital of France is Paris.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Paris", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "London", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Berlin", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Madrid", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is 2 + 2?",
                        FeedBack = "2 + 2 equals 4.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "3", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "4", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "5", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "6", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the largest planet in our solar system?",
                        FeedBack = "The largest planet in our solar system is Jupiter.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Earth", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Mars", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Jupiter", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Saturn", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the chemical symbol for water?",
                        FeedBack = "The chemical symbol for water is H2O.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "H2O", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "O2", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "CO2", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "HO", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "Who wrote 'Romeo and Juliet'?",
                        FeedBack = "William Shakespeare wrote 'Romeo and Juliet'.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Charles Dickens", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "William Shakespeare", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Mark Twain", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Jane Austen", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the speed of light?",
                        FeedBack = "The speed of light is approximately 299,792 kilometers per second.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "150,000 km/s", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "299,792 km/s", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "500,000 km/s", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "1,000,000 km/s", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the smallest prime number?",
                        FeedBack = "The smallest prime number is 2.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "1", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "2", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "3", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "5", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the largest mammal?",
                        FeedBack = "The largest mammal is the blue whale.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Elephant", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Blue Whale", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Giraffe", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Hippopotamus", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the hardest natural substance on Earth?",
                        FeedBack = "The hardest natural substance on Earth is diamond.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Gold", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Diamond", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Iron", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Quartz", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the main ingredient in guacamole?",
                        FeedBack = "The main ingredient in guacamole is avocado.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Tomato", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Avocado", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Onion", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Pepper", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the largest ocean on Earth?",
                        FeedBack = "The largest ocean on Earth is the Pacific Ocean.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Atlantic Ocean", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Indian Ocean", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Pacific Ocean", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Arctic Ocean", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the boiling point of water?",
                        FeedBack = "The boiling point of water is 100 degrees Celsius.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "0 degrees Celsius", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "50 degrees Celsius", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "100 degrees Celsius", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "150 degrees Celsius", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the largest continent?",
                        FeedBack = "The largest continent is Asia.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Africa", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Asia", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "North America", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "South America", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the main gas found in the air we breathe?",
                        FeedBack = "The main gas found in the air we breathe is nitrogen.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Oxygen", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Nitrogen", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Carbon Dioxide", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Hydrogen", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the largest desert in the world?",
                        FeedBack = "The largest desert in the world is the Antarctic Desert.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Sahara Desert", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Arabian Desert", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Gobi Desert", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Antarctic Desert", IsCorrect = true }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the largest organ in the human body?",
                        FeedBack = "The largest organ in the human body is the skin.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Heart", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Liver", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Skin", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Lungs", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the hardest natural substance on Earth?",
                        FeedBack = "The hardest natural substance on Earth is diamond.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Gold", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Diamond", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Iron", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Quartz", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the main ingredient in sushi?",
                        FeedBack = "The main ingredient in sushi is rice.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Rice", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Noodles", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Bread", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Potatoes", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the largest animal on Earth?",
                        FeedBack = "The largest animal on Earth is the blue whale.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Elephant", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Blue Whale", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Giraffe", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Hippopotamus", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the main ingredient in hummus?",
                        FeedBack = "The main ingredient in hummus is chickpeas.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Chickpeas", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Lentils", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Beans", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Peas", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the largest volcano in the world?",
                        FeedBack = "The largest volcano in the world is Mauna Loa.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Mount Everest", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Kilimanjaro", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Mauna Loa", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Mount Fuji", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the main ingredient in pesto?",
                        FeedBack = "The main ingredient in pesto is basil.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Basil", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Parsley", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Cilantro", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Mint", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the main ingredient in chocolate?",
                        FeedBack = "The main ingredient in chocolate is cocoa.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Cocoa", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Sugar", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Milk", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Vanilla", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the main ingredient in bread?",
                        FeedBack = "The main ingredient in bread is flour.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Flour", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Sugar", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Salt", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Water", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the main ingredient in mayonnaise?",
                        FeedBack = "The main ingredient in mayonnaise is egg yolk.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Egg Yolk", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Mustard", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Vinegar", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Oil", IsCorrect = false }
                        }
                    },
                    new Quiz.Models.Quiz
                    {
                        Content = "What is the main ingredient in ketchup?",
                        FeedBack = "The main ingredient in ketchup is tomatoes.",
                        Answers = new List<Quiz.Models.Answer>
                        {
                            new Quiz.Models.Answer { Content = "Tomatoes", IsCorrect = true },
                            new Quiz.Models.Answer { Content = "Peppers", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Onions", IsCorrect = false },
                            new Quiz.Models.Answer { Content = "Garlic", IsCorrect = false }
                        }
                    },
                };

                await _context.Quizzes.AddRangeAsync(quizData);
                await _context.SaveChangesAsync();
            }
        }
    }
}