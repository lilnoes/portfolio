require("dotenv").config();
const axios = require("axios").default;

const token = process.env.TELEGRAM_TOKEN;
const webhook = process.env.WEBHOOK_URL;
const openweather = process.env.OPENWEATHER_KEY;

(async () => {
  let token1 = openweather;
  console.log(token);
  let part = "";
  let lat = 41.037466;
  let lon = 28.635414;
  //   return;
  const endpoint = `https://api.openweathermap.org/data/2.5/onecall?lat=${lat}&lon=${lon}&exclude=${part}&appid=${token1}`;
  const resp = await axios.get(`${endpoint}`);
  //   console.log(resp);
})();
