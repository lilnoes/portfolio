import os
import requests as r
from os import environ
from dotenv import load_dotenv

# load .env file in root directory
load_dotenv()


ENDPOINT = "https://yfapi.net/v8/finance/chart"

# symbol like BTC-USD


def getData(ticker, range, interval):
    try:
        resp = r.get(f"{ENDPOINT}/{ticker}",
                     params={range: range, interval: interval},
                     headers={"x-api-key": os.environ['YAHOOFINANCE_KEY']},
                     )

        return resp.json()
    except Exception as e:
        print("error", e)
