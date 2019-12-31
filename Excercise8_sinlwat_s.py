Username = input("Username : ")
Password = input("Password : ")
if Username == "Sinlawat" and Password == "zerodark5":
    print("You are enter to website")
    print("-----mill Store-----")
    VegetableEggRoll = 100
    EggRoll = 30
    FriedShimp = 70
    print("1. Vegetable Egg Roll..............................100 THB")
    print("2. Egg Roll........................................ 30 THB")
    print("3. Fried Shrimp.................................... 70 THB")
    UserSelected = input("do you need Vegetable Egg Roll? (Yes) or (no) : ")
    if UserSelected == "Yes":
        amount1 = int(input("How many food do you want to bye : "))
        MoreFood1 = input("do you need Egg Roll ? (Yes) or (no) ")
        if MoreFood1 == "Yes":
            amount2 = int(input("How many food do you want to bye : "))
            MoreFood2 = input("do you need Fried shrimp? (Yes) or (no)")
            if MoreFood2 == "Yes":
                amount3 = int(input("How many food do you want to bye : "))
                print("--------------------------------------------------------")
                sum1 = (100 * amount1) + (30 * amount2) + (70 * amount3)
                print("Food name                                    amount  Price")
                print("VegetableEggRoll............................",amount1,"......",VegetableEggRoll,"THB")
                print("Egg Roll....................................",amount2,"......",EggRoll, "THB")
                print("Egg Roll....................................", amount3, "......", FriedShimp, "THB")
                print("Total Price :........................................", sum1, "THB")
            elif MoreFood2 == "no":
                print("------------------------------------------------------")
                sum2 = (100 * amount1) + (30 * amount2)
                print("Food name                                    amount  Price")
                print("VegetableEggRoll............................", amount1, "......", VegetableEggRoll, "THB")
                print("Egg Roll....................................", amount2, "......", EggRoll, "THB")
                print("Total Price :............................. ", sum2, "THB")
        elif MoreFood1 == "no":
            MoreFood6 = input("do you need Fried shrimp? (Yes) or (no)")
            if MoreFood6 == "Yes":
                amount6 = int(input("How many food do you want to bye : "))
                print("------------------------------------------------------")
                sum2 = (100 * amount1) + (70 * amount6)
                print("Food name                                    amount  Price")
                print("VegetableEggRoll............................", amount1, "......", VegetableEggRoll, "THB")
                print("Fried Shrimp................................", amount6, "......", FriedShimp, "THB")
                print("Total Price :....................................... ",sum2,"THB")
            elif MoreFood6 == "no":
                print("------------------------------------------------------")
                print("VegetableEggRoll............................", amount1, "......", VegetableEggRoll, "THB")
                sum4 = 100 * amount1
                print("Total Price :....................................... ", sum4, "THB")
    elif UserSelected == "no":
        MoreFood4 = input("do you need Egg Roll ? (Yes) or (no) ")
        if MoreFood4 == "Yes":
            amount4 = int(input("How many food do you want to bye : "))
            MoreFood5 = input("do you need Fried Shrimp? (Yes) or (no)")
            if MoreFood5== "Yes":
                amount5 = int(input("How many food do you want to bye : "))
                print("--------------------------------------------------------")
                sum2 = (30 * amount4) + (70 * amount5)
                print("Food name                                    amount  Price")
                print("Egg Roll....................................", amount4, "......", EggRoll, "THB")
                print("Fried Shrimp................................", amount5, "......", FriedShimp, "THB")
                print("Total Price :........................................", sum2, "THB")
            elif MoreFood5 == "no":
                print("Food name                                    amount  Price")
                print("Egg Roll....................................", amount4, "......", EggRoll, "THB")
                sum3 = (30 * amount4)
                print("Total Price :........................................", sum3, "THB")
    MoreFood7 = input("do you need Fried Shrimp? (Yes) or (no)")
    if MoreFood7 == "Yes":
        amount7 = int(input("How many food do you want to bye : "))
        print("--------------------------------------------------------")
        sum5 = 70 * amount7
        print("Fried Shrimp................................", amount7, "......", FriedShimp, "THB")
        print("Total Price :........................................", sum5, "THB")
    elif MoreFood7 == "no":
        print("--------------------------------------------------------")
        print("--------------Thank You For Yor comming in--------------")


