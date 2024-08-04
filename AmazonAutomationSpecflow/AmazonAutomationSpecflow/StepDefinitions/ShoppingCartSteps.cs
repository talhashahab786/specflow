using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

namespace AmazonTests
{

    [Binding]
    public class ShoppingCartSteps
    {
        private AmazonPage amazonPage;
        private ShoppingCartPage shoppingCartPage;
        public string searchedItem = "TP-Link N450 WiFi Router - Wireless Internet Router for Home (TL-WR940N)";

        [Given(@"I am an unregistered user on Amazon website")]
        public void GivenIAmAnUnregisteredUserOnAmazonWebsite()
        {
            amazonPage = new AmazonPage();
            amazonPage.NavigateToAmazon();
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string itemName)
        {
            amazonPage.SearchForItem(itemName);
        }

        [When(@"I add the corresponding item to the cart")]
        public void WhenIAddTheCorrespondingItemToTheCart()
        {
            amazonPage.AddItemToCart(searchedItem);
        }

        [When(@"I navigate to the cart")]
        public void WhenINavigateToTheCart()
        {
            shoppingCartPage.NavigateToCart();
        }

        [Then(@"I should see the correct item and amount displayed in the cart")]
        public void ThenIShouldSeeTheCorrectItemAndAmountDisplayedInTheCart()
        {
            List<String> cartItemName = shoppingCartPage.GetCartItemNames();
            List<String> cartItemPrice = shoppingCartPage.GetCartItemPrices();
            decimal cartItemZeroPrice = decimal.Parse(cartItemPrice[0]);

           // Assert.That(ShoppingCartSteps, cartItemName, "Incorrect item name in the cart");
            Assert.That(cartItemZeroPrice > 0, "Invalid item price in the cart");
        }
    }


       public class AmazonPage
        {
            private IWebDriver driver;

            public AmazonPage()
            {
            new DriverManager().SetUpDriver(new ChromeConfig());

            // Initialize ChromeDriver
             driver = new ChromeDriver();

            // Example usage: navigate to a webpage
           // driver.Navigate().GoToUrl("https://example.com");

            // Close the browser
           // driver.Quit();
        }

            // Method to navigate to Amazon website
            public void NavigateToAmazon()
            {
            //  driver.Navigate().GoToUrl("https://www.amazon.com/");
            driver.Navigate().GoToUrl("https://www.amazon.com/dp/B096N2MV3H?th=1");
            // driver.Navigate().GoToUrl("https://www.amazon.com/dp/B096N2MV3H?th=1");
            driver.Navigate().GoToUrl("https://www.amazon.com/dp/B096N2MV3H?th=1");
            driver.Navigate().Refresh();
            driver.Manage().Window.Maximize();

        }

        // Method to search for a product on Amazon
        public void SearchForItem(string productName)
            {
            try
            {
                IWebElement captchaBox = driver.FindElement(By.Id("captchacharacters"));
                if (captchaBox != null)
                {
                    if (captchaBox.Displayed && captchaBox.Enabled)
                    {
                        Assert.AreEqual(true, false, "[FAILED] Captcha box was shown, Automation tests cannot proceed on this website with unregistered user.");
                    }
                }
            }
            catch (Exception ex){
            Console.WriteLine("Captcha was not found so the test can proceed.");
            IWebElement searchBox = driver.FindElement(By.Id("twotabsearchtextbox"));
            searchBox.SendKeys(productName);
                searchBox.SendKeys(Keys.Enter);
            }
        }

        // Method to add a product to the cart
        public void AddItemToCart(string productTitle)
            {
            // Click on the product
            //  IWebElement productLink = driver.FindElement(By.PartialLinkText(productTitle));
            //  productLink.Click();
            
        //    ReadOnlyCollection<IWebElement> addToCartButton = driver.FindElements(By.LinkText("Add to cart"));
            //addToCartButton.

           
         //   IList<IWebElement> selectElements = driver.FindElements(By.TagName("select"));
         //   var displayedSelectElements = selectElements.get;
         //   var element = driver.FindElement(By.Id("a-autoid-1-announce"));
         //   Actions actions = new Actions(driver);
         //   actions.MoveToElement(element);
          //   actions.Perform(); 
          //  driver.FindElement(By.Id("a-autoid-2-announce")).Click();


          //   element = driver.FindElement(By.Id("a-autoid-2-announce"));
       //      actions = new Actions(driver);
         //   actions.MoveToElement(element);
         //   actions.Perform();
            driver.FindElement(By.Id("a-autoid-3-announce")).Click();
            // id = "a-autoid-3-announce"
            // Click on the "Add to Cart" button
            //  IWebElement addToCartButton = driver.FindElement(By.Id("add-to-cart-button"));
            //     addToCartButton.Click();

      //      var element = driver.FindElement(By.XPath("//*[@id=\"nav-cart-count-container\"]/span[2]"));
      //       Actions actions = new Actions(driver);
       //      actions.MoveToElement(element);
        //     actions.Perform();
         //    driver.FindElement(By.XPath("//*[@id=\"nav-cart-count-container\"]/span[2]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("Go to Cart")).Click();
            IWebElement productLink = driver.FindElement(By.PartialLinkText("TP-Link"));
                                                                   //*[@id="sc-active-f6f5759a-c5f7-48d3-89af-76dc36c5c8b5"]/div[4]/div/div[2]/ul/li/span/a/span[1]/span/span[2]
            IWebElement productLink2 = driver.FindElement(By.PartialLinkText("$"));
            String x = "TP-Link";
            if (productLink.Text.Contains(x)){
                Assert.AreEqual(true, true, "[FAILED] Doesn't contain text 'TP-LINK', text: "+productLink.Text);
                Console.WriteLine("[PASSED] Contain text 'TP-LINK', text: "+productLink.Text);
            }
            else
            {
                Console.WriteLine("");
                Assert.AreEqual(true, false, "[FAILED] Doesn't contain text 'TP-LINK', text: "+productLink.Text);
            }
            if (productLink2.Text.Contains("$")){
                Assert.AreEqual(true, true, "[FAILED] Doesn't contain $ sign, text: "+productLink2.Text);
                Console.WriteLine("[PASSED] Contain $ sign, text: "+productLink2.Text);
            }
            else
            {
                Console.WriteLine("");
                Assert.AreEqual(true, false, "[FAILED] Doesn't contain $ sign, text: " + productLink2.Text);
            }
            //*[@id="sc-active-252e5ed1-69fe-4040-a85a-7563615ca171"]/div[4]/div/div[2]/ul/li/span/a/span[1]/span/span[2]
            //*[@id="sc-active-252e5ed1-69fe-4040-a85a-7563615ca171"]/div[4]/div/div[2]/ul/div[1]/div[1]/div/div/span

            //            driver.FindElement(By.LinkText("Go to Cart")).Click();
        }

