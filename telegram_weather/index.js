require("dotenv").config();
const {
  sendAction,
  sendMessage,
  askLocation,
  getTimezone,
  getWeather,
  replyMessage,
  getWeatherName,
  toEmoji,
} = require("./utils");

exports.hello = async (req, res) => {
  const { message } = req.body;
  // console.log(req.body);
  if (!message) return res.send("");

  let name = message.from.last_name;
  let chat_id = message.chat.id;
  let location = message.location;

  await sendAction(chat_id);

  let text = message.text;

  if (text == "/weather") {
    // console.log("start...", message);
    await askLocation(chat_id, "Send location");
    await sendAction(chat_id);
    return res.send("");
  }

  if (text.startsWith("/weather")) {
    let d = text.match(/weather\W+(\w+)/);
    if (d?.[1] == null) {
      await sendMessage(chat_id, "Please use format /weather {city name}");
      return res.send("");
    }
    let weather = await getWeatherName(d[1]);
    await sendMessage(chat_id, formatMessage(name, weather));
    return res.send("");
  }

  if (location) {
    let reply_id = message.reply_to_message.message_id;
    let weather = await getWeather(location.latitude, location.longitude);
    await replyMessage(chat_id, reply_id, formatMessage(name, weather));
    return res.send("");
  }
  //   console.log("got", e);
  // let weather = await getWeather(-1.95, 30);

  await sendMessage(chat_id, "Unknown command...");
  res.send("");
};

function formatMessage(name, weather) {
  let offset = weather.timezone_offset;
  let text = `Hello <b>${name}</b>,\nAll dates are in <i>${weather.timezone}</i>\n\n`;

  const extractText = function (current) {
    let date = new Date((current.dt + offset) * 1000);
    let _date = `${date.getUTCHours()}:00`;
    return `<b>Time (${_date})</b>\n<i>Temp:</i> ${
      current.temp
    } °C\n<i>Feels like:</i> ${current.feels_like} °C\n<i>Description:</i> ${
      current.weather[0].description
    } ${toEmoji(current.weather[0])}\n\n`;
  };

  let current = weather.current;
  text += `<b>Current</b>\n<i>Temp:</i> ${
    current.temp
  } °C\n<i>Feels like:</i> ${current.feels_like} °C\n<i>Description:</i> ${
    current.weather[0].description
  } ${toEmoji(current.weather[0])}\n\n`;
  for (let i = 1; i < 5; ++i) text += extractText(weather.hourly[i]);

  return text;
}
