import json
import utils as utils
import plotly.graph_objects as go
from datetime import datetime

f = open("file.json")
# resp = utils.getData("BTC-USD", "1h", "1mo")
# print

d = json.load(f)
quote = d['chart']['result'][0]['indicators']['quote'][0]
timestamps = d['chart']['result'][0]['timestamp']
timestamps = [datetime.fromtimestamp(i) for i in timestamps]
# print(timestamps[0])
# t = datetime.fromtimestamp(timestamps[0])
# print(t)

fig = go.Figure(data=[go.Candlestick(
    x=timestamps, low=quote['low'], high=quote['high'], open=quote['open'], close=quote['close'])])

fig.write_image("image.png")
