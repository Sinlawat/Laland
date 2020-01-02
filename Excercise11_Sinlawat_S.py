'''
ทำพีรามิดตามความกว้างของผู้ใช้งาน
'''
number= int(input("input number of Weight : "))
space = int((number - 1) / 2)
for i in range(1,number+2, 2):
    print(" " * space,("*" * i))
    space -= 1

'''
ทำพีรามิดตามความสูงของผู้ใช้งาน
'''
number = int(input("input number of Height : "))
for i in range(number):
    print(" " * (number - i) + "*" * (2*i+1))