
fig = go.Figure(data=[go.Candlestick(
    x=timestamps, low=quote['low'], high=quote['high'], open=quote['open'], close=quote['close'])])

fig.show()