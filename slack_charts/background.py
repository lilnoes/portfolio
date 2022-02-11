import time
import os
from threading import Thread
from urllib import response
from slack_sdk import WebClient
import json
from flask import Flask, request as req, make_response
from crypt import methods
import dotenv
import view as view
import chart as chart
import background as bg
dotenv.load_dotenv()

slack_token = os.environ['SLACK_TOKEN']

client = WebClient(slack_token)


def doWork(values, view_id, hash):
    try:
        print("doing worl", values)
        file = chart.saveChart(
            values['ticker'], values['range'], values['interval'])
        print(file)
        client.files_upload(file=file, channels="#charts",
                            title=f"Chart for {values['ticker']}")
        print("message sent")
    except Exception as e:
        print("error thread", e)


def updateView(view_id, hash, title, link):
    imageBlock = {"type": "image",
                  "image_url": link, "alt_text": title}

    client.views_update(view_id=view_id,
                        hash=hash,
                        view={
                            "type": "modal",
                            "callback_id": "modal_id",
                            "title": {"type": "plain_text", "text": title},
                            "blocks": [imageBlock]
                        })
