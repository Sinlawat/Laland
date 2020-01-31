from flask import Flask,render_template,request,redirect,url_for
import pymysql

app = Flask(__name__)
conn=pymysql.connect('localhost','root','','studentdb')



@app.route('/')
def showdata():
    with conn:
        cur=conn.cursor()
        cur.execute("SELECT * from student")
        row=cur.fetchall()
    return render_template('index.html',data=row)

@app.route('/student')
def showform():
    return render_template('addstudent.html')

@app.route('/insert',methods=['POST'])
def insert():
    if request.method=="POST":
        Firstname=request.form['Firstname']
        Lastname=request.form['Lastname']
        Phone=request.form['Phone']
        with conn.cursor() as cursor:
            sql = "Insert into `student` (`Firstname`, `Lastname`, `Phone`) values(%s,%s,%s)"
            cursor.execute(sql,(Firstname, Lastname, Phone))
            conn.commit()
            return redirect(url_for('showdata'))

@app.route('/delete/<string:id_data>',methods=['GET'])
def delete(id_data):
    with conn:
        cur=conn.cursor()
        cur.execute("delete from student where id=%s",(id_data))
        conn.commit()
    return redirect(url_for('showdata'))

@app.route('/update',methods=['POST'])
def update():
    if request.method=="POST":
        id_update=request.form['id']
        Firstname=request.form['Firstname']
        Lastname=request.form['Lastname']
        Phone=request.form['Phone']
        with conn.cursor() as cursor:
            sql = "update student set Firstname=%s , Lastname=%s , Phone=%s where id=%s "
            cursor.execute(sql,(Firstname, Lastname, Phone,id_update))
            conn.commit()
            return redirect(url_for('showdata'))

if __name__ == '__main__':
    app.run(debug=True)
