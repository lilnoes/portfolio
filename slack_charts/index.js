const d = require("./file.json");
const { getData } = require("./utils");
const axios = require("axios").default;
const plotly = require("plotly")("username", "aaaa");
var fs = require("fs");

(async () => {
  // const res = await getData("AAPL", "1mo", "1h");
  // console.log(res);

  var trace1 = {
    x: [1, 2, 3, 4],
    y: [10, 15, 13, 17],
    type: "scatter",
  };

  var figure = { data: [trace1] };

  var imgOpts = {
    format: "png",
    width: 1000,
    height: 500,
  };

  plotly.getImage(figure, imgOpts, function (error, imageStream) {
    if (error) return console.log(error);

    var fileStream = fs.createWriteStream("1.png");
    imageStream.pipe(fileStream);
  });
})();

// let res = d.chart.result;
// console.log(res[0].timestamp.length, res[0].indicators.quote[0].close.length);
