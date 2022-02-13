require("dotenv").config();
const axios = require("axios").default;

const token = process.env.TELEGRAM_TOKEN;
const webhook = process.env.WEBHOOK_URL;

(async () => {
  const endpoint = `https://api.telegram.org/bot${token}`;
  const resp = await axios.get(`${endpoint}/setWebhook`, {
    params: { url: webhook },
  });
  console.log(resp);
})();
