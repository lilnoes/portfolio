require("dotenv").config();
const axios = require("axios").default;
const icons = require("./icons.json");

const token = process.env.TELEGRAM_TOKEN;
const webhook = process.env.WEBHOOK_URL;
const openweather = process.env.OPENWEATHER_KEY;

const endpoint = `https://api.telegram.org/bot${token}`;

async function sendAction(chat_id, action = "typing") {
  await axios.post(`${endpoint}/sendChatAction`, { chat_id: chat_id, action });
}

async function sendMessage(chat_id, text, parse_mode = "html") {
  await axios.post(`${endpoint}/sendMessage`, {
    chat_id: chat_id,
    text,
    parse_mode,
  });
}

async function replyMessage(chat_id, reply_id, text, parse_mode = "html") {
  try {
    await axios.post(`${endpoint}/sendMessage`, {
      chat_id: chat_id,
      reply_to_message_id: reply_id,
      text,
      parse_mode,
    });
  } catch (e) {
    console.log("error", e, chat_id, reply_id);
  }
}

async function askLocation(chat_id, text) {
  await axios.post(`${endpoint}/sendMessage`, {
    chat_id: chat_id,
    text,
    reply_markup: {
      resize_keyboard: true,
      one_time_keyboard: true,
      keyboard: [[{ text, request_location: true }]],
    },
  });
}

async function getCoordinates(name) {
  const endpoint = `http://api.openweathermap.org/geo/1.0/direct?q=${name}&limit=1&appid=${openweather}`;
  const resp = await axios.get(endpoint);
  if (!resp.data) return null;
  return { lat: resp.data[0].lat, lon: resp.data[0].lon };
}

async function getWeather(lat, lon) {
  const endpoint = `https://api.openweathermap.org/data/2.5/onecall?lat=${lat}&lon=${lon}&exclude=minutely,daily,alerts&appid=${openweather}&units=metric`;
  const resp = await axios.get(endpoint);
  return resp.data;
}

async function getWeatherName(name) {
  const { lat, lon } = await getCoordinates(name);
  return getWeather(lat, lon);
}

function toEmoji(weather) {
  let emoji = icons[weather.icon];
  if (!emoji) return "";
  return emoji;
}

module.exports = {
  sendAction,
  sendMessage,
  replyMessage,
  askLocation,
  getWeather,
  getWeatherName,
  toEmoji,
};