        // Method to close the browser
        public void CloseBrowser()
            {
                driver.Quit();
            }
        }

        public class ShoppingCartPage
        {
            private IWebDriver driver;

            public ShoppingCartPage(IWebDriver driver)
            {
                this.driver = driver;
            }

            // Method to navigate to the shopping cart
            public void NavigateToCart()
            {
                IWebElement cartIcon = driver.FindElement(By.Id("nav-cart-count"));
                cartIcon.Click();
            }


        // Method to get names of items in the shopping cart
        public List<string> GetCartItemNames()
        {
            // Navigate to the shopping cart
            NavigateToCart();

            // Initialize a list to store item names
            List<string> itemNames = new List<string>();

            // Get list of items in the cart
            IReadOnlyCollection<IWebElement> itemRows = driver.FindElements(By.CssSelector(".a-spacing-mini.sc-list-item"));

            // Iterate through each item row and extract name
            foreach (IWebElement itemRow in itemRows)
            {
                // Get item name
                IWebElement itemNameElement = itemRow.FindElement(By.CssSelector(".a-text-left.sc-product-link"));
                string itemName = itemNameElement.Text;

                // Add item name to the list
                itemNames.Add(itemName);
            }

            return itemNames;
        }

        // Method to get prices of items in the shopping cart
        public List<string> GetCartItemPrices()
        {
            // Navigate to the shopping cart
            NavigateToCart();

            // Initialize a list to store item prices
            List<string> itemPrices = new List<string>();

            // Get list of items in the cart
            IReadOnlyCollection<IWebElement> itemRows = driver.FindElements(By.CssSelector(".a-spacing-mini.sc-list-item"));

            // Iterate through each item row and extract price
            foreach (IWebElement itemRow in itemRows)
            {
                // Get item price
                IWebElement itemPriceElement = itemRow.FindElement(By.CssSelector(".a-color-price"));
                string itemPrice = itemPriceElement.Text;

                // Add item price to the list
                itemPrices.Add(itemPrice);
            }

            return itemPrices;
        }
        
        // Method to get the total price of items in the shopping cart
        public double GetTotalPrice()
            {
                IWebElement totalPriceElement = driver.FindElement(By.CssSelector("[data-name='Subtotals'] .a-color-price"));
                string totalPriceText = totalPriceElement.Text;
                // Parse the total price string into a double
                double totalPrice = double.Parse(totalPriceText.Replace("$", ""));
                return totalPrice;
            }
        }
    }


/*
 * 
      
        [Test]
        public void TheUntitledTestCaseTest()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com/");
            driver.FindElement(By.Id("captchacharacters")).Click();
            driver.FindElement(By.Id("captchacharacters")).Clear();
            driver.FindElement(By.Id("captchacharacters")).SendKeys("xbulfj");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.Id("twotabsearchtextbox")).Click();
            driver.FindElement(By.Id("twotabsearchtextbox")).Clear();
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("TP-Link N450 WiFi Router - Wireless Internet Router for Home (TL-WR940N)");
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            driver.FindElement(By.Id("a-autoid-2-announce")).Click();
            driver.FindElement(By.Id("a-autoid-4-announce")).Click();
            driver.FindElement(By.LinkText("Go to Cart")).Click();
            driver.FindElement(By.XPath("//div[@id='sc-active-9bd18247-ab42-4656-a9c8-dc748b131746']/div[4]/div/div[2]/ul/li/span/a/span/span/span[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_1 | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_local | ]]
            driver.FindElement(By.XPath("//div[@id='sc-active-9bd18247-ab42-4656-a9c8-dc748b131746']/div[4]/div/div[2]/ul/li/span/a/span/span/span[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_2 | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_local | ]]
            driver.FindElement(By.XPath("//div[@id='sc-active-9bd18247-ab42-4656-a9c8-dc748b131746']/div[4]/div/div[2]/ul/li/span/a/span/span/span[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_3 | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_local | ]]
            driver.FindElement(By.XPath("//div[@id='sc-active-9bd18247-ab42-4656-a9c8-dc748b131746']/div[4]/div/div[2]/ul/div/div/div/div/span")).Click();
            driver.FindElement(By.XPath("//div[@id='sc-active-265468e9-3d7a-40c7-9230-ec5439d4453b']/div[4]/div/div[2]/ul/li/span/a/span/span/span[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_4 | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_local | ]]
            driver.FindElement(By.XPath("//div[@id='sc-active-265468e9-3d7a-40c7-9230-ec5439d4453b']/div[4]/div/div[2]/ul/div/div/div/div/span")).Click();
            driver.FindElement(By.XPath("//span[@id='sc-subtotal-amount-activecart']/span")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
 */