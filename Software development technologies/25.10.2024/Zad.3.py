import turtle

t = turtle.Turtle()
t.speed(0)

for i in range(8):
    t.circle(50)
    t.penup()
    t.setheading(45 * (i + 1))
    t.forward(100)
    t.pendown()

turtle.done()
