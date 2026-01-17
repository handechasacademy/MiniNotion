using System;
using MiniNotion.Core.Services;

namespace MiniNotion.ConsoleApp
{
    public class ConsoleMenu
    {
        private readonly PageService _pageService;
        public ConsoleMenu(PageService pageService) 
        {
            _pageService= pageService;
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                ShowMainMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreatePageFlow();
                        Console.WriteLine("Create page selected");
                        break;
                    case "2":
                        ListPagesFlow();
                        Console.WriteLine("View pages selected");
                        break;
                    case "3":
                        EditPageFlow();
                        Console.WriteLine("Edit page selected");
                        break;
                    case "4":
                        DeletePageFlow();
                        Console.WriteLine("Delete page selected");
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void ShowMainMenu()
        {
            Console.WriteLine("=== MiniNotion Console Application ===");
            Console.WriteLine("1. Create a new page");
            Console.WriteLine("2. View all pages");
            Console.WriteLine("3. Edit a page");
            Console.WriteLine("4. Delete a page");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
        }

        private void CreatePageFlow()
        {
            Console.Write("Enter page title: ");
            string title = Console.ReadLine();
            try 
           {
               _pageService.CreatePage(title);
               Console.WriteLine("Page created successfully.");
           }
           catch (Exception ex)
           {
               Console.WriteLine($"Error creating page: {ex.Message}");
            }

        }

        private void ListPagesFlow()
        {
            try
            {
                var pages = _pageService.GetAllPages();
                Console.WriteLine("Pages:");
                foreach (var page in pages)
                {
                    Console.WriteLine($"ID: {page.Id}, Title: {page.Title}, Created At: {page.CreatedAt}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving pages: {ex.Message}");

            }            
        }

        private void EditPageFlow()
        {
            Console.Write("Enter page id to edit:");
            string idInputStr = Console.ReadLine();
            if (!int.TryParse(idInputStr, out int idInput))
            {
                Console.WriteLine("Invalid page id.");
                return;
            }
            Console.Write("Enter new page title: ");
            string newTitle = Console.ReadLine();
            try
            {
                _pageService.EditPage(idInput, newTitle);
                Console.WriteLine("Page edited successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error editing page: {ex.Message}");
            }
        }

        private void DeletePageFlow()
        {
            Console.WriteLine("Enter page id to delete:");
            string idInputString = Console.ReadLine();
            if (!int.TryParse(idInputString, out int idInput))
            {
                Console.WriteLine("Invalid page id.");
                return;
            }
            try
            {
                _pageService.DeletePage(idInput);
                Console.WriteLine("Page deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting page: {ex.Message}");
            }
        }
    }
}