﻿namespace Gachishop.Controllers;

public class AdminController
{
    private IAdminControllerDataParser _dataParser;
    private IAdminService _service;

    public AdminController(IAdminService service, IAdminControllerDataParser dataParser)
    {
        _dataParser = dataParser;
        _service = service;
    }
    
    public void Start()
    {
        bool done = false;
        int enteredNumber;
        while (!done)
        {
            Console.WriteLine("Введите номер команды: \n" +
                              "(1)Добавить товар \n" +
                              "(2)Добавить категорию \n" +
                              "(3)Выйти");
            enteredNumber = CustomInput.ReadNumber();

            switch (enteredNumber)
            {
                case(1):
                    Console.Clear();
                    AddProduct();
                    Console.WriteLine("Нажмите любую клавишу");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(2):
                    Console.Clear();
                    AddCategory();
                    Console.WriteLine("Нажмите любую клавишу");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(3):
                    done = true;
                    break;
                default:
                    Console.WriteLine("Нет команды с данной цифрой");
                    break;
            }
        }
        Console.Clear();
        
    }

    private void AddProduct()
    {
        string name = _dataParser.GetProductName();
        string description = _dataParser.GetProductDescription();
        string category = _dataParser.GetProductCategory();
        int price = _dataParser.GetProductPrice();
        int quantity = _dataParser.GetProductQuantity();
        int discount = _dataParser.GetProductDiscount();

        _service.AddProduct(name, description, category, price, quantity, discount);

        Console.WriteLine("Товар добавлен");
    }

    private void AddCategory()
    {
        string categoryName = _dataParser.GetProductCategoryName();
        ProductCategory productCategory = new ProductCategory(categoryName);
        
        _service.AddProductCategory(productCategory);
        Console.WriteLine("Категория добавлена");
    }
}