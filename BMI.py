import math
from tkinter import *

def description(x):
    if x > 30:
        return "อ้วนมาก"
    elif x > 25 and x <= 30:
        return "อ้วน"
    elif x > 23 and x <= 25:
        return "น้ำหนักเกิน"
    elif x > 18.6 and x <= 23:
        return "ปกติ"
    elif x < 18.5:
        return "ผอมเกินไป"

def LeftClickCalculateButton(event):
    showLabel.configure(text=float(textboxWeight.get())/math.pow(float(textboxHeight.get())/100,2))

def LeftClickShowButton(event):
    bmi = float(textboxWeight.get())/math.pow(float(textboxHeight.get())/100,2)
    ResultLabel.configure(text=description(bmi))

mainWindow = Tk()
lableHeight = Label(mainWindow,text = "ส่วนสูง (Cm.)")
lableHeight.grid(row=0,column=0)
textboxHeight = Entry(mainWindow)
textboxHeight.grid(row=0,column=1)


lableWeight = Label(mainWindow,text = "น้ำหนัก (Kg.)")
lableWeight.grid(row=1,column=0)
textboxWeight = Entry(mainWindow)
textboxWeight.grid(row=1,column=1)

calculateButton = Button(mainWindow,text = "คำนวณ")
calculateButton.bind('<Button-1>',LeftClickCalculateButton)
calculateButton.grid(row=2,column=0)
showLabel = Label(mainWindow,text="ผลลัพธ์")
showLabel.grid(row=2,column=1)

showButton = Button(mainWindow,text = "แสดงผล")
showButton.bind('<Button-1>',LeftClickShowButton)
showButton.grid(row=3,column=0)
ResultLabel = Label(mainWindow,text = "สรุปผล")
ResultLabel.grid(row=3,column=1)

mainWindow.mainloop()