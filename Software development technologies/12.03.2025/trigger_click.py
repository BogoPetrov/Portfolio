from tkinter import *

i = 1
j = 1
labels_1 = []
labels_2 = []


def function():
    global i
    label = Label(root, text="Welcome")
    label.grid(row=i, column=0)
    labels_1.append(label)  # Store reference to label
    i += 1


def function2(event):
    global j
    label = Label(root, text="Python Students!")
    label.grid(row=j, column=1)
    labels_2.append(label)  # Store reference to label
    j += 1


def delete_last_label(label_list, index_name):
    global i, j
    if label_list:  # Check if list is not empty
        label = label_list.pop()  # Get the last added label
        label.destroy()  # Remove it from the UI
        if index_name == "i":
            i -= 1  # Update correct index
            i = max(i, 1)  # Prevent i from going below 1
        else:
            j -= 1
            j = max(j, 1)  # Prevent j from going below 1


root = Tk()
root.geometry("300x200")

button = Button(root, text="Click Here 1", command=function)
button.grid(row=0, column=0)
button.bind('<Button-3>', lambda event: delete_last_label(labels_1, "i"))  # Right-click to delete last "Welcome"

button2 = Button(root, text="Click Here 2")
button2.bind('<Button-1>', function2)  # Left-click to add "Python Students!"
button2.bind('<Button-3>', lambda event: delete_last_label(labels_2, "j"))  # Right-click to delete last "Python Students!"
button2.grid(row=0, column=1)

root.mainloop()