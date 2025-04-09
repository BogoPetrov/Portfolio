from tkinter import *
import requests
import json

root = Tk()
root.title("Codemy.com - Weather forecast")
root.iconbitmap("images/weather.ico")
root.geometry("700x50")

#https://www.airnowapi.org/aq/observation/zipCode/current/?format=application/json&zipCode=60007&distance=25&API_KEY=7127B23D-3685-41D6-992D-B79F9DE945B4

city = ""
quality = 0
category = ""
weather_color = ""

try:
    api_request = requests.get("https://www.airnowapi.org/aq/observation/zipCode/current/?format=application/json&zipCode=60007&distance=25&API_KEY=7127B23D-3685-41D6-992D-B79F9DE945B4")
    api = json.loads(api_request.content)
    city = api[0]['ReportingArea']
    quality = api[0]['AQI']
    category = api[0]['Category']['Name']

    if category == "Good":
        weather_color = "#0C0"
    elif category == "Moderate":
        weather_color = "#FFFF00"
    elif category == "Unhealthy for Sensitive Groups":
        weather_color = "#FF9900"
    elif category == "Unhealthy":
        weather_color = "#FF0000"
    elif category == "Very Unhealthy":
        weather_color = "#990066"
    elif category == "Hazardous":
        weather_color = "#66000"


    root.configure(background=weather_color)
except Exception as e:
    api = "Error..."

myLabel = Label(root, text=city + " Air Quality " + str(quality) + " " + category, font=("Helvetica", 20), background = weather_color)
myLabel.pack()

root.mainloop()