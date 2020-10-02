
| Cameron Robinson|
| :---|
| s208065|
| Game Programminh |
| Shop Documentation |

## I. Requirements

1. Description of Problem

	- **Name**: Shop Assessment

	- **Problem Statement**: 
	Making a player choose which shop to go to

	- **Problem Specifications**:  
    

2. Input Information
[1] First Option
[2] Second Option




### Object Information

   **File**: Game.cs

     
  **Attributes**

         Name: Run()
             Description: This allows the game to run what is inside of it
             Type:public void

        Name: InitializeItems() 
             Description: Allows the items to be used in the program
             Type: private void

        Name: GetInput(out char input, string option1, string option2, string query)
             Description: Allows input to be used in the program
             Type: public void

        Name: PrintInventory(Item[] inventory)
             Description: Sets up the inventory
             Type: public void

        Name: GroceryGarden()
             Description: The program in which you select items and put them in your inventory
             Type: private void

        Name: Save()
             Description: Saves data
             Type: public void

        Name: Load()
             Description: Loads data
             Type: public void
 
        Name: Start()
             Description: Starts the program. Everything is in here will run first
             Type: public void

       Name: Update()
             Description: Updates the information needed for the game to run
             Type:  public void

       Name: End()
             Description: Ends the program
             Type: public void
       

**File** : Player.cs

**Attributes**

         Name: Buy(Item item, int inventoryIndex)
             Description: Aloows the player to but items in the shop
             Type: string

        Name: GetDollars()
             Description: Allows the players to recieve and use the money they have
             Type: public int

        Name: GetInventory()
             Description: Allows the player to access the inventory
             Type: public Item[]

        Name: Save(StreamWriter writer)
             Description: Saves data
              Type: public virtual void

       Name: Load(StreamReader reader)
             Description: Loads data
             Type: public virtual bool
   
       
**File**: Shop.cs

**Attributes**

         Name: Shop(Item[] items)
             Description: Makes up the shop
             Type: public

          Name: Sell(Player player, int itemIndex, int playerIndex)
             Description: Allows the shop to be used
             Type: public bool




**File**: Shop.cs

**Attributes**

         Name: Shop(Item[] items)
             Description: Makes up the shop
             Type: public

          Name: Sell(Player player, int itemIndex, int playerIndex)
             Description: Allows the shop to be used
             Type: public bool



**File**: Magician.cs

**Attributes**

         Name: Magician() : base()
             Description: Sets up mana system fpr the magician
             Type: public

          


       