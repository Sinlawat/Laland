menuList = []
priceList = []

def showBill():
    print("My food".center(20,"-"))
    for number in range(len(menuList)):
        print(menuList[number],priceList[number])

def total():
    total = 0
    for price in priceList:
        total = total + int(price)
    print("total Price = %d THB"%(total))


while True:
    menuName = input("Please Enter menu:")
    if(menuName.lower() == "exit"):
        break
    else:
        menuPrice = input("Price :")
        menuList.append(menuName)
        priceList.append(menuPrice)
showBill()
total()
