require("dotenv").config();
const axios = require("axios").default;

const token = process.env.TELEGRAM_TOKEN;
const webhook = process.env.WEBHOOK_URL;
const openweather = process.env.OPENWEATHER_KEY;

(async () => {
  let token1 = openweather;
  console.log(token);
  console.log(new Date(1644913116 * 1000));
  let part = "";
  let lat = 41.037466;
  let lon = 28.635414;
  let text = "\weather kigali";
  let d = text.match(/weather\W+(\w+)/);
  console.log(text, d);
  //   return;
  // const endpoint = `https://api.openweathermap.org/data/2.5/onecall?lat=${lat}&lon=${lon}&exclude=${part}&appid=${token1}`;
  // const resp = await axios.get(`${endpoint}`);
  // const endpoint = `http://api.openweathermap.org/geo/1.0/direct?q=kigali&limit=1&appid=${token1}`;
  // const resp = await axios.get(`${endpoint}`);
  // console.log(resp.data);
})();
