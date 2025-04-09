from turtle import *

move_speed = 10
angle = 45

def moveForward():
    forward(move_speed)

def incrementSpeed():
    global move_speed
    move_speed += 10

def decrementSpeed():
    global move_speed
    move_speed -= 10

def incrementAngle():
    global angle
    angle += 5

def decrementAngle():
    global angle
    angle -= 5

def moveLeft():
    left(angle)


def moveRight():
    right(angle)


def leave():
    win.bye()


setup(400, 500)
win = Screen()
win.title("Event Handling!")
win.bgcolor("white")
main = Turtle()

win.onkey(moveForward, "w")
win.onkey(moveLeft, "a")
win.onkey(moveRight, "d")
win.onkey(incrementSpeed, "Up")
win.onkey(decrementSpeed, "Down")
win.onkey(incrementAngle, "Left")
win.onkey(decrementAngle, "Right")
win.onkey(leave, "q")
win.listen()
win.mainloop()