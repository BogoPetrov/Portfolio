import turtle


def draw_circle(color, x, y, radius):
    turtle.penup()
    turtle.goto(x, y - radius)
    turtle.pendown()
    turtle.color(color)
    turtle.begin_fill()
    turtle.circle(radius)
    turtle.end_fill()


def draw_leaves():
    turtle.penup()
    turtle.goto(-10, 130)  # Adjust leaf position to align with the end of the shorter stem
    turtle.pendown()
    turtle.color("green")
    turtle.begin_fill()
    turtle.goto(-30, 150)
    turtle.goto(0, 160)
    turtle.goto(20, 140)
    turtle.goto(-10, 130)
    turtle.end_fill()

    # Mirror the first leaf to the other side
    turtle.penup()
    turtle.goto(10, 130)
    turtle.pendown()
    turtle.begin_fill()
    turtle.goto(30, 150)
    turtle.goto(0, 160)
    turtle.goto(-20, 140)
    turtle.goto(10, 130)
    turtle.end_fill()


def draw_stem():
    turtle.penup()
    turtle.goto(0, 100)
    turtle.pendown()
    turtle.color("brown")
    turtle.width(8)  # Make stem thicker
    turtle.goto(0, 130)  # Shorten the stem


def draw_apple():
    turtle.speed(3)

    # Draw apple body (red circle)
    draw_circle("red", 0, 0, 100)

    # Draw apple stem (shorter and thicker)
    draw_stem()

    # Draw leaves (mirrored and positioned correctly)
    draw_leaves()

    turtle.hideturtle()
    turtle.done()


# Call function to draw the apple
draw_apple()

