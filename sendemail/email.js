const { createTransport } = require("nodemailer");

const transporter = createTransport({
  host: "smtp-relay.sendinblue.com",
  port: 587,
  auth: { user: "login", pass: "master password" },
});

//Sending email
(async () => {
  let info = await transporter.sendMail({
    from: "Leon <fromemail>",
    to: "toemail",
    replyTo: "replyemail",
    subject: "Email From Server",
    text: `Hello from the server`,
  });
  console.log(info);
})();
