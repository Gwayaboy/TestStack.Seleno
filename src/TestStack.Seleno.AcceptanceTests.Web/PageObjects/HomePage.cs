﻿using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace TestStack.Seleno.AcceptanceTests.Web.PageObjects
{
    public class HomePage : Page
    {
        public Form1Page GoToReadModelPage()
        {
            return Navigate().To<Form1Page>(By.LinkText("Fixture A values"));
        }

        public Form1Page GoToWriteModelPage()
        {
            return Navigate().To<Form1Page>(By.LinkText("Empty form, but expecting Fixture A upon submit"));
        }
    }
}