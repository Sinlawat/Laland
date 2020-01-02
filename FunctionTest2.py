def Login():
    UserName = input("input your User name : ")
    Password = input("input your Password :  ")
    while UserName == "Sinlawat" and Password == "zerodark5":
        return True
    else:
        return False
def ShowMenu():
    print("----mill Store----")
    print("1. Vat calculator")
    print("2. Price calculator")
    MenuSelect()
def MenuSelect():
    Userselected = int(input("Select what's you need : "))
    if Userselected == 1:
        print("Your price in vat is :",VatCalculate(int(input("input Your product price : "))))
    elif Userselected == 2:
        print("Total of Your price : ",priceCalculate())
    return Userselected
def VatCalculate(totalPrice):
    vat = 7
    result = totalPrice + (totalPrice * vat / 100)
    return result
def priceCalculate():
    price1 = int(input("First product price : "))
    price2 = int(input("Second product price : "))
    return VatCalculate(price1 + price2)

if Login() == True:
    ShowMenu()
else:
    print("Username or Password is Wrong!!!")