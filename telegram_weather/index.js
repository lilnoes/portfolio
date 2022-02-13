require("dotenv").config();
const { sendAction, sendMessage } = require("./utils");
exports.hello = async (req, res) => {
  const { message } = req.body;
  console.log(req.body);
  if (!message) return res.send("");

  let text = message.text;
  let name = message.from.last_name;
  let chat_id = message.chat.id;
  await sendAction(chat_id);
  //   console.log("got", e);
  await sendMessage(chat_id, `Hello ${name}, thanks for your patience.`);
  res.send("Helllo");
};
