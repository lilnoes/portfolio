require("dotenv").config();
const axios = require("axios").default;

const token = process.env.TELEGRAM_TOKEN;
const webhook = process.env.WEBHOOK_URL;
const endpoint = `https://api.telegram.org/bot${token}`;

async function sendAction(chat_id, action = "typing") {
  await axios.post(`${endpoint}/sendChatAction`, { chat_id: chat_id, action });
}

async function sendMessage(chat_id, text) {
  await axios.post(`${endpoint}/sendMessage`, {
    chat_id: chat_id,
    text,
    reply_markup: {
      resize_keyboard: true,
      keyboard: [[{ text: "Get Location", request_location: true }]],
    },
  });
}

module.exports = { sendAction, sendMessage };
