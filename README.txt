This program is dynamically generated. The food objects are created at runtime to allow the owner to customize the appearance and food
objects as they please.

To run this program's EXE, go to /ISYSHomework2/ISYSHomework2/bin/Debug/ISYSHomework2.exe

To experience the Dynamic element of this program, open the code and go to the GraphicalFoodMenu.cs file. Once there find the 
InitFoodObject function. Inside of this function there are 6 FoodObject objects that are being loaded into a FoodObject array.
These FoodObjects are being initialized with a Name (String), Photo (System.Drawing.Image), Price (double) and Classification (int)
To change the classification of one of these objects (salad, drink or dessert) change the Classification int to a 1 (salads), 2 (drink)
or 3 (dessert). The changes will be reflected when application is built and ran again. 