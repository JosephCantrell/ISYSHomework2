using System.Windows.Forms;
using System;
using System.IO;
using static System.Console;
using System.Linq;

namespace ISYSHomework2
{
    
    static class GraphicalFoodMenu
    {
        static FoodObject[] foodObjects;
        static SplashScreen splashScreen;
        static Cashier cashierScreen;
        private static string username = "";
        private static int numOfItems = 6;

        private static byte saladCount = 0;
        private static byte drinkCount = 0;
        private static byte dessertCount = 0;

       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            splashScreen = new SplashScreen();
            Application.Run(splashScreen);
        }

        public static void BtnExit_MouseUp()
        {
            Application.Exit();
        }

        public static void ChangeScreen(string name)
        {
            //splashScreen.Hide();
            username = name;
            CreateSecondScreen();
        }

        public static void RadioButtonCheckedChanged()
        {
            System.Windows.Forms.GroupBox[] tempGroupBox = cashierScreen.GetGroupBoxes();
            for(int i = 0; i < 3; i++)
            {
                foreach(RadioButton r in tempGroupBox[i].Controls.OfType<RadioButton>())
                {
                    if (r.Checked)
                    {
                        string text = r.Text;
                        // Set the selection label equal to this text as well
                        foreach(TextBox t in tempGroupBox[i].Controls.OfType<TextBox>())
                        {
                            if(!t.Enabled)                                              // Only the price textbox is disabled
                            {
                                t.Text = String.Format("{0:C2}", GetPrice(text));
                                foreach(Label l in tempGroupBox[i].Controls.OfType<Label>())
                                {
                                    string tempName = "lblSelection" + i;
                                    //System.Diagnostics.Debug.Print(tempName);
                                    //System.Diagnostics.Debug.Print(l.Name);
                                    if (l.Name.Equals(tempName))
                                    {
                                        switch (i)
                                        {
                                            case 0:                         // Salads
                                                l.Text = "Salad Selection: " + r.Text;
                                                break;
                                            case 1:                         // Salads
                                                l.Text = "Drink Selection: " + r.Text;
                                                break;
                                            case 2:                         // Salads
                                                l.Text = "Dessert Selection: " + r.Text;
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void ClearAllSelections()
        {
            System.Windows.Forms.GroupBox[] tempGroupBox = cashierScreen.GetGroupBoxes();
            for(int i = 0; i < 3; i++)
            {
                foreach(RadioButton r in tempGroupBox[i].Controls.OfType<RadioButton>())
                {
                    r.Checked = false;
                }
                foreach(TextBox t in tempGroupBox[i].Controls.OfType<TextBox>())
                {
                    t.Text = "";
                }
                foreach(Label l in tempGroupBox[i].Controls.OfType<Label>())
                {
                    string tempName = "lblSelection" + i;
                    if (l.Name.Equals(tempName))
                    {
                        l.Text = "";
                    }
                }
            }
            cashierScreen.SetFinalText("");
        }

        public static void Calculate()
        {
            System.Windows.Forms.GroupBox[] tempGroupBox = cashierScreen.GetGroupBoxes();
            byte saladQuantity = 0;
            double saladCost = 0;
            byte drinkQuantity = 0;
            double drinkCost = 0;
            byte dessertQuantity = 0;
            double dessertCost = 0;
            for (int i = 0; i < 3; i++)
            {
                foreach(RadioButton r in tempGroupBox[i].Controls.OfType<RadioButton>())                    // Getting the cost of the item through the radioButton (Less Converting)
                {
                    if (r.Checked)
                    {
                        switch (i)
                        {
                            case 0:
                                saladCost = GetPrice(r.Text);
                                break;
                            case 1:
                                drinkCost = GetPrice(r.Text);
                                break;
                            case 2:
                                dessertCost = GetPrice(r.Text);
                                break;
                        }
                    }
                }
                foreach(TextBox t in tempGroupBox[i].Controls.OfType<TextBox>())                            // Getting the quantity of items through the textBox
                {
                    string tempName = "TxtBoxQuantity" + i;
                    if (t.Name.Equals(tempName))
                    {
                        switch (i)
                        {
                            case 0:
                                if(!t.Text.Equals(""))
                                    saladQuantity = Byte.Parse(t.Text);
                                break;
                            case 1:
                                if (!t.Text.Equals(""))
                                    drinkQuantity = Byte.Parse(t.Text);
                                break;
                            case 2:
                                if (!t.Text.Equals(""))
                                    dessertQuantity = Byte.Parse(t.Text);
                                break;
                        }
                    }
                }



            }
            if (saladCost.Equals(0))
                saladQuantity = 0;
            if (drinkCost.Equals(0))
                drinkQuantity = 0;
            if (dessertCost.Equals(0))
                dessertQuantity = 0;

            string finalResult = "";

            if (dessertQuantity.Equals(0) && saladQuantity.Equals(0) && drinkQuantity.Equals(0))
                finalResult = String.Format("You did not purchase anything\n\n\nCome again soon {0}", username);
            else
            {
                double total = (saladQuantity * saladCost) + (drinkQuantity * drinkCost) + (dessertQuantity * dessertCost);
                int itemsSold = saladQuantity + drinkQuantity + dessertQuantity;
                //WriteLine("Total: {0:C2}", total);
                finalResult = String.Format("Your total is {0:C2}\nYou purchased {1} item(s)\n\nThank you for your purchase {2}", total, itemsSold, username);
            }
            cashierScreen.SetFinalText(finalResult);
        }

        public static int GetNumOfItems()
        {
            return numOfItems;
        }

        public static double GetPrice(string tag)
        {
            for(int i = 0; i < foodObjects.Length; i++)
            {
                if(foodObjects[i].Name.Equals(tag))
                {
                    return foodObjects[i].Price;
                }
            }

            return 0.0;
        }

        private static void CreateSecondScreen()
        {
            foodObjects = InitFoodObject();                    // Create an array of food objects and set it equal to the function initFood
            cashierScreen = BuildSelectionOptions(foodObjects);     // Start to build the GUI using the foodObjects array
            cashierScreen.InitializeComponent();
            cashierScreen.Show();
            //Application.Run(cashierScreen);                                 // Run the cashier screen
        }

        static FoodObject[] InitFoodObject()
        {
            FoodObject[] FoodObjects = new FoodObject[GetNumOfItems()];

            FoodObjects[0] = new FoodObject("Fruit Salad", global::ISYSHomework2.Properties.Resources.Fruit_Salad, 9.95, 1);
            FoodObjects[1] = new FoodObject("Pasta Salad", global::ISYSHomework2.Properties.Resources.Pasta_Salad, 12.00, 1);
            FoodObjects[2] = new FoodObject("Smoothie", global::ISYSHomework2.Properties.Resources.Smoothie, 4.95, 2);
            FoodObjects[3] = new FoodObject("Fruit Juice", global::ISYSHomework2.Properties.Resources.Fruit_Juice, 3.95, 2);
            FoodObjects[4] = new FoodObject("Cupcake", global::ISYSHomework2.Properties.Resources.Cupcake, 3.00, 3);
            FoodObjects[5] = new FoodObject("Shortcake", global::ISYSHomework2.Properties.Resources.Shortcake, 6.00, 3);

            for(int i = 0; i < FoodObjects.Length; i++)
            {
                switch (FoodObjects[i].Classification)
                {
                    case 1:
                        saladCount++;
                        break;
                    case 2:
                        drinkCount++;
                        break;
                    case 3:
                        dessertCount++;
                        break;
                    default:
                        break;
                }  
            }

            return FoodObjects;
        }

        static Cashier BuildSelectionOptions(FoodObject[] foodObjects)
        {
            Cashier cashierScreen = new Cashier();
            const int Y_ITEM_SEPARATION = 120;
            const int X_ITEM_SEPARATION = 300;
            const int BUTTON_PICTURE_SEPARATION = 110;
            const int GROUP_BOX_X_INITIAL = 40;
            const int GROUP_BOX_Y_INITIAL = 80;
            const int X_INITIAL_POSITION = 10;
            const int Y_INITIAL_POSITION = 20;
            const int Y_LABEL_SEPARATION = 40;
            
            int saladStartingX = 0;
            int saladStartingY = 0;
            int drinkStartingX = 0;
            int drinkStartingY = 0;
            int dessertStartingX = 0;
            int dessertStartingY = 0;
            int numOfSalads = 0;
            int numOfDrinks = 0;
            int numOfDesserts = 0;

            for(int i = 0; i < 3; i++)
            {
                const int GROUP_BOX_X_SIZE = 230;
                const int GROUP_BOX_Y_PER_ITEM = X_INITIAL_POSITION + 100 + 15;
                switch (i)
                {
                    case 0:
                        {
                            int sizeY = (GROUP_BOX_Y_PER_ITEM * saladCount) + (Y_LABEL_SEPARATION * 3);
                            int sizeX = GROUP_BOX_X_SIZE;
                            int xPos = GROUP_BOX_X_INITIAL;
                            int yPos = GROUP_BOX_Y_INITIAL;
                            cashierScreen.addGroupBoxes(xPos, yPos, "Salads", i, sizeX, sizeY);
                            break;
                        }

                    case 1:
                        {
                            int sizeY = (GROUP_BOX_Y_PER_ITEM * drinkCount) + (Y_LABEL_SEPARATION * 3);
                            int sizeX = GROUP_BOX_X_SIZE;
                            int xPos = GROUP_BOX_X_INITIAL + X_ITEM_SEPARATION;
                            int yPos = GROUP_BOX_Y_INITIAL;
                            cashierScreen.addGroupBoxes(xPos, yPos, "Drinks", i, sizeX, sizeY);
                            break;
                        }

                    case 2:
                        {
                            int sizeY = (GROUP_BOX_Y_PER_ITEM * dessertCount) + (Y_LABEL_SEPARATION * 3);
                            int sizeX = GROUP_BOX_X_SIZE;
                            int xPos = GROUP_BOX_X_INITIAL + (X_ITEM_SEPARATION * 2);
                            int yPos = GROUP_BOX_Y_INITIAL;
                            cashierScreen.addGroupBoxes(xPos, yPos, "Desserts", i, sizeX, sizeY);
                            break;
                        }
                }
            }                                 // Create the Dynamic GroupBoxes
           
            for (int i = 0; i < foodObjects.Length; i++)
            {
                //WriteLine("Object {0} with classification {1} and name {2} is being processed", i, foodObjects[i].Classification, foodObjects[i].Name);
                switch (foodObjects[i].Classification)
                {
                    case 1:
                        if(numOfSalads == 0)                // If this is the first salad
                        {
                            saladStartingX = X_INITIAL_POSITION;
                            saladStartingY = Y_INITIAL_POSITION;
                        }
                        else
                        {
                            saladStartingY += Y_ITEM_SEPARATION;
                        }
                        cashierScreen.addRadioButton(saladStartingX, saladStartingY, foodObjects[i].Name, 0);
                        cashierScreen.addPictureBox(saladStartingX + BUTTON_PICTURE_SEPARATION, saladStartingY, foodObjects[i].Name, foodObjects[i].PhotoLocation, 0);
                       
                        numOfSalads++;
                        cashierScreen.IncrementCurrentItemCount();
                        break;
                    case 2:
                        if(numOfDrinks == 0)
                        {
                            drinkStartingX = X_INITIAL_POSITION;
                            drinkStartingY = Y_INITIAL_POSITION;
                        }
                        else
                        {
                            drinkStartingY += Y_ITEM_SEPARATION;
                        }
                        cashierScreen.addRadioButton(drinkStartingX, drinkStartingY, foodObjects[i].Name, 1);
                        cashierScreen.addPictureBox(drinkStartingX + BUTTON_PICTURE_SEPARATION, drinkStartingY, foodObjects[i].Name, foodObjects[i].PhotoLocation, 1);
                        
                        numOfDrinks++;
                        break;
                    case 3:
                        if(numOfDesserts == 0)
                        {
                            dessertStartingX = X_INITIAL_POSITION;
                            dessertStartingY = Y_INITIAL_POSITION;
                        }
                        else
                        {
                            dessertStartingY += Y_ITEM_SEPARATION;
                        }
                        cashierScreen.addRadioButton(dessertStartingX, dessertStartingY, foodObjects[i].Name, 2);
                        cashierScreen.addPictureBox(dessertStartingX + BUTTON_PICTURE_SEPARATION, dessertStartingY, foodObjects[i].Name, foodObjects[i].PhotoLocation, 2);
                        
                        numOfDesserts++;
                        break;
                    default:
                        WriteLine("ERROR: Object {0} of name {1} does not have a classification", i, foodObjects[i].Name);
                        break;
                }
            }               // Create the Dynamic RadioButtons and PictureBoxes

            for(int i = 0; i < 3; i++)                                  
            {
                switch (i)
                {
                    case 0:
                        saladStartingY += Y_ITEM_SEPARATION;
                        cashierScreen.AddPriceLabel(saladStartingX, saladStartingY, "Salad Price", 0);
                        saladStartingY += Y_LABEL_SEPARATION;
                        cashierScreen.AddQuantityLabel(saladStartingX, saladStartingY, "Quantity", 0);
                        saladStartingX += BUTTON_PICTURE_SEPARATION;
                        cashierScreen.AddQuantityTextBox(saladStartingX, saladStartingY, 0);
                        saladStartingY -= Y_LABEL_SEPARATION;
                        cashierScreen.AddPriceTextBox(saladStartingX, saladStartingY, 0);
                        saladStartingX -= BUTTON_PICTURE_SEPARATION;
                        saladStartingY += (Y_LABEL_SEPARATION * 2);
                        cashierScreen.AddSelectionLabel(saladStartingX, saladStartingY, 0);
                        break;

                    case 1:
                        drinkStartingY += Y_ITEM_SEPARATION;
                        cashierScreen.AddPriceLabel(drinkStartingX, drinkStartingY, "Drink Price", 1);
                        drinkStartingY += Y_LABEL_SEPARATION;
                        cashierScreen.AddQuantityLabel(drinkStartingX, drinkStartingY, "Quantity", 1);
                        drinkStartingX += BUTTON_PICTURE_SEPARATION;
                        cashierScreen.AddQuantityTextBox(drinkStartingX, drinkStartingY, 1);
                        drinkStartingY -= Y_LABEL_SEPARATION;
                        cashierScreen.AddPriceTextBox(drinkStartingX, drinkStartingY, 1);
                        drinkStartingX -= BUTTON_PICTURE_SEPARATION;
                        drinkStartingY += (Y_LABEL_SEPARATION * 2);
                        cashierScreen.AddSelectionLabel(drinkStartingX, drinkStartingY, 1);
                        break;

                    case 2:
                        dessertStartingY += Y_ITEM_SEPARATION;
                        cashierScreen.AddPriceLabel(dessertStartingX, dessertStartingY, "Salad Price", 2);
                        dessertStartingY += Y_LABEL_SEPARATION;
                        cashierScreen.AddQuantityLabel(dessertStartingX, dessertStartingY, "Quantity", 2);
                        dessertStartingX += BUTTON_PICTURE_SEPARATION;
                        cashierScreen.AddQuantityTextBox(dessertStartingX, dessertStartingY, 2);
                        dessertStartingY -= Y_LABEL_SEPARATION;
                        cashierScreen.AddPriceTextBox(dessertStartingX, dessertStartingY, 2);
                        dessertStartingX -= BUTTON_PICTURE_SEPARATION;
                        dessertStartingY += (Y_LABEL_SEPARATION * 2);
                        cashierScreen.AddSelectionLabel(dessertStartingX, dessertStartingY, 2);
                        break;
                }
            }                                 // Create the Dynamic Price and quanitity Labels and TextBoxes

            return cashierScreen;
        }
    }
}
