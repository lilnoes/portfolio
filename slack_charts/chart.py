import utils as utils
import os
import json
import dotenv
import plotly.graph_objects as go
from datetime import datetime
dotenv.load_dotenv()


def saveChart(ticker, range, interval, file="image.png"):
    data = utils.getData(ticker, range, interval)
    quote = data['chart']['result'][0]['indicators']['quote'][0]
    timestamps = data['chart']['result'][0]['timestamp']
    timestamps = [datetime.fromtimestamp(i) for i in timestamps]

    fig = go.Figure(data=[go.Candlestick(
        x=timestamps, low=quote['low'], high=quote['high'], open=quote['open'], close=quote['close'])])

    fig.write_image(file)
    return file
