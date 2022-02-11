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

app = Flask(__name__)


@ app.route("/interactivity", methods=['POST', 'GET'])
def interactivity():

    # _payload = req.form["payload"]
    if "payload" not in req.form:
        return make_response("", 200)
    payload = json.loads(req.form['payload'])
    # print(payload)
    if payload["type"] == "shortcut" and payload["callback_id"] == "crypto_chart":
        client.views_open(
            trigger_id=payload['trigger_id'], view=view.getView())
    elif payload["type"] == "view_submission" and payload["view"]["callback_id"] == "modal_id":
        view_id = payload['view']['id']
        hash = payload['view']['hash']
        values = payload['view']['state']['values']
        values = view.getValues(values)
        thread = Thread(target=bg.doWork, kwargs={
                        "values": values, "view_id": view_id, "hash": hash})
        thread.start()
        # link = chart.uploadChart(values)
        # print(values, link)
        return ""
    # print(payload)
    return "hello"


if __name__ == "__main__":
    # f = upload_file()
    # print(f)
    app.run(debug=True)
