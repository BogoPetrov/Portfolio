from tkinter import *
from tkinter import messagebox

def insert_Task():
    task = entry.get().strip()
    if task:
        listbox.insert(END, task)
        entry.delete(0, END)
    else:
        messagebox.showwarning("Warning", "Please enter a task.")

def del_Task():
    try:
        listbox.delete(listbox.curselection())
    except:
        messagebox.showwarning("Warning", "Please select a task to delete.")

# Main Window
root = Tk()
root.geometry('500x500+500+200')
root.title('Task Manager')
root.config(bg='#2C3E50')
root.resizable(width=False, height=False)

# Frame for Listbox
frame = Frame(root, bg='#34495E')
frame.pack(pady=10)

listbox = Listbox(
    frame,
    width=30,
    height=10,
    font=('Arial', 14),
    bd=0,
    fg='white',
    bg='#1ABC9C',
    selectbackground='#16A085',
    highlightthickness=0,
    activestyle="none",
)
listbox.pack(side=LEFT, fill=BOTH, padx=10, pady=10)

# Scrollbar
scroll = Scrollbar(frame)
scroll.pack(side=RIGHT, fill=Y)
listbox.config(yscrollcommand=scroll.set)
scroll.config(command=listbox.yview)

# Default Task List
task_list = ['Make my list']
for item in task_list:
    listbox.insert(END, item)

# Entry Widget
entry = Entry(
    root,
    font=('Arial', 14),
    fg='black',
    bg='white',
    bd=2,
    relief=GROOVE,
)
entry.pack(pady=10, padx=20, fill=X)

# Button Frame
button_frame = Frame(root, bg='#2C3E50')
button_frame.pack(pady=20)

# Add Task Button
addTask_button = Button(
    button_frame,
    text='Add Task',
    font=('Arial', 12),
    fg='white',
    bg='#27AE60',
    activebackground='#229954',
    padx=20,
    pady=10,
    relief=FLAT,
    command=insert_Task
)
addTask_button.pack(fill=BOTH, expand=True, side=LEFT, padx=5)

# Delete Task Button
delTask_button = Button(
    button_frame,
    text='Delete Task',
    font=('Arial', 12),
    fg='white',
    bg='#E74C3C',
    activebackground='#C0392B',
    padx=20,
    pady=10,
    relief=FLAT,
    command=del_Task
)
delTask_button.pack(fill=BOTH, expand=True, side=LEFT, padx=5)

root.mainloop()