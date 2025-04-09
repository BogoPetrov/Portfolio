import turtle


def draw_circle(color, x, y, radius):
    turtle.penup()
    turtle.goto(x, y - radius)
    turtle.pendown()
    turtle.color(color)
    turtle.begin_fill()
    turtle.circle(radius)
    turtle.end_fill()


def draw_apple():
    turtle.speed(3)

    # Draw apple body (red circle)
    draw_circle("red", 0, -50, 100)

    # Draw leaf (green oval)
    turtle.penup()
    turtle.goto(-20, 70)
    turtle.pendown()
    turtle.color("green")
    turtle.begin_fill()
    turtle.circle(30, 90)
    turtle.goto(0, 100)
    turtle.goto(20, 70)
    turtle.circle(30, 90)
    turtle.goto(-20, 70)
    turtle.end_fill()

    # Draw apple stem (brown rectangle)
    turtle.penup()
    turtle.goto(-5, 100)
    turtle.pendown()
    turtle.color("brown")
    turtle.begin_fill()
    turtle.goto(5, 100)
    turtle.goto(5, 130)
    turtle.goto(-5, 130)
    turtle.goto(-5, 100)
    turtle.end_fill()

    turtle.hideturtle()
    turtle.done()


# Call function to draw the apple
draw_apple()