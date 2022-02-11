def getView():
    nameOptions = {"BTC-USD": "BTC-USD", "ETH-USD": "ETH-USD"}
    nameOptions = [{"text": {"type": "plain_text", "text": value}, "value": key}
                   for key, value in nameOptions.items()]
    name_select_element = {"type": "static_select", "placeholder": {"type": "plain_text", "text": "Choose Chart"}, "action_id": "chart_name",
                           "options": nameOptions, "initial_option": nameOptions[0]}
    block1 = {"type": "input", "label": {"type": "plain_text", "text": "Chart Name"}, "block_id": "input1",
              "element": name_select_element}

    rangeOptions = {"1mo": "1 Month", "3mo": "3 Months"}
    rangeOptions = [{"text": {"type": "plain_text", "text": value}, "value": key}
                    for key, value in rangeOptions.items()]
    range_select_element = {"type": "static_select", "placeholder": {"type": "plain_text", "text": "Choose Range"}, "action_id": "chart_range",
                            "options": rangeOptions, "initial_option": rangeOptions[0]}
    block2 = {"type": "input", "label": {"type": "plain_text", "text": "Chart Range"}, "block_id": "input2",
              "element": range_select_element}

    intervalOptions = {"1h": "Hourly", "1d": "Daily"}
    intervalOptions = [{"text": {"type": "plain_text", "text": value}, "value": key}
                       for key, value in intervalOptions.items()]
    interval_select_element = {"type": "static_select", "placeholder": {"type": "plain_text", "text": "Choose Interval"}, "action_id": "chart_interval",
                               "options": intervalOptions, "initial_option": intervalOptions[0]}
    block3 = {"type": "input", "label": {"type": "plain_text", "text": "Chart Interval"}, "block_id": "input3",
              "element": interval_select_element}

    imageBlock = {"type": "image",
                  "image_url": "https://siasky.net/dACpcNS2UmwqEo7pPtZS7yrhq-whebx3EjAOm2LdcyfHxg", "alt_text": "Hello"}
    blocks = [block1, block2, block3]
    return {"type": "modal",
            "callback_id": "modal_id",
            "title": {"type": "plain_text", "text": "Get Chart"},
            "close": {"type": "plain_text", "text": "Cancel"},
            "submit": {"type": "plain_text", "text": "Submit"},
            "blocks": blocks
            }


def getValues(values):
    return {"ticker": values['input1']['chart_name']['selected_option']['value'],
            "range": values['input2']['chart_range']['selected_option']['value'],
            "interval": values['input3']['chart_interval']['selected_option']['value'],
            }
