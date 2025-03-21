using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using Xunit;

 namespace SaleManagementTest.UI
 {
     public class UserInterfaceTests : IDisposable
     {
         private const string AppPath = @"D:\window_app\WpfApp1\SalesManagementApp.exe";

         private readonly WindowsDriver<WindowsElement> _session;

         public UserInterfaceTests()
         {
             var options = new AppiumOptions();
             options.AddAdditionalCapability("app", AppPath);
             options.AddAdditionalCapability("platformName", "Windows");

             _session = new WindowsDriver<WindowsElement>(new Uri("http: 127.0.0.1:4723"), options);
         }

         public void UserManagementPage_ShouldBeDisplayed()
         {
             var title = _session.FindElementByAccessibilityId("UserManagementTitle");
             Assert.NotNull(title);
         }

         public void LoadUsersButton_ShouldLoadData()
         {
             var loadButton = _session.FindElementByAccessibilityId("LoadUsersButton");
             loadButton.Click();

             var dataGrid = _session.FindElementByAccessibilityId("UsersDataGrid");
             Assert.NotNull(dataGrid);
        }

        public void Dispose() => _session.Quit();
     }
 }
